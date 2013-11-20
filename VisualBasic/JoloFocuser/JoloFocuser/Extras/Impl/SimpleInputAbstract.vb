Public MustInherit Class SimpleInputAbstract
    Protected refreshTimer As System.Timers.Timer

    Protected ValueLabel As Label
    Protected WithEvents RefreshButton As Button
    Protected WithEvents RefreshCombo As ComboBox
    Protected UnitLabel As Label

    Protected saveButton As Button
    Protected statusLabel As Label
    Protected focuser As JoloFocuser.Focuser
    Protected pin As Byte
    Protected pinName As String
    Protected digitalOnly As Boolean


    Public Overridable Sub clearPanel(ByRef parent As System.Windows.Forms.GroupBox)
        parent.Controls.Remove(ValueLabel)
        ValueLabel.Dispose()
        parent.Controls.Remove(RefreshButton)
        RefreshButton.Dispose()
        parent.Controls.Remove(RefreshCombo)
        RefreshCombo.Dispose()
        parent.Controls.Remove(UnitLabel)
        UnitLabel.Dispose()
    End Sub

    Public Overridable Sub drawControls(ByRef parent As System.Windows.Forms.GroupBox)
        ValueLabel = New Label
        parent.Controls.Add(ValueLabel)
        ValueLabel.Text = "Value: N/A"
        ValueLabel.Font = New Drawing.Font(ValueLabel.Font.FontFamily, 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Pixel)
        ValueLabel.ForeColor = Drawing.Color.Red
        ValueLabel.Top = 28
        ValueLabel.Left = 20

        RefreshButton = New Button
        parent.Controls.Add(RefreshButton)
        RefreshButton.Top = 25
        RefreshButton.Left = 150
        RefreshButton.Text = "Refresh"

        RefreshCombo = New ComboBox
        parent.Controls.Add(RefreshCombo)
        RefreshCombo.Top = 25
        RefreshCombo.Left = 250
        RefreshCombo.DropDownStyle = ComboBoxStyle.DropDownList
        Dim refreshs(6) As String
        refreshs(0) = "0"
        refreshs(1) = "3"
        refreshs(2) = "5"
        refreshs(3) = "10"
        refreshs(4) = "30"
        refreshs(5) = "60"
        RefreshCombo.DataSource = refreshs
        RefreshCombo.SelectedIndex = 0
        RefreshCombo.Width = 50

        UnitLabel = New Label
        parent.Controls.Add(UnitLabel)
        UnitLabel.Top = 28
        UnitLabel.Left = 320
        UnitLabel.Text = "sec (0 - OFF)"

        statusLabel.Text = pinName + " -> N/A"
        statusLabel.ForeColor = Drawing.Color.Red
    End Sub


    Public Overridable Sub initialize(ByRef parent As System.Windows.Forms.GroupBox, ByRef statusLabel As System.Windows.Forms.Label, ByRef focuser As Focuser, ByRef pin As Byte, ByRef pinName As String, ByRef digitalOnly As Boolean, ByRef saveButton As Button)
        refreshTimer = New System.Timers.Timer()
        refreshTimer.Enabled = False
        refreshTimer.SynchronizingObject = parent

        Me.saveButton = saveButton
        Me.statusLabel = statusLabel
        Me.pin = pin
        Me.pinName = pinName
        Me.focuser = focuser
        Me.digitalOnly = digitalOnly
        drawControls(parent)
    End Sub

End Class
