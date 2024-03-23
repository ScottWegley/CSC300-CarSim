Public Class Lights

    Private pbxLowBeamIndicator As PictureBox
    Private pbxHighBeamIndicator As PictureBox
    Private pbxFogLightIndicator As PictureBox

    Dim boolLowBeam As Boolean = False
    Dim boolHighBeam As Boolean = False
    Dim boolFogLights As Boolean = False

    Public Sub New(ByRef LowBeamLight As PictureBox, ByRef HighBeamLight As PictureBox, ByRef FogLight As PictureBox)
        pbxLowBeamIndicator = LowBeamLight
        pbxHighBeamIndicator = HighBeamLight
        pbxFogLightIndicator = FogLight
    End Sub

    Public Sub allLightsOff()
        pbxLowBeamIndicator.Visible = False
        pbxHighBeamIndicator.Visible = False
        pbxFogLightIndicator.Visible = False
        boolFogLights = False
        boolLowBeam = False
        boolHighBeam = False
    End Sub

    Public Sub lowBeamToggle()
        boolLowBeam = Not boolLowBeam
        pbxLowBeamIndicator.Visible = boolLowBeam
    End Sub

    Public Sub highBeamToggle()
        boolHighBeam = Not boolHighBeam
        pbxHighBeamIndicator.Visible = boolHighBeam
    End Sub

    Public Sub fogLightToggle()
        boolFogLights = Not boolFogLights
        pbxFogLightIndicator.Visible = boolFogLights
    End Sub
End Class
