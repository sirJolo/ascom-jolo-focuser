Public Class MonitorForm
    Private JOLOfocuser As Focuser
    Private monitorTimer As System.Timers.Timer

    Delegate Sub SetPositionStepsCallback(ByVal positionSteps As String)
    Delegate Sub SetPositionMMCallback(ByVal positionSteps As String)

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        monitorTimer = New System.Timers.Timer()
        monitorTimer.Interval = 500
        monitorTimer.Enabled = False
        AddHandler monitorTimer.Elapsed, AddressOf OnMonitorTimer
    End Sub


    Private Sub OnMonitorTimer(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim answer As String = JOLOfocuser.CommandString("P")
        Dim values() As String = Split(answer, ":")
        Dim position As Integer = Integer.Parse(values(1))
        SetPositionSteps(position.ToString)

        Dim positionMM As Double = position / 1000 * My.Settings.StepSize
        SetPositionMM(Math.Round(positionMM, 3))
    End Sub


    Private Sub SetPositionSteps(ByVal position As String)
        If Me.PositionSteps.InvokeRequired Then
            Dim d As New SetPositionStepsCallback(AddressOf SetPositionSteps)
            Me.Invoke(d, New Object() {position})
        Else
            Me.PositionSteps.Text = position
        End If
    End Sub

    Private Sub SetPositionMM(ByVal position As String)
        If Me.PositionMM.InvokeRequired Then
            Dim d As New SetPositionMMCallback(AddressOf SetPositionMM)
            Me.Invoke(d, New Object() {position})
        Else
            Me.PositionMM.Text = position
        End If
    End Sub

    Public Property running() As Boolean
        Get
            Return monitorTimer.Enabled
        End Get
        Set(ByVal value As Boolean)
            monitorTimer.Enabled = value
        End Set
    End Property


    Public WriteOnly Property focuser() As Focuser
        Set(ByVal value As Focuser)
            JOLOfocuser = value
        End Set
    End Property


End Class