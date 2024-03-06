Imports System.Xml.Schema

Public Class frmCarSim
    Const deltaTime = 100

    ' These represent the current change being applied to the speed and rpm
    Dim dblRpmIncrease As Double = 400
    Dim dblSpeedIncrease As Double

    ' This boolean represents whether or not the car is on.
    Dim boolCarOn As Boolean = False

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeSpeedMod As Double = 0.99
    Dim dblBrakeRpmMod As Double = 0

    Private WithEvents tmrPedals As Timer = New Timer()

    ' These booleans represent the current state of the gas pedal and the brake pedal
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    Const dblVehicleMass As Double = 2000 ' Weight of vehicle pounds

    Dim gear As Integer = 1 'First gear
    Dim gearRatio As Double = 1 / 4 ' First gear gear ratio

    Dim dblRPM As Double = 0
    Const dblMaxRPM As Double = 6000 ' Fairly standard max RPM

    Dim dblEngineTorque As Double = 0
    Const dblMaxEngineTorque As Double = 2000 ' Mostly arbitrary (similar to horsepower). Allows other variables to have realistic values.

    Const dblDragCoefficient As Double = 0.3
    Const dblRollingResistanceCoefficient As Double = 0.01
    Dim dblDragForce As Double = 0
    Dim dblRollingResistanceForce As Double = 0

    Dim dblNetForce As Double = 0
    Dim dblAcceleration As Double = 0
    Dim dblVelocity As Double = 0

    Const intNeedleLength = 75

    Const dblSpeedNeedleMinAngle = 2.25
    Const dblSpeedNeedleMaxAngle = 7.2
    Dim dblSpeedNeedleAngle = 2.15
    Const intSpeedNeedleXOrigin = 80
    Const intSpeedNeedleYOrigin = 84
    Dim intSpeedNeedleXEnd = intSpeedNeedleXOrigin
    Dim intSpeedNeedleYEnd = intSpeedNeedleYOrigin

    Const intRpmNeedleLength = 60
    Const dblRpmNeedleMinAngle = 2.25
    Const dblRpmNeedleMaxAngle = 7.2
    Dim dblRpmNeedleAngle = 2.25
    Const intRpmNeedleXOrigin = 90
    Const intRpmNeedleYOrigin = 84
    Dim intRpmNeedleXEnd = intRpmNeedleXOrigin
    Dim intRpmNeedleYEnd = intRpmNeedleYOrigin

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
        tmrNeedleUpdate.Interval = deltaTime ' Update interval in milliseconds
        tmrNeedleUpdate.Start()
        tmrPedals.Start()
    End Sub

    ' Speed is dictated by RPM instead of the other way around.
    Private Sub tmrPedalsHeld_Tick(sender As Object, e As EventArgs) Handles tmrPedals.Tick
        If gear = 1 Then
            gearRatio = 1 / 4
            dblRpmIncrease = 400
        ElseIf gear = 2 Then
            gearRatio = 1 / 3
            dblRpmIncrease = 200
        ElseIf gear = 3 Then
            gearRatio = 1 / 2
            dblRpmIncrease = 100
        ElseIf gear = 4 Then
            gearRatio = 1 / 1.5
            dblRpmIncrease = 50
        ElseIf gear = 5 Then
            gearRatio = 1 / 1.25
            dblRpmIncrease = 25
        ElseIf gear = 6 Then
            gearRatio = 1
            dblRpmIncrease = 12.5
        End If


        ' Increase or decrease the speed based on the gas, with upper and lower limits
        If boolGasHeld Then
            dblRPM = Math.Min(dblMaxRPM, dblRPM + (dblRpmIncrease * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * gearRatio))

            dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * gearRatio

            ' Upshift
            If gear < 6 AndAlso dblRPM >= dblMaxRPM Then
                gear += 1
                ' Reset RPM to prevent overshooting the next gear's RPM range
                dblRPM = dblMaxRPM * gearRatio
            End If
        Else
            ' If gas not held, gradually reduce RPM (likely needs to be dictated by rolling/drag in someway)
            dblRPM = Math.Max(0, dblRPM - gearRatio)

            ' Idle engine power
            dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * gearRatio

            ' Downshift
            If gear > 1 AndAlso dblRPM < dblMaxRPM * gearRatio Then
                gear -= 1
                ' Reset RPM to prevent undershooting the next gear's RPM range
                dblRPM = dblMaxRPM * gearRatio
            End If
        End If

        dblDragForce = 0.5 * dblDragCoefficient * dblVelocity ^ 2
        dblRollingResistanceForce = dblRollingResistanceCoefficient * dblVehicleMass * 9.81

        dblNetForce = dblEngineTorque - dblDragForce - dblRollingResistanceForce
        dblAcceleration = dblNetForce / dblVehicleMass
        dblVelocity = dblVelocity + dblAcceleration

        If dblVelocity < 0 Then
            dblVelocity = 0
        End If

        TextBox1.Text = "Speed: " & Convert.ToInt32(dblVelocity) & " mph"
        TextBox2.Text = "RPM: " & Convert.ToInt32(dblRPM)
        TextBox3.Text = "Current Gear: " & gear
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

    Dim bmpSpeedNeedle As New Bitmap(1024, 1024)
    Dim bmpRpmNeedle As New Bitmap(1024, 1024)
    Dim speedSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)
    Dim rpmSheet As Graphics = Graphics.FromImage(bmpRpmNeedle)

    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick
        ' Update end coordinates
        intSpeedNeedleXEnd = intSpeedNeedleXOrigin + Convert.ToInt32((Math.Cos((dblVelocity / 40.5) - 4) * intNeedleLength))
        intSpeedNeedleYEnd = intSpeedNeedleYOrigin + Convert.ToInt32((Math.Sin((dblVelocity / 40.5) - 4) * intNeedleLength))

        dblRpmNeedleAngle = dblRpmNeedleAngle + (dblRpmIncrease * 0.15)
        intRpmNeedleXEnd = intRpmNeedleXOrigin + Convert.ToInt32(Math.Cos((dblRPM / 2250) - 3.8) * intRpmNeedleLength)
        intRpmNeedleYEnd = intRpmNeedleYOrigin + Convert.ToInt32(Math.Sin((dblRPM / 2250) - 3.8) * intRpmNeedleLength)

        speedSheet.Dispose()
        rpmSheet.Dispose()

        bmpSpeedNeedle.Dispose()
        bmpSpeedNeedle = New Bitmap(1024, 1024)

        bmpRpmNeedle.Dispose()
        bmpRpmNeedle = New Bitmap(1024, 1024)

        speedSheet = Graphics.FromImage(bmpSpeedNeedle)
        rpmSheet = Graphics.FromImage(bmpRpmNeedle)

        pbxSpeed.Refresh()
        pbxRpm.Refresh()
    End Sub


    Private Sub frmCarSim_PaintSpeedNeedle(sender As Object, e As PaintEventArgs) Handles pbxSpeed.Paint
        speedSheet.DrawLine(New Pen(Color.Red, 3), intSpeedNeedleXOrigin, intSpeedNeedleYOrigin, intSpeedNeedleXEnd, intSpeedNeedleYEnd)
        e.Graphics.DrawImage(bmpSpeedNeedle, 0, 0)
    End Sub

    Private Sub frmCarSim_PaintRpmNeedle(sender As Object, e As PaintEventArgs) Handles pbxRpm.Paint
        rpmSheet.DrawLine(New Pen(Color.Yellow, 3), intRpmNeedleXOrigin, intRpmNeedleYOrigin, intRpmNeedleXEnd, intRpmNeedleYEnd)
        e.Graphics.DrawImage(bmpRpmNeedle, 0, 0)
    End Sub

    Private Sub pbxStartButton_Click(sender As Object, e As EventArgs) Handles pbxStartButton.Click
        boolCarOn = Not boolCarOn
        TextBox2.Text = "Car is " & IIf(boolCarOn, "On", "Off")
    End Sub
End Class
