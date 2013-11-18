Imports ASCOM.JoloFocuser.Focuser

Public Class RunDialogForm

    Private posReadTimer As System.Timers.Timer
    Private tempReadTimer As System.Timers.Timer

    Public dialogFocuser As JoloFocuser.Focuser

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        posReadTimer = New System.Timers.Timer()
        posReadTimer.Interval = 3112
        posReadTimer.Enabled = True
        tempReadTimer = New System.Timers.Timer()
        tempReadTimer.Interval = 9154
        tempReadTimer.Enabled = True

        AddHandler posReadTimer.Elapsed, AddressOf OnPosRead

    End Sub


    Public Property focuser() As JoloFocuser.Focuser
        Get
            Return dialogFocuser
        End Get
        Set(ByVal value As JoloFocuser.Focuser)
            dialogFocuser = value
        End Set
    End Property


    Private Sub RunButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunButton.Click
        focuser.CommandString("RUN:")
    End Sub


    Private Sub MoveFocuserButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveFocuserButton.Click
        focuser.Move(PositionNumericUpDown.Value)
    End Sub

    Private Sub MoveInButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveInButton.Click
        focuser.Move(focuser.Position - MoveFocuserNumericUpDown.Value)
    End Sub

    Private Sub MoveOutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveOutButton.Click
        focuser.Move(focuser.Position + MoveFocuserNumericUpDown.Value)
    End Sub


    Private Sub OnPosRead(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim position As Integer = focuser.Position
        PositionLabel.Text = position
    End Sub

    Private Sub OnTempRead(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim temp As Double = focuser.Temperature
        TemperatureLabel.Text = temp.ToString("F2") + " C"
    End Sub
End Class