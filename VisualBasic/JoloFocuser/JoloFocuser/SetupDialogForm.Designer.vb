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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.NumericUpDown8 = New System.Windows.Forms.NumericUpDown
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.StepSizeUpDown = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label10 = New System.Windows.Forms.Label
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown7 = New System.Windows.Forms.NumericUpDown
        Me.COM1 = New System.Windows.Forms.ComboBox
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown
        Me.CompensationUpDown = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StepSizeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompensationUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(201, 463)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.JoloFocuser.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(298, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(14, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(52, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "COM port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Max focuser position"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(204, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Test port"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 268)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Temp cycle (sec)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Comp. (steps/C)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Stepper spped (pps)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 210)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Backslash (steps)"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(298, 95)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 49)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'NumericUpDown8
        '
        Me.NumericUpDown8.Location = New System.Drawing.Point(125, 360)
        Me.NumericUpDown8.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.NumericUpDown8.Name = "NumericUpDown8"
        Me.NumericUpDown8.Size = New System.Drawing.Size(103, 20)
        Me.NumericUpDown8.TabIndex = 26
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(253, 359)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Set"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(21, 395)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(307, 53)
        Me.TextBox1.TabIndex = 29
        Me.TextBox1.Text = "Use it if you want to set current focser position, when you loose synchronization" & _
            " between focuser and driver. For example move focuser to its most inward positio" & _
            "n and then set position to 0."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Stepper duty cycle %"
        '
        'StepSizeUpDown
        '
        Me.StepSizeUpDown.DecimalPlaces = 1
        Me.StepSizeUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.StepSizeUpDown.Location = New System.Drawing.Point(125, 170)
        Me.StepSizeUpDown.Name = "StepSizeUpDown"
        Me.StepSizeUpDown.Size = New System.Drawing.Size(55, 20)
        Me.StepSizeUpDown.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Step size (microns)"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(18, 476)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(148, 13)
        Me.LinkLabel1.TabIndex = 34
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://astrojolo.blogspot.com/"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 362)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Set focuser position"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "DutyCycle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown2.Location = New System.Drawing.Point(125, 132)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDown2.TabIndex = 30
        Me.NumericUpDown2.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.DutyCycle
        '
        'NumericUpDown7
        '
        Me.NumericUpDown7.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "Backslash", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown7.Location = New System.Drawing.Point(125, 208)
        Me.NumericUpDown7.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumericUpDown7.Name = "NumericUpDown7"
        Me.NumericUpDown7.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDown7.TabIndex = 23
        Me.NumericUpDown7.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.Backslash
        '
        'COM1
        '
        Me.COM1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "CommPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.COM1.FormattingEnabled = True
        Me.COM1.Location = New System.Drawing.Point(125, 15)
        Me.COM1.Name = "COM1"
        Me.COM1.Size = New System.Drawing.Size(55, 21)
        Me.COM1.TabIndex = 22
        Me.COM1.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.CommPort
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepperRPM", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown6.Location = New System.Drawing.Point(125, 95)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NumericUpDown6.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDown6.TabIndex = 20
        Me.NumericUpDown6.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepperRPM
        '
        'CompensationUpDown
        '
        Me.CompensationUpDown.DecimalPlaces = 1
        Me.CompensationUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.CompensationUpDown.Location = New System.Drawing.Point(125, 302)
        Me.CompensationUpDown.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.CompensationUpDown.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.CompensationUpDown.Name = "CompensationUpDown"
        Me.CompensationUpDown.Size = New System.Drawing.Size(55, 20)
        Me.CompensationUpDown.TabIndex = 16
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "TempCycle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown4.Location = New System.Drawing.Point(125, 266)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.NumericUpDown4.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDown4.TabIndex = 15
        Me.NumericUpDown4.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.TempCycle
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "FocuserMax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown1.Location = New System.Drawing.Point(125, 59)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(103, 20)
        Me.NumericUpDown1.TabIndex = 8
        Me.NumericUpDown1.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.FocuserMax
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 456)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "ver. 1.2"
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(359, 504)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.StepSizeUpDown)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NumericUpDown8)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.NumericUpDown7)
        Me.Controls.Add(Me.COM1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.NumericUpDown6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CompensationUpDown)
        Me.Controls.Add(Me.NumericUpDown4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jolo Focuser Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StepSizeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompensationUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents CompensationUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents COM1 As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents NumericUpDown8 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StepSizeUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
