Public Class MonitorForm
    Private JOLOfocuser As Focuser
    Private monitorTimer As System.Timers.Timer
    Private isMoving As Boolean = False
    Private logCounter As Short = 0

    Delegate Sub SetPositionStepsCallback(ByVal positionSteps As String)
    Delegate Sub SetPositionMMCallback(ByVal positionSteps As String)
    Delegate Sub SetTemperatureCallback(ByVal temp As String)
    Delegate Sub SetHumidityCallback(ByVal hum As String)
    Delegate Sub SetDewpointCallback(ByVal dewpoint As String)
    Delegate Sub SetPWM1Callback(ByVal PWM As String)
    Delegate Sub SetPWM2Callback(ByVal PWM As String)
    Delegate Sub SetPWM3Callback(ByVal PWM As String)
    Delegate Sub SetADCCallback(ByVal PWM As String)

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
        If JOLOfocuser Is Nothing Then Return
        Dim answer As String = JOLOfocuser.CommandString("q")
        Dim values() As String = Split(answer, ":")

        Dim position As Integer = Integer.Parse(values(1))
        SetPositionSteps(position.ToString)
        Dim positionMM As Double = position / 1000 * My.Settings.StepSize
        SetPositionMM(FormatNumber(positionMM, 3))

        isMoving = (Integer.Parse(values(2)) <> 0)

        Dim temp As Double = Double.Parse(values(3), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
        SetTemperature(FormatNumber(temp, 1))

        SetHumidity(values(4))

        Dim dewpoint As Double = Double.Parse(values(5), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
        SetDewpoint(FormatNumber(dewpoint, 1))

        SetPWM1(values(6))
        SetPWM2(values(7))
        SetPWM3(values(8))

        If My.Settings.ADC_Read Then
            SetADC(values(9))
        Else
            SetADC("0")
        End If

        logCounter += 1
        If (logCounter > 19) Then
            If SaveLogCheckBox.Checked Then logInfo(answer)
            logCounter = 1
        End If
    End Sub


    Public Sub logLine(ByVal logs As String)
        Dim fileName As String = Date.Now.ToShortDateString & ".txt"
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\JOLOFocuser"
        Dim folderExists As Boolean = My.Computer.FileSystem.DirectoryExists(path)
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory(path)
        End If

        Dim file As String = System.IO.Path.Combine(path, fileName)
        Dim fileExists As Boolean = My.Computer.FileSystem.FileExists(file)
        If fileExists = False Then
            My.Computer.FileSystem.WriteAllText(file, "Time;position;temperature;humidity;dewpoint;pwm6;pwm9;pwm10;adc" & vbCrLf, False)
        End If
        Dim line As String = Date.Now & ";" & logs & vbCrLf
        My.Computer.FileSystem.WriteAllText(file, line, True)
    End Sub

    Private Sub logInfo(ByVal logs As String)
        Dim values() As String = Split(logs, ":")
        Dim vt As String = values(1) & ";" & values(3) & ";" & values(4) & ";" & values(5) & ";" & values(6) & ";" & values(7) & ";" & values(8) & ";" & values(9)
        logLine(vt)
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

    Private Sub SetPWM1(ByVal pwm As String)
        If Me.PWM1.InvokeRequired Then
            Dim d As New SetPWM1Callback(AddressOf SetPWM1)
            Me.Invoke(d, New Object() {pwm})
        Else
            Me.PWM1.Text = pwm
        End If
    End Sub


    Private Sub SetPWM2(ByVal pwm As String)
        If Me.PWM2.InvokeRequired Then
            Dim d As New SetPWM2Callback(AddressOf SetPWM2)
            Me.Invoke(d, New Object() {pwm})
        Else
            Me.PWM2.Text = pwm
        End If
    End Sub

    Private Sub SetPWM3(ByVal pwm As String)
        If Me.PWM3.InvokeRequired Then
            Dim d As New SetPWM3Callback(AddressOf SetPWM3)
            Me.Invoke(d, New Object() {pwm})
        Else
            Me.PWM3.Text = pwm
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button8.Click
        If JOLOfocuser Is Nothing Then Return
        If isMoving Then Return
        Dim position As Integer = JOLOfocuser.Position
        position = position - RelPosUpDown.Value
        JOLOfocuser.Move(position)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button7.Click
        If JOLOfocuser Is Nothing Then Return
        If isMoving Then Return
        Dim position As Integer = JOLOfocuser.Position
        position = position + RelPosUpDown.Value
        JOLOfocuser.Move(position)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click, Button6.Click
        If isMoving Then Return
        JOLOfocuser.Move(AbsPosNumericUpDown.Value)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using F As ADCSetupForm = New ADCSetupForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                My.Settings.Save()
            End If
        End Using
    End Sub

    Private Sub ADC_CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.Save()
        ADCLabel.Enabled = ADC_CheckBox.Checked
    End Sub


    Private Sub PWM_1_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.Save()
        Dim pwm As String = PWM_1_ComboBox.Text
        If pwm = "AUTO" Then pwm = "255"
        If Not JOLOfocuser Is Nothing Then JOLOfocuser.CommandString("B:1:" + pwm)
    End Sub

    Private Sub PWM_2_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.Save()
        Dim pwm As String = PWM_2_ComboBox.Text
        If pwm = "AUTO" Then pwm = "255"
        If Not JOLOfocuser Is Nothing Then JOLOfocuser.CommandString("B:2:" + pwm)
    End Sub

    Private Sub PWM_3_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.Save()
        Dim pwm As String = PWM_3_ComboBox.Text
        If pwm = "AUTO" Then pwm = "255"
        If Not JOLOfocuser Is Nothing Then JOLOfocuser.CommandString("B:3:" + pwm)
    End Sub

    Private Sub StopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopButton.Click, Stop2Button.Click
        If Not JOLOfocuser Is Nothing Then JOLOfocuser.Halt()
    End Sub

End Class
