Public Class Blinkers

    Private WithEvents tmrBlinkers As Timer = New Timer()

    Dim boolLeftSignalOn As Boolean = False
    Dim boolRightSignalOn As Boolean = False
    Dim boolHazardLights As Boolean = False

    Dim pbxRightTurnSignalLight As PictureBox
    Dim pbxLeftTurnSignalLight As PictureBox
    Dim pbxTurnSignalStock As PictureBox
    Dim pbxTurnSignalStockDown As PictureBox
    Dim pbxTurnSignalStockUp As PictureBox

    Public Sub New(ByRef RightTurnSignalLight As PictureBox, ByRef LeftTurnSignalLight As PictureBox, ByRef TurnStockDefault As PictureBox, ByRef TurnStockUp As PictureBox, ByRef TurnStockDown As PictureBox)
        tmrBlinkers.Interval = 500
        pbxRightTurnSignalLight = RightTurnSignalLight
        pbxLeftTurnSignalLight = LeftTurnSignalLight
        pbxTurnSignalStock = TurnStockDefault
        pbxTurnSignalStockDown = TurnStockDown
        pbxTurnSignalStockUp = TurnStockUp
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

    Public Sub RightTurnSignalOn()
        tmrBlinkers.Start()
        pbxRightTurnSignalLight.Visible = True
        pbxLeftTurnSignalLight.Visible = False
        pbxTurnSignalStock.Visible = False
        pbxTurnSignalStockUp.Visible = True
        boolRightSignalOn = True
        boolLeftSignalOn = False
    End Sub

    Public Sub LeftTurnSignalOn()
        tmrBlinkers.Start()
        pbxLeftTurnSignalLight.Visible = True
        pbxRightTurnSignalLight.Visible = False
        pbxTurnSignalStock.Visible = False
        pbxTurnSignalStockDown.Visible = True
        boolLeftSignalOn = True
        boolRightSignalOn = False
    End Sub

    Public Sub HazardsToggle()
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

    Public Sub ForceSignalsOff()
        tmrBlinkers.Stop()
        pbxRightTurnSignalLight.Visible = False
        pbxLeftTurnSignalLight.Visible = False
        pbxTurnSignalStock.Visible = True
        pbxTurnSignalStockUp.Visible = False
        pbxTurnSignalStockDown.Visible = False
        boolLeftSignalOn = False
        boolRightSignalOn = False
    End Sub
End Class
