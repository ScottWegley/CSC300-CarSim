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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.pbRightTurnSignalLight = New System.Windows.Forms.PictureBox()
        Me.pbLeftTurnSignalLight = New System.Windows.Forms.PictureBox()
        Me.pbParkingBrakeLight = New System.Windows.Forms.PictureBox()
        Me.pbParkingBrake = New System.Windows.Forms.PictureBox()
        Me.pbxStartButton = New System.Windows.Forms.PictureBox()
        Me.pbxSpeed = New System.Windows.Forms.PictureBox()
        Me.pbxSteeringWheel = New System.Windows.Forms.PictureBox()
        Me.pbxRpm = New System.Windows.Forms.PictureBox()
        Me.pbxGas = New System.Windows.Forms.PictureBox()
        Me.pbxBrake = New System.Windows.Forms.PictureBox()
        CType(Me.pbRightTurnSignalLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLeftTurnSignalLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParkingBrakeLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParkingBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxStartButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSteeringWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(76, 163)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(381, 512)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 7
        '
        'pbRightTurnSignalLight
        '
        Me.pbRightTurnSignalLight.Image = Global.CSC300_CarSim.My.Resources.Resources.RightTurnSignal
        Me.pbRightTurnSignalLight.Location = New System.Drawing.Point(333, 193)
        Me.pbRightTurnSignalLight.Name = "pbRightTurnSignalLight"
        Me.pbRightTurnSignalLight.Size = New System.Drawing.Size(30, 28)
        Me.pbRightTurnSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRightTurnSignalLight.TabIndex = 11
        Me.pbRightTurnSignalLight.TabStop = False
        Me.pbRightTurnSignalLight.Visible = False
        '
        'pbLeftTurnSignalLight
        '
        Me.pbLeftTurnSignalLight.Image = Global.CSC300_CarSim.My.Resources.Resources.LeftTurnSignal
        Me.pbLeftTurnSignalLight.Location = New System.Drawing.Point(128, 195)
        Me.pbLeftTurnSignalLight.Name = "pbLeftTurnSignalLight"
        Me.pbLeftTurnSignalLight.Size = New System.Drawing.Size(30, 28)
        Me.pbLeftTurnSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLeftTurnSignalLight.TabIndex = 10
        Me.pbLeftTurnSignalLight.TabStop = False
        Me.pbLeftTurnSignalLight.Visible = False
        '
        'pbParkingBrakeLight
        '
        Me.pbParkingBrakeLight.Enabled = False
        Me.pbParkingBrakeLight.Image = Global.CSC300_CarSim.My.Resources.Resources.ParkingBrakeLight
        Me.pbParkingBrakeLight.Location = New System.Drawing.Point(227, 185)
        Me.pbParkingBrakeLight.Name = "pbParkingBrakeLight"
        Me.pbParkingBrakeLight.Size = New System.Drawing.Size(41, 29)
        Me.pbParkingBrakeLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbParkingBrakeLight.TabIndex = 9
        Me.pbParkingBrakeLight.TabStop = False
        Me.pbParkingBrakeLight.Visible = False
        '
        'pbParkingBrake
        '
        Me.pbParkingBrake.Image = Global.CSC300_CarSim.My.Resources.Resources.ParkingBrake
        Me.pbParkingBrake.Location = New System.Drawing.Point(58, 662)
        Me.pbParkingBrake.Name = "pbParkingBrake"
        Me.pbParkingBrake.Size = New System.Drawing.Size(100, 50)
        Me.pbParkingBrake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbParkingBrake.TabIndex = 8
        Me.pbParkingBrake.TabStop = False
        '
        'pbxStartButton
        '
        Me.pbxStartButton.Image = Global.CSC300_CarSim.My.Resources.Resources.engine_start_stop
        Me.pbxStartButton.Location = New System.Drawing.Point(392, 452)
        Me.pbxStartButton.Name = "pbxStartButton"
        Me.pbxStartButton.Size = New System.Drawing.Size(74, 65)
        Me.pbxStartButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxStartButton.TabIndex = 6
        Me.pbxStartButton.TabStop = False
        '
        'pbxSpeed
        '
        Me.pbxSpeed.Image = Global.CSC300_CarSim.My.Resources.Resources.BlankSpeedometer
        Me.pbxSpeed.InitialImage = Global.CSC300_CarSim.My.Resources.Resources.BlankSpeedometer
        Me.pbxSpeed.Location = New System.Drawing.Point(76, 54)
        Me.pbxSpeed.Name = "pbxSpeed"
        Me.pbxSpeed.Size = New System.Drawing.Size(108, 106)
        Me.pbxSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSpeed.TabIndex = 0
        Me.pbxSpeed.TabStop = False
        '
        'pbxSteeringWheel
        '
        Me.pbxSteeringWheel.Image = Global.CSC300_CarSim.My.Resources.Resources.SteeringWheel
        Me.pbxSteeringWheel.Location = New System.Drawing.Point(76, 229)
        Me.pbxSteeringWheel.Name = "pbxSteeringWheel"
        Me.pbxSteeringWheel.Size = New System.Drawing.Size(350, 314)
        Me.pbxSteeringWheel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSteeringWheel.TabIndex = 5
        Me.pbxSteeringWheel.TabStop = False
        '
        'pbxRpm
        '
        Me.pbxRpm.Image = Global.CSC300_CarSim.My.Resources.Resources.Tachometer1
        Me.pbxRpm.Location = New System.Drawing.Point(174, 45)
        Me.pbxRpm.Name = "pbxRpm"
        Me.pbxRpm.Size = New System.Drawing.Size(135, 124)
        Me.pbxRpm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRpm.TabIndex = 3
        Me.pbxRpm.TabStop = False
        '
        'pbxGas
        '
        Me.pbxGas.Image = Global.CSC300_CarSim.My.Resources.Resources.GasPedal1
        Me.pbxGas.Location = New System.Drawing.Point(305, 538)
        Me.pbxGas.Name = "pbxGas"
        Me.pbxGas.Size = New System.Drawing.Size(121, 203)
        Me.pbxGas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGas.TabIndex = 2
        Me.pbxGas.TabStop = False
        '
        'pbxBrake
        '
        Me.pbxBrake.ErrorImage = Nothing
        Me.pbxBrake.Image = Global.CSC300_CarSim.My.Resources.Resources.BrakePedal1
        Me.pbxBrake.InitialImage = Global.CSC300_CarSim.My.Resources.Resources.BrakePedal
        Me.pbxBrake.Location = New System.Drawing.Point(164, 538)
        Me.pbxBrake.Name = "pbxBrake"
        Me.pbxBrake.Size = New System.Drawing.Size(145, 203)
        Me.pbxBrake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxBrake.TabIndex = 1
        Me.pbxBrake.TabStop = False
        '
        'frmCarSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 743)
        Me.Controls.Add(Me.pbRightTurnSignalLight)
        Me.Controls.Add(Me.pbLeftTurnSignalLight)
        Me.Controls.Add(Me.pbParkingBrakeLight)
        Me.Controls.Add(Me.pbParkingBrake)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.pbxStartButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.pbxSpeed)
        Me.Controls.Add(Me.pbxSteeringWheel)
        Me.Controls.Add(Me.pbxRpm)
        Me.Controls.Add(Me.pbxGas)
        Me.Controls.Add(Me.pbxBrake)
        Me.Name = "frmCarSim"
        Me.Text = "Car Simulator"
        CType(Me.pbRightTurnSignalLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLeftTurnSignalLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParkingBrakeLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParkingBrake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxStartButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSteeringWheel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbxSpeed As PictureBox
    Friend WithEvents pbxBrake As PictureBox
    Friend WithEvents pbxGas As PictureBox
    Friend WithEvents pbxRpm As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents pbxSteeringWheel As PictureBox
    Friend WithEvents pbxStartButton As PictureBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents pbParkingBrake As PictureBox
    Friend WithEvents pbParkingBrakeLight As PictureBox
    Friend WithEvents pbLeftTurnSignalLight As PictureBox
    Friend WithEvents pbRightTurnSignalLight As PictureBox
End Class
