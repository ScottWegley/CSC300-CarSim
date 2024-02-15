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
    Dim accelerating As Boolean = True

    Private WithEvents timer As Timer

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

        timer = New Timer()
        timer.Interval = 1 ' Update interval in milliseconds (e.g., 100ms)
        timer.Start()
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

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        ' Update end coordinates
        end_x = start_x + Convert.ToInt32(Math.Cos(angle) * length)
        end_y = start_y + Convert.ToInt32(Math.Sin(angle) * length)

        ' Update angle for next iteration
        If accelerating Then
            If angle + 0.01 < Math.PI * 2 Then
                angle = angle + 0.01
            Else
                accelerating = False
            End If
        Else
            If angle - 0.1 > Math.PI Then
                angle = angle - 0.01
            Else
                accelerating = True
            End If
        End If

        ' Trigger the Paint event to redraw the form
        Me.Invalidate()
    End Sub

    Private Sub frmCarSim_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim graphics As Graphics = e.Graphics
        Dim pen As Pen = New Pen(Brushes.DarkMagenta, 1)

        ' Draw the line
        graphics.DrawLine(pen, start_x, start_y, end_x, end_y)
    End Sub
End Class
