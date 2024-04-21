Public Class Steering

    Private dblCurrentTurns As Double = 0

    Private pbxSteeringWheel As PictureBox
    Public Sub New(ByRef steeringWheel As PictureBox)
        pbxSteeringWheel = steeringWheel
    End Sub

    Public Sub turnRight()
        If dblCurrentTurns < 2 Then
            pbxSteeringWheel.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            pbxSteeringWheel.Refresh()
            dblCurrentTurns = dblCurrentTurns + 0.25
        End If
    End Sub

    Public Sub turnLeft()
        If dblCurrentTurns > -2 Then
            For x = 0 To 2
                pbxSteeringWheel.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Next
            pbxSteeringWheel.Refresh()
            dblCurrentTurns = dblCurrentTurns - 0.25
        End If
    End Sub
End Class
