Imports System.Xml.Schema

Public Class frmCarSim

    ' These represent the decay of speed and rpm naturally, values to be refined later
    ' Application interval currently undecided
    Const dblSpeedLoss As Double = 1
    Const dblRpmLoss As Double = 1

    ' These represent the current change being applied to the speed and rpm
    Dim dblSpeedIncrease As Double = 0
    Dim dblRpmIncrease As Double = 0

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeSpeedMod As Double = 0
    Dim dblBrakeRpmMod As Double = 0

    ' Used for calculating how long the gas/brakes are being held so we can scale the modification with the held length
    Private WithEvents tmrBrakeHeld As Timer = New Timer()
    Private WithEvents tmrGasHeld As Timer = New Timer()

    Const intNeedleLength = 100
    Dim dblSpeedNeedleAngle = Math.PI
    Const intSpeedNeedleXOrigin = 114
    Const intSpeedNeedleYOrigin = 114
    Dim intSpeedNeedleXEnd = intSpeedNeedleXOrigin
    Dim intSpeedNeedleYEnd = intSpeedNeedleYOrigin
    Dim accelerating As Boolean = True

    Private WithEvents tmrNeedleUpdate As Timer

    ' This sub is where all configuration code should go.
    Public Sub New()
        ' Enable double buffering for the form
        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Private Sub frmCarSim_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Currently the brakes and gas trigger 5 times a second, or once every 200 milliseconds, subject to change
        tmrBrakeHeld.Interval = 200
        tmrGasHeld.Interval = 200

        tmrNeedleUpdate = New Timer()
        tmrNeedleUpdate.Interval = 1 ' Update interval in milliseconds (e.g., 100ms)
        tmrNeedleUpdate.Start()
    End Sub


    Private Sub pbxBrake_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseDown
        tmrBrakeHeld.Start()
    End Sub

    Private Sub pbxBrake_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseUp
        tmrBrakeHeld.Stop()
    End Sub

    Private Sub pbxGas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseDown
        tmrGasHeld.Start()
    End Sub

    Private Sub pbxGas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseUp
        tmrGasHeld.Stop()
    End Sub

    Dim bmpSpeedNeedle As New Bitmap(216, 216)
    Dim grphSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)

    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick
        ' Update end coordinates
        intSpeedNeedleXEnd = intSpeedNeedleXOrigin + Convert.ToInt32(Math.Cos(dblSpeedNeedleAngle) * intNeedleLength)
        intSpeedNeedleYEnd = intSpeedNeedleYOrigin + Convert.ToInt32(Math.Sin(dblSpeedNeedleAngle) * intNeedleLength)

        ' Update angle for next iteration
        If accelerating Then
            If dblSpeedNeedleAngle + 0.01 < Math.PI * 2 Then
                dblSpeedNeedleAngle = dblSpeedNeedleAngle + 0.01
            Else
                accelerating = False
            End If
        Else
            If dblSpeedNeedleAngle - 0.1 > Math.PI Then
                dblSpeedNeedleAngle = dblSpeedNeedleAngle - 0.01
            Else
                accelerating = True
            End If
        End If

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
End Class
