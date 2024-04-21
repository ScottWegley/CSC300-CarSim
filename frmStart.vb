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

    Private Sub InstructionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructionsToolStripMenuItem.Click
        MessageBox.Show("To use the simulator, you must use your mouse or trackpad as well as your left and right arrow keys as follows:" & Environment.NewLine & Environment.NewLine &
                "CAR ON/OFF: Click the Red StartStop Button with the Mouse" & Environment.NewLine & "STEERINGWHEEL: Left and Right Arrow Keys" & Environment.NewLine &
                "THROTTLE AND BRAKE: Click and Hold Brake or Gas Icon with Mouse" & Environment.NewLine & "TURN SIGNALS: Click and Drag Turn Signal Stock Up or Down with Mouse" & Environment.NewLine &
                "LIGHTS: Click Toggle Switches With Mouse" & Environment.NewLine & "PARKING BRAKE: Click Parking Brake Icon with Mouse" & Environment.NewLine &
                "RADIO: Click Radio Buttons With Mouse" & Environment.NewLine & "TRANSMISSION: Click the 'D', 'R', 'N', and 'P' button with mouse" & Environment.NewLine & Environment.NewLine &
                "*HOW TO DRIVE*" & Environment.NewLine & "Turn Vehicle On, Hit the 'D' button to put vehicle in drive, Release the parking brake, and Press the throttle!",
                "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class