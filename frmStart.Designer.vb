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
        Me.mnStartExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnStart.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(12, 39)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(428, 193)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'mnStart
        '
        Me.mnStart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnStartHelp, Me.mnStartExit})
        Me.mnStart.Location = New System.Drawing.Point(0, 0)
        Me.mnStart.Name = "mnStart"
        Me.mnStart.Size = New System.Drawing.Size(452, 24)
        Me.mnStart.TabIndex = 1
        Me.mnStart.Text = "MenuStrip1"
        '
        'mnStartHelp
        '
        Me.mnStartHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnStartAbout})
        Me.mnStartHelp.Name = "mnStartHelp"
        Me.mnStartHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnStartHelp.Text = "Help"
        '
        'mnStartAbout
        '
        Me.mnStartAbout.Name = "mnStartAbout"
        Me.mnStartAbout.Size = New System.Drawing.Size(180, 22)
        Me.mnStartAbout.Text = "About"
        '
        'mnStartExit
        '
        Me.mnStartExit.Name = "mnStartExit"
        Me.mnStartExit.Size = New System.Drawing.Size(38, 20)
        Me.mnStartExit.Text = "Exit"
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 244)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.mnStart)
        Me.MainMenuStrip = Me.mnStart
        Me.Name = "frmStart"
        Me.Text = "frmStart"
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
End Class
