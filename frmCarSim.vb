Imports System.Xml.Schema

Public Class frmCarSim
    Const intDeltaTime = 100

    ' These represent the current change being applied to the speed and rpm
    Dim dblRpmIncrease As Double = 400
    Dim dblRpmBrakeDecrease As Double = 10
    Dim dblSpeedIncrease As Double

    ' This boolean represents whether or not the car is on.
    Dim boolCarOn As Boolean = False

    ' This boolean represents whether the parking break is on or not
    Dim boolParkingBrake As Boolean = False

    ' These represent the current modification the brake is applying to the speed and rpm
    Dim dblBrakeSpeedMod As Double = 0.99
    Dim dblBrakeRpmMod As Double = 0

    Private WithEvents tmrPedals As Timer = New Timer()

    Private WithEvents tmrBlinkers As Timer = New Timer()

    ' These booleans represent the current state of the gas pedal and the brake pedal
    Dim boolGasHeld As Boolean = False
    Dim boolBrakeHeld As Boolean = False

    ' Config variables for speed needle
    Const intNeedleLength = 75
    Const dblSpeedNeedleMinAngle = 2.25
    Const dblSpeedNeedleMaxAngle = 7.2
    Dim dblSpeedNeedleAngle = 2.15
    Const intSpeedNeedleXOrigin = 80
    Const intSpeedNeedleYOrigin = 90
    Const dblVehicleMass As Double = 2000 ' Weight of vehicle pounds

    Dim intGear As Integer = 1 'First gear
    Dim dblGearRatio As Double = 1 / 4 ' First gear gear ratio

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

    ' This sub is where all configuration code should go.
    Public Sub New()
        ' Enable double buffering for the form
        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Private Sub frmCarSim_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmrPedals.Interval = 5
        tmrBlinkers.Interval = 500

        tmrNeedleUpdate = New Timer()
        tmrNeedleUpdate.Interval = intDeltaTime ' Update interval in milliseconds
        tmrNeedleUpdate.Start()
        tmrPedals.Start()
    End Sub

    ' Speed is dictated by RPM instead of the other way around.
    Private Sub tmrPedalsHeld_Tick(sender As Object, e As EventArgs) Handles tmrPedals.Tick
        If intGear = 1 Then
            dblGearRatio = 1 / 4
            dblRpmIncrease = 400
        ElseIf intGear = 2 Then
            dblGearRatio = 1 / 3
            dblRpmIncrease = 200
        ElseIf intGear = 3 Then
            dblGearRatio = 1 / 2
            dblRpmIncrease = 100
        ElseIf intGear = 4 Then
            dblGearRatio = 1 / 1.5
            dblRpmIncrease = 50
        ElseIf intGear = 5 Then
            dblGearRatio = 1 / 1.25
            dblRpmIncrease = 25
        ElseIf intGear = 6 Then
            dblGearRatio = 1
            dblRpmIncrease = 12.5
        End If


        ' Increase or decrease the speed based on the gas, with upper and lower limits
        If boolGasHeld Then
            dblRPM = Math.Min(dblMaxRPM, dblRPM + (dblRpmIncrease * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * dblGearRatio))

            dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * dblGearRatio

            ' Upshift
            If intGear < 6 AndAlso dblRPM >= dblMaxRPM Then
                intGear += 1
                ' Reset RPM to prevent overshooting the next gear's RPM range
                dblRPM = dblMaxRPM * dblGearRatio
            End If
        Else
            ' Downshift
            If intGear > 1 AndAlso dblRPM < dblMaxRPM * dblGearRatio Then
                intGear -= 1
                ' Reset RPM to prevent undershooting the next gear's RPM range
                dblRPM = dblMaxRPM * dblGearRatio
            End If

            If Not boolBrakeHeld Then
                ' If gas not held, gradually reduce RPM (likely needs to be dictated by rolling/drag in someway)
                dblRPM = Math.Max(0, dblRPM - dblGearRatio)

                ' Idle engine power
                dblEngineTorque = dblMaxEngineTorque * (dblRPM / dblMaxRPM) * dblGearRatio
            End If
        End If

        If boolBrakeHeld Then
            'dblRPM = Math.Min(dblMaxRPM, dblRPM - (dblRpmBrakeDecrease * ((dblMaxRPM - (dblRPM - 1000)) / (dblMaxRPM - 1000)) * dblGearRatio))
            dblRPM = Math.Max(0, dblRPM - dblRpmBrakeDecrease / dblGearRatio)
            dblEngineTorque = -(dblMaxEngineTorque / 10) * (dblRPM / dblMaxRPM) / dblGearRatio
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
        TextBox3.Text = "Current Gear: " & intGear

    End Sub

    Private Sub tmrBlinkers_Tick(sender As Object, e As EventArgs) Handles tmrBlinkers.Tick
        If boolLeftSignalOn Then
            pbxLeftTurnSignalLight.Visible = Not pbxLeftTurnSignalLight.Visible
        ElseIf boolRightSignalOn Then
            pbxRightTurnSignalLight.Visible = Not pbxRightTurnSignalLight.Visible
        Else
            pbxLeftTurnSignalLight.Visible = False
            pbxRightTurnSignalLight.Visible = False
        End If
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


    Private Sub frmCarSim_PaintSpeedNeedle(sender As Object, e As PaintEventArgs) Handles pbxSpeed.Paint
        grphSpeedSheet.DrawLine(New Pen(Color.Red, 3), intSpeedNeedleXOrigin, intSpeedNeedleYOrigin, intSpeedNeedleXEnd, intSpeedNeedleYEnd)
        e.Graphics.DrawImage(bmpSpeedNeedle, 0, 0)
    End Sub

    Private Sub frmCarSim_PaintRpmNeedle(sender As Object, e As PaintEventArgs) Handles pbxRpm.Paint
        grphRpmSheet.DrawLine(New Pen(Color.Yellow, 3), intRpmNeedleXOrigin, intRpmNeedleYOrigin, intRpmNeedleXEnd, intRpmNeedleYEnd)
        e.Graphics.DrawImage(bmpRpmNeedle, 0, 0)
    End Sub

    ' Turns the car on/off
    Private Sub pbxStartButton_Click(sender As Object, e As EventArgs) Handles pbxStartButton.Click
        boolCarOn = Not boolCarOn
        If boolCarOn = True Then
            pbxParkingBrakeLight.Visible = boolParkingBrake

        Else
            pbxRightTurnSignalLight.Visible = False
            pbxParkingBrakeLight.Visible = False
            pbxLeftTurnSignalLight.Visible = False
            pbxTurnSignalStock.Visible = True
            pbxTurnSignalStockDown.Visible = False
            pbxTurnSignalStockUp.Visible = False
        End If
    End Sub

    ' Throw the parking brake
    Private Sub pbParkingBrake_Click(sender As Object, e As EventArgs) Handles pbParkingBrake.Click
        boolParkingBrake = Not boolParkingBrake
        pbxParkingBrakeLight.Visible = boolParkingBrake And boolCarOn
        boolBrakeHeld = boolParkingBrake
    End Sub

    ' Logging for the turn stock interactions
    Dim MousePosition1 As Point
    ' Grab the first position on click
    Dim boolLeftSignalOn As Boolean = False
    Dim boolRightSignalOn As Boolean = False
    Private Sub pbxTurnSignalStock_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxTurnSignalStock.MouseDown
        If boolCarOn Then
            MousePosition1 = Cursor.Position
        End If
    End Sub

    Private Sub pbxTurnSignalStock_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxTurnSignalStock.MouseUp
        If boolCarOn Then
            tmrBlinkers.Start()
            ' Log the second position, 
            Dim MousePosition2 As Point
            MousePosition2 = Cursor.Position
            If MousePosition1.Y >= MousePosition2.Y Then
                pbxRightTurnSignalLight.Visible = True
                pbxLeftTurnSignalLight.Visible = False
                pbxTurnSignalStock.Visible = False
                pbxTurnSignalStockUp.Visible = True
                boolRightSignalOn = True
                boolLeftSignalOn = False
            ElseIf MousePosition1.Y < MousePosition2.Y Then
                pbxLeftTurnSignalLight.Visible = True
                pbxRightTurnSignalLight.Visible = False
                pbxTurnSignalStock.Visible = False
                pbxTurnSignalStockDown.Visible = True
                boolLeftSignalOn = True
                boolRightSignalOn = False
            End If
        End If
    End Sub

    Private Sub pbxTurnSignalAlt_Click(sender As Object, e As EventArgs) Handles pbxTurnSignalStockUp.Click, pbxTurnSignalStockDown.Click
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
End Class
