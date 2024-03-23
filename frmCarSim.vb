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
        car = New Car(lblMPH, lblGear, TextBox2, TextBox3, TextBox4, pbxSpeed, pbxRpm, pbxParkingBrakeLight, lblDriveSelecterIndicator, pbxRightTurnSignalLight, pbxLeftTurnSignalLight, pbxTurnSignalStock, pbxTurnSignalStockDown, pbxTurnSignalStockUp, pbxLowBeamIndicator, pbxHighBeamIndicator, pbxFogLightIndicator)
    End Sub

    Private Sub pbxBrake_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseDown
        ' Car brakes on
        car.BrakesOn()
    End Sub

    Private Sub pbxBrake_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxBrake.MouseUp
        ' Car brakes off
        car.BrakesOff()
    End Sub

    Private Sub pbxGas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseDown
        ' Car gas on
        car.GasOn()
    End Sub

    Private Sub pbxGas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxGas.MouseUp
        ' Car gas off
        car.GasOff()
    End Sub


    Private Sub frmCarSim_PaintSpeedNeedle(sender As Object, e As PaintEventArgs) Handles pbxSpeed.Paint
        ' Draw Speed
        car.DrawSpeed(e)
    End Sub

    Private Sub frmCarSim_PaintRpmNeedle(sender As Object, e As PaintEventArgs) Handles pbxRpm.Paint
        'Draw Rpm
        car.DrawRPM(e)
    End Sub

    ' Turns the car on/off
    Private Sub pbxStartButton_Click(sender As Object, e As EventArgs) Handles pbxStartButton.Click
        ' Toggle Car On
        car.ToggleCarOn()
    End Sub

    ' Throw the parking brake
    Private Sub pbParkingBrake_Click(sender As Object, e As EventArgs) Handles pbParkingBrake.Click
        ' Toggle Parking Brake
        car.ToggleParkingBrake()
    End Sub

    ' Logging for the turn stock interactions
    Dim MousePosition1 As Point
    ' Grab the first position on click

    Private Sub pbxTurnSignalStock_MouseDown(sender As Object, e As MouseEventArgs) Handles pbxTurnSignalStock.MouseDown
        If car.isOn() Then 'Check if Car is on
            MousePosition1 = Cursor.Position
        End If
    End Sub

    Private Sub pbxTurnSignalStock_MouseUp(sender As Object, e As MouseEventArgs) Handles pbxTurnSignalStock.MouseUp
        If car.isOn() Then 'Check if Car is on

            ' Log the second position, 
            Dim MousePosition2 As Point
            MousePosition2 = Cursor.Position
            If MousePosition1.Y >= MousePosition2.Y Then
                ' Right Turn Signal On
                car.getBlinkers().RightTurnSignalOn()
            ElseIf MousePosition1.Y < MousePosition2.Y Then
                ' Left Turn Signal On
                car.getBlinkers().LeftTurnSignalOn()
            End If
        End If
    End Sub

    Private Sub pbxTurnSignalAlt_Click(sender As Object, e As EventArgs) Handles pbxTurnSignalStockUp.Click, pbxTurnSignalStockDown.Click
        ' Turn Signal Off
        car.getBlinkers().ForceSignalsOff()
    End Sub

    Private Sub pbxLowBeamSwitch_Click(sender As Object, e As EventArgs) Handles pbxLowBeamSwitch.Click
        car.LowBeamToggle()
    End Sub

    Private Sub pbxHighBeamSwitch_Click(sender As Object, e As EventArgs) Handles pbxHighBeamSwitch.Click
        car.HighBeamToggle()
    End Sub

    Private Sub pbxFogLightSwitch_Click(sender As Object, e As EventArgs) Handles pbxFogLightSwitch.Click
        car.FogLightToggle()
    End Sub

    Private Sub pbxHazardSwitch_Click(sender As Object, e As EventArgs) Handles pbxHazardSwitch.Click
        If (car.isOn()) Then
            car.getBlinkers().HazardsToggle()
        End If
    End Sub


    Private Sub pbxParkingButton_Click(sender As Object, e As EventArgs) Handles pbxParkingButton.Click
        car.ParkingBrakeToggle()
    End Sub

    Private Sub pbxReverseButton_Click(sender As Object, e As EventArgs) Handles pbxReverseButton.Click
        car.ReverseButtonClick()
    End Sub

    Private Sub pbxNuetralButton_Click(sender As Object, e As EventArgs) Handles pbxNuetralButton.Click
        car.NuetralButtonClick()
    End Sub

    Private Sub pbxDriveButton_Click(sender As Object, e As EventArgs) Handles pbxDriveButton.Click
        car.DriveButtonClick()
    End Sub
End Class
