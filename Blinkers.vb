Public Class Blinkers

    Private WithEvents tmrBlinkers As Timer = New Timer()

    Dim boolLeftSignalOn As Boolean = False
    Dim boolRightSignalOn As Boolean = False
    Dim boolHazardLights As Boolean = False

    Dim pbxRightTurnSignalLight As PictureBox
    Dim pbxLeftTurnSignalLight As PictureBox
    Dim pbxTurnSignalStalk As PictureBox
    Dim pbxTurnSignalStalkDown As PictureBox
    Dim pbxTurnSignalStalkUp As PictureBox

    Public Sub New(ByRef RightTurnSignalLight As PictureBox, ByRef LeftTurnSignalLight As PictureBox, ByRef TurnStalkDefault As PictureBox, ByRef TurnStalkUp As PictureBox, ByRef TurnStalkDown As PictureBox)
        tmrBlinkers.Interval = 500
        pbxRightTurnSignalLight = RightTurnSignalLight
        pbxLeftTurnSignalLight = LeftTurnSignalLight
        pbxTurnSignalStalk = TurnStalkDefault
        pbxTurnSignalStalkDown = TurnStalkDown
        pbxTurnSignalStalkUp = TurnStalkUp
    End Sub

    Private Sub tmrBlinkers_Tick(sender As Object, e As EventArgs) Handles tmrBlinkers.Tick
        If boolHazardLights Then
            pbxLeftTurnSignalLight.Visible = Not pbxLeftTurnSignalLight.Visible
            pbxRightTurnSignalLight.Visible = Not pbxRightTurnSignalLight.Visible
        ElseIf boolLeftSignalOn Then
            pbxLeftTurnSignalLight.Visible = Not pbxLeftTurnSignalLight.Visible
        ElseIf boolRightSignalOn Then
            pbxRightTurnSignalLight.Visible = Not pbxRightTurnSignalLight.Visible
        Else
            pbxLeftTurnSignalLight.Visible = False
            pbxRightTurnSignalLight.Visible = False
        End If
    End Sub

    Public Sub rightTurnSignalOn()
        tmrBlinkers.Start()
        pbxRightTurnSignalLight.Visible = True
        pbxLeftTurnSignalLight.Visible = False
        pbxTurnSignalStalk.Visible = False
        pbxTurnSignalStalkUp.Visible = True
        boolRightSignalOn = True
        boolLeftSignalOn = False
    End Sub

    Public Sub leftTurnSignalOn()
        tmrBlinkers.Start()
        pbxLeftTurnSignalLight.Visible = True
        pbxRightTurnSignalLight.Visible = False
        pbxTurnSignalStalk.Visible = False
        pbxTurnSignalStalkDown.Visible = True
        boolLeftSignalOn = True
        boolRightSignalOn = False
    End Sub

    Public Sub hazardsToggle()
        boolHazardLights = Not boolHazardLights
        If boolHazardLights Then
            pbxRightTurnSignalLight.Visible = True
            boolRightSignalOn = True
            pbxLeftTurnSignalLight.Visible = True
            boolLeftSignalOn = True
            tmrBlinkers.Start()
        ElseIf Not boolHazardLights Then
            tmrBlinkers.Stop()
            pbxRightTurnSignalLight.Visible = False
            pbxLeftTurnSignalLight.Visible = False
            boolLeftSignalOn = False
            boolRightSignalOn = False
        End If
    End Sub

    Public Sub forceSignalsOff()
        tmrBlinkers.Stop()
        pbxRightTurnSignalLight.Visible = False
        pbxLeftTurnSignalLight.Visible = False
        pbxTurnSignalStalk.Visible = True
        pbxTurnSignalStalkUp.Visible = False
        pbxTurnSignalStalkDown.Visible = False
        boolLeftSignalOn = False
        boolRightSignalOn = False
    End Sub
End Class
