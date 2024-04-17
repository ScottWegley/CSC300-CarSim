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

    Private Function secondsToAngle(ByVal intSeconds) As Double
        Return intSeconds / 60 * 360
    End Function

    Private Function minutesToAngle(ByVal intMinutes) As Double
        Return intMinutes / 60 * 360
    End Function

    Private Function hoursToAngle(ByVal intHours) As Double
        Return (intHours Mod 12) / 12 * 360
    End Function

    ' Function to calculate the X and Y of a point where the needle ends
    Private Function getEndPoint(ByVal intXOrigin As Integer, ByVal intYOrigin As Integer, ByVal dblAngle As Double, ByVal intNeedleLength As Integer) As (intEndX As Integer, intEndY As Integer)
        Dim intEndX As Integer = intXOrigin + intNeedleLength * Math.Cos(Math.PI * 2 * ((dblAngle - 90) / (360)))
        Dim intEndY As Integer = intYOrigin + -intNeedleLength * Math.Sin(Math.PI * 2 * ((dblAngle - 90) / (360)))
        Return (intEndX, intEndY)
    End Function
End Class
