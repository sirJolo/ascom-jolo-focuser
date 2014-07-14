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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.NumericUpDown8 = New System.Windows.Forms.NumericUpDown
        Me.Label10 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.LCDTextBox = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ShowMonitorCheckBox = New System.Windows.Forms.CheckBox
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.StepSizeUpDown = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown
        Me.COM1 = New System.Windows.Forms.ComboBox
        Me.LCDOffCheckBox = New System.Windows.Forms.CheckBox
        Me.LCD4ComboBox = New System.Windows.Forms.ComboBox
        Me.LCD3ComboBox = New System.Windows.Forms.ComboBox
        Me.LCD2ComboBox = New System.Windows.Forms.ComboBox
        Me.LCD1ComboBox = New System.Windows.Forms.ComboBox
        Me.BuzzerCheckBox = New System.Windows.Forms.CheckBox
        Me.TempCompensation = New System.Windows.Forms.NumericUpDown
        Me.AccASCOM = New System.Windows.Forms.NumericUpDown
        Me.AccManual = New System.Windows.Forms.NumericUpDown
        Me.DutyCycleStop = New System.Windows.Forms.NumericUpDown
        Me.DutyCycleRun = New System.Windows.Forms.NumericUpDown
        Me.TempCycleTime = New System.Windows.Forms.NumericUpDown
        Me.TableLayoutPanel1.SuspendLayout()
        Me.LCDTabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StepSizeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TempCompensation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccASCOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccManual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DutyCycleStop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DutyCycleRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TempCycleTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(276, 464)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(20, 19)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(52, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "COM port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Max focuser position"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(210, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Test port"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Temp cycle (sec)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Comp. (steps/C)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Stepper spped (pps)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Stepper duty cycle run %"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Step size (microns)"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(18, 479)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(148, 13)
        Me.LinkLabel1.TabIndex = 34
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://astrojolo.blogspot.com/"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 461)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "ver. 2.1"
        '
        'LCDTabControl
        '
        Me.LCDTabControl.Controls.Add(Me.TabPage1)
        Me.LCDTabControl.Controls.Add(Me.TabPage2)
        Me.LCDTabControl.Location = New System.Drawing.Point(12, 12)
        Me.LCDTabControl.Name = "LCDTabControl"
        Me.LCDTabControl.SelectedIndex = 0
        Me.LCDTabControl.Size = New System.Drawing.Size(357, 441)
        Me.LCDTabControl.TabIndex = 36
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.ShowMonitorCheckBox)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.NumericUpDown8)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.NumericUpDown1)
        Me.TabPage1.Controls.Add(Me.label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.StepSizeUpDown)
        Me.TabPage1.Controls.Add(Me.NumericUpDown6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.COM1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(349, 415)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Basic"
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
        Me.GroupBox1.Location = New System.Drawing.Point(20, 293)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 108)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Critical Focus Zone calculator"
        '
        'RedCFZ
        '
        Me.RedCFZ.AutoSize = True
        Me.RedCFZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.RedCFZ.ForeColor = System.Drawing.Color.Red
        Me.RedCFZ.Location = New System.Drawing.Point(189, 66)
        Me.RedCFZ.Name = "RedCFZ"
        Me.RedCFZ.Size = New System.Drawing.Size(61, 13)
        Me.RedCFZ.TabIndex = 2
        Me.RedCFZ.Text = "0 microns"
        '
        'GreenCFZ
        '
        Me.GreenCFZ.AutoSize = True
        Me.GreenCFZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.GreenCFZ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GreenCFZ.Location = New System.Drawing.Point(190, 46)
        Me.GreenCFZ.Name = "GreenCFZ"
        Me.GreenCFZ.Size = New System.Drawing.Size(61, 13)
        Me.GreenCFZ.TabIndex = 2
        Me.GreenCFZ.Text = "0 microns"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(9, 87)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(262, 13)
        Me.LinkLabel2.TabIndex = 34
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "http://www.wilmslowastro.com/software/formulae.htm"
        '
        'BlueCFZ
        '
        Me.BlueCFZ.AutoSize = True
        Me.BlueCFZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.BlueCFZ.ForeColor = System.Drawing.Color.Blue
        Me.BlueCFZ.Location = New System.Drawing.Point(190, 25)
        Me.BlueCFZ.Name = "BlueCFZ"
        Me.BlueCFZ.Size = New System.Drawing.Size(61, 13)
        Me.BlueCFZ.TabIndex = 2
        Me.BlueCFZ.Text = "0 microns"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(143, 63)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(21, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "um"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "CCD pixel size"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "f ratio"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DecimalPlaces = 1
        Me.NumericUpDown2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown2.Location = New System.Drawing.Point(98, 59)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(44, 20)
        Me.NumericUpDown2.TabIndex = 0
        Me.NumericUpDown2.Value = New Decimal(New Integer() {74, 0, 0, 65536})
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.DecimalPlaces = 1
        Me.NumericUpDown5.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown5.Location = New System.Drawing.Point(98, 31)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDown5.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(44, 20)
        Me.NumericUpDown5.TabIndex = 0
        Me.NumericUpDown5.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(20, 214)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(307, 53)
        Me.TextBox1.TabIndex = 37
        Me.TextBox1.Text = "Use it if you want to set current focser position, when you loose synchronization" & _
            " between focuser and driver. For example move focuser to its most inward positio" & _
            "n and then set position to 0."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(253, 186)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Set"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NumericUpDown8
        '
        Me.NumericUpDown8.Location = New System.Drawing.Point(129, 187)
        Me.NumericUpDown8.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDown8.Name = "NumericUpDown8"
        Me.NumericUpDown8.Size = New System.Drawing.Size(103, 20)
        Me.NumericUpDown8.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 189)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Set focuser position"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.LCDOffCheckBox)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.TextBox5)
        Me.TabPage2.Controls.Add(Me.TextBox4)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.LCDTextBox)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.LCD4ComboBox)
        Me.TabPage2.Controls.Add(Me.LCD3ComboBox)
        Me.TabPage2.Controls.Add(Me.LCD2ComboBox)
        Me.TabPage2.Controls.Add(Me.LCD1ComboBox)
        Me.TabPage2.Controls.Add(Me.BuzzerCheckBox)
        Me.TabPage2.Controls.Add(Me.TempCompensation)
        Me.TabPage2.Controls.Add(Me.AccASCOM)
        Me.TabPage2.Controls.Add(Me.AccManual)
        Me.TabPage2.Controls.Add(Me.DutyCycleStop)
        Me.TabPage2.Controls.Add(Me.DutyCycleRun)
        Me.TabPage2.Controls.Add(Me.TempCycleTime)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(349, 415)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Advanced"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 250)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "LCD screens"
        '
        'TextBox5
        '
        Me.TextBox5.AutoCompleteCustomSource.AddRange(New String() {"pppppp", "ttt.t", "pp.ppp", "hh", "ddd.d"})
        Me.TextBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox5.BackColor = System.Drawing.Color.Black
        Me.TextBox5.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox5.Location = New System.Drawing.Point(188, 344)
        Me.TextBox5.MaxLength = 100
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(147, 41)
        Me.TextBox5.TabIndex = 48
        Me.TextBox5.Text = "ADC=1007   3.42V" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OPTO:1      455s"
        '
        'TextBox4
        '
        Me.TextBox4.AutoCompleteCustomSource.AddRange(New String() {"pppppp", "ttt.t", "pp.ppp", "hh", "ddd.d"})
        Me.TextBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox4.BackColor = System.Drawing.Color.Black
        Me.TextBox4.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox4.Location = New System.Drawing.Point(20, 344)
        Me.TextBox4.MaxLength = 100
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(147, 41)
        Me.TextBox4.TabIndex = 46
        Me.TextBox4.Text = "PWM  6    9   10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   89%  43%  44%"
        '
        'TextBox3
        '
        Me.TextBox3.AutoCompleteCustomSource.AddRange(New String() {"pppppp", "ttt.t", "pp.ppp", "hh", "ddd.d"})
        Me.TextBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox3.BackColor = System.Drawing.Color.Black
        Me.TextBox3.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox3.Location = New System.Drawing.Point(188, 266)
        Me.TextBox3.MaxLength = 100
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(147, 41)
        Me.TextBox3.TabIndex = 44
        Me.TextBox3.Text = " 12345  13.555mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 87% 12.3/ 15.6C"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(229, 312)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 13)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "s"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(229, 391)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "s"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(61, 391)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "s"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(61, 312)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "s"
        '
        'LCDTextBox
        '
        Me.LCDTextBox.AutoCompleteCustomSource.AddRange(New String() {"pppppp", "ttt.t", "pp.ppp", "hh", "ddd.d"})
        Me.LCDTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.LCDTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.LCDTextBox.BackColor = System.Drawing.Color.Black
        Me.LCDTextBox.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LCDTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LCDTextBox.Location = New System.Drawing.Point(20, 266)
        Me.LCDTextBox.MaxLength = 100
        Me.LCDTextBox.Multiline = True
        Me.LCDTextBox.Name = "LCDTextBox"
        Me.LCDTextBox.ReadOnly = True
        Me.LCDTextBox.Size = New System.Drawing.Size(147, 41)
        Me.LCDTextBox.TabIndex = 41
        Me.LCDTextBox.Text = " 12345  13.555mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Temp:     -12.5C"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(232, 215)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(103, 23)
        Me.Button3.TabIndex = 36
        Me.Button3.Text = "Restore defaults"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Acceleration ASCOM control"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(236, 107)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "pps/s"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(236, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "pps/s"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(138, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Acceleration manual control"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Stepper duty cycle stop %"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(375, 82)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 49)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 25
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.JoloFocuser.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(373, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ShowMonitorCheckBox
        '
        Me.ShowMonitorCheckBox.AutoSize = True
        Me.ShowMonitorCheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.ShowMonitor
        Me.ShowMonitorCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "ShowMonitor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ShowMonitorCheckBox.Location = New System.Drawing.Point(23, 148)
        Me.ShowMonitorCheckBox.Name = "ShowMonitorCheckBox"
        Me.ShowMonitorCheckBox.Size = New System.Drawing.Size(162, 17)
        Me.ShowMonitorCheckBox.TabIndex = 39
        Me.ShowMonitorCheckBox.Text = "Show monitor popup window"
        Me.ShowMonitorCheckBox.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "FocuserMax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown1.Location = New System.Drawing.Point(131, 55)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(103, 20)
        Me.NumericUpDown1.TabIndex = 8
        Me.NumericUpDown1.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.FocuserMax
        '
        'StepSizeUpDown
        '
        Me.StepSizeUpDown.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepSize", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.StepSizeUpDown.DecimalPlaces = 1
        Me.StepSizeUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.StepSizeUpDown.Location = New System.Drawing.Point(131, 118)
        Me.StepSizeUpDown.Name = "StepSizeUpDown"
        Me.StepSizeUpDown.Size = New System.Drawing.Size(55, 20)
        Me.StepSizeUpDown.TabIndex = 32
        Me.StepSizeUpDown.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepSize
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepperRPM", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown6.Location = New System.Drawing.Point(131, 86)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NumericUpDown6.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDown6.TabIndex = 20
        Me.NumericUpDown6.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepperRPM
        '
        'COM1
        '
        Me.COM1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "CommPort", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.COM1.FormattingEnabled = True
        Me.COM1.Location = New System.Drawing.Point(131, 16)
        Me.COM1.Name = "COM1"
        Me.COM1.Size = New System.Drawing.Size(65, 21)
        Me.COM1.TabIndex = 22
        Me.COM1.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.CommPort
        '
        'LCDOffCheckBox
        '
        Me.LCDOffCheckBox.AutoSize = True
        Me.LCDOffCheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.LCDOffDuringMove
        Me.LCDOffCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LCDOffCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "LCDOffDuringMove", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LCDOffCheckBox.Location = New System.Drawing.Point(20, 221)
        Me.LCDOffCheckBox.Name = "LCDOffCheckBox"
        Me.LCDOffCheckBox.Size = New System.Drawing.Size(183, 17)
        Me.LCDOffCheckBox.TabIndex = 51
        Me.LCDOffCheckBox.Text = "Turn off LCD during stepper work"
        Me.LCDOffCheckBox.UseVisualStyleBackColor = True
        '
        'LCD4ComboBox
        '
        Me.LCD4ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "LCD4", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LCD4ComboBox.FormattingEnabled = True
        Me.LCD4ComboBox.Items.AddRange(New Object() {"0", "1", "2", "3", "5", "7", "9"})
        Me.LCD4ComboBox.Location = New System.Drawing.Point(188, 388)
        Me.LCD4ComboBox.Name = "LCD4ComboBox"
        Me.LCD4ComboBox.Size = New System.Drawing.Size(35, 21)
        Me.LCD4ComboBox.TabIndex = 49
        Me.LCD4ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.LCD4
        '
        'LCD3ComboBox
        '
        Me.LCD3ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "LCD3", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LCD3ComboBox.FormattingEnabled = True
        Me.LCD3ComboBox.Items.AddRange(New Object() {"0", "1", "2", "3", "5", "7", "9"})
        Me.LCD3ComboBox.Location = New System.Drawing.Point(20, 388)
        Me.LCD3ComboBox.Name = "LCD3ComboBox"
        Me.LCD3ComboBox.Size = New System.Drawing.Size(35, 21)
        Me.LCD3ComboBox.TabIndex = 47
        Me.LCD3ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.LCD3
        '
        'LCD2ComboBox
        '
        Me.LCD2ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "LCD2", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LCD2ComboBox.FormattingEnabled = True
        Me.LCD2ComboBox.Items.AddRange(New Object() {"0", "1", "2", "3", "5", "7", "9"})
        Me.LCD2ComboBox.Location = New System.Drawing.Point(188, 310)
        Me.LCD2ComboBox.Name = "LCD2ComboBox"
        Me.LCD2ComboBox.Size = New System.Drawing.Size(35, 21)
        Me.LCD2ComboBox.TabIndex = 45
        Me.LCD2ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.LCD2
        '
        'LCD1ComboBox
        '
        Me.LCD1ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "LCD1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LCD1ComboBox.FormattingEnabled = True
        Me.LCD1ComboBox.Items.AddRange(New Object() {"0", "1", "2", "3", "5", "7", "9"})
        Me.LCD1ComboBox.Location = New System.Drawing.Point(20, 310)
        Me.LCD1ComboBox.Name = "LCD1ComboBox"
        Me.LCD1ComboBox.Size = New System.Drawing.Size(35, 21)
        Me.LCD1ComboBox.TabIndex = 42
        Me.LCD1ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.LCD1
        '
        'BuzzerCheckBox
        '
        Me.BuzzerCheckBox.AutoSize = True
        Me.BuzzerCheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.BuzzerON
        Me.BuzzerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BuzzerCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "BuzzerON", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BuzzerCheckBox.Location = New System.Drawing.Point(20, 197)
        Me.BuzzerCheckBox.Name = "BuzzerCheckBox"
        Me.BuzzerCheckBox.Size = New System.Drawing.Size(58, 17)
        Me.BuzzerCheckBox.TabIndex = 32
        Me.BuzzerCheckBox.Text = "Buzzer"
        Me.BuzzerCheckBox.UseVisualStyleBackColor = True
        '
        'TempCompensation
        '
        Me.TempCompensation.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "StepsPerC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TempCompensation.DecimalPlaces = 1
        Me.TempCompensation.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.TempCompensation.Location = New System.Drawing.Point(128, 168)
        Me.TempCompensation.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TempCompensation.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.TempCompensation.Name = "TempCompensation"
        Me.TempCompensation.Size = New System.Drawing.Size(55, 20)
        Me.TempCompensation.TabIndex = 16
        Me.TempCompensation.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.StepsPerC
        '
        'AccASCOM
        '
        Me.AccASCOM.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "AccASCOM", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AccASCOM.Location = New System.Drawing.Point(175, 103)
        Me.AccASCOM.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AccASCOM.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.AccASCOM.Name = "AccASCOM"
        Me.AccASCOM.Size = New System.Drawing.Size(55, 20)
        Me.AccASCOM.TabIndex = 30
        Me.AccASCOM.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.AccASCOM
        '
        'AccManual
        '
        Me.AccManual.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "AccManual", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AccManual.Location = New System.Drawing.Point(175, 75)
        Me.AccManual.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AccManual.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.AccManual.Name = "AccManual"
        Me.AccManual.Size = New System.Drawing.Size(55, 20)
        Me.AccManual.TabIndex = 30
        Me.AccManual.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.AccManual
        '
        'DutyCycleStop
        '
        Me.DutyCycleStop.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "DutyCycle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DutyCycleStop.Location = New System.Drawing.Point(175, 44)
        Me.DutyCycleStop.Name = "DutyCycleStop"
        Me.DutyCycleStop.Size = New System.Drawing.Size(55, 20)
        Me.DutyCycleStop.TabIndex = 30
        Me.DutyCycleStop.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.DutyCycle
        '
        'DutyCycleRun
        '
        Me.DutyCycleRun.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "DutyCycleRun", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DutyCycleRun.Location = New System.Drawing.Point(175, 16)
        Me.DutyCycleRun.Name = "DutyCycleRun"
        Me.DutyCycleRun.Size = New System.Drawing.Size(55, 20)
        Me.DutyCycleRun.TabIndex = 30
        Me.DutyCycleRun.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.DutyCycleRun
        '
        'TempCycleTime
        '
        Me.TempCycleTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "TempCycle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TempCycleTime.Location = New System.Drawing.Point(128, 140)
        Me.TempCycleTime.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.TempCycleTime.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.TempCycleTime.Name = "TempCycleTime"
        Me.TempCycleTime.Size = New System.Drawing.Size(55, 20)
        Me.TempCycleTime.TabIndex = 15
        Me.TempCycleTime.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.TempCycle
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(434, 505)
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
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jolo ASCOM Focuser Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.LCDTabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StepSizeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TempCompensation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccASCOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccManual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DutyCycleStop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DutyCycleRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TempCycleTime, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TempCycleTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents TempCompensation As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents COM1 As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DutyCycleRun As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StepSizeUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LCDTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DutyCycleStop As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown8 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ShowMonitorCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RedCFZ As System.Windows.Forms.Label
    Friend WithEvents GreenCFZ As System.Windows.Forms.Label
    Friend WithEvents BlueCFZ As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents AccASCOM As System.Windows.Forms.NumericUpDown
    Friend WithEvents AccManual As System.Windows.Forms.NumericUpDown
    Friend WithEvents BuzzerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LCD2ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LCD1ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LCDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LCD4ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents LCD3ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LCDOffCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown

End Class
