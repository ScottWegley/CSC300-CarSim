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

    Private Sub pbxGas_Click(sender As Object, e As EventArgs) Handles pbxGas.Click
        'go vroom
    End Sub
End Class
