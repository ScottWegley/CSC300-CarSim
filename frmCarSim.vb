Imports System.Xml.Schema

Public Class frmCarSim

    ' These represent the current change being applied to the speed and rpm
    Dim dblSpeedIncrease As Double = 0
    Dim dblRpmIncrease As Double = 0

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeSpeedMod As Double = 0
    Dim dblBrakeRpmMod As Double = 0

    Private WithEvents tmrPedals As Timer = New Timer()
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    Const intNeedleLength = 100
    Const dblSpeedNeedleMinAngle = 2.25
    Const dblSpeedNeedleMaxAngle = 7.2
    Dim dblSpeedNeedleAngle = 2.15
    Const intSpeedNeedleXOrigin = 107
    Const intSpeedNeedleYOrigin = 114
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
        If boolBrakeHeld Then

        Else

        End If

        If boolGasHeld Then
            dblSpeedIncrease = dblSpeedIncrease + 0.003
            If dblSpeedIncrease > 0.05 Then
                dblSpeedIncrease = 0.05
            End If
        Else
            dblSpeedIncrease = dblSpeedIncrease - 0.002
            If dblSpeedIncrease < -0.074 Then
                dblSpeedIncrease = -0.075
            End If
        End If
        TextBox1.Text = dblSpeedIncrease
    End Sub

    Private Sub pbxBrake_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseDown
        boolBrakeHeld = True
    End Sub

    Private Sub pbxBrake_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseUp
        boolBrakeHeld = False
    End Sub

    Private Sub pbxGas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseDown
        boolGasHeld = True
    End Sub

    Private Sub pbxGas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseUp
        boolGasHeld = False
    End Sub

    Dim bmpSpeedNeedle As New Bitmap(216, 216)
    Dim grphSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)

    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick
        ' Update end coordinates
        intSpeedNeedleXEnd = intSpeedNeedleXOrigin + Convert.ToInt32(Math.Cos(dblSpeedNeedleAngle) * intNeedleLength)
        intSpeedNeedleYEnd = intSpeedNeedleYOrigin + Convert.ToInt32(Math.Sin(dblSpeedNeedleAngle) * intNeedleLength)

        dblSpeedNeedleAngle = dblSpeedNeedleAngle + (dblSpeedIncrease * 0.15)
        If dblSpeedNeedleAngle < dblSpeedNeedleMinAngle Then dblSpeedNeedleAngle = dblSpeedNeedleMinAngle
        If dblSpeedNeedleAngle > dblSpeedNeedleMaxAngle Then dblSpeedNeedleAngle = dblSpeedNeedleMaxAngle


        grphSheet.Dispose()
        bmpSpeedNeedle.Dispose()
        bmpSpeedNeedle = New Bitmap(216, 216)
        grphSheet = Graphics.FromImage(bmpSpeedNeedle)

        pbxSpeed.Refresh()
    End Sub


    Private Sub frmCarSim_Paint(sender As Object, e As PaintEventArgs) Handles pbxSpeed.Paint
        grphSheet.DrawLine(New Pen(Color.Red, 3), intSpeedNeedleXOrigin, intSpeedNeedleYOrigin, intSpeedNeedleXEnd, intSpeedNeedleYEnd)
        e.Graphics.DrawImage(bmpSpeedNeedle, 0, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        tmrNeedleUpdate.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        tmrNeedleUpdate.Start()
    End Sub
End Class
