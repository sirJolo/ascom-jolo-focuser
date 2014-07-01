Public Class MonitorForm
    Private JOLOfocuser As Focuser
    Private monitorTimer As System.Timers.Timer
    Private monitorTimerSkipper As Long

    Private Const MONITOR_TIMER_SKIP As Integer = 6

    Delegate Sub SetPositionStepsCallback(ByVal positionSteps As String)
    Delegate Sub SetPositionMMCallback(ByVal positionSteps As String)
    Delegate Sub SetTemperatureCallback(ByVal temp As String)
    Delegate Sub SetHumidityCallback(ByVal hum As String)
    Delegate Sub SetDewpointCallback(ByVal dewpoint As String)
    Delegate Sub SetPWM6Callback(ByVal PWM As String)
    Delegate Sub SetPWM9Callback(ByVal PWM As String)
    Delegate Sub SetPWM10Callback(ByVal PWM As String)
    Delegate Sub SetADCCallback(ByVal PWM As String)
    Delegate Sub SetOPTOCallback(ByVal opto As String)

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        monitorTimer = New System.Timers.Timer()
        monitorTimer.Interval = 500
        monitorTimer.Enabled = False
        AddHandler monitorTimer.Elapsed, AddressOf OnMonitorTimer
        monitorTimerSkipper = 0
    End Sub


    Private Sub OnMonitorTimer(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        Dim answer As String = JOLOfocuser.CommandString("P")
        Dim values() As String = Split(answer, ":")
        Dim position As Integer = Integer.Parse(values(1))

        SetPositionSteps(position.ToString)
        Dim positionMM As Double = position / 1000 * My.Settings.StepSize
        SetPositionMM(FormatNumber(positionMM, 3))

        If ((monitorTimerSkipper Mod 6) = 0) Then
            answer = JOLOfocuser.CommandString("V") 'temp:hum:dewpoint
            values = Split(answer, ":")

            SetHumidity(values(2))

            Dim temp As Double = Double.Parse(values(1), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            SetTemperature(FormatNumber(temp, 1))

            Dim dewpoint As Double = Double.Parse(values(3), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            SetDewpoint(FormatNumber(dewpoint, 1))

            answer = JOLOfocuser.CommandString("Z") 'opto:adc:pwm6:pwm9:pwm10
            values = Split(answer, ":")
        End If

        monitorTimerSkipper = monitorTimerSkipper + 1
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

    Private Sub SetTemperature(ByVal temp As String)
        If Me.Temperature.InvokeRequired Then
            Dim d As New SetTemperatureCallback(AddressOf SetTemperature)
            Me.Invoke(d, New Object() {temp})
        Else
            Me.Temperature.Text = temp
        End If
    End Sub

    Private Sub SetHumidity(ByVal hum As String)
        If Me.Humidity.InvokeRequired Then
            Dim d As New SetHumidityCallback(AddressOf SetHumidity)
            Me.Invoke(d, New Object() {hum})
        Else
            Me.Humidity.Text = hum
        End If
    End Sub

    Private Sub SetDewpoint(ByVal dp As String)
        If Me.DewPoint.InvokeRequired Then
            Dim d As New SetDewpointCallback(AddressOf SetDewpoint)
            Me.Invoke(d, New Object() {dp})
        Else
            Me.DewPoint.Text = dp
        End If
    End Sub

    Private Sub SetPWM6(ByVal pwm As String)
        If Me.PWM6.InvokeRequired Then
            Dim d As New SetPWM6Callback(AddressOf SetPWM6)
            Me.Invoke(d, New Object() {pwm})
        Else
            Me.PWM6.Text = pwm
        End If
    End Sub

    Private Sub SetPWM9(ByVal pwm As String)
        If Me.PWM9.InvokeRequired Then
            Dim d As New SetPWM9Callback(AddressOf SetPWM9)
            Me.Invoke(d, New Object() {pwm})
        Else
            Me.PWM9.Text = pwm
        End If
    End Sub

    Private Sub SetPWM10(ByVal pwm As String)
        If Me.PWM10.InvokeRequired Then
            Dim d As New SetPWM10Callback(AddressOf SetPWM10)
            Me.Invoke(d, New Object() {pwm})
        Else
            Me.PWM10.Text = pwm
        End If
    End Sub

    Private Sub SetADC(ByVal adc As String)
        If Me.ADCLabel.InvokeRequired Then
            Dim d As New SetADCCallback(AddressOf SetADC)
            Me.Invoke(d, New Object() {adc})
        Else
            Me.ADCLabel.Text = calculateADCvalue(adc)
        End If
    End Sub

    Private Sub SetOPTO(ByVal opto As String)
        If Me.OPTOLabel.InvokeRequired Then
            Dim d As New SetOPTOCallback(AddressOf SetOPTO)
            Me.Invoke(d, New Object() {opto})
        Else
            Me.OPTOLabel.Text = opto
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


    Function calculateADCvalue(ByVal adcRaw As String) As String
        Dim adc As String = ""
        Dim rescaled As Double = Integer.Parse(adcRaw) * Double.Parse(My.Settings.ADC_A, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) + Double.Parse(My.Settings.ADC_B, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
        adc = adc + FormatNumber(rescaled, 2) + My.Settings.ADC_suffix
        Return adc
    End Function
End Class