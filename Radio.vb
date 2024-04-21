Public Class Radio
    Private boolRadioOn As Boolean = False

    Private Enum Media
        FashionPop
        GroovyFunk
        Jazz
        Movement
        Smoke
        TrapFutureBass
    End Enum

    Public Sub New()

    End Sub

    Public Sub toggleBooleanOn()
        boolRadioOn = Not boolRadioOn
    End Sub

    Public Sub PlayMediaOne()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.fashion_pop, AudioPlayMode.Background)
    End Sub

    Public Sub PlayMediaTwo()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.groovy_funk, AudioPlayMode.Background)
    End Sub

    Public Sub PlayMediaThree()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.jazz, AudioPlayMode.Background)
    End Sub

    Public Sub PlayMediaFour()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.movement, AudioPlayMode.Background)
    End Sub

    Public Sub PlayMediaFive()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.smoke, AudioPlayMode.Background)
    End Sub

    Public Sub PlayMediaSix()
        My.Computer.Audio.Stop()
        My.Computer.Audio.Play(My.Resources.trap_future_bass, AudioPlayMode.Background)
    End Sub
End Class
