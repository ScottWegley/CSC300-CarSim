Imports System.Security.Authentication.ExtendedProtection
Imports System.Xml.Schema

Public Class frmCarSim

    Dim car As Car

    ' This sub is where all configuration code should go.
    Public Sub New()
        ' Enable double buffering for the form
        Me.DoubleBuffered = True
        InitializeComponent()
    End Sub

    Private Sub frmCarSim_Load(sender As Object, e As EventArgs) Handles Me.Load
        car = New Car(lblMPH, lblGear, TextBox2, TextBox3, TextBox4, pbxSpeed, pbxRpm, pbxFuelAndTempGauge, pbxParkingBrakeLight, lblDriveSelecterIndicator, pbxRightTurnSignalLight, pbxLeftTurnSignalLight, pbxTurnSignalStalk, pbxTurnSignalStalkDown, pbxTurnSignalStalkUp, pbxLowBeamIndicator, pbxHighBeamIndicator, pbxFogLightIndicator, pbxSteeringWheel, pbxClock)
    End Sub

    Private Sub pbxBrake_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseDown
        ' Car brakes on
        car.getRPMSystem().BrakesOn()
    End Sub

    Private Sub pbxBrake_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseUp
        ' Car brakes off
        car.getRPMSystem().BrakesOff()
    End Sub

    Private Sub pbxGas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseDown
        ' Car gas on
        car.getRPMSystem().GasOn()
    End Sub

    Private Sub pbxGas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseUp
        ' Car gas off
        car.getRPMSystem().GasOff()
    End Sub


    Private Sub frmCarSim_PaintClockNeedles(Sender As Object, e As PaintEventArgs) Handles pbxClock.Paint
        car.getClock().DrawNeedles(e)
    End Sub

    Private Sub frmCarSim_PaintSpeedNeedle(sender As Object, e As PaintEventArgs) Handles pbxSpeed.Paint
        ' Draw Speed
        car.getRPMSystem().DrawSpeed(e)
    End Sub

    Private Sub frmCarSim_PaintRpmNeedle(sender As Object, e As PaintEventArgs) Handles pbxRpm.Paint
        'Draw Rpm
        car.getRPMSystem().DrawRPM(e)
    End Sub

    Private Sub frmCarSim_PaintFuelTempNeedle(sender As Object, e As PaintEventArgs) Handles pbxFuelAndTempGauge.Paint
        car.getRPMSystem().DrawFuelAndTemperature(e)
    End Sub

    ' Turns the car on/off
    Private Sub pbxStartButton_Click(sender As Object, e As EventArgs) Handles pbxStartButton.Click
        ' Toggle Car On
        car.getRPMSystem().ToggleCarOn()
        ' Toggle Clock On
        car.getClock().ToggleClock()
    End Sub

    ' Throw the parking brake
    Private Sub pbParkingBrake_Click(sender As Object, e As EventArgs) Handles pbParkingBrake.Click
        ' Toggle Parking Brake
        car.getRPMSystem().ToggleParkingBrake()
    End Sub

    ' Logging for the turn stalk interactions
    Dim MousePosition1 As Point
    ' Grab the first position on click

    Private Sub pbxTurnSignalStalk_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxTurnSignalStalk.MouseDown
        If car.isOn() Then 'Check if Car is on
            MousePosition1 = Cursor.Position
        End If
    End Sub

    Private Sub pbxTurnSignalStalk_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxTurnSignalStalk.MouseUp
        If car.isOn() Then 'Check if Car is on

            ' Log the second position, 
            Dim MousePosition2 As Point
            MousePosition2 = Cursor.Position
            If MousePosition1.Y >= MousePosition2.Y Then
                ' Right Turn Signal On
                car.getBlinkers().rightTurnSignalOn()
            ElseIf MousePosition1.Y < MousePosition2.Y Then
                ' Left Turn Signal On
                car.getBlinkers().leftTurnSignalOn()
            End If
        End If
    End Sub

    Private Sub pbxTurnSignalAlt_Click(sender As Object, e As EventArgs) Handles pbxTurnSignalStalkUp.Click, pbxTurnSignalStalkDown.Click
        ' Turn Signal Off
        car.getBlinkers().forceSignalsOff()
    End Sub

    Private Sub pbxLowBeamSwitch_Click(sender As Object, e As EventArgs) Handles pbxLowBeamSwitch.Click
        If (car.isOn()) Then
            car.getLights().lowBeamToggle()
        End If
    End Sub

    Private Sub pbxHighBeamSwitch_Click(sender As Object, e As EventArgs) Handles pbxHighBeamSwitch.Click
        If (car.isOn()) Then
            car.getLights().highBeamToggle()
        End If
    End Sub

    Private Sub pbxFogLightSwitch_Click(sender As Object, e As EventArgs) Handles pbxFogLightSwitch.Click
        If (car.isOn()) Then
            car.getLights().fogLightToggle()
        End If
    End Sub

    Private Sub pbxHazardSwitch_Click(sender As Object, e As EventArgs) Handles pbxHazardSwitch.Click
        If (car.isOn()) Then
            car.getBlinkers().hazardsToggle()
        End If
    End Sub


    Private Sub pbxParkingButton_Click(sender As Object, e As EventArgs) Handles pbxParkingButton.Click
        car.getRPMSystem().ParkingBrakeToggle()
    End Sub

    Private Sub pbxReverseButton_Click(sender As Object, e As EventArgs) Handles pbxReverseButton.Click
        car.getRPMSystem().ReverseButtonClick()
    End Sub

    Private Sub pbxNuetralButton_Click(sender As Object, e As EventArgs) Handles pbxNuetralButton.Click
        car.getRPMSystem().NuetralButtonClick()
    End Sub

    Private Sub pbxDriveButton_Click(sender As Object, e As EventArgs) Handles pbxDriveButton.Click
        car.getRPMSystem().DriveButtonClick()
    End Sub

    Private Sub mnCarExit_Click(sender As Object, e As EventArgs) Handles mnCarExit.Click
        Me.Close()
    End Sub

    Private Sub mnCarAbout_Click(sender As Object, e As EventArgs) Handles mnCarAbout.Click
        MessageBox.Show("This is a physics accurate car simulation designed by Adam Cartozian, Keegan Lenz, and Scott Wegley." & Environment.NewLine & "Turn the car on, put it in drive, release the parking brake and step on the gas!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Dim SWTurns As Double = 0
    Private Sub frmCarSim_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim bHandled As Boolean = False
        If car.isOn() Then
            Select Case e.KeyCode
                Case Keys.Right
                    car.getSteering.turnRight()
                    e.Handled = True
                Case Keys.Left
                    car.getSteering.turnLeft()
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub mnCarInstructions_Click(sender As Object, e As EventArgs) Handles mnCarInstructions.Click
        MessageBox.Show("To use the simulator, you must use your mouse or trackpad as well as your left and right arrow keys as follows:" & Environment.NewLine & Environment.NewLine &
                        "CAR ON/OFF: Click the Red StartStop Button with the Mouse" & Environment.NewLine & "STEERINGWHEEL: Left and Right Arrow Keys" & Environment.NewLine &
                        "THROTTLE AND BRAKE: Click and Hold Brake or Gas Icon with Mouse" & Environment.NewLine & "TURN SIGNALS: Click and Drag Turn Signal Stock Up or Down with Mouse" & Environment.NewLine &
                        "LIGHTS: Click Toggle Switches With Mouse" & Environment.NewLine & "PARKING BRAKE: Click Parking Brake Icon with Mouse" & Environment.NewLine &
                        "RADIO: Click Radio Buttons With Mouse" & Environment.NewLine & "TRANSMISSION: Click the 'D', 'R', 'N', and 'P' button with mouse" & Environment.NewLine & Environment.NewLine &
                        "*HOW TO DRIVE*" & Environment.NewLine & "Turn Vehicle On, Hit the 'D' button to put vehicle in drive, Release the parking brake, and Press the throttle!",
                        "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

    Private Sub pbxRadio_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxRadio.MouseDown
        If e.X <= 219 And e.X >= 195 And e.Y >= 66 And e.Y <= 76 Then
            ' Button 6
            car.getRadio().PlayMediaSix()
            Return
        End If
        If e.X <= 194 And e.X >= 169 And e.Y <= 76 And e.Y >= 67 Then
            ' Button 5
            car.getRadio().PlayMediaFive()
            Return
        End If
        If e.X <= 169 And e.X >= 143 And e.Y <= 78 And e.Y >= 67 Then
            ' Button 4
            car.getRadio().PlayMediaFour()
            Return
        End If
        If e.X <= 143 And e.X >= 115 And e.Y <= 75 And e.Y >= 66 Then
            ' Button 3
            car.getRadio().PlayMediaThree()
            Return
        End If
        If e.X <= 112 And e.X >= 89 And e.Y <= 76 And e.Y >= 64 Then
            ' Button 2
            car.getRadio().PlayMediaTwo()
            Return
        End If
        If e.X <= 86 And e.X >= 62 And e.Y <= 74 And e.Y >= 64 Then
            ' Button 1
            car.getRadio().PlayMediaOne()
            Return
        End If
        If e.X <= 38 And e.X >= 28 And e.Y <= 54 And e.Y >= 42 Then
            ' Volume Button
            car.getRadio().stopMusic()
        End If
        Console.WriteLine(e.X & " " & e.Y)
    End Sub
End Class
