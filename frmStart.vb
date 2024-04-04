Public Class frmStart
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim frmCarSim As frmCarSim = New frmCarSim()
        frmCarSim.Show()
        Me.Close()
    End Sub

    Private Sub mnStartExit_Click(sender As Object, e As EventArgs) Handles mnStartExit.Click
        Me.Close()
    End Sub

    Private Sub mnStartAbout_Click(sender As Object, e As EventArgs) Handles mnStartAbout.Click
        MessageBox.Show("Made by Adam Cartozian, Keegan Lenz, Scott Wegley", "Car Sim v0.8.7 Credits", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class