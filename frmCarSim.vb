﻿Imports System.Xml.Schema

Public Class frmCarSim
    Const deltaTime = 100

    ' These represent the current change being applied to the speed and rpm
    Dim dblSpeedIncrease As Double = 0
    Dim dblRpmIncrease As Double = 100
    Const maxRpmIncreaseFactor As Double = 10000
    Const sigmoidMidpoint As Double = 0.8 ' Midpoint where the increase starts slowing down
    Const steepness As Double = 10 ' Steepness of the sigmoid curve


    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeSpeedMod As Double = 0
    Dim dblBrakeRpmMod As Double = 0

    Private WithEvents tmrPedals As Timer = New Timer()
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    Const dblVehicleMass As Double = 2000 ' In pounds

    Dim gear As Integer = 1 'First gear
    Dim gearRatio As Double = 1 / 2.97 ' First gear gear ratio

    Dim dblRPM As Double = 0
    Dim dblMaxRPM As Double = 6000 ' Fairly standard max RPM

    Dim dblEngineTorque As Double = 0
    Dim dblMaxEngineTorque As Double = 2000 ' Mostly used to make all the other values make sense while being realistic

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


    Private Sub tmrPedalsHeld_Tick(sender As Object, e As EventArgs) Handles tmrPedals.Tick
        If gear = 1 Then
            gearRatio = 1 / 4
        ElseIf gear = 2 Then
            gearRatio = 1 / 3
        ElseIf gear = 3 Then
            gearRatio = 1 / 2
        ElseIf gear = 4 Then
            gearRatio = 1 / 1.5
        ElseIf gear = 5 Then
            gearRatio = 1 / 1.25
        ElseIf gear = 6 Then
            gearRatio = 1
        End If

        If boolGasHeld Then
            ' Calculate the increase factor using a sigmoid function
            ' dblRpmIncrease = maxRpmIncreaseFactor / (1 + Math.Exp(-steepness * (dblRPM / dblMaxRPM - sigmoidMidpoint)))

            ' Calculate RPM based on gear ratio and throttle
            dblRPM = Math.Min(dblMaxRPM, dblRPM + (dblRpmIncrease * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * gearRatio))

            ' Calculate engine torque based on RPM and gear ratio
            dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * gearRatio

            ' Check if it's time to shift gears
            If gear < 6 AndAlso dblRPM >= dblMaxRPM Then
                gear += 1
                ' Reset RPM to prevent overshooting the next gear's RPM range
                dblRPM = dblMaxRPM * 0.5
            End If
        Else
            ' If gas not held, gradually reduce RPM
            dblRPM = Math.Max(0, dblRPM - 100 * gearRatio)

            ' Set a base engine torque to simulate engine braking
            dblEngineTorque = 100 * gearRatio

            ' Check if it's time to downshift
            If gear > 1 AndAlso dblRPM < dblMaxRPM * 0.25 Then
                gear -= 1
                ' Reset RPM to prevent undershooting the next gear's RPM range
                dblRPM = dblMaxRPM * 0.5
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

        TextBox1.Text = Convert.ToInt32(dblVelocity)
        TextBox2.Text = dblRPM
        TextBox3.Text = gear
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

    Dim bmpSpeedNeedle As New Bitmap(1024, 1024)
    Dim bmpRpmNeedle As New Bitmap(1024, 1024)
    Dim speedSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)
    Dim rpmSheet As Graphics = Graphics.FromImage(bmpRpmNeedle)

    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick
        ' Update end coordinates
        intSpeedNeedleXEnd = intSpeedNeedleXOrigin + Convert.ToInt32((Math.Cos((dblVelocity / 40.5) - 4) * intNeedleLength))
        intSpeedNeedleYEnd = intSpeedNeedleYOrigin + Convert.ToInt32((Math.Sin((dblVelocity / 40.5) - 4) * intNeedleLength))

        If dblSpeedNeedleAngle < dblSpeedNeedleMinAngle Then dblSpeedNeedleAngle = dblSpeedNeedleMinAngle
        If dblSpeedNeedleAngle > dblSpeedNeedleMaxAngle Then dblSpeedNeedleAngle = dblSpeedNeedleMaxAngle

        dblRpmNeedleAngle = dblRpmNeedleAngle + (dblRpmIncrease * 0.15)
        intRpmNeedleXEnd = intRpmNeedleXOrigin + Convert.ToInt32(Math.Cos((dblRPM / 2250) - 3.8) * intRpmNeedleLength)
        intRpmNeedleYEnd = intRpmNeedleYOrigin + Convert.ToInt32(Math.Sin((dblRPM / 2250) - 3.8) * intRpmNeedleLength)

        If dblRpmNeedleAngle < dblRpmNeedleMinAngle Then dblRpmNeedleAngle = dblRpmNeedleMinAngle
        If dblRpmNeedleAngle > dblRpmNeedleMaxAngle Then dblRpmNeedleAngle = dblRpmNeedleMaxAngle
        TextBox3.Text = dblRpmNeedleAngle

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


    Private Sub pbxGas_Click(sender As Object, e As EventArgs) Handles pbxGas.Click
        'go vroom
    End Sub
End Class
