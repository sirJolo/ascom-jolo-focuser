Public Class ScheduleElement
    Public time As Integer
    Public state As Boolean
    Public type As String

    Public Sub New(ByVal time As Integer, ByVal state As Boolean, ByVal type As String)
        Me.time = time
        Me.state = state
        Me.type = type
    End Sub

End Class
