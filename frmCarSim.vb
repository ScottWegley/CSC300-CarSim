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
    Dim tmrBrakeHeld As Timer = New Timer()
    Dim tmrGasHeld As Timer = New Timer()

    Dim length = 100
    Dim angle = Math.PI
    Dim start_x = 200
    Dim start_y = 350
    Dim end_x = start_x
    Dim end_y = start_y

    ' This sub is where all configuration code should go.
    Private Sub frmCarSim_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Currently the brakes and gas trigger 5 times a second, or once every 200 milliseconds, subject to change
        tmrBrakeHeld.Interval = 200
        tmrGasHeld.Interval = 200
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

    Private Sub pbxSpeed_Click(sender As Object, e As EventArgs) Handles pbxSpeed.Click

    End Sub

    Private Sub BtnDraw_Click(sender As Object, e As EventArgs) Handles BtnDraw.Click
        Dim graphics As Graphics = Me.CreateGraphics
        Dim pen As Pen

        end_x = start_x + Convert.ToInt32(Math.Cos(angle) * length)
        end_y = start_y + Convert.ToInt32(Math.Sin(angle) * length)

        pen = New Pen(Brushes.DarkMagenta, 1)

        graphics.DrawLine(pen, start_x, start_y, end_x, end_y)

        If angle + 0.1 < Math.PI * 2 Then
            angle = angle + 0.1
        End If
    End Sub
End Class
