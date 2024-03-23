Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Car

#Region "Subsystems"
    Private blinkers As Blinkers
    Private lights As Lights
    Private rpmSystem As RPMSystem
#End Region

    Public Function isOn()
        Return rpmSystem.isOn()
    End Function

    Public Sub New(ByRef lblMPH_IN As Label, ByRef lblGear_IN As Label, ByRef TextBox2_IN As System.Windows.Forms.TextBox, ByRef TextBox3_IN As System.Windows.Forms.TextBox, ByRef TextBox4_IN As System.Windows.Forms.TextBox, ByRef SpeedGauge As PictureBox, ByRef RPMGauge As PictureBox, ByRef ParkingBrakeLight As PictureBox, ByRef DriveIndicator As Label, ByRef RightBlinker As PictureBox, ByRef LeftBlinker As PictureBox, ByRef TurnStockDefault As PictureBox, ByRef TurnStockDown As PictureBox, ByRef TurnStockUp As PictureBox, ByRef LowBeams As PictureBox, ByRef HighBeams As PictureBox, ByRef FogLights As PictureBox)

        lights = New Lights(LowBeams, HighBeams, FogLights)
        blinkers = New Blinkers(RightBlinker, LeftBlinker, TurnStockDefault, TurnStockUp, TurnStockDown)
        rpmSystem = New RPMSystem(lblMPH_IN, lblGear_IN, TextBox2_IN, TextBox3_IN, TextBox4_IN, SpeedGauge, RPMGauge, ParkingBrakeLight, DriveIndicator)
    End Sub

    Public Function getBlinkers() As Blinkers
        Return blinkers
    End Function

    Public Function getLights() As Lights
        Return lights
    End Function

    Public Function getRPMSystem() As RPMSystem
        Return rpmSystem
    End Function
End Class
