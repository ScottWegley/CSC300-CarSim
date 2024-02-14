<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarSim
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pbxSpeed = New System.Windows.Forms.PictureBox()
        Me.pbxBrake = New System.Windows.Forms.PictureBox()
        Me.pbxGas = New System.Windows.Forms.PictureBox()
        Me.pbxRpm = New System.Windows.Forms.PictureBox()
        Me.BtnDraw = New System.Windows.Forms.Button()
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbxSpeed
        '
        Me.pbxSpeed.Image = Global.CSC300_CarSim.My.Resources.Resources.BlankSpeedometer
        Me.pbxSpeed.Location = New System.Drawing.Point(18, 18)
        Me.pbxSpeed.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pbxSpeed.Name = "pbxSpeed"
        Me.pbxSpeed.Size = New System.Drawing.Size(324, 332)
        Me.pbxSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxSpeed.TabIndex = 0
        Me.pbxSpeed.TabStop = False
        '
        'pbxBrake
        '
        Me.pbxBrake.ErrorImage = Nothing
        Me.pbxBrake.Image = Global.CSC300_CarSim.My.Resources.Resources.BrakePedal
        Me.pbxBrake.InitialImage = Global.CSC300_CarSim.My.Resources.Resources.BrakePedal
        Me.pbxBrake.Location = New System.Drawing.Point(18, 757)
        Me.pbxBrake.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pbxBrake.Name = "pbxBrake"
        Me.pbxBrake.Size = New System.Drawing.Size(218, 312)
        Me.pbxBrake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxBrake.TabIndex = 1
        Me.pbxBrake.TabStop = False
        '
        'pbxGas
        '
        Me.pbxGas.Image = Global.CSC300_CarSim.My.Resources.Resources.GasPedal
        Me.pbxGas.Location = New System.Drawing.Point(351, 757)
        Me.pbxGas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pbxGas.Name = "pbxGas"
        Me.pbxGas.Size = New System.Drawing.Size(182, 312)
        Me.pbxGas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGas.TabIndex = 2
        Me.pbxGas.TabStop = False
        '
        'pbxRpm
        '
        Me.pbxRpm.Image = Global.CSC300_CarSim.My.Resources.Resources.Tachometer
        Me.pbxRpm.Location = New System.Drawing.Point(351, 18)
        Me.pbxRpm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pbxRpm.Name = "pbxRpm"
        Me.pbxRpm.Size = New System.Drawing.Size(324, 332)
        Me.pbxRpm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRpm.TabIndex = 3
        Me.pbxRpm.TabStop = False
        '
        'BtnDraw
        '
        Me.BtnDraw.Location = New System.Drawing.Point(581, 381)
        Me.BtnDraw.Name = "BtnDraw"
        Me.BtnDraw.Size = New System.Drawing.Size(75, 30)
        Me.BtnDraw.TabIndex = 4
        Me.BtnDraw.Text = "Draw"
        Me.BtnDraw.UseVisualStyleBackColor = True
        '
        'frmCarSim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1713, 1088)
        Me.Controls.Add(Me.BtnDraw)
        Me.Controls.Add(Me.pbxRpm)
        Me.Controls.Add(Me.pbxGas)
        Me.Controls.Add(Me.pbxBrake)
        Me.Controls.Add(Me.pbxSpeed)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmCarSim"
        Me.Text = "Car Simulator"
        CType(Me.pbxSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxBrake, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRpm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbxSpeed As PictureBox
    Friend WithEvents pbxBrake As PictureBox
    Friend WithEvents pbxGas As PictureBox
    Friend WithEvents pbxRpm As PictureBox
    Friend WithEvents BtnDraw As Button
End Class
