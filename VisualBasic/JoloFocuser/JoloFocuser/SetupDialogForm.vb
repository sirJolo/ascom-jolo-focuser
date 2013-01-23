Imports System.Windows.Forms
Imports System.Runtime.InteropServices

<ComVisible(False)> _
Public Class SetupDialogForm

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
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
        SerialPort1.Open()
        Dim message As String
        If (SerialPort1.IsOpen) Then
            message = "Port opened!"
        Else
            message = "Port not available!"
        End If
        SerialPort1.Close()
        Dim style As MsgBoxStyle = MsgBoxStyle.OkOnly
        MsgBox(message, style, COM1.Text)
    End Sub

    Private Sub SetupDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        COM1.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            COM1.Items.Add(sp)
        Next
    End Sub
End Class
