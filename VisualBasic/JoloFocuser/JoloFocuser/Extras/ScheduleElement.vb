Public Class ScheduleElement
    Public time As Integer
    Public state As Boolean

    Public Sub New(ByVal time As Integer, ByVal state As Boolean)
        Me.time = time
        Me.state = state
    End Sub

End Class
