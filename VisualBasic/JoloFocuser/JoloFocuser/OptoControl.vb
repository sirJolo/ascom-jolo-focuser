Public Class OptoControl
    Enum OptoActions
        MirrorUp
        MirrorDown
        OptoOn
        OptoOff
        Standby
    End Enum

    Enum OptoModes
        Standby
        Simple
        Time
        Schedule
    End Enum
    Private Const PIN As String = "5"

    Private optoTimer As System.Timers.Timer
    Private optostate As Boolean

    Private optoAction As OptoActions
    Private optoMode As OptoModes
    Private optoNextActionTime As Date
    Private expStartTime As Date

    Private focuser As JoloFocuser.Focuser
    Private WithEvents startButton As Button
    Private WithEvents runButton As Button
    Private WithEvents scheduleButton As Button
    Private statusProgress As ProgressBar
    Private statusLabel As Label


    Public Sub New(ByRef focuser As JoloFocuser.Focuser, ByRef syncObject As Control, ByRef startButton As Button, ByRef runButton As Button, ByRef scheduleButton As Button, ByRef statusProgress As ProgressBar, ByRef statusLabel As Label)
        Me.startButton = startButton
        Me.runButton = runButton
        Me.scheduleButton = scheduleButton
        Me.statusLabel = statusLabel
        Me.statusProgress = statusProgress

        optoTimer = New System.Timers.Timer()
        optoTimer.Interval = 1000
        optoTimer.SynchronizingObject = syncObject
        optoTimer.Enabled = False
        AddHandler optoTimer.Elapsed, AddressOf OnOptoTimer

        optoMode = OptoModes.Standby
        optoAction = OptoActions.Standby
    End Sub


    Private Sub OnOptoTimer(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        If optoAction = OptoActions.OptoOn Then
            Dim elapsed As Integer = Date.Now.Subtract(expStartTime).Ticks / TimeSpan.TicksPerSecond
            Dim period As Integer = optoNextActionTime.Subtract(expStartTime).Ticks / TimeSpan.TicksPerSecond
            If optoMode = OptoModes.Simple Then
                statusLabel.Text = elapsed.ToString + " sec"
            End If
            If optoMode = OptoModes.Time Then
                statusLabel.Text = elapsed.ToString + " of " + period.ToString + " sec"
                statusProgress.Value = 100 * (elapsed / period)
            End If
            If Date.Now.CompareTo(optoNextActionTime) > 0 Then
                optoTimer.Enabled = False
                optoPin = False
                optoAction = OptoActions.Standby
                If optoMode = OptoModes.Schedule Then
                    'progressSchedule()
                Else
                    optoMode = OptoModes.Standby
                    adjustButtonState()
                    statusLabel.Text = "Stop"
                    runButton.Text = "Run"
                    statusProgress.Value = 0
                End If
            End If
        End If
    End Sub


    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        optoMode = OptoModes.Simple
        adjustButtonState()
        If startButton.Text = "Start" Then
            If optoPin = True Then
                MsgBox("OPTO is already ON!", MsgBoxStyle.OkOnly, "Error")
            Else
                startButton.Text = "Stop"
                exposure(3600)
            End If
        Else
            If optoPin = False Then
                MsgBox("OPTO is already OFF!", MsgBoxStyle.OkOnly, "Error")
            Else
                startButton.Text = "Start"
                exposure(0) 'abort
                optoMode = OptoModes.Standby
                adjustButtonState()
            End If
        End If
    End Sub

    Private Sub RunButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runButton.Click
        optoMode = OptoModes.Time
        adjustButtonState()
        If runButton.Text = "Run" Then
            If optoPin = True Then
                MsgBox("OPTO is already ON!", MsgBoxStyle.OkOnly, "Error")
            Else
                runButton.Text = "Abort"
                exposure(My.Settings.QuickRunTime)
            End If
        Else
            If optoPin = False Then
                MsgBox("OPTO is already OFF!", MsgBoxStyle.OkOnly, "Error")
            Else
                runButton.Text = "Run"
                exposure(0) 'abort
                optoMode = OptoModes.Standby
                adjustButtonState()
            End If
        End If
    End Sub

    Private Sub ScheduleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scheduleButton.Click

    End Sub

    Private Sub exposure(ByVal time As Integer)
        If time = 0 Then
            optoNextActionTime = Date.Now.AddSeconds(-1)
        Else
            If optoAction = OptoActions.Standby Then
                If My.Settings.MirrorLock = "off" Then
                    exp(time)
                End If
            End If
        End If
    End Sub

    Private Sub mirrorLock()

    End Sub

    Private Sub exp(ByVal time As Integer)
        optoAction = OptoActions.OptoOn
        optoNextActionTime = Date.Now.AddSeconds(time)
        expStartTime = Date.Now
        optoTimer.Interval = 200
        optoTimer.Enabled = True
        optoPin = True
    End Sub

    Private Sub adjustButtonState()
        startButton.Enabled = False
        runButton.Enabled = False
        scheduleButton.Enabled = False
        If optoMode = OptoModes.Simple Then
            startButton.Enabled = True
        End If
        If optoMode = OptoModes.Time Then
            runButton.Enabled = True
        End If
        If optoMode = OptoModes.Schedule Then
            scheduleButton.Enabled = True
        End If
        If optoMode = OptoModes.Standby Then
            startButton.Enabled = True
            runButton.Enabled = True
            scheduleButton.Enabled = True
        End If
    End Sub

    Private Property optoPin() As Boolean
        Get
            'Dim result As String = focuser.CommandString("VRE:" + PIN)
            'Return (result = "1")
            Return optostate
        End Get
        Set(ByVal value As Boolean)
            If value Then
                'focuser.CommandString("VSE:" + PIN + ",1")
            Else
                'focuser.CommandString("VSE:" + PIN + ",0")
            End If
            optostate = value
        End Set
    End Property

End Class
