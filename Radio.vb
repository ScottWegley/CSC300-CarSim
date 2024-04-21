Public Class Radio
    Private boolRadioOn As Boolean = False

    Public Sub New()

    End Sub

    Public Sub toggleBooleanOn()
        boolRadioOn = Not boolRadioOn
    End Sub

    Public Sub PlayMediaOne()
        My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
    End Sub

    Public Sub PlayMediaTwo()

    End Sub

    Public Sub PlayMediaThree()

    End Sub

    Public Sub PlayMediaFour()

    End Sub

    Public Sub PlayMediaFive()

    End Sub

    Public Sub PlayMediaSix()

    End Sub
End Class
