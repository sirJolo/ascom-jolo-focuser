Imports ASCOM.JoloFocuser.Focuser

Public Class SimpleDigitalInput
    Inherits SimpleInputAbstract
    Implements Extrasable

    Private pinHigh As Boolean

    Public Overrides Sub clearPanel(ByRef parent As System.Windows.Forms.GroupBox) Implements Extrasable.clearPanel
        MyBase.clearPanel(parent)
    End Sub

    Public Overrides Sub drawControls(ByRef parent As System.Windows.Forms.GroupBox) Implements Extrasable.drawControls
        MyBase.drawControls(parent)
    End Sub

    Public Overrides Sub initialize(ByRef parent As System.Windows.Forms.GroupBox, ByRef statusLabel As System.Windows.Forms.Label, ByRef focuser As Focuser, ByRef pin As Byte, ByRef pinName As String, ByRef digitalOnly As Boolean, ByRef saveButton As Button) Implements Extrasable.initialize
        MyBase.initialize(parent, statusLabel, focuser, pin, pinName, digitalOnly, saveButton)
        AddHandler refreshTimer.Elapsed, AddressOf onRefreshData
    End Sub


    Public Property config() As String Implements Extrasable.config
        Get
            Return "digital input:" + RefreshCombo.Text
        End Get
        Set(ByVal value As String)
            Dim resultArray As String() = value.Split(":")
            RefreshCombo.Text = resultArray(1)
            refreshChanged()
        End Set
    End Property


    Private Sub RefreshComboChangeHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshCombo.SelectedIndexChanged
        refreshChanged()
    End Sub

    Private Sub refreshChanged()
        Dim value As String = RefreshCombo.Text
        If value = "0" Then
            refreshTimer.Enabled = False
        Else
            refreshTimer.Interval = (1000 * Double.Parse(value)) - 500 + 1000 * Rnd()
            refreshTimer.Enabled = True
        End If
        saveButton.Enabled = True
    End Sub


    Private Sub RefreshButtonHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshButton.Click
        If focuser.Connected Then
            MsgBox("Focuser not connected", MsgBoxStyle.OkOnly, "Not connected")
        Else
            refreshData()
        End If
    End Sub


    Public Sub onRefreshData()
        refreshData()
    End Sub

    ' Must be thread safe because called from the timer as well
    Public Sub refreshData() Implements Extrasable.refreshData
        If focuser.Connected Then
            Dim result As String = focuser.CommandString("VRE:" + pin)
            Dim resultArray As String() = result.Split(":")
            If resultArray(1) = "0" Then
                ValueLabel.Text = "Value: LOW"
                ValueLabel.ForeColor = Drawing.Color.Green
                pinHigh = False
                statusLabel.Text = pinName + " -> L"
                statusLabel.ForeColor = Drawing.Color.Green
            Else
                ValueLabel.Text = "Value: HIGH"
                ValueLabel.ForeColor = Drawing.Color.Red
                pinHigh = True
                statusLabel.Text = pinName + " -> H"
                statusLabel.ForeColor = Drawing.Color.Red
            End If
        Else
            ValueLabel.Text = "Value: N/A"
            ValueLabel.ForeColor = Drawing.Color.Red
            statusLabel.Text = pinName + " -> N/A"
            statusLabel.ForeColor = Drawing.Color.Red
        End If

    End Sub


End Class
