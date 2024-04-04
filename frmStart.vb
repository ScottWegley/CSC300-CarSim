Public Class frmStart
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim frmCarSim As frmCarSim = New frmCarSim()
        frmCarSim.Show()
        Me.Close()
    End Sub

    Private Sub mnStartExit_Click(sender As Object, e As EventArgs) Handles mnStartExit.Click
        Me.Close()
    End Sub
End Class