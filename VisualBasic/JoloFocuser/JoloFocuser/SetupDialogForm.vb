Imports System.Windows.Forms
Imports System.Runtime.InteropServices

<ComVisible(False)> _
Public Class SetupDialogForm
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.StepSize = StepSizeUpDown.Value
        My.Settings.StepsPerC = TempCompensation.Value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        My.Settings.Save()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowAscomWebPage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick, PictureBox1.Click
        Try
            System.Diagnostics.Process.Start("http://ascom-standards.org/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SerialPort1.BaudRate = 9600
        SerialPort1.PortName = COM1.Text
        Dim message As String = "Unexpected failure"
        Try
            SerialPort1.Open()
            If (SerialPort1.IsOpen) Then
                message = "Port opened!"
            Else
                message = "Unable to open port!"
            End If
            SerialPort1.Close()
        Catch ex As System.InvalidOperationException
            message = "Port already opened by another process!"
        Catch ex As System.IO.IOException
            message = "Invalid port state!"
        Catch ex As System.UnauthorizedAccessException
            message = "Access to the port denied!"
        End Try

        Dim style As MsgBoxStyle = MsgBoxStyle.OkOnly
        MsgBox(message, style, COM1.Text)
    End Sub

    Private Sub SetupDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StepSizeUpDown.Value = My.Settings.StepSize
        TempCompensation.Value = My.Settings.StepsPerC
        COM1.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            COM1.Items.Add(sp)
        Next
        calculateCFZ()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (MessageBox.Show("Are you sure to set current focuser position to " + NumericUpDown8.Value.ToString + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            SerialPort1.BaudRate = 9600
            SerialPort1.ReadTimeout = 2000
            SerialPort1.PortName = COM1.Text
            Try
                SerialPort1.Open()
            Catch ex As Exception
                'Will not send command
            End Try
            If (SerialPort1.IsOpen) Then
                SerialPort1.Write("R:" + NumericUpDown8.Value.ToString + Constants.vbLf)
                Dim answer As String = ""
                Try
                    answer = SerialPort1.ReadTo(Constants.vbLf)
                    If (answer = "R") Then
                        MessageBox.Show("Focuser position updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Focuser response invalid, was " + answer + ", expected R", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As System.TimeoutException
                    MessageBox.Show("Serial port response time out " + SerialPort1.PortName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Try
                    SerialPort1.Close()
                Catch ex As Exception
                    'Will not close port
                End Try
            Else
                MessageBox.Show("Cannot open serial port " + SerialPort1.PortName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown5.ValueChanged
        calculateCFZ()
    End Sub


    Private Sub NumericUpDown5_KeyDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown5.KeyUp
        calculateCFZ()
    End Sub

    Private Sub calculateCFZ()
        Dim cfz As Double
        cfz = 4.88 * NumericUpDown5.Value * NumericUpDown5.Value * 0.475
        BlueCFZ.Text = Math.Round(cfz).ToString + " microns"
        cfz = 4.88 * NumericUpDown5.Value * NumericUpDown5.Value * 0.51
        GreenCFZ.Text = Math.Round(cfz).ToString + " microns"
        cfz = 4.88 * NumericUpDown5.Value * NumericUpDown5.Value * 0.65
        RedCFZ.Text = Math.Round(cfz).ToString + " microns"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (MessageBox.Show("Restore default values at Advanced Settings tab?", "Restore values?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            DutyCycleRun.Value = 100
            DutyCycleStop.Value = 0
            AccASCOM.Value = 100
            AccManual.Value = 100
            TempCompensation.Value = 0.0
            TempCycleTime.Value = 20
            BuzzerCheckBox.Checked = True
            LCDTextBox.Text = "Jolo Focuser 2.1" & vbCrLf & "pppppp(T) : tttttC()"
        End If
    End Sub

    Private Sub LCDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LCDTextBox.TextChanged
        LCDLabel.Text = "LCD " + LCDTextBox.Text.Length
    End Sub
End Class
