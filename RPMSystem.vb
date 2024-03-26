Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class RPMSystem

#Region "RPM System Variables"
    ' These represent the current change being applied to the speed and rpm
    Private dblRpmIncrease As Double = 400
    Private dblRpmBrakeDecrease As Double = 200

    Private dblRPM As Double = 0
    Const MINIMUM_RPM As Double = 800
    Const SHIFT_RPM As Double = 3500 ' Fairly standard RPM shift point
    Const MAX_RPM As Double = 6000

    Private dblEngineTorque As Double = 0
    Const MAX_ENGINE_TORQUE As Double = 2000

    Const DRAG_COEFFICIENT As Double = 0.05
    'Const MIN_DRAG_FORCE = 17.5 ' Prevent excessive velocity when idle while stationary
    Const ROLLING_RESISTANCE_COEFFICIENT As Double = 0.01
    Private dblDragForce As Double = 0
    Private dblRollingResistanceForce As Double = 0

    Private dblNetForce As Double = 0
    Private dblAcceleration As Double = 0
    Private dblVelocity As Double = 0

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeForce As Double = 1000

    Const VEHICLE_MASS As Double = 1000 ' Weight of vehicle in kilograms

    Dim intGear As Integer = 1 'First gear
    Dim dblGearRatio As Double = 1 / 4 ' First gear gear ratio
#End Region

#Region "Vehicle State Tracking"
    ' This boolean represents whether or not the car is on.
    Dim boolCarOn As Boolean = False
    ' This boolean represents whether the parking break is on or not
    Dim boolParkingBrake As Boolean = False
    ' These booleans represent the current state of the gas pedal and the brake pedal
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    Dim boolPark As Boolean = True
    Dim boolDrive As Boolean
    Dim boolNuetral As Boolean
    Dim boolReverse As Boolean
#End Region

#Region "Gauge Variables"
    ' Config variables for speed needle
    Const SPEED_NEEDLE_LENGTH = 75
    Const SPEED_NEEDLE_MIN_ANGLE = 2.25
    Private dblSpeedNeedleMaxAngle = 7.2
    Private dblSpeedNeedleAngle = 2.15

    Const SPEED_NEEDLE_X_ORIGIN = 80
    Const SPEED_NEEDLE_Y_ORIGIN = 90


    Private intSpeedNeedleXEnd = SPEED_NEEDLE_X_ORIGIN
    Private intSpeedNeedleYEnd = SPEED_NEEDLE_Y_ORIGIN

    ' Config variables for rpm needle
    Const RPM_NEEDLE_LENGTH = 60

    Const RPM_NEEDLE_MIN_ANGLE = 2.25
    Const RPM_NEEDLE_MAX_ANGLE = 7.2
    Private dblRpmNeedleAngle = 2.25

    Const RPM_NEEDLE_X_ORIGIN = 90
    Const RPM_NEEDLE_Y_ORIGIN = 84
    Private intRpmNeedleXEnd = RPM_NEEDLE_X_ORIGIN
    Private intRpmNeedleYEnd = RPM_NEEDLE_Y_ORIGIN

    ' Config variables for drawing on Gauges
    Dim bmpSpeedNeedle As New Bitmap(1024, 1024)
    Dim bmpRpmNeedle As New Bitmap(1024, 1024)
    Dim grphSpeedSheet As Graphics = Graphics.FromImage(bmpSpeedNeedle)
    Dim grphRpmSheet As Graphics = Graphics.FromImage(bmpRpmNeedle)
