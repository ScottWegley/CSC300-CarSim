﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCarSim
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lblDriveSelecterIndicator = New System.Windows.Forms.Label()
        Me.lblMPH = New System.Windows.Forms.Label()
        Me.lblGear = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.mnStripCar = New System.Windows.Forms.MenuStrip()
        Me.mnCarHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCarAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCarInstructions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCarExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbxRadio = New System.Windows.Forms.PictureBox()
        Me.pbxClock = New System.Windows.Forms.PictureBox()
        Me.pbxFuelAndTempGauge = New System.Windows.Forms.PictureBox()
        Me.pbxDriveButton = New System.Windows.Forms.PictureBox()
        Me.pbxNuetralButton = New System.Windows.Forms.PictureBox()
        Me.pbxReverseButton = New System.Windows.Forms.PictureBox()
        Me.pbxParkingButton = New System.Windows.Forms.PictureBox()
        Me.pbxHazardSwitch = New System.Windows.Forms.PictureBox()
        Me.pbxHighBeamSwitch = New System.Windows.Forms.PictureBox()
        Me.pbxLowBeamSwitch = New System.Windows.Forms.PictureBox()
        Me.pbxFogLightSwitch = New System.Windows.Forms.PictureBox()
        Me.pbxFogLightIndicator = New System.Windows.Forms.PictureBox()
        Me.pbxLowBeamIndicator = New System.Windows.Forms.PictureBox()
        Me.pbxHighBeamIndicator = New System.Windows.Forms.PictureBox()
        Me.pbxStartButton = New System.Windows.Forms.PictureBox()
        Me.pbxSteeringWheel = New System.Windows.Forms.PictureBox()
        Me.pbxRightTurnSignalLight = New System.Windows.Forms.PictureBox()
        Me.pbxLeftTurnSignalLight = New System.Windows.Forms.PictureBox()
        Me.pbxParkingBrakeLight = New System.Windows.Forms.PictureBox()
        Me.pbParkingBrake = New System.Windows.Forms.PictureBox()
        Me.pbxSpeed = New System.Windows.Forms.PictureBox()
        Me.pbxRpm = New System.Windows.Forms.PictureBox()
        Me.pbxGas = New System.Windows.Forms.PictureBox()
        Me.pbxBrake = New System.Windows.Forms.PictureBox()
        Me.pbxTurnSignalStalk = New System.Windows.Forms.PictureBox()
        Me.pbxTurnSignalStalkUp = New System.Windows.Forms.PictureBox()
        Me.pbxTurnSignalStalkDown = New System.Windows.Forms.PictureBox()
        Me.mnStripCar.SuspendLayout()
        CType(Me.pbxRadio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxClock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxFuelAndTempGauge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDriveButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuetralButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxReverseButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxParkingButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxHazardSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxHighBeamSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLowBeamSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxFogLightSwitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxFogLightIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLowBeamIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxHighBeamIndicator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxStartButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSteeringWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRightTurnSignalLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLeftTurnSignalLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxParkingBrakeLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParkingBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTurnSignalStalk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTurnSignalStalkUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTurnSignalStalkDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(980, 593)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(980, 639)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 15
        Me.TextBox4.Visible = False
        '
        'lblDriveSelecterIndicator
        '
        Me.lblDriveSelecterIndicator.AutoSize = True
        Me.lblDriveSelecterIndicator.BackColor = System.Drawing.Color.Transparent
        Me.lblDriveSelecterIndicator.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDriveSelecterIndicator.Location = New System.Drawing.Point(555, 185)
        Me.lblDriveSelecterIndicator.Name = "lblDriveSelecterIndicator"
        Me.lblDriveSelecterIndicator.Size = New System.Drawing.Size(23, 24)
        Me.lblDriveSelecterIndicator.TabIndex = 26
        Me.lblDriveSelecterIndicator.Text = "P"
        Me.lblDriveSelecterIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDriveSelecterIndicator.Visible = False
        '
        'lblMPH
        '
        Me.lblMPH.AutoSize = True
        Me.lblMPH.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPH.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMPH.Location = New System.Drawing.Point(350, 219)
        Me.lblMPH.Name = "lblMPH"
        Me.lblMPH.Size = New System.Drawing.Size(45, 15)
        Me.lblMPH.TabIndex = 27
        Me.lblMPH.Text = "0 MPH"
        Me.lblMPH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMPH.Visible = False
        '
        'lblGear
        '
        Me.lblGear.AutoSize = True
        Me.lblGear.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblGear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblGear.Location = New System.Drawing.Point(558, 156)
        Me.lblGear.Name = "lblGear"
        Me.lblGear.Size = New System.Drawing.Size(14, 15)
        Me.lblGear.TabIndex = 28
        Me.lblGear.Text = "1"
        Me.lblGear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblGear.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(980, 618)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(441, 20)
        Me.TextBox3.TabIndex = 29
        Me.TextBox3.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(691, 86)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 30
        Me.TextBox1.Visible = False
        '
        'mnStripCar
        '
        Me.mnStripCar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnCarHelp, Me.mnCarExit})
        Me.mnStripCar.Location = New System.Drawing.Point(0, 0)
        Me.mnStripCar.Name = "mnStripCar"
        Me.mnStripCar.Size = New System.Drawing.Size(1154, 24)
        Me.mnStripCar.TabIndex = 33
        Me.mnStripCar.Text = "MenuStrip1"
        '
        'mnCarHelp
        '
        Me.mnCarHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnCarAbout, Me.mnCarInstructions})
        Me.mnCarHelp.Name = "mnCarHelp"
        Me.mnCarHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnCarHelp.Text = "Help"
        '
        'mnCarAbout
        '
        Me.mnCarAbout.Name = "mnCarAbout"
        Me.mnCarAbout.Size = New System.Drawing.Size(136, 22)
        Me.mnCarAbout.Text = "About"
        '
        'mnCarInstructions
        '
        Me.mnCarInstructions.Name = "mnCarInstructions"
        Me.mnCarInstructions.Size = New System.Drawing.Size(136, 22)
        Me.mnCarInstructions.Text = "Instructions"
        '
        'mnCarExit
        '
        Me.mnCarExit.Name = "mnCarExit"
        Me.mnCarExit.Size = New System.Drawing.Size(38, 20)
        Me.mnCarExit.Text = "Exit"
        '
        'pbxRadio
        '
        Me.pbxRadio.BackColor = System.Drawing.Color.Transparent
        Me.pbxRadio.Image = Global.CSC300_CarSim.My.Resources.Resources.Radio
        Me.pbxRadio.Location = New System.Drawing.Point(810, 368)
        Me.pbxRadio.Name = "pbxRadio"
        Me.pbxRadio.Size = New System.Drawing.Size(283, 87)
        Me.pbxRadio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRadio.TabIndex = 32
        Me.pbxRadio.TabStop = False
        '
        'pbxClock
        '
        Me.pbxClock.BackColor = System.Drawing.Color.Transparent
        Me.pbxClock.Image = Global.CSC300_CarSim.My.Resources.Resources.Clock1
        Me.pbxClock.Location = New System.Drawing.Point(878, 256)
        Me.pbxClock.Name = "pbxClock"
        Me.pbxClock.Size = New System.Drawing.Size(139, 115)
        Me.pbxClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxClock.TabIndex = 31
        Me.pbxClock.TabStop = False
        '
        'pbxFuelAndTempGauge
        '
        Me.pbxFuelAndTempGauge.BackColor = System.Drawing.Color.Transparent
        Me.pbxFuelAndTempGauge.Image = Global.CSC300_CarSim.My.Resources.Resources.TemoAndFuelGauge
        Me.pbxFuelAndTempGauge.Location = New System.Drawing.Point(679, 112)
        Me.pbxFuelAndTempGauge.Name = "pbxFuelAndTempGauge"
        Me.pbxFuelAndTempGauge.Size = New System.Drawing.Size(112, 108)
        Me.pbxFuelAndTempGauge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxFuelAndTempGauge.TabIndex = 30
        Me.pbxFuelAndTempGauge.TabStop = False
        '
        'pbxDriveButton
        '
        Me.pbxDriveButton.BackColor = System.Drawing.Color.Transparent
        Me.pbxDriveButton.Image = Global.CSC300_CarSim.My.Resources.Resources.Drive_Button
        Me.pbxDriveButton.Location = New System.Drawing.Point(722, 638)
        Me.pbxDriveButton.Name = "pbxDriveButton"
        Me.pbxDriveButton.Size = New System.Drawing.Size(57, 45)
        Me.pbxDriveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxDriveButton.TabIndex = 25
        Me.pbxDriveButton.TabStop = False
        '
        'pbxNuetralButton
        '
        Me.pbxNuetralButton.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuetralButton.Image = Global.CSC300_CarSim.My.Resources.Resources.Nuetral_Button
        Me.pbxNuetralButton.Location = New System.Drawing.Point(722, 601)
        Me.pbxNuetralButton.Name = "pbxNuetralButton"
        Me.pbxNuetralButton.Size = New System.Drawing.Size(57, 31)
        Me.pbxNuetralButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNuetralButton.TabIndex = 24
        Me.pbxNuetralButton.TabStop = False
        '
        'pbxReverseButton
        '
        Me.pbxReverseButton.BackColor = System.Drawing.Color.Transparent
        Me.pbxReverseButton.Image = Global.CSC300_CarSim.My.Resources.Resources.Reverse_Button
        Me.pbxReverseButton.Location = New System.Drawing.Point(722, 554)
        Me.pbxReverseButton.Name = "pbxReverseButton"
        Me.pbxReverseButton.Size = New System.Drawing.Size(57, 41)
        Me.pbxReverseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxReverseButton.TabIndex = 23
        Me.pbxReverseButton.TabStop = False
        '
        'pbxParkingButton
        '
        Me.pbxParkingButton.BackColor = System.Drawing.Color.Transparent
        Me.pbxParkingButton.Image = Global.CSC300_CarSim.My.Resources.Resources.Parking_Button
        Me.pbxParkingButton.Location = New System.Drawing.Point(722, 517)
        Me.pbxParkingButton.Name = "pbxParkingButton"
        Me.pbxParkingButton.Size = New System.Drawing.Size(57, 31)
        Me.pbxParkingButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxParkingButton.TabIndex = 22
        Me.pbxParkingButton.TabStop = False
        '
        'pbxHazardSwitch
        '
        Me.pbxHazardSwitch.BackColor = System.Drawing.Color.Transparent
        Me.pbxHazardSwitch.Image = Global.CSC300_CarSim.My.Resources.Resources.HazardLights_Switch
        Me.pbxHazardSwitch.Location = New System.Drawing.Point(378, 573)
        Me.pbxHazardSwitch.Name = "pbxHazardSwitch"
        Me.pbxHazardSwitch.Size = New System.Drawing.Size(28, 50)
        Me.pbxHazardSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxHazardSwitch.TabIndex = 21
        Me.pbxHazardSwitch.TabStop = False
        '
        'pbxHighBeamSwitch
        '
        Me.pbxHighBeamSwitch.BackColor = System.Drawing.Color.Transparent
        Me.pbxHighBeamSwitch.Image = Global.CSC300_CarSim.My.Resources.Resources.HighBeam_Switch
        Me.pbxHighBeamSwitch.Location = New System.Drawing.Point(339, 573)
        Me.pbxHighBeamSwitch.Name = "pbxHighBeamSwitch"
        Me.pbxHighBeamSwitch.Size = New System.Drawing.Size(28, 50)
        Me.pbxHighBeamSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxHighBeamSwitch.TabIndex = 20
        Me.pbxHighBeamSwitch.TabStop = False
        '
        'pbxLowBeamSwitch
        '
        Me.pbxLowBeamSwitch.BackColor = System.Drawing.Color.Transparent
        Me.pbxLowBeamSwitch.Image = Global.CSC300_CarSim.My.Resources.Resources.LowBeam_Switch
        Me.pbxLowBeamSwitch.Location = New System.Drawing.Point(339, 517)
        Me.pbxLowBeamSwitch.Name = "pbxLowBeamSwitch"
        Me.pbxLowBeamSwitch.Size = New System.Drawing.Size(28, 50)
        Me.pbxLowBeamSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxLowBeamSwitch.TabIndex = 19
        Me.pbxLowBeamSwitch.TabStop = False
        '
        'pbxFogLightSwitch
        '
        Me.pbxFogLightSwitch.BackColor = System.Drawing.Color.Transparent
        Me.pbxFogLightSwitch.Image = Global.CSC300_CarSim.My.Resources.Resources.Fog_Light_Switch
        Me.pbxFogLightSwitch.Location = New System.Drawing.Point(378, 517)
        Me.pbxFogLightSwitch.Name = "pbxFogLightSwitch"
        Me.pbxFogLightSwitch.Size = New System.Drawing.Size(28, 50)
        Me.pbxFogLightSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxFogLightSwitch.TabIndex = 18
        Me.pbxFogLightSwitch.TabStop = False
        '
        'pbxFogLightIndicator
        '
        Me.pbxFogLightIndicator.BackColor = System.Drawing.Color.Transparent
        Me.pbxFogLightIndicator.Image = Global.CSC300_CarSim.My.Resources.Resources.Fog_Light_Indicator
        Me.pbxFogLightIndicator.Location = New System.Drawing.Point(625, 189)
        Me.pbxFogLightIndicator.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxFogLightIndicator.Name = "pbxFogLightIndicator"
        Me.pbxFogLightIndicator.Size = New System.Drawing.Size(20, 18)
        Me.pbxFogLightIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxFogLightIndicator.TabIndex = 17
        Me.pbxFogLightIndicator.TabStop = False
        Me.pbxFogLightIndicator.Visible = False
        '
        'pbxLowBeamIndicator
        '
        Me.pbxLowBeamIndicator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pbxLowBeamIndicator.Image = Global.CSC300_CarSim.My.Resources.Resources.Low_Beam_Indicator
        Me.pbxLowBeamIndicator.Location = New System.Drawing.Point(524, 189)
        Me.pbxLowBeamIndicator.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxLowBeamIndicator.Name = "pbxLowBeamIndicator"
        Me.pbxLowBeamIndicator.Size = New System.Drawing.Size(20, 18)
        Me.pbxLowBeamIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxLowBeamIndicator.TabIndex = 16
        Me.pbxLowBeamIndicator.TabStop = False
        Me.pbxLowBeamIndicator.Visible = False
        '
        'pbxHighBeamIndicator
        '
        Me.pbxHighBeamIndicator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pbxHighBeamIndicator.Image = Global.CSC300_CarSim.My.Resources.Resources.HighBeamIndicator
        Me.pbxHighBeamIndicator.Location = New System.Drawing.Point(491, 189)
        Me.pbxHighBeamIndicator.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxHighBeamIndicator.Name = "pbxHighBeamIndicator"
        Me.pbxHighBeamIndicator.Size = New System.Drawing.Size(20, 18)
        Me.pbxHighBeamIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxHighBeamIndicator.TabIndex = 15
        Me.pbxHighBeamIndicator.TabStop = False
        Me.pbxHighBeamIndicator.Visible = False
        '
        'pbxStartButton
        '
        Me.pbxStartButton.BackColor = System.Drawing.Color.Transparent
        Me.pbxStartButton.Image = Global.CSC300_CarSim.My.Resources.Resources.engine_start_stop
        Me.pbxStartButton.Location = New System.Drawing.Point(714, 445)
        Me.pbxStartButton.Name = "pbxStartButton"
        Me.pbxStartButton.Size = New System.Drawing.Size(77, 70)
        Me.pbxStartButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxStartButton.TabIndex = 6
        Me.pbxStartButton.TabStop = False
        '
        'pbxSteeringWheel
        '
        Me.pbxSteeringWheel.BackColor = System.Drawing.Color.Transparent
        Me.pbxSteeringWheel.Image = Global.CSC300_CarSim.My.Resources.Resources.SteeringWheel
        Me.pbxSteeringWheel.Location = New System.Drawing.Point(391, 212)
        Me.pbxSteeringWheel.Name = "pbxSteeringWheel"
        Me.pbxSteeringWheel.Size = New System.Drawing.Size(350, 314)
        Me.pbxSteeringWheel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSteeringWheel.TabIndex = 5
        Me.pbxSteeringWheel.TabStop = False
        '
        'pbxRightTurnSignalLight
        '
        Me.pbxRightTurnSignalLight.BackColor = System.Drawing.Color.Transparent
        Me.pbxRightTurnSignalLight.Image = Global.CSC300_CarSim.My.Resources.Resources.RightTurnSignal
        Me.pbxRightTurnSignalLight.Location = New System.Drawing.Point(654, 189)
        Me.pbxRightTurnSignalLight.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxRightTurnSignalLight.Name = "pbxRightTurnSignalLight"
        Me.pbxRightTurnSignalLight.Size = New System.Drawing.Size(20, 18)
        Me.pbxRightTurnSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRightTurnSignalLight.TabIndex = 11
        Me.pbxRightTurnSignalLight.TabStop = False
        Me.pbxRightTurnSignalLight.Visible = False
        '
        'pbxLeftTurnSignalLight
        '
        Me.pbxLeftTurnSignalLight.BackColor = System.Drawing.Color.Transparent
        Me.pbxLeftTurnSignalLight.Image = Global.CSC300_CarSim.My.Resources.Resources.LeftTurnSignal
        Me.pbxLeftTurnSignalLight.Location = New System.Drawing.Point(457, 189)
        Me.pbxLeftTurnSignalLight.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxLeftTurnSignalLight.Name = "pbxLeftTurnSignalLight"
        Me.pbxLeftTurnSignalLight.Size = New System.Drawing.Size(20, 18)
        Me.pbxLeftTurnSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxLeftTurnSignalLight.TabIndex = 10
        Me.pbxLeftTurnSignalLight.TabStop = False
        Me.pbxLeftTurnSignalLight.Visible = False
        '
        'pbxParkingBrakeLight
        '
        Me.pbxParkingBrakeLight.BackColor = System.Drawing.Color.Transparent
        Me.pbxParkingBrakeLight.Enabled = False
        Me.pbxParkingBrakeLight.Image = Global.CSC300_CarSim.My.Resources.Resources.ParkingBrakeLight
        Me.pbxParkingBrakeLight.Location = New System.Drawing.Point(586, 188)
        Me.pbxParkingBrakeLight.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxParkingBrakeLight.Name = "pbxParkingBrakeLight"
        Me.pbxParkingBrakeLight.Size = New System.Drawing.Size(27, 19)
        Me.pbxParkingBrakeLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxParkingBrakeLight.TabIndex = 9
        Me.pbxParkingBrakeLight.TabStop = False
        Me.pbxParkingBrakeLight.Visible = False
        '
        'pbParkingBrake
        '
        Me.pbParkingBrake.BackColor = System.Drawing.Color.Transparent
        Me.pbParkingBrake.Image = Global.CSC300_CarSim.My.Resources.Resources.ParkingBrake
        Me.pbParkingBrake.Location = New System.Drawing.Point(339, 647)
        Me.pbParkingBrake.Margin = New System.Windows.Forms.Padding(2)
        Me.pbParkingBrake.Name = "pbParkingBrake"
        Me.pbParkingBrake.Size = New System.Drawing.Size(67, 32)
        Me.pbParkingBrake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbParkingBrake.TabIndex = 8
        Me.pbParkingBrake.TabStop = False
        '
        'pbxSpeed
        '
        Me.pbxSpeed.Image = Global.CSC300_CarSim.My.Resources.Resources.BlankSpeedometer
        Me.pbxSpeed.InitialImage = Global.CSC300_CarSim.My.Resources.Resources.BlankSpeedometer
        Me.pbxSpeed.Location = New System.Drawing.Point(292, 86)
        Me.pbxSpeed.Name = "pbxSpeed"
        Me.pbxSpeed.Size = New System.Drawing.Size(160, 159)
        Me.pbxSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSpeed.TabIndex = 0
        Me.pbxSpeed.TabStop = False
        '
        'pbxRpm
        '
        Me.pbxRpm.BackColor = System.Drawing.Color.Transparent
        Me.pbxRpm.Image = Global.CSC300_CarSim.My.Resources.Resources.Tachometer1
        Me.pbxRpm.Location = New System.Drawing.Point(475, 25)
        Me.pbxRpm.Name = "pbxRpm"
        Me.pbxRpm.Size = New System.Drawing.Size(181, 177)
        Me.pbxRpm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRpm.TabIndex = 3
        Me.pbxRpm.TabStop = False
        '
        'pbxGas
        '
        Me.pbxGas.BackColor = System.Drawing.Color.Transparent
        Me.pbxGas.Image = Global.CSC300_CarSim.My.Resources.Resources.GasPedal1
        Me.pbxGas.Location = New System.Drawing.Point(584, 509)
        Me.pbxGas.Name = "pbxGas"
        Me.pbxGas.Size = New System.Drawing.Size(121, 203)
        Me.pbxGas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGas.TabIndex = 2
        Me.pbxGas.TabStop = False
        '
        'pbxBrake
        '
        Me.pbxBrake.BackColor = System.Drawing.Color.Transparent
        Me.pbxBrake.ErrorImage = Nothing
        Me.pbxBrake.Image = Global.CSC300_CarSim.My.Resources.Resources.BrakePedal1
        Me.pbxBrake.InitialImage = Global.CSC300_CarSim.My.Resources.Resources.BrakePedal
        Me.pbxBrake.Location = New System.Drawing.Point(439, 509)
        Me.pbxBrake.Name = "pbxBrake"
        Me.pbxBrake.Size = New System.Drawing.Size(147, 203)
        Me.pbxBrake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxBrake.TabIndex = 1
        Me.pbxBrake.TabStop = False
        '
        'pbxTurnSignalStalk
        '
        Me.pbxTurnSignalStalk.BackColor = System.Drawing.Color.Transparent
        Me.pbxTurnSignalStalk.Image = Global.CSC300_CarSim.My.Resources.Resources.TurnStalk
        Me.pbxTurnSignalStalk.Location = New System.Drawing.Point(325, 323)
        Me.pbxTurnSignalStalk.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxTurnSignalStalk.Name = "pbxTurnSignalStalk"
        Me.pbxTurnSignalStalk.Size = New System.Drawing.Size(87, 39)
        Me.pbxTurnSignalStalk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxTurnSignalStalk.TabIndex = 12
        Me.pbxTurnSignalStalk.TabStop = False
        '
        'pbxTurnSignalStalkUp
        '
        Me.pbxTurnSignalStalkUp.BackColor = System.Drawing.Color.Transparent
        Me.pbxTurnSignalStalkUp.Image = Global.CSC300_CarSim.My.Resources.Resources.TurnSignalStalkUp
        Me.pbxTurnSignalStalkUp.Location = New System.Drawing.Point(330, 279)
        Me.pbxTurnSignalStalkUp.Name = "pbxTurnSignalStalkUp"
        Me.pbxTurnSignalStalkUp.Size = New System.Drawing.Size(112, 83)
        Me.pbxTurnSignalStalkUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxTurnSignalStalkUp.TabIndex = 13
        Me.pbxTurnSignalStalkUp.TabStop = False
        Me.pbxTurnSignalStalkUp.Visible = False
        '
        'pbxTurnSignalStalkDown
        '
        Me.pbxTurnSignalStalkDown.BackColor = System.Drawing.Color.Transparent
        Me.pbxTurnSignalStalkDown.Image = Global.CSC300_CarSim.My.Resources.Resources.TurnSignalStalkDown
        Me.pbxTurnSignalStalkDown.Location = New System.Drawing.Point(325, 354)
        Me.pbxTurnSignalStalkDown.Name = "pbxTurnSignalStalkDown"
        Me.pbxTurnSignalStalkDown.Size = New System.Drawing.Size(115, 48)
        Me.pbxTurnSignalStalkDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxTurnSignalStalkDown.TabIndex = 14
        Me.pbxTurnSignalStalkDown.TabStop = False
        Me.pbxTurnSignalStalkDown.Visible = False
        '
        'frmCarSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.CSC300_CarSim.My.Resources.Resources.Road
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1154, 690)
        Me.Controls.Add(Me.pbxClock)
        Me.Controls.Add(Me.lblMPH)
        Me.Controls.Add(Me.pbxSpeed)
        Me.Controls.Add(Me.pbxRadio)
        Me.Controls.Add(Me.pbxFuelAndTempGauge)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.lblGear)
        Me.Controls.Add(Me.lblDriveSelecterIndicator)
        Me.Controls.Add(Me.pbxDriveButton)
        Me.Controls.Add(Me.pbxNuetralButton)
        Me.Controls.Add(Me.pbxReverseButton)
        Me.Controls.Add(Me.pbxParkingButton)
        Me.Controls.Add(Me.pbxHazardSwitch)
        Me.Controls.Add(Me.pbxHighBeamSwitch)
        Me.Controls.Add(Me.pbxLowBeamSwitch)
        Me.Controls.Add(Me.pbxFogLightSwitch)
        Me.Controls.Add(Me.pbxFogLightIndicator)
        Me.Controls.Add(Me.pbxLowBeamIndicator)
        Me.Controls.Add(Me.pbxHighBeamIndicator)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.pbxStartButton)
        Me.Controls.Add(Me.pbxSteeringWheel)
        Me.Controls.Add(Me.pbxRightTurnSignalLight)
        Me.Controls.Add(Me.pbxLeftTurnSignalLight)
        Me.Controls.Add(Me.pbxParkingBrakeLight)
        Me.Controls.Add(Me.pbParkingBrake)
        Me.Controls.Add(Me.pbxRpm)
        Me.Controls.Add(Me.pbxGas)
        Me.Controls.Add(Me.pbxBrake)
        Me.Controls.Add(Me.pbxTurnSignalStalk)
        Me.Controls.Add(Me.pbxTurnSignalStalkUp)
        Me.Controls.Add(Me.pbxTurnSignalStalkDown)
        Me.Controls.Add(Me.mnStripCar)
        Me.DoubleBuffered = True
        Me.MainMenuStrip = Me.mnStripCar
        Me.Name = "frmCarSim"
        Me.Text = "Car Simulator"
        Me.mnStripCar.ResumeLayout(False)
        Me.mnStripCar.PerformLayout()
        CType(Me.pbxRadio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxClock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxFuelAndTempGauge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDriveButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuetralButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxReverseButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxParkingButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxHazardSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxHighBeamSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLowBeamSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxFogLightSwitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxFogLightIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLowBeamIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxHighBeamIndicator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxStartButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSteeringWheel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRightTurnSignalLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLeftTurnSignalLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxParkingBrakeLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParkingBrake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTurnSignalStalk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTurnSignalStalkUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTurnSignalStalkDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbxSpeed As PictureBox
    Friend WithEvents pbxBrake As PictureBox
    Friend WithEvents pbxGas As PictureBox
    Friend WithEvents pbxRpm As PictureBox
    Friend WithEvents pbxSteeringWheel As PictureBox
    Friend WithEvents pbxStartButton As PictureBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents pbParkingBrake As PictureBox
    Friend WithEvents pbxParkingBrakeLight As PictureBox
    Friend WithEvents pbxLeftTurnSignalLight As PictureBox
    Friend WithEvents pbxRightTurnSignalLight As PictureBox
    Friend WithEvents pbxTurnSignalStalk As PictureBox
    Friend WithEvents pbxTurnSignalStalkUp As PictureBox
    Friend WithEvents pbxTurnSignalStalkDown As PictureBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents pbxHighBeamIndicator As PictureBox
    Friend WithEvents pbxLowBeamIndicator As PictureBox
    Friend WithEvents pbxFogLightIndicator As PictureBox
    Friend WithEvents pbxFogLightSwitch As PictureBox
    Friend WithEvents pbxLowBeamSwitch As PictureBox
    Friend WithEvents pbxHighBeamSwitch As PictureBox
    Friend WithEvents pbxHazardSwitch As PictureBox
    Friend WithEvents pbxParkingButton As PictureBox
    Friend WithEvents pbxReverseButton As PictureBox
    Friend WithEvents pbxNuetralButton As PictureBox
    Friend WithEvents pbxDriveButton As PictureBox
    Friend WithEvents lblDriveSelecterIndicator As Label
    Friend WithEvents lblMPH As Label
    Friend WithEvents lblGear As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents pbxFuelAndTempGauge As PictureBox
    Friend WithEvents pbxClock As PictureBox
    Friend WithEvents pbxRadio As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents mnStripCar As MenuStrip
    Friend WithEvents mnCarHelp As ToolStripMenuItem
    Friend WithEvents mnCarAbout As ToolStripMenuItem
    Friend WithEvents mnCarExit As ToolStripMenuItem
    Friend WithEvents mnCarInstructions As ToolStripMenuItem
End Class
