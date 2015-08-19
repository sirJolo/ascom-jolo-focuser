<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupDialogForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupDialogForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.LCDTabControl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RedCFZ = New System.Windows.Forms.Label
        Me.GreenCFZ = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.BlueCFZ = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown
        Me.ShowMonitorCheckBox = New System.Windows.Forms.CheckBox
        Me.COM1 = New System.Windows.Forms.ComboBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TempCompensation = New System.Windows.Forms.NumericUpDown
        Me.AccASCOM = New System.Windows.Forms.NumericUpDown
        Me.DutyCycleStop = New System.Windows.Forms.NumericUpDown
        Me.DutyCycleRun = New System.Windows.Forms.NumericUpDown
        Me.TempCycleTime = New System.Windows.Forms.NumericUpDown
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.NumericUpDown8 = New System.Windows.Forms.NumericUpDown
        Me.Label10 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.StepSizeUpDown = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.BuzzerCheckBox = New System.Windows.Forms.CheckBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.LCDTabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.TempCompensation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccASCOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DutyCycleStop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DutyCycleRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TempCycleTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StepSizeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'label2
        '
        resources.ApplyResources(Me.label2, "label2")
        Me.label2.Name = "label2"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'LCDTabControl
        '
        Me.LCDTabControl.Controls.Add(Me.TabPage1)
        Me.LCDTabControl.Controls.Add(Me.TabPage2)
        resources.ApplyResources(Me.LCDTabControl, "LCDTabControl")
        Me.LCDTabControl.Name = "LCDTabControl"
        Me.LCDTabControl.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.BuzzerCheckBox)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.ShowMonitorCheckBox)
        Me.TabPage1.Controls.Add(Me.label2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.COM1)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.RedCFZ)
        Me.GroupBox1.Controls.Add(Me.GreenCFZ)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.BlueCFZ)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown5)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'RedCFZ
        '
        resources.ApplyResources(Me.RedCFZ, "RedCFZ")
        Me.RedCFZ.ForeColor = System.Drawing.Color.Red
        Me.RedCFZ.Name = "RedCFZ"
        '
        'GreenCFZ
        '
        resources.ApplyResources(Me.GreenCFZ, "GreenCFZ")
        Me.GreenCFZ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GreenCFZ.Name = "GreenCFZ"
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        '
        'BlueCFZ
        '
        resources.ApplyResources(Me.BlueCFZ, "BlueCFZ")
        Me.BlueCFZ.ForeColor = System.Drawing.Color.Blue
        Me.BlueCFZ.Name = "BlueCFZ"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DecimalPlaces = 1
        Me.NumericUpDown2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.NumericUpDown2, "NumericUpDown2")
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Value = New Decimal(New Integer() {74, 0, 0, 65536})
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.DecimalPlaces = 1
        Me.NumericUpDown5.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.NumericUpDown5, "NumericUpDown5")
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDown5.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'ShowMonitorCheckBox
        '
        resources.ApplyResources(Me.ShowMonitorCheckBox, "ShowMonitorCheckBox")
        Me.ShowMonitorCheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.ShowMonitor
        Me.ShowMonitorCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "ShowMonitor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ShowMonitorCheckBox.Name = "ShowMonitorCheckBox"
        Me.ShowMonitorCheckBox.UseVisualStyleBackColor = True
        '
        'COM1
        '
        Me.COM1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "CommPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.COM1.FormattingEnabled = True
        resources.ApplyResources(Me.COM1, "COM1")
        Me.COM1.Name = "COM1"
        Me.COM1.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.CommPort
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.NumericUpDown8)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.NumericUpDown1)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.StepSizeUpDown)
        Me.TabPage2.Controls.Add(Me.NumericUpDown6)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.TempCompensation)
        Me.TabPage2.Controls.Add(Me.AccASCOM)
        Me.TabPage2.Controls.Add(Me.DutyCycleStop)
        Me.TabPage2.Controls.Add(Me.DutyCycleRun)
        Me.TabPage2.Controls.Add(Me.TempCycleTime)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'TempCompensation
        '
        Me.TempCompensation.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepsPerC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TempCompensation.DecimalPlaces = 1
        Me.TempCompensation.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.TempCompensation, "TempCompensation")
        Me.TempCompensation.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TempCompensation.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.TempCompensation.Name = "TempCompensation"
        Me.TempCompensation.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepsPerC
        '
        'AccASCOM
        '
        Me.AccASCOM.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "AccASCOM", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.AccASCOM, "AccASCOM")
        Me.AccASCOM.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AccASCOM.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.AccASCOM.Name = "AccASCOM"
        Me.AccASCOM.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.AccASCOM
        '
        'DutyCycleStop
        '
        Me.DutyCycleStop.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "DutyCycle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.DutyCycleStop, "DutyCycleStop")
        Me.DutyCycleStop.Name = "DutyCycleStop"
        Me.DutyCycleStop.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.DutyCycle
        '
        'DutyCycleRun
        '
        Me.DutyCycleRun.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "DutyCycleRun", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.DutyCycleRun, "DutyCycleRun")
        Me.DutyCycleRun.Name = "DutyCycleRun"
        Me.DutyCycleRun.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.DutyCycleRun
        '
        'TempCycleTime
        '
        Me.TempCycleTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "TempCycle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.TempCycleTime, "TempCycleTime")
        Me.TempCycleTime.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.TempCycleTime.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.TempCycleTime.Name = "TempCycleTime"
        Me.TempCycleTime.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.TempCycle
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.JoloFocuser.My.Resources.Resources.ASCOM
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NumericUpDown8
        '
        resources.ApplyResources(Me.NumericUpDown8, "NumericUpDown8")
        Me.NumericUpDown8.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDown8.Name = "NumericUpDown8"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "FocuserMax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.NumericUpDown1, "NumericUpDown1")
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.FocuserMax
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'StepSizeUpDown
        '
        Me.StepSizeUpDown.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepSize", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.StepSizeUpDown.DecimalPlaces = 1
        Me.StepSizeUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.StepSizeUpDown, "StepSizeUpDown")
        Me.StepSizeUpDown.Name = "StepSizeUpDown"
        Me.StepSizeUpDown.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepSize
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepperRPM", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.NumericUpDown6, "NumericUpDown6")
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NumericUpDown6.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepperRPM
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'BuzzerCheckBox
        '
        resources.ApplyResources(Me.BuzzerCheckBox, "BuzzerCheckBox")
        Me.BuzzerCheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.BuzzerON
        Me.BuzzerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BuzzerCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "BuzzerON", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BuzzerCheckBox.Name = "BuzzerCheckBox"
        Me.BuzzerCheckBox.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.LCDTabControl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.LCDTabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.TempCompensation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccASCOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DutyCycleStop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DutyCycleRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TempCycleTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StepSizeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents TempCycleTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents TempCompensation As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents COM1 As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DutyCycleRun As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LCDTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DutyCycleStop As System.Windows.Forms.NumericUpDown
    Friend WithEvents ShowMonitorCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RedCFZ As System.Windows.Forms.Label
    Friend WithEvents GreenCFZ As System.Windows.Forms.Label
    Friend WithEvents BlueCFZ As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents AccASCOM As System.Windows.Forms.NumericUpDown
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents BuzzerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown8 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StepSizeUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox

End Class
