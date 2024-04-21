Imports System.ComponentModel
Imports CSC300_CarSim.My

Public Class Clock
    Private pbxClock As PictureBox

    ' Draw needles in order: HOURS -> MINUTES -> SECONDS to ensure seconds is on top of minutes is on top of hours
    ' Link to desmos graph if you need to rederive clock angles: https://www.desmos.com/calculator/pmi4rhpogu

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
        tmrClockUpdate.Interval = 250

        intSecondsNeedleLength = 0.3 * ((pbxClock.Width + pbxClock.Height) / 2)
        intMinutesNeedleLength = 0.2 * ((pbxClock.Width + pbxClock.Height) / 2)
        intHoursNeedleLength = 0.12 * ((pbxClock.Width + pbxClock.Height) / 2)

        intSecondsNeedleOriginX = 0.54 * ((pbxClock.Width + pbxClock.Height) / 2)
        intSecondsNeedleOriginY = 0.52 * ((pbxClock.Width + pbxClock.Height)/2)
        intSecondsNeedleEndX = intSecondsNeedleOriginX
        intSecondsNeedleEndY = intSecondsNeedleOriginY

        intMinutesNeedleOriginX = intSecondsNeedleOriginX
        intMinutesNeedleOriginY = intSecondsNeedleOriginY
        intMinutesNeedleEndX = intMinutesNeedleOriginX
        intMinutesNeedleEndY = intMinutesNeedleOriginY

        intHoursNeedleOriginX = intSecondsNeedleOriginX
        intHoursNeedleOriginY = intSecondsNeedleOriginY
        intHoursNeedleEndX = intHoursNeedleOriginX
        intHoursNeedleEndY = intHoursNeedleOriginY
    End Sub

    Private Function secondsToAngle(ByVal dblSeconds As Double) As Double
        Return 180 - (dblSeconds / 60 * 360)
    End Function

    Private Function minutesToAngle(ByVal dblMinutes As Double) As Double
        Return 180 - (dblMinutes / 60 * 360)
    End Function

    Private Function hoursToAngle(ByVal dblHours As Double) As Double
        Return 180 - ((IIf(dblHours > 12, dblHours - 12, dblHours) / 12) * 360)
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

        Dim dblCurrentSeconds As Double = DateTime.Now.Second
        Dim dblCurrentMinutes As Double = DateTime.Now.Minute + (dblCurrentSeconds / 60)
        Dim dblCurrentHours As Double = DateTime.Now.Hour + (dblCurrentMinutes / 60)


        Dim secondsEnd As (intX As Integer, intY As Integer) = getEndPoint(intSecondsNeedleOriginX, intSecondsNeedleOriginY, secondsToAngle(dblCurrentSeconds), intSecondsNeedleLength)
        intSecondsNeedleEndX = secondsEnd.intX
        intSecondsNeedleEndY = secondsEnd.intY

        Dim minutesEnd As (intX As Integer, intY As Integer) = getEndPoint(intMinutesNeedleOriginX, intMinutesNeedleOriginY, minutesToAngle(dblCurrentMinutes), intMinutesNeedleLength)
        intMinutesNeedleEndX = minutesEnd.intX
        intMinutesNeedleEndY = minutesEnd.intY

        Dim hoursEnd As (intX As Integer, intY As Integer) = getEndPoint(intHoursNeedleOriginX, intHoursNeedleOriginY, hoursToAngle(dblCurrentHours), intHoursNeedleLength)
        intHoursNeedleEndX = hoursEnd.intX
        intHoursNeedleEndY = hoursEnd.intY

        pbxClock.Refresh()
    End Sub

    Public Sub DrawNeedles(e As PaintEventArgs)
        If boolClockOn Then
            grphClock.DrawLine(New Pen(Color.White, 1), intHoursNeedleOriginX, intHoursNeedleOriginY, intHoursNeedleEndX, intHoursNeedleEndY)
            grphClock.DrawLine(New Pen(Color.Red, 1), intMinutesNeedleOriginX, intMinutesNeedleOriginY, intMinutesNeedleEndX, intMinutesNeedleEndY)
            grphClock.DrawLine(New Pen(Color.Yellow, 1), intSecondsNeedleOriginX, intSecondsNeedleOriginY, intSecondsNeedleEndX, intSecondsNeedleEndY)
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
