Public Class OptoControl
    Enum OptoModes
        Standby
        Simple
        Time
        Schedule
    End Enum
    Private Const PIN As String = "5"
    Private Const MIRROR_UP_TIME As Integer = 500
    Private Const SHUTTER_DOWN_DELAY = 200

    Private optoTimer As System.Timers.Timer
    Private updateTimer As System.Timers.Timer
    Private optostate As Boolean

    Private optoMode As OptoModes
    Private expStartTime As Date
    Private schedule As Queue(Of ScheduleElement)

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

        updateTimer = New System.Timers.Timer()
        updateTimer.Interval = 100
        updateTimer.SynchronizingObject = syncObject
        updateTimer.Enabled = False
        AddHandler updateTimer.Elapsed, AddressOf OnUpdateTimer

        optoMode = OptoModes.Standby
        schedule = New Queue(Of ScheduleElement)
    End Sub

    Private Sub runSchedule()
        updateTimer.Enabled = True
        expStartTime = Date.Now
        progressSchedule()
    End Sub

    Private Sub progressSchedule()
        If (schedule.Count > 0) Then
            Dim element As ScheduleElement = schedule.Dequeue
            optoTimer.Interval = element.time
            optoTimer.Enabled = True
            optoPin = element.state
        Else
            stopSchedule()
        End If
    End Sub

    Private Sub stopSchedule()
        optoPin = False
        optoTimer.Enabled = False
        updateTimer.Enabled = False
        schedule.Clear()
        optoMode = OptoModes.Standby
        adjustButtonState()
    End Sub

    Private Function calculateScheduleTime() As Integer
        Dim total As Integer = 0
        For Each element As ScheduleElement In schedule
            total += element.time
        Next
        Return total
    End Function

    Private Sub OnOptoTimer(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        progressSchedule()
    End Sub

    Private Sub OnUpdateTimer(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'progressSchedule()
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        If startButton.Text = "Start" Then
            startButton.Text = "Stop"
            optoMode = OptoModes.Simple
            buildScheduleForSimple()
            adjustButtonState()
            runSchedule()
        Else
            stopSchedule()
            startButton.Text = "Start"
        End If
    End Sub

    Private Sub RunButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runButton.Click
        If runButton.Text = "Start" Then
            runButton.Text = "Abort"
            optoMode = OptoModes.Time
            buildScheduleForTime()
            adjustButtonState()
            runSchedule()
        Else
            stopSchedule()
            runButton.Text = "Start"
        End If
    End Sub

    Private Sub ScheduleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scheduleButton.Click
        If scheduleButton.Text = "Start" Then
            scheduleButton.Text = "Abort"
            optoMode = OptoModes.Schedule
            buildSchedule()
            adjustButtonState()
            runSchedule()
        Else
            stopSchedule()
            scheduleButton.Text = "Start"
        End If
    End Sub

    Private Sub buildScheduleForSimple()
        schedule.Enqueue(New ScheduleElement(3600000, True))
    End Sub

    Private Sub buildScheduleForTime()
        scheduleEnqueueExposure(1000 * My.Settings.QuickRunTime, 0)
    End Sub

    Private Sub buildSchedule()
        Dim mirrorUp As Integer = 0
        If My.Settings.MirrorLock <> "off" Then
            mirrorUp = Integer.Parse(My.Settings.MirrorLock.Substring(0, 1))
        End If
        If My.Settings.SchedDelayFirst > 0 Then
            schedule.Enqueue(New ScheduleElement(1000 * My.Settings.SchedDelayFirst, False))
        End If
        If My.Settings.GroupBySlot Then
            If My.Settings.SchedNum1 > 0 And My.Settings.SchedExp1 > 0 Then
                scheduleSlotGroup(My.Settings.SchedExp1, My.Settings.SchedDel1, My.Settings.SchedNum1)
            End If
            If My.Settings.SchedNum2 > 0 And My.Settings.SchedExp2 > 0 Then
                scheduleSlotGroup(My.Settings.SchedExp2, My.Settings.SchedDel2, My.Settings.SchedNum2)
            End If
            If My.Settings.SchedNum3 > 0 And My.Settings.SchedExp3 > 0 Then
                scheduleSlotGroup(My.Settings.SchedExp3, My.Settings.SchedDel3, My.Settings.SchedNum3)
            End If
        Else
            Dim slot1count As Integer = My.Settings.SchedNum1
            Dim slot2count As Integer = My.Settings.SchedNum2
            Dim slot3count As Integer = My.Settings.SchedNum3
            Dim maxCount As Integer = Math.Max(Math.Max(slot1count, slot2count), slot3count)
            For index As Integer = 1 To maxCount
                If slot1count > 0 Then
                    scheduleEnqueueExposure(My.Settings.SchedExp1, My.Settings.SchedDel1)
                    slot1count -= 1
                End If
                If slot2count > 0 Then
                    scheduleEnqueueExposure(My.Settings.SchedExp2, My.Settings.SchedDel2)
                    slot2count -= 1
                End If
                If slot3count > 0 Then
                    scheduleEnqueueExposure(My.Settings.SchedExp3, My.Settings.SchedDel3)
                    slot1count -= 1
                End If
            Next
        End If
    End Sub

    Private Sub scheduleSlotGroup(ByVal time As Integer, ByVal delayAfter As Integer, ByVal number As Integer)
        For index As Integer = 1 To number
            scheduleEnqueueExposure(time, delayAfter)
        Next
    End Sub

    Private Sub scheduleEnqueueExposure(ByVal time As Integer, ByVal delayAfter As Integer)
        If My.Settings.MirrorLock <> "off" Then
            Dim mirrorUp As Integer = Integer.Parse(My.Settings.MirrorLock.Substring(0, 1))
            schedule.Enqueue(New ScheduleElement(MIRROR_UP_TIME, True))
            schedule.Enqueue(New ScheduleElement(1000 * mirrorUp - MIRROR_UP_TIME, False))
        End If
        schedule.Enqueue(New ScheduleElement(1000 * time, True))
        If delayAfter > 0 Then
            schedule.Enqueue(New ScheduleElement(1000 * delayAfter, False))
        Else
            schedule.Enqueue(New ScheduleElement(SHUTTER_DOWN_DELAY, False))
        End If
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
            If value Then
                statusLabel.BackColor = Drawing.Color.Pink
            Else
                statusLabel.BackColor = Drawing.Color.LimeGreen
            End If
        End Set
    End Property

End Class
