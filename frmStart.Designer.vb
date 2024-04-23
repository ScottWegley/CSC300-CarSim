<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart
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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.mnStart = New System.Windows.Forms.MenuStrip()
        Me.mnStartHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnStartAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstructionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnStartExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.mnStart.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.Black
        Me.btnStart.Location = New System.Drawing.Point(429, 447)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(264, 78)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'mnStart
        '
        Me.mnStart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnStartHelp, Me.mnStartExit})
        Me.mnStart.Location = New System.Drawing.Point(0, 0)
        Me.mnStart.Name = "mnStart"
        Me.mnStart.Size = New System.Drawing.Size(1120, 24)
        Me.mnStart.TabIndex = 1
        Me.mnStart.Text = "MenuStrip1"
        '
        'mnStartHelp
        '
        Me.mnStartHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnStartAbout, Me.InstructionsToolStripMenuItem})
        Me.mnStartHelp.Name = "mnStartHelp"
        Me.mnStartHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnStartHelp.Text = "Help"
        '
        'mnStartAbout
        '
        Me.mnStartAbout.Name = "mnStartAbout"
        Me.mnStartAbout.Size = New System.Drawing.Size(136, 22)
        Me.mnStartAbout.Text = "About"
        '
        'InstructionsToolStripMenuItem
        '
        Me.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem"
        Me.InstructionsToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.InstructionsToolStripMenuItem.Text = "Instructions"
        '
        'mnStartExit
        '
        Me.mnStartExit.Name = "mnStartExit"
        Me.mnStartExit.Size = New System.Drawing.Size(38, 20)
        Me.mnStartExit.Text = "Exit"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Georgia", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(45, 53)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1031, 144)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Welcome To The Codebrewers" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Car Simulator"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CSC300_CarSim.My.Resources.Resources.StartBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1120, 550)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.mnStart)
        Me.DoubleBuffered = True
        Me.MainMenuStrip = Me.mnStart
        Me.Name = "frmStart"
        Me.Text = "Start"
        Me.mnStart.ResumeLayout(False)
        Me.mnStart.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents mnStart As MenuStrip
    Friend WithEvents mnStartHelp As ToolStripMenuItem
    Friend WithEvents mnStartAbout As ToolStripMenuItem
    Friend WithEvents mnStartExit As ToolStripMenuItem
    Friend WithEvents lblTitle As Label
    Friend WithEvents InstructionsToolStripMenuItem As ToolStripMenuItem
End Class
