Public Class SimpleAnalogInput
    Inherits SimpleInputAbstract
    Implements Extrasable

    Private WithEvents paramABox As TextBox
    Private WithEvents paramBBox As TextBox
    Private WithEvents unitBox As TextBox

    Private paramALabel As Label
    Private paramBLabel As Label
    Private paramUnitLabel As Label
    Private formattedValue As Label

    Private paramA As Single
    Private paramB As Single
    Private unit As String

    Public Overrides Sub clearPanel(ByRef parent As System.Windows.Forms.GroupBox) Implements Extrasable.clearPanel
        MyBase.clearPanel(parent)
        parent.Controls.Remove(paramABox)
        paramABox.Dispose()
        parent.Controls.Remove(paramBBox)
        paramBBox.Dispose()
        parent.Controls.Remove(unitBox)
        unitBox.Dispose()
        parent.Controls.Remove(paramALabel)
        paramALabel.Dispose()
        parent.Controls.Remove(paramBLabel)
        paramBLabel.Dispose()
        parent.Controls.Remove(paramUnitLabel)
        paramUnitLabel.Dispose()
        parent.Controls.Remove(formattedValue)
        formattedValue.Dispose()
    End Sub

    Public Overrides Sub drawControls(ByRef parent As System.Windows.Forms.GroupBox) Implements Extrasable.drawControls
        MyBase.drawControls(parent)

        paramABox = New TextBox
        parent.Controls.Add(paramABox)
        paramABox.Text = paramA.ToString
        paramABox.Top = 60
        paramABox.Left = 80
        paramABox.Width = 50

        paramALabel = New Label
        parent.Controls.Add(paramALabel)
        paramALabel.Text = "A coeff."
        paramALabel.Top = 63
        paramALabel.Left = 40

        paramBBox = New TextBox
        parent.Controls.Add(paramBBox)
        paramBBox.Text = paramB.ToString
        paramBBox.Top = 60
        paramBBox.Left = 180
        paramBBox.Width = 50

        paramBLabel = New Label
        parent.Controls.Add(paramBLabel)
        paramBLabel.Text = "B coeff."
        paramBLabel.Top = 63
        paramBLabel.Left = 140

        unitBox = New TextBox
        parent.Controls.Add(unitBox)
        unitBox.Text = unit
        unitBox.Top = 60
        unitBox.Left = 280
        unitBox.Width = 50

        paramUnitLabel = New Label
        parent.Controls.Add(paramUnitLabel)
        paramUnitLabel.Text = "unit"
        paramUnitLabel.Top = 63
        paramUnitLabel.Left = 260

        formattedValue = New Label
        parent.Controls.Add(formattedValue)
        formattedValue.Top = 120
        formattedValue.Left = 140
        formattedValue.Text = "N/A"
        formattedValue.Font = New Drawing.Font(formattedValue.Font.FontFamily, 20, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Pixel)
        formattedValue.ForeColor = Drawing.Color.Navy

    End Sub

    Public Overrides Sub initialize(ByRef parent As System.Windows.Forms.GroupBox, ByRef statusLabel As System.Windows.Forms.Label, ByRef focuser As Focuser, ByRef pin As Byte, ByRef pinName As String, ByRef digitalOnly As Boolean, ByRef saveButton As System.Windows.Forms.Button) Implements Extrasable.initialize
        MyBase.initialize(parent, statusLabel, focuser, pin, pinName, digitalOnly, saveButton)
        AddHandler refreshTimer.Elapsed, AddressOf onRefreshData
    End Sub

    Public Property config() As String Implements Extrasable.config
        Get
            Return "analog input:" + RefreshCombo.Text + ":" + paramA.ToString + ":" + paramB.ToString + ":" + unit
        End Get
        Set(ByVal value As String)
            Dim resultArray As String() = value.Split(":")
            RefreshCombo.Text = resultArray(1)
            paramA = Single.Parse(resultArray(2))
            paramB = Single.Parse(resultArray(3))
            unit = resultArray(4)
            paramABox.Text = paramA.ToString
            paramBBox.Text = paramB.ToString
            unitBox.Text = unit
            refreshChanged()
        End Set
    End Property

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

    Public Sub onRefreshData()
        refreshData()
    End Sub

    Private Sub RefreshComboChangeHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshCombo.SelectedIndexChanged
        refreshChanged()
    End Sub

    Private Sub ParamAChangeHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paramABox.TextChanged
        Try
            paramA = Single.Parse(paramABox.Text)
            saveButton.Enabled = True
        Catch ex As System.FormatException
            MsgBox(paramABox.Text + " is not a valid numeric value!", MsgBoxStyle.OkOnly, "Not a number!")
        End Try
    End Sub

    Private Sub ParamBChangeHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paramBBox.TextChanged
        Try
            paramB = Single.Parse(paramBBox.Text)
            saveButton.Enabled = True
        Catch ex As System.FormatException
            MsgBox(paramBBox.Text + " is not a valid numeric value!", MsgBoxStyle.OkOnly, "Not a number!")
        End Try
    End Sub

    Private Sub UnitChangeHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unitBox.TextChanged
        unit = unitBox.Text
        saveButton.Enabled = True
    End Sub

    Public Sub refreshData() Implements Extrasable.refreshData
        If focuser.Connected Then
            Dim result As String = focuser.CommandString("VRE:" + pin)
            Dim resultArray As String() = result.Split(":")

            ValueLabel.Text = "Value: " + resultArray(1)
            ValueLabel.ForeColor = Drawing.Color.Black
            statusLabel.Text = pinName + " -> " + resultArray(1)
            statusLabel.ForeColor = Drawing.Color.Black
            Dim val As Single = Integer.Parse(resultArray(1)) * paramA + paramB
            formattedValue.Text = val.ToString + " " + unit
        Else
            ValueLabel.Text = "Value: N/A"
            ValueLabel.ForeColor = Drawing.Color.Red
            statusLabel.Text = pinName + " -> N/A"
            statusLabel.ForeColor = Drawing.Color.Red
            formattedValue.Text = "N/A"
        End If
    End Sub
End Class
