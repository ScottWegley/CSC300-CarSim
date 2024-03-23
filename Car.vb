﻿Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Car
    Const intDeltaTime = 100
    ' These represent the current change being applied to the speed and rpm
    Dim dblRpmIncrease As Double = 400
    Dim dblRpmBrakeDecrease As Double = 200

    ' This boolean represents whether or not the car is on.
    Dim boolCarOn As Boolean = False

    ' This boolean represents whether the parking break is on or not
    Dim boolParkingBrake As Boolean = False

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeForce As Double = 1000

    Private WithEvents tmrPedals As Timer = New Timer()

    Private WithEvents tmrBlinkers As Timer = New Timer()

    ' These booleans represent the current state of the gas pedal and the brake pedal
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    Dim boolLowBeam As Boolean = False
    Dim boolHighBeam As Boolean = False
    Dim boolFogLights As Boolean = False
    Dim boolHazardLights As Boolean = False

    Dim boolPark As Boolean = True
    Dim boolDrive As Boolean
    Dim boolNuetral As Boolean
    Dim boolReverse As Boolean

    ' Config variables for speed needle
    Const intNeedleLength = 75
    Const dblSpeedNeedleMinAngle = 2.25
    Dim dblSpeedNeedleMaxAngle = 7.2
    Dim dblSpeedNeedleAngle = 2.15
    Const intSpeedNeedleXOrigin = 80
    Const intSpeedNeedleYOrigin = 90
    Const dblVehicleMass As Double = 1000 ' Weight of vehicle in kilograms

    Dim intGear As Integer = 1 'First gear
    Dim dblGearRatio As Double = 1 / 4 ' First gear gear ratio

    Dim dblRPM As Double = 0
    Const dblMinRPM As Double = 800
    Const dblMaxRPM As Double = 3500 ' Fairly standard RPM shift point

    Dim dblEngineTorque As Double = 0
    Const dblMaxEngineTorque As Double = 500 ' This variable is probably incorrectly named. Not sure what to rename it

    Const dblDragCoefficient As Double = 0.05
    Const dblRollingResistanceCoefficient As Double = 0.01
    Dim dblDragForce As Double = 0
    Dim dblRollingResistanceForce As Double = 0

    Dim dblNetForce As Double = 0
    Dim dblAcceleration As Double = 0
    Dim dblVelocity As Double = 0

    Dim intSpeedNeedleXEnd = intSpeedNeedleXOrigin
    Dim intSpeedNeedleYEnd = intSpeedNeedleYOrigin

    ' Config variables for rpm needle
    Const intRpmNeedleLength = 60
    Const dblRpmNeedleMinAngle = 2.25
    Const dblRpmNeedleMaxAngle = 7.2
    Dim dblRpmNeedleAngle = 2.25
    Const intRpmNeedleXOrigin = 90
    Const intRpmNeedleYOrigin = 84
    Dim intRpmNeedleXEnd = intRpmNeedleXOrigin
    Dim intRpmNeedleYEnd = intRpmNeedleYOrigin

    Private WithEvents tmrNeedleUpdate As Timer
    Private WithEvents lblMPH As Label
    Private WithEvents lblGear As Label
    Dim TextBox2 As System.Windows.Forms.TextBox
    Dim TextBox3 As System.Windows.Forms.TextBox
    Dim TextBox4 As System.Windows.Forms.TextBox
    Dim pbxSpeed As PictureBox
    Dim pbxRPM As PictureBox
    Dim pbxParkingBrakeLight As PictureBox
    Dim lblDriveSelecterIndicator As Label
    Dim pbxRightTurnSignalLight As PictureBox
    Dim pbxLeftTurnSignalLight As PictureBox
    Dim pbxTurnSignalStock As PictureBox
    Dim pbxTurnSignalStockDown As PictureBox
    Dim pbxTurnSignalStockUp As PictureBox
    Dim pbxLowBeamIndicator As PictureBox
    Dim pbxHighBeamIndicator As PictureBox
    Dim pbxFogLightIndicator As PictureBox


    Dim boolLeftSignalOn As Boolean = False
    Dim boolRightSignalOn As Boolean = False

    Public Function isOn()
        Return boolCarOn
    End Function

    Public Sub New(ByRef lblMPH_IN As Label, ByRef lblGear_IN As Label, ByRef TextBox2_IN As System.Windows.Forms.TextBox, ByRef TextBox3_IN As System.Windows.Forms.TextBox, ByRef TextBox4_IN As System.Windows.Forms.TextBox, ByRef SPEED As PictureBox, ByRef RPM As PictureBox, ByRef PARKINGBRAKELIGHT As PictureBox, ByRef DRIVESELECTORINDICATOR As Label, ByRef RIGHTLIGHT As PictureBox, ByRef LEFTLIGHT As PictureBox, ByRef TURN As PictureBox, ByRef TURNDOWN As PictureBox, ByRef TURNUP As PictureBox, ByRef LOW As PictureBox, ByRef HIGH As PictureBox, ByRef FOG As PictureBox)
        tmrPedals.Interval = 5
        tmrBlinkers.Interval = 500
        tmrNeedleUpdate = New Timer()
        tmrNeedleUpdate.Interval = intDeltaTime ' Update interval in milliseconds
        tmrNeedleUpdate.Start()
        tmrPedals.Start()

        lblMPH = lblMPH_IN
        lblGear = lblGear_IN
        TextBox2 = TextBox2_IN
        TextBox3 = TextBox3_IN
        TextBox4 = TextBox4_IN
        pbxSpeed = SPEED
        pbxRPM = RPM
        pbxParkingBrakeLight = PARKINGBRAKELIGHT
        lblDriveSelecterIndicator = DRIVESELECTORINDICATOR
        pbxRightTurnSignalLight = RIGHTLIGHT
        pbxLeftTurnSignalLight = LEFTLIGHT
        pbxTurnSignalStock = TURN
        pbxTurnSignalStockDown = TURNDOWN
        pbxTurnSignalStockUp = TURNUP
        pbxLowBeamIndicator = LOW
        pbxHighBeamIndicator = HIGH
        pbxFogLightIndicator = FOG
    End Sub

    ' Speed is dictated by RPM instead of the other way around.
    Private Sub tmrPedalsHeld_Tick(sender As Object, e As EventArgs) Handles tmrPedals.Tick
        If intGear = 1 Then
            dblGearRatio = 1 / 4
            dblRpmIncrease = 200
        ElseIf intGear = 2 Then
            dblGearRatio = 1 / 3
            dblRpmIncrease = 100
        ElseIf intGear = 3 Then
            dblGearRatio = 1 / 2
            dblRpmIncrease = 50
        ElseIf intGear = 4 Then
            dblGearRatio = 1 / 1.5
            dblRpmIncrease = 25
        ElseIf intGear = 5 Then
            dblGearRatio = 1 / 1.25
            dblRpmIncrease = 12.5
        ElseIf intGear = 6 Then
            dblGearRatio = 1
            dblRpmIncrease = 6.25
        End If


        ' Increase or decrease the speed based on the gas, with upper and lower limits
        If boolGasHeld And boolDrive And boolParkingBrake.Equals(False) Then
            dblRPM = Math.Min(dblMaxRPM, dblRPM + (dblRpmIncrease * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * dblGearRatio))

            dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * dblGearRatio

            ' Upshift
            If intGear < 6 AndAlso dblRPM >= dblMaxRPM Then
                intGear += 1
                ' Reset RPM to prevent overshooting the next gear's RPM range
                dblRPM = dblMaxRPM * dblGearRatio
            End If
        ElseIf boolGasHeld And (boolPark Or boolNuetral) And dblVelocity.Equals(0) Then
            dblRPM = Math.Min(dblMaxRPM, dblRPM + (400 * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * 1))
            dblSpeedNeedleMaxAngle = 2.25
        ElseIf boolGasHeld And boolReverse And boolParkingBrake.Equals(False) Then
            dblRPM = Math.Min(4000, dblRPM + (dblRpmIncrease * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * dblGearRatio))
            dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * dblGearRatio
            intGear = 1
        Else
            ' Downshift
            If intGear > 1 AndAlso dblRPM < (2700 - dblRpmIncrease) Then
                intGear -= 1
                ' Reset RPM to prevent undershooting the next gear's RPM range
                'dblRPM = (dblMaxRPM * dblGearRatio) + 1500
                'dblRPM = dblRPM + 1000 + dblRpmIncrease
                dblRPM = dblMaxRPM - (intGear * 200)
            End If

            If Not boolBrakeHeld Then
                ' If gas not held, gradually reduce RPM
                If boolCarOn Then
                    dblRPM = Math.Max(dblMinRPM, dblRPM - (dblGearRatio * 2)) ' Gear ratio is just acting as a small decay that is tied to current gear
                    'dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * dblGearRatio ' Idle engine power
                    dblEngineTorque = 0
                Else
                    dblRPM = Math.Max(0, dblRPM - (dblGearRatio * 100))
                    dblEngineTorque = 0
                    ' Idle engine power
                    If boolPark.Equals(False) Then
                        dblEngineTorque = -(dblMaxEngineTorque / 60) * (dblRPM / dblMaxRPM) / dblGearRatio

                    End If
                End If
            End If
        End If

        ' Resistance forces must grow faster than Engine Torque in order to prevent infinite velocity increase
        dblDragForce = dblDragCoefficient * (dblVelocity ^ 2)
        dblRollingResistanceForce = dblRollingResistanceCoefficient * dblVehicleMass

        If boolBrakeHeld Then
            dblRPM = Math.Max(dblMinRPM, dblRPM - dblRpmBrakeDecrease / dblGearRatio)
            dblNetForce = dblEngineTorque - dblDragForce - dblRollingResistanceForce - dblBrakeForce
        Else
            dblNetForce = dblEngineTorque - dblDragForce - dblRollingResistanceForce
        End If

        dblAcceleration = dblNetForce / dblVehicleMass
        dblVelocity = dblVelocity + dblAcceleration

        If dblVelocity < 0 Then
            dblVelocity = 0
        End If

        lblMPH.Text = Convert.ToInt32(dblVelocity) & " MPH"
        Me.TextBox2.Text = "RPM: " & Convert.ToInt32(dblRPM)
        TextBox3.Text = "Current Gear: " & intGear
        TextBox4.Text = "Power: " & Convert.ToInt32(dblEngineTorque)
        lblGear.Text = intGear
    End Sub

    Public Sub BrakesOn()
        ' The AND means this will only work if the car is on
        boolBrakeHeld = True And boolCarOn
    End Sub

    Public Sub BrakesOff()
        boolBrakeHeld = False
    End Sub

    Public Sub GasOn()
        ' The AND means this will only work if the car is on
        boolGasHeld = True And boolCarOn
    End Sub

    Public Sub GasOff()
        boolGasHeld = False
    End Sub

    Dim bmpSpeedNeedle As New Bitmap(1024, 1024)
    Dim bmpRpmNeedle As New Bitmap(1024, 1024)
    Dim grphSpeedSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)
    Dim grphRpmSheet As Graphics = Graphics.FromImage(bmpRpmNeedle)


    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick
        ' Update end coordinates
        intSpeedNeedleXEnd = intSpeedNeedleXOrigin + Convert.ToInt32((Math.Cos((dblVelocity / 40.5) - 4) * intNeedleLength))
        intSpeedNeedleYEnd = intSpeedNeedleYOrigin + Convert.ToInt32((Math.Sin((dblVelocity / 40.5) - 4) * intNeedleLength))

        dblRpmNeedleAngle = dblRpmNeedleAngle + (dblRpmIncrease * 0.15)
        intRpmNeedleXEnd = intRpmNeedleXOrigin + Convert.ToInt32(Math.Cos((dblRPM / 2250) - 3.8) * intRpmNeedleLength)
        intRpmNeedleYEnd = intRpmNeedleYOrigin + Convert.ToInt32(Math.Sin((dblRPM / 2250) - 3.8) * intRpmNeedleLength)

        grphSpeedSheet.Dispose()
        grphRpmSheet.Dispose()

        bmpSpeedNeedle.Dispose()
        bmpSpeedNeedle = New Bitmap(1024, 1024)

        bmpRpmNeedle.Dispose()
        bmpRpmNeedle = New Bitmap(1024, 1024)

        grphSpeedSheet = Graphics.FromImage(bmpSpeedNeedle)
        grphRpmSheet = Graphics.FromImage(bmpRpmNeedle)

        pbxSpeed.Refresh()
        pbxRpm.Refresh()
    End Sub

    Private Sub tmrBlinkers_Tick(sender As Object, e As EventArgs) Handles tmrBlinkers.Tick
        If boolHazardLights Then
            pbxLeftTurnSignalLight.Visible = Not pbxLeftTurnSignalLight.Visible
            pbxRightTurnSignalLight.Visible = Not pbxRightTurnSignalLight.Visible
        ElseIf boolLeftSignalOn Then
            pbxLeftTurnSignalLight.Visible = Not pbxLeftTurnSignalLight.Visible
        ElseIf boolRightSignalOn Then
            pbxRightTurnSignalLight.Visible = Not pbxRightTurnSignalLight.Visible
        Else
            pbxLeftTurnSignalLight.Visible = False
            pbxRightTurnSignalLight.Visible = False
        End If
    End Sub

    Public Sub ToggleCarOn()
        If boolPark.Equals(True) Or boolNuetral.Equals(True) Then
            boolCarOn = Not boolCarOn
        ElseIf boolCarOn.Equals(True) And boolPark.Equals(False) And boolNuetral.Equals(False) Then
            MsgBox("Put Vehicle in PARK (P) or NUETRAL (N)" & Environment.NewLine & Environment.NewLine & "Cannot Turn Vehicle Off When in Drive (D) or Reverse (R)", MsgBoxStyle.Exclamation, "Stop Vehicle Error")
        End If

        If boolCarOn = True Then
            pbxParkingBrakeLight.Visible = True
            lblDriveSelecterIndicator.Visible = True
            lblMPH.Visible = True
            boolParkingBrake = True
        Else
            pbxRightTurnSignalLight.Visible = False
            pbxParkingBrakeLight.Visible = False
            pbxLeftTurnSignalLight.Visible = False
            pbxTurnSignalStock.Visible = True
            pbxTurnSignalStockDown.Visible = False
            pbxTurnSignalStockUp.Visible = False
            pbxLowBeamIndicator.Visible = False
            pbxHighBeamIndicator.Visible = False
            pbxFogLightIndicator.Visible = False
            boolFogLights = False
            boolLowBeam = False
            boolHighBeam = False
            lblDriveSelecterIndicator.Visible = False
            lblMPH.Visible = False
        End If
    End Sub

    Public Sub ToggleParkingBrake()
        If boolCarOn Then
            boolParkingBrake = Not boolParkingBrake
            pbxParkingBrakeLight.Visible = boolParkingBrake
            boolBrakeHeld = boolParkingBrake
        End If
    End Sub

    Public Sub RightTurnSignalOn()
        tmrBlinkers.Start()
        pbxRightTurnSignalLight.Visible = True
        pbxLeftTurnSignalLight.Visible = False
        pbxTurnSignalStock.Visible = False
        pbxTurnSignalStockUp.Visible = True
        boolRightSignalOn = True
        boolLeftSignalOn = False
    End Sub

    Public Sub LeftTurnSignalOn()
        tmrBlinkers.Start()
        pbxLeftTurnSignalLight.Visible = True
        pbxRightTurnSignalLight.Visible = False
        pbxTurnSignalStock.Visible = False
        pbxTurnSignalStockDown.Visible = True
        boolLeftSignalOn = True
        boolRightSignalOn = False
    End Sub

    Public Sub ResetTurnSignals()
        If (boolLeftSignalOn Or boolRightSignalOn) And boolCarOn Then
            tmrBlinkers.Stop()
            pbxRightTurnSignalLight.Visible = False
            pbxLeftTurnSignalLight.Visible = False
            pbxTurnSignalStock.Visible = True
            pbxTurnSignalStockUp.Visible = False
            pbxTurnSignalStockDown.Visible = False
            boolLeftSignalOn = False
            boolRightSignalOn = False
        End If
    End Sub

    Public Sub LowBeamToggle()
        If boolCarOn Then
            boolLowBeam = Not boolLowBeam
            pbxLowBeamIndicator.Visible = boolLowBeam
        End If
    End Sub

    Public Sub HighBeamToggle()
        If boolCarOn Then
            boolHighBeam = Not boolHighBeam
            pbxHighBeamIndicator.Visible = boolHighBeam
        End If
    End Sub

    Public Sub FogLightToggle()
        If boolCarOn Then
            boolFogLights = Not boolFogLights
            pbxFogLightIndicator.Visible = boolFogLights
        End If
    End Sub

    Public Sub HazardsToggle()
        boolHazardLights = Not boolHazardLights
        If boolCarOn And boolHazardLights Then
            pbxRightTurnSignalLight.Visible = True
            boolRightSignalOn = True
            pbxLeftTurnSignalLight.Visible = True
            boolLeftSignalOn = True
            tmrBlinkers.Start()
        ElseIf boolCarOn And Not boolHazardLights Then
            tmrBlinkers.Stop()
            pbxRightTurnSignalLight.Visible = False
            pbxLeftTurnSignalLight.Visible = False
            boolLeftSignalOn = False
            boolRightSignalOn = False
        End If
    End Sub

    Public Sub ParkingBrakeToggle()
        If boolCarOn And (dblVelocity < 1) Then
            boolPark = True
            boolDrive = False
            boolNuetral = False
            boolReverse = False
            lblDriveSelecterIndicator.Text = "P"
            lblGear.Visible = False
        End If
    End Sub

    Public Sub ParkButtonClick()
        If boolCarOn And (dblVelocity < 1) Then
            boolPark = True
            boolDrive = False
            boolNuetral = False
            boolReverse = False
            lblDriveSelecterIndicator.Text = "P"
            lblGear.Visible = False
        End If
    End Sub

    Public Sub ReverseButtonClick()
        If boolCarOn And (dblVelocity < 1) Then
            boolPark = False
            boolDrive = False
            boolNuetral = False
            boolReverse = True
            lblDriveSelecterIndicator.Text = "R"
            lblGear.Visible = False
        End If
    End Sub

    Public Sub NuetralButtonClick()
        If boolCarOn Then
            boolPark = False
            boolDrive = False
            boolNuetral = True
            boolReverse = False
            lblDriveSelecterIndicator.Text = "N"
            lblGear.Visible = False
        End If
    End Sub

    Public Sub DriveButtonClick()
        If boolCarOn And (dblVelocity < 1) Then
            boolPark = False
            boolDrive = True
            boolNuetral = False
            boolReverse = False
            lblDriveSelecterIndicator.Text = "D"
            lblGear.Visible = True
        End If
    End Sub

    Public Sub DrawSpeed(e As PaintEventArgs)
        grphSpeedSheet.DrawLine(New Pen(Color.Red, 3), intSpeedNeedleXOrigin, intSpeedNeedleYOrigin, intSpeedNeedleXEnd, intSpeedNeedleYEnd)
        e.Graphics.DrawImage(bmpSpeedNeedle, 0, 0)
    End Sub

    Public Sub DrawRPM(e As PaintEventArgs)
        grphRpmSheet.DrawLine(New Pen(Color.Yellow, 3), intRpmNeedleXOrigin, intRpmNeedleYOrigin, intRpmNeedleXEnd, intRpmNeedleYEnd)
        e.Graphics.DrawImage(bmpRpmNeedle, 0, 0)
    End Sub
End Class