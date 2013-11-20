Imports ASCOM.JoloFocuser.Focuser

Public Class RunDialogForm

    Private Const FOCUSER_POS_TIME As Single = 3127
    Private Const TEMP_READ_TIME As Single = 9154

    Private posReadTimer As System.Timers.Timer
    Private tempReadTimer As System.Timers.Timer

    Private d7Select As Extrasable

    Private dialogFocuser As JoloFocuser.Focuser

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        initializeFocuserTimers()

        AddHandler posReadTimer.Elapsed, AddressOf OnPosRead
    End Sub

    Private Sub initializeFocuserTimers()
        posReadTimer = New System.Timers.Timer()
        posReadTimer.Interval = FOCUSER_POS_TIME
        posReadTimer.Enabled = True
        tempReadTimer = New System.Timers.Timer()
        tempReadTimer.Interval = TEMP_READ_TIME
        tempReadTimer.Enabled = True
    End Sub

    Private Sub RunDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        D7ModeComboBox.Text = My.Settings.D7type.Split(":")(0)
        d7Select.config = My.Settings.D7type
        D7SaveButton.Enabled = False
    End Sub

    Public Property focuser() As JoloFocuser.Focuser
        Get
            Return dialogFocuser
        End Get
        Set(ByVal value As JoloFocuser.Focuser)
            dialogFocuser = value
        End Set
    End Property


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
        If Not focuser.Connected Then
            Return
        End If
        Dim position As Integer = focuser.Position
        PositionLabel.Text = position
    End Sub

    Private Sub OnTempRead(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        If Not focuser.Connected Then
            Return
        End If
        Dim temp As Double = focuser.Temperature
        TemperatureLabel.Text = temp.ToString("F2") + " C"
    End Sub



    Private Sub D7SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D7SaveButton.Click
        My.Settings.D7type = Me.d7Select.config
        My.Settings.Save()
        D7SaveButton.Enabled = False
    End Sub

    Private Sub D7ModeComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles D7ModeComboBox.TextChanged
        Dim combo As ComboBox = DirectCast(sender, ComboBox)
        If Not (Me.d7Select Is Nothing) Then
            Me.d7Select.clearPanel(D7GroupBox)
        End If
        Me.d7Select = getExtrasable(combo.Text)
        d7Select.initialize(D7GroupBox, D7StatusLabel, dialogFocuser, 7, "D7", True, D7SaveButton)
        D7SaveButton.Enabled = True
    End Sub


    Private Function getExtrasable(ByVal name As String) As Extrasable
        If name = "digital output" Then
            Return New SimpleDigital
        ElseIf name = "analog input" Then
            Return New SimpleAnalogInput
        End If
        Return New SimpleDigitalInput
    End Function

End Class