#End Region

    Private WithEvents tmrPedals As Timer = New Timer()
    Private WithEvents tmrNeedleUpdate As Timer = New Timer()
    Private WithEvents lblMPH As Label
    Private WithEvents lblGear As Label
    Dim TextBox2 As System.Windows.Forms.TextBox
    Dim TextBox3 As System.Windows.Forms.TextBox
    Dim TextBox4 As System.Windows.Forms.TextBox
    Dim pbxSpeed As PictureBox
    Dim pbxRPM As PictureBox
    Dim pbxParkingBrakeLight As PictureBox
    Dim lblDriveSelecterIndicator As Label


    Const TIMER_INTERVAL = 100

    Public Sub New(ByRef lblMPH_IN As Label, ByRef lblGear_IN As Label, ByRef TextBox2_IN As System.Windows.Forms.TextBox, ByRef TextBox3_IN As System.Windows.Forms.TextBox, TextBox4_IN As System.Windows.Forms.TextBox, ByRef SpeedGauge As PictureBox, ByRef RPMGauge As PictureBox, ByRef ParkingBrakeLight As PictureBox, ByRef DriveIndicator As Label)
        tmrPedals.Interval = 5
        tmrNeedleUpdate.Interval = TIMER_INTERVAL ' Update interval in milliseconds

        tmrNeedleUpdate.Start()
        tmrPedals.Start()

        lblMPH = lblMPH_IN
        lblGear = lblGear_IN
        TextBox2 = TextBox2_IN
        TextBox3 = TextBox3_IN
        TextBox4 = TextBox4_IN
        pbxSpeed = SpeedGauge
        pbxRPM = RPMGauge
        pbxParkingBrakeLight = ParkingBrakeLight
        lblDriveSelecterIndicator = DriveIndicator
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
            If intGear < 6 Then
                dblRPM = Math.Min(SHIFT_RPM, dblRPM + (dblRpmIncrease * ((SHIFT_RPM - (dblRPM - 1000)) / (SHIFT_RPM - 1000)) * dblGearRatio))
            Else
                dblRPM = Math.Min(MAX_RPM, dblRPM + (dblRpmIncrease) * ((MAX_RPM - (dblRPM - 1000)) / (MAX_RPM - 1000)) * dblGearRatio)
            End If

            dblEngineTorque = MAX_ENGINE_TORQUE * (dblRPM / MAX_RPM) * dblGearRatio

            ' Upshift
            If intGear < 6 AndAlso dblRPM >= SHIFT_RPM Then
                intGear += 1
                ' Reset RPM to prevent overshooting the next gear's RPM range
                dblRPM = SHIFT_RPM * dblGearRatio
            End If
        ElseIf boolGasHeld And (boolPark Or boolNuetral) And dblVelocity.Equals(0) Then
            dblRPM = Math.Min(SHIFT_RPM, dblRPM + (400 * ((SHIFT_RPM - (dblRPM - 1000)) / (SHIFT_RPM - 1000)) * 1))
            dblSpeedNeedleMaxAngle = 2.25

        ElseIf boolGasHeld And boolReverse And boolParkingBrake.Equals(False) Then
            dblRPM = Math.Min(4000, dblRPM + (dblRpmIncrease * ((SHIFT_RPM - (dblRPM - 1000)) / (SHIFT_RPM - 1000)) * dblGearRatio))
            dblEngineTorque = MAX_ENGINE_TORQUE * (dblRPM / MAX_RPM) * dblGearRatio
            intGear = 1
        Else
            ' Downshift
            If intGear > 1 AndAlso dblRPM < (2700 - dblRpmIncrease) Then
                intGear -= 1
                ' Reset RPM to prevent undershooting the next gear's RPM range
                'dblRPM = (dblMaxRPM * dblGearRatio) + 1500
                'dblRPM = dblRPM + 1000 + dblRpmIncrease
                dblRPM = SHIFT_RPM - (intGear * 200)
            End If

            If Not boolBrakeHeld Then
                ' If gas not held, gradually reduce RPM
                If boolCarOn Then
                    dblRPM = Math.Max(MINIMUM_RPM, dblRPM - (dblGearRatio * 2)) ' Gear ratio is just acting as a small decay that is tied to current gear
                    If boolDrive Then
                        dblEngineTorque = MAX_ENGINE_TORQUE * (dblRPM / MAX_RPM) * dblGearRatio ' Idle engine power
                        If dblEngineTorque < 50 Then
                            dblEngineTorque = 0
                        End If
                    Else
                        dblEngineTorque = 0
                    End If

                    'dblRPM = Math.Max(0, dblRPM - (dblGearRatio * 100))

                    'If boolPark.Equals(False) Then
                    '    dblEngineTorque = -(MAX_ENGINE_TORQUE / 60) * (dblRPM / MAX_RPM) / dblGearRatio
                    'End If
                End If
            End If
        End If

        ' Resistance forces must grow faster than Engine Torque in order to prevent infinite velocity increase
        'dblDragForce = Math.Max(MIN_DRAG_FORCE, DRAG_COEFFICIENT * (dblVelocity ^ 2))
        dblDragForce = DRAG_COEFFICIENT * (dblVelocity ^ 2)
        dblRollingResistanceForce = ROLLING_RESISTANCE_COEFFICIENT * VEHICLE_MASS

        If boolBrakeHeld Then
            dblRPM = Math.Max(MINIMUM_RPM, dblRPM - dblRpmBrakeDecrease / dblGearRatio)
            dblNetForce = dblEngineTorque - dblDragForce - dblRollingResistanceForce - dblBrakeForce
        Else
            dblNetForce = dblEngineTorque - dblDragForce - dblRollingResistanceForce
        End If

        dblAcceleration = dblNetForce / VEHICLE_MASS
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

    Private Sub tmrNeedleUpdate_Tick(sender As Object, e As EventArgs) Handles tmrNeedleUpdate.Tick
        ' Update end coordinates
        intSpeedNeedleXEnd = SPEED_NEEDLE_X_ORIGIN + Convert.ToInt32((Math.Cos((dblVelocity / 40.5) - 4) * SPEED_NEEDLE_LENGTH))
        intSpeedNeedleYEnd = SPEED_NEEDLE_Y_ORIGIN + Convert.ToInt32((Math.Sin((dblVelocity / 40.5) - 4) * SPEED_NEEDLE_LENGTH))

        dblRpmNeedleAngle = dblRpmNeedleAngle + (dblRpmIncrease * 0.15)
        intRpmNeedleXEnd = RPM_NEEDLE_X_ORIGIN + Convert.ToInt32(Math.Cos((dblRPM / 2250) - 3.8) * RPM_NEEDLE_LENGTH)
        intRpmNeedleYEnd = RPM_NEEDLE_Y_ORIGIN + Convert.ToInt32(Math.Sin((dblRPM / 2250) - 3.8) * RPM_NEEDLE_LENGTH)

        grphSpeedSheet.Dispose()
        grphRpmSheet.Dispose()

        bmpSpeedNeedle.Dispose()
        bmpSpeedNeedle = New Bitmap(1024, 1024)

        bmpRpmNeedle.Dispose()
        bmpRpmNeedle = New Bitmap(1024, 1024)

        grphSpeedSheet = Graphics.FromImage(bmpSpeedNeedle)
        grphRpmSheet = Graphics.FromImage(bmpRpmNeedle)

        pbxSpeed.Refresh()
        pbxRPM.Refresh()
    End Sub
    Public Sub DrawSpeed(e As PaintEventArgs)
        grphSpeedSheet.DrawLine(New Pen(Color.Red, 3), SPEED_NEEDLE_X_ORIGIN, SPEED_NEEDLE_Y_ORIGIN, intSpeedNeedleXEnd, intSpeedNeedleYEnd)
        e.Graphics.DrawImage(bmpSpeedNeedle, 0, 0)
    End Sub

    Public Sub DrawRPM(e As PaintEventArgs)
        grphRpmSheet.DrawLine(New Pen(Color.Yellow, 3), RPM_NEEDLE_X_ORIGIN, RPM_NEEDLE_Y_ORIGIN, intRpmNeedleXEnd, intRpmNeedleYEnd)
        e.Graphics.DrawImage(bmpRpmNeedle, 0, 0)
    End Sub


    Public Sub ToggleCarOn()
        If boolPark.Equals(True) Or boolNuetral.Equals(True) Then
            boolCarOn = Not boolCarOn
        ElseIf boolCarOn.Equals(True) And boolPark.Equals(False) And boolNuetral.Equals(False) Then
            MsgBox("Put Vehicle in PARK (P) or NUETRAL (N)" & Environment.NewLine & Environment.NewLine & "Cannot Turn Vehicle Off When in Drive (D) or Reverse (R)", MsgBoxStyle.Exclamation, "Stop Vehicle Error")
        End If
        ' MAKE SURE TO TURN BLINKERS OFF HERE
        If boolCarOn = True Then
            pbxParkingBrakeLight.Visible = True
            lblDriveSelecterIndicator.Visible = True
            lblMPH.Visible = True
            boolParkingBrake = True
        Else
            pbxParkingBrakeLight.Visible = False
            ' Put all lights off here
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

    Public Function isOn()
        Return boolCarOn
    End Function
End Class
