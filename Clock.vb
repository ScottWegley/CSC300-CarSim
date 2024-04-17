Imports System.ComponentModel
Imports CSC300_CarSim.My

Public Class Clock
    Private pbxClock As PictureBox

    ' Draw needles in order: HOURS -> MINUTES -> SECONDS to ensure seconds is on top of minutes is on top of hours

#Region "Needle Coordinate Variables"
    Private intSecondsNeedleLength As Integer
    Private intMinutesNeedleLength As Integer
    Private intHoursNeedleLength As Integer

    Private intSecondsNeedleOriginX As Integer
    Private intSecondsNeedleOriginY As Integer
    Private intMinutesNeedleOriginX As Integer
    Private intMinutesNeedleOriginY As Integer
    Private intHoursNeedleOriginX As Integer
    Private intHoursNeedleOriginY As Integer

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

        intSecondsNeedleLength = 0.4 * Math.Max(pbxClock.Width, pbxClock.Height)
        intMinutesNeedleLength = 0.3 * Math.Max(pbxClock.Width, pbxClock.Height)
        intHoursNeedleLength = 0.2 * Math.Max(pbxClock.Width, pbxClock.Height)

        intSecondsNeedleOriginX = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intSecondsNeedleOriginY = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intSecondsNeedleEndX = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intSecondsNeedleEndY = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)

        intMinutesNeedleOriginX = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intMinutesNeedleOriginY = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intMinutesNeedleEndX = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intMinutesNeedleEndY = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)

        intHoursNeedleOriginX = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intHoursNeedleOriginY = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intHoursNeedleEndX = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
        intHoursNeedleEndY = 0.45 * Math.Max(pbxClock.Width, pbxClock.Height)
    End Sub

    Private Function secondsToAngle(ByVal intSeconds As Integer) As Double
        Return 360 - (intSeconds / 60 * 360)
    End Function

    Private Function minutesToAngle(ByVal intMinutes As Integer) As Double
        Return 360 - (intMinutes / 60 * 360)
    End Function

    Private Function hoursToAngle(ByVal intHours As Integer) As Double
        Return 360 - ((intHours Mod 12) / 12 * 360)
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

        Dim secondsEnd As (intX As Integer, intY As Integer) = getEndPoint(intSecondsNeedleOriginX, intSecondsNeedleOriginY, secondsToAngle(intCurrentSeconds), intSecondsNeedleLength)
        intSecondsNeedleEndX = secondsEnd.intX
        intSecondsNeedleEndY = secondsEnd.intY

        Dim minutesEnd As (intX As Integer, intY As Integer) = getEndPoint(intMinutesNeedleOriginX, intMinutesNeedleOriginY, minutesToAngle(intCurrentMinutes), intMinutesNeedleLength)
        intMinutesNeedleEndX = minutesEnd.intX
        intMinutesNeedleEndY = minutesEnd.intY

        Dim hoursEnd As (intX As Integer, intY As Integer) = getEndPoint(intHoursNeedleOriginX, hoursNeedleOriginY, hoursToAngle(intCurrentHours), intHoursNeedleLength)
        intHoursNeedleEndX = hoursEnd.intX
        intHoursNeedleEndY = hoursEnd.intY

        pbxClock.Refresh()
    End Sub

    Public Sub DrawNeedles(e As PaintEventArgs)
        If boolClockOn Then
            grphClock.DrawLine(New Pen(Color.Green, 1), intSecondsNeedleOriginX, intSecondsNeedleOriginY, intSecondsNeedleEndX, intSecondsNeedleEndY)
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
