Imports System.ComponentModel
Imports CSC300_CarSim.My

Public Class Clock
    Private pbxClock As PictureBox

    ' Draw needles in order: HOURS -> MINUTES -> SECONDS to ensure seconds is on top of minutes is on top of hours

#Region "Needle Coordinate Variables"
    Const SECONDS_NEEDLE_LENGTH As Integer = 25
    Const MINUTES_NEEDLE_LENGTH As Integer = 20
    Const HOURS_NEEDLE_LENGTH As Integer = 15

    Const SECONDS_NEEDLE_ORIGIN_X As Integer = 37
    Const SECONDS_NEEDLE_ORIGIN_Y As Integer = 40
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

#Region "Gauge Drawing Variables"
    Dim bmpClock As New Bitmap(1024, 1024)
    Dim grphClock As Graphics = Graphics.FromImage(bmpClock)
#End Region

    Private boolClockOn As Boolean = False

    Private WithEvents tmrClockUpdate As Timer = New Timer()

    Public Sub New(ByRef Clock As PictureBox)
        pbxClock = Clock
        tmrClockUpdate.Interval = 1000
    End Sub

    Private Function secondsToAngle(ByVal intSeconds As Integer) As Double
        Return 360 - intSeconds / 60 * 360
    End Function

    Private Function minutesToAngle(ByVal intMinutes As Integer) As Double
        Return 360 - intMinutes / 60 * 360
    End Function

    Private Function hoursToAngle(ByVal intHours As Integer) As Double
        Return 360 - (intHours Mod 12) / 12 * 360
    End Function

    ' Function to calculate the X and Y of a point where the needle ends
    Private Function getEndPoint(ByVal intXOrigin As Integer, ByVal intYOrigin As Integer, ByVal dblAngle As Double, ByVal intNeedleLength As Integer) As (intEndX As Integer, intEndY As Integer)
        Dim intEndX As Integer = intXOrigin + intNeedleLength * Math.Cos(Math.PI * 2 * ((dblAngle - 90) / (360)))
        Dim intEndY As Integer = intYOrigin + -intNeedleLength * Math.Sin(Math.PI * 2 * ((dblAngle - 90) / (360)))
        Return (intEndX, intEndY)
    End Function

    Public Sub tmrClockUpdate_Tick(sender As Object, e As EventArgs) Handles tmrClockUpdate.Tick
        grphClock.Dispose()
        bmpClock.Dispose()

        bmpClock = New Bitmap(1024, 1024)
        grphClock = Graphics.FromImage(bmpClock)

        Dim intCurrentSeconds As Integer = DateTime.Now.Second
        Dim intCurrentMinutes As Integer = DateTime.Now.Minute
        Dim intCurrentHours As Integer = DateTime.Now.Hour

        Dim secondsEnd As (intX As Integer, intY As Integer) = getEndPoint(SECONDS_NEEDLE_ORIGIN_X, SECONDS_NEEDLE_ORIGIN_Y, secondsToAngle(intCurrentSeconds), SECONDS_NEEDLE_LENGTH)
        intSecondsNeedleEndX = secondsEnd.intX
        intSecondsNeedleEndY = secondsEnd.intY

        Dim minutesEnd As (intX As Integer, intY As Integer) = getEndPoint(MINUTES_NEEDLE_ORIGIN_X, MINUTES_NEEDLE_ORIGIN_Y, minutesToAngle(intCurrentMinutes), MINUTES_NEEDLE_LENGTH)
        intMinutesNeedleEndX = minutesEnd.intX
        intMinutesNeedleEndY = minutesEnd.intY

        Dim hoursEnd As (intX As Integer, intY As Integer) = getEndPoint(HOURS_NEEDLE_ORIGIN_X, HOURS_NEEDLE_ORIGIN_Y, hoursToAngle(intCurrentHours), HOURS_NEEDLE_LENGTH)
        intHoursNeedleEndX = hoursEnd.intX
        intHoursNeedleEndY = hoursEnd.intY

        pbxClock.Refresh()
    End Sub

    Public Sub DrawNeedles(e As PaintEventArgs)
        If boolClockOn Then
            grphClock.DrawLine(New Pen(Color.Green, 1), SECONDS_NEEDLE_ORIGIN_X, SECONDS_NEEDLE_ORIGIN_Y, intSecondsNeedleEndX, intSecondsNeedleEndY)
            e.Graphics.DrawImage(bmpClock, 0, 0)
        End If
    End Sub

    Public Sub startClock()
        tmrClockUpdate.Start()
    End Sub

    Public Sub stopClock()
        tmrClockUpdate.Stop()
    End Sub

    Public Sub ToggleClock()
        If boolClockOn Then
            stopClock()
        Else startClock()
        End If
        boolClockOn = Not boolClockOn
    End Sub
End Class
