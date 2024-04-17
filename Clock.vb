Public Class Clock
    Private pbxClock As PictureBox

    ' Draw needles in order: HOURS -> MINUTES -> SECONDS to ensure seconds is on top of minutes is on top of hours

#Region "Needle Coordinate Variables"
    Const SECONDS_NEEDLE_LENGTH As Integer = 25
    Const MINUTES_NEEDLE_LENGTH As Integer = 20
    Const HOURS_NEEDLE_LENGTH As Integer = 15

    Const SECONDS_NEEDLE_ORIGIN_X As Integer = 0
    Const SECONDS_NEEDLE_ORIGIN_Y As Integer = 0
    Const MINUTES_NEEDLE_ORIGIN_X As Integer = 0
    Const MINUTES_NEEDLE_ORIGIN_Y As Integer = 0
    Const HOURS_NEEDLE_ORIGIN_X As Integer = 0
    Const HOURS_NEEDLE_ORIGIN_Y As Integer = 0

    Private intSecondsNeedleEndX As Integer
    Private intSecondsNeedleEndY As Integer
    Private intMinutesNeedleEndX As Integer
    Private intMinutesNeedleEndY As Integer
    Private intHoursNeedleEndX As Integer
    Private intHoursNeedleEndY As Integer
#End Region

    Public Sub New(ByRef Clock As PictureBox)
        pbxClock = Clock
    End Sub
End Class
