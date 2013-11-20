Imports ASCOM.JoloFocuser.Focuser


Public Class SimpleDigital
    Implements Extrasable

    Private WithEvents SwitchButton As Button
    Private ValueLabel As Label

    Private saveButton As Button
    Private statusLabel As Label
    Private focuser As JoloFocuser.Focuser
    Private pin As Byte
    Private pinName As String
    Private digitalOnly As Boolean
    Private pinHigh As Boolean


    Public Sub initialize(ByRef parent As GroupBox, ByRef statusLabel As Label, ByRef focuser As JoloFocuser.Focuser, ByRef pin As Byte, ByRef pinName As String, ByRef digitalOnly As Boolean, ByRef saveButton As Button) Implements Extrasable.initialize
        Me.saveButton = saveButton
        Me.statusLabel = statusLabel
        Me.pin = pin
        Me.focuser = focuser
        Me.digitalOnly = digitalOnly
        Me.pinName = pinName
        drawControls(parent)
    End Sub


    Public Sub drawControls(ByRef parent As System.Windows.Forms.GroupBox) Implements Extrasable.drawControls
        SwitchButton = New Button
        parent.Controls.Add(SwitchButton)
        SwitchButton.Top = 25
        SwitchButton.Left = 150
        SwitchButton.Text = "OFF"

        ValueLabel = New Label
        parent.Controls.Add(ValueLabel)
        ValueLabel.Text = "Status: N/A"
        ValueLabel.Font = New Drawing.Font(ValueLabel.Font.FontFamily, 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Pixel)
        ValueLabel.ForeColor = Drawing.Color.Red
        ValueLabel.Top = 28
        ValueLabel.Left = 20

        statusLabel.Text = pinName + " -> N/A"
        statusLabel.ForeColor = Drawing.Color.Red
    End Sub

    Public Sub clearPanel(ByRef parent As System.Windows.Forms.GroupBox) Implements Extrasable.clearPanel
        parent.Controls.Remove(SwitchButton)
        SwitchButton.Dispose()
        parent.Controls.Remove(ValueLabel)
        ValueLabel.Dispose()
    End Sub

    Public Sub refreshData() Implements Extrasable.refreshData
        If focuser.Connected Then
            Dim result As String = focuser.CommandString("VRE:" + pin)
            Dim resultArray As String() = result.Split(":")
            If resultArray(1) = "0" Then
                SwitchButton.Text = "ON"
                ValueLabel.Text = "Status: OFF"
                ValueLabel.ForeColor = Drawing.Color.Green
                pinHigh = False
            Else
                SwitchButton.Text = "OFF"
                ValueLabel.Text = "Status: ON"
                ValueLabel.ForeColor = Drawing.Color.Red
                pinHigh = True
            End If
            statusLabel.Text = pinName + " -> " + SwitchButton.Text
        End If
    End Sub


    Private Sub SwitchButtonHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchButton.Click
        If Not focuser.Connected Then
            MsgBox("Focuser not connected", MsgBoxStyle.OkOnly, "Not connected")
        Else
            If pinHigh Then
                Dim result As String = focuser.CommandString("VSE:" + pin + ",0")
            Else
                Dim result As String = focuser.CommandString("VSE:" + pin + ",1")
            End If
            refreshData()
        End If
    End Sub



    Public Property config() As String Implements Extrasable.config
        Get
            Return ""
        End Get
        Set(ByVal value As String)

        End Set
    End Property
End Class
