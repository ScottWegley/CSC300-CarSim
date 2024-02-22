Imports System.Xml.Schema

Public Class frmCarSim

    ' These represent the current change being applied to the speed and rpm
    Dim dblSpeedIncrease As Double
    Dim dblRpmIncrease As Double = 0

    ' This boolean represents whether or not the car is on.
    Dim boolCarOn As Boolean = False

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeSpeedMod As Double = 0.99
    Dim dblBrakeRpmMod As Double = 0

    Private WithEvents tmrPedals As Timer = New Timer()

    ' These booleans represent the current state of the gas pedal and the brake pedal
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    Const intNeedleLength = 94
    Const dblSpeedNeedleMinAngle = 2.25
    Const dblSpeedNeedleMaxAngle = 7.2
    Dim dblSpeedNeedleAngle = 2.15
    Const intSpeedNeedleXOrigin = 80
    Const intSpeedNeedleYOrigin = 90
    Dim intSpeedNeedleXEnd = intSpeedNeedleXOrigin
    Dim intSpeedNeedleYEnd = intSpeedNeedleYOrigin

    Private WithEvents tmrNeedleUpdate As Timer

    ' This sub is where all configuration code should go.
    Public Sub New()
        ' Enable double buffering for the form
        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Private Sub frmCarSim_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrPedals.Interval = 5

        tmrNeedleUpdate = New Timer()
        tmrNeedleUpdate.Interval = 5 ' Update interval in milliseconds
        tmrNeedleUpdate.Start()
        tmrPedals.Start()
    End Sub


    Private Sub tmrPedalsHeld_Tick(sender As Object, e As EventArgs) Handles tmrPedals.Tick
        ' Increase or decrease the speed based on the gas, with upper and lower limits
        If boolGasHeld Then
            dblSpeedIncrease = dblSpeedIncrease + 0.003
            If dblSpeedIncrease > 0.05 Then
                dblSpeedIncrease = 0.05
            End If
        Else
            dblSpeedIncrease = dblSpeedIncrease - 0.002
            If dblSpeedIncrease < -0.074 Then
                dblSpeedIncrease = -0.074
            End If
        End If
        TextBox1.Text = dblSpeedIncrease
    End Sub

    Private Sub pbxBrake_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseDown
        ' The AND means this will only work if the car is on
        boolBrakeHeld = True And boolCarOn
    End Sub

    Private Sub pbxBrake_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseUp
        boolBrakeHeld = False
    End Sub

    Private Sub pbxGas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseDown
        ' The AND means this will only work if the car is on
        boolGasHeld = True And boolCarOn
    End Sub

    Private Sub pbxGas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseUp
        boolGasHeld = False
    End Sub

    ' Create a blank overlay to store the speedneedle on
    Dim bmpSpeedNeedle As New Bitmap(216, 216)
    Dim grphSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)

    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick

        ' Apply the increase/decreate to the angle, limit the angle to the ends of the gauge
        dblSpeedNeedleAngle = dblSpeedNeedleAngle + (dblSpeedIncrease * 0.15)
        If dblSpeedNeedleAngle < dblSpeedNeedleMinAngle Then dblSpeedNeedleAngle = dblSpeedNeedleMinAngle
        If dblSpeedNeedleAngle > dblSpeedNeedleMaxAngle Then dblSpeedNeedleAngle = dblSpeedNeedleMaxAngle

        ' Apply the brake if it is held
        If boolBrakeHeld Then
            dblSpeedNeedleAngle = dblSpeedNeedleAngle * dblBrakeSpeedMod
        End If

        ' Update end coordinates
        intSpeedNeedleXEnd = intSpeedNeedleXOrigin + Convert.ToInt32(Math.Cos(dblSpeedNeedleAngle) * intNeedleLength)
        intSpeedNeedleYEnd = intSpeedNeedleYOrigin + Convert.ToInt32(Math.Sin(dblSpeedNeedleAngle) * intNeedleLength)

        ' Remove the previous needle and put a new blank bitmap over the gauge
        grphSheet.Dispose()
        bmpSpeedNeedle.Dispose()
        bmpSpeedNeedle = New Bitmap(216, 216)
        grphSheet = Graphics.FromImage(bmpSpeedNeedle)

        pbxSpeed.Refresh()
    End Sub


    Private Sub frmCarSim_Paint(sender As Object, e As PaintEventArgs) Handles pbxSpeed.Paint
        ' Draw the needle onto the graphics sheet from the bitmap.
        grphSheet.DrawLine(New Pen(Color.Red, 3), intSpeedNeedleXOrigin, intSpeedNeedleYOrigin, intSpeedNeedleXEnd, intSpeedNeedleYEnd)
        ' Draw the bitmap on top of the gauge
        e.Graphics.DrawImage(bmpSpeedNeedle, 0, 0)
    End Sub

    Private Sub pbxStartButton_Click(sender As Object, e As EventArgs) Handles pbxStartButton.Click
        boolCarOn = Not boolCarOn
        TextBox2.Text = "Car is " & IIf(boolCarOn, "On", "Off")
    End Sub
End Class
