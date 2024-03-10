<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.pbxturnsignalstockdown = New System.Windows.Forms.PictureBox()
        Me.pbxStartButton = New System.Windows.Forms.PictureBox()
        Me.pbxSteeringWheel = New System.Windows.Forms.PictureBox()
        Me.pbRightTurnSignalLight = New System.Windows.Forms.PictureBox()
        Me.pbLeftTurnSignalLight = New System.Windows.Forms.PictureBox()
        Me.pbParkingBrakeLight = New System.Windows.Forms.PictureBox()
        Me.pbParkingBrake = New System.Windows.Forms.PictureBox()
        Me.pbxSpeed = New System.Windows.Forms.PictureBox()
        Me.pbxRpm = New System.Windows.Forms.PictureBox()
        Me.pbxGas = New System.Windows.Forms.PictureBox()
        Me.pbxBrake = New System.Windows.Forms.PictureBox()
        Me.pbxTurnSignalStock = New System.Windows.Forms.PictureBox()
        Me.pbxTurnSignalStockUp = New System.Windows.Forms.PictureBox()
        CType(Me.pbxturnsignalstockdown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxStartButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSteeringWheel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRightTurnSignalLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLeftTurnSignalLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParkingBrakeLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbParkingBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTurnSignalStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTurnSignalStockUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(407, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(407, 52)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(407, 73)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 9
        '
        'pbxturnsignalstockdown
        '
        Me.pbxturnsignalstockdown.Image = Global.CSC300_CarSim.My.Resources.Resources.TurnSignalStockDown
        Me.pbxturnsignalstockdown.Location = New System.Drawing.Point(19, 311)
        Me.pbxturnsignalstockdown.Name = "pbxturnsignalstockdown"
        Me.pbxturnsignalstockdown.Size = New System.Drawing.Size(115, 48)
        Me.pbxturnsignalstockdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxturnsignalstockdown.TabIndex = 14
        Me.pbxturnsignalstockdown.TabStop = False
        Me.pbxturnsignalstockdown.Visible = False
        '
        'pbxStartButton
        '
        Me.pbxStartButton.Image = Global.CSC300_CarSim.My.Resources.Resources.engine_start_stop
        Me.pbxStartButton.Location = New System.Drawing.Point(391, 438)
        Me.pbxStartButton.Name = "pbxStartButton"
        Me.pbxStartButton.Size = New System.Drawing.Size(74, 65)
        Me.pbxStartButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxStartButton.TabIndex = 6
        Me.pbxStartButton.TabStop = False
        '
        'pbxSteeringWheel
        '
        Me.pbxSteeringWheel.BackColor = System.Drawing.Color.Transparent
        Me.pbxSteeringWheel.Image = Global.CSC300_CarSim.My.Resources.Resources.SteeringWheel
        Me.pbxSteeringWheel.Location = New System.Drawing.Point(76, 189)
        Me.pbxSteeringWheel.Name = "pbxSteeringWheel"
        Me.pbxSteeringWheel.Size = New System.Drawing.Size(350, 314)
        Me.pbxSteeringWheel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSteeringWheel.TabIndex = 5
        Me.pbxSteeringWheel.TabStop = False
        '
        'pbRightTurnSignalLight
        '
        Me.pbRightTurnSignalLight.Image = Global.CSC300_CarSim.My.Resources.Resources.RightTurnSignal
        Me.pbRightTurnSignalLight.Location = New System.Drawing.Point(251, 11)
        Me.pbRightTurnSignalLight.Margin = New System.Windows.Forms.Padding(2)
        Me.pbRightTurnSignalLight.Name = "pbRightTurnSignalLight"
        Me.pbRightTurnSignalLight.Size = New System.Drawing.Size(20, 18)
        Me.pbRightTurnSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRightTurnSignalLight.TabIndex = 11
        Me.pbRightTurnSignalLight.TabStop = False
        Me.pbRightTurnSignalLight.Visible = False
        '
        'pbLeftTurnSignalLight
        '
        Me.pbLeftTurnSignalLight.Image = Global.CSC300_CarSim.My.Resources.Resources.LeftTurnSignal
        Me.pbLeftTurnSignalLight.Location = New System.Drawing.Point(114, 13)
        Me.pbLeftTurnSignalLight.Margin = New System.Windows.Forms.Padding(2)
        Me.pbLeftTurnSignalLight.Name = "pbLeftTurnSignalLight"
        Me.pbLeftTurnSignalLight.Size = New System.Drawing.Size(20, 18)
        Me.pbLeftTurnSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLeftTurnSignalLight.TabIndex = 10
        Me.pbLeftTurnSignalLight.TabStop = False
        Me.pbLeftTurnSignalLight.Visible = False
        '
        'pbParkingBrakeLight
        '
        Me.pbParkingBrakeLight.Enabled = False
        Me.pbParkingBrakeLight.Image = Global.CSC300_CarSim.My.Resources.Resources.ParkingBrakeLight
        Me.pbParkingBrakeLight.Location = New System.Drawing.Point(180, 6)
        Me.pbParkingBrakeLight.Margin = New System.Windows.Forms.Padding(2)
        Me.pbParkingBrakeLight.Name = "pbParkingBrakeLight"
        Me.pbParkingBrakeLight.Size = New System.Drawing.Size(27, 19)
        Me.pbParkingBrakeLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbParkingBrakeLight.TabIndex = 9
        Me.pbParkingBrakeLight.TabStop = False
        Me.pbParkingBrakeLight.Visible = False
        '
        'pbParkingBrake
        '
        Me.pbParkingBrake.Image = Global.CSC300_CarSim.My.Resources.Resources.ParkingBrake
        Me.pbParkingBrake.Location = New System.Drawing.Point(39, 430)
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
        Me.pbxSpeed.Location = New System.Drawing.Point(24, 38)
        Me.pbxSpeed.Name = "pbxSpeed"
        Me.pbxSpeed.Size = New System.Drawing.Size(160, 159)
        Me.pbxSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSpeed.TabIndex = 0
        Me.pbxSpeed.TabStop = False
        '
        'pbxRpm
        '
        Me.pbxRpm.Image = Global.CSC300_CarSim.My.Resources.Resources.Tachometer1
        Me.pbxRpm.Location = New System.Drawing.Point(207, 29)
        Me.pbxRpm.Name = "pbxRpm"
        Me.pbxRpm.Size = New System.Drawing.Size(181, 177)
        Me.pbxRpm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRpm.TabIndex = 3
        Me.pbxRpm.TabStop = False
        '
        'pbxGas
        '
        Me.pbxGas.Image = Global.CSC300_CarSim.My.Resources.Resources.GasPedal1
        Me.pbxGas.Location = New System.Drawing.Point(227, 509)
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
        Me.pbxBrake.Location = New System.Drawing.Point(76, 509)
        Me.pbxBrake.Name = "pbxBrake"
        Me.pbxBrake.Size = New System.Drawing.Size(145, 203)
        Me.pbxBrake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxBrake.TabIndex = 1
        Me.pbxBrake.TabStop = False
        '
        'pbxTurnSignalStock
        '
        Me.pbxTurnSignalStock.Image = Global.CSC300_CarSim.My.Resources.Resources.TurnStock
        Me.pbxTurnSignalStock.Location = New System.Drawing.Point(19, 280)
        Me.pbxTurnSignalStock.Margin = New System.Windows.Forms.Padding(2)
        Me.pbxTurnSignalStock.Name = "pbxTurnSignalStock"
        Me.pbxTurnSignalStock.Size = New System.Drawing.Size(87, 39)
        Me.pbxTurnSignalStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxTurnSignalStock.TabIndex = 12
        Me.pbxTurnSignalStock.TabStop = False
        '
        'pbxTurnSignalStockUp
        '
        Me.pbxTurnSignalStockUp.Image = Global.CSC300_CarSim.My.Resources.Resources.TurnSignalStockUp
        Me.pbxTurnSignalStockUp.Location = New System.Drawing.Point(24, 236)
        Me.pbxTurnSignalStockUp.Name = "pbxTurnSignalStockUp"
        Me.pbxTurnSignalStockUp.Size = New System.Drawing.Size(112, 83)
        Me.pbxTurnSignalStockUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxTurnSignalStockUp.TabIndex = 13
        Me.pbxTurnSignalStockUp.TabStop = False
        Me.pbxTurnSignalStockUp.Visible = False
        '
        'frmCarSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1154, 690)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.pbxStartButton)
        Me.Controls.Add(Me.pbxSteeringWheel)
        Me.Controls.Add(Me.pbRightTurnSignalLight)
        Me.Controls.Add(Me.pbLeftTurnSignalLight)
        Me.Controls.Add(Me.pbParkingBrakeLight)
        Me.Controls.Add(Me.pbParkingBrake)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.pbxSpeed)
        Me.Controls.Add(Me.pbxRpm)
        Me.Controls.Add(Me.pbxGas)
        Me.Controls.Add(Me.pbxBrake)
        Me.Controls.Add(Me.pbxTurnSignalStock)
        Me.Controls.Add(Me.pbxTurnSignalStockUp)
        Me.Controls.Add(Me.pbxturnsignalstockdown)
        Me.Name = "frmCarSim"
        Me.Text = "Car Simulator"
        CType(Me.pbxturnsignalstockdown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxStartButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSteeringWheel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRightTurnSignalLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLeftTurnSignalLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParkingBrakeLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbParkingBrake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTurnSignalStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTurnSignalStockUp, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pbxTurnSignalStock As PictureBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents pbxTurnSignalStockUp As PictureBox
    Friend WithEvents pbxturnsignalstockdown As PictureBox
End Class
