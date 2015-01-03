<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitorForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonitorForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.StopButton = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DewPoint = New System.Windows.Forms.Label
        Me.Humidity = New System.Windows.Forms.Label
        Me.Temperature = New System.Windows.Forms.Label
        Me.PositionMM = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PositionSteps = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.ADCLabel = New System.Windows.Forms.Label
        Me.OPTOLabel = New System.Windows.Forms.Label
        Me.PWM10 = New System.Windows.Forms.Label
        Me.PWM9 = New System.Windows.Forms.Label
        Me.PWM6 = New System.Windows.Forms.Label
        Me.SaveLogCheckBox = New System.Windows.Forms.CheckBox
        Me.AbsPosNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.RelPosUpDown = New System.Windows.Forms.NumericUpDown
        Me.ADC_CheckBox = New System.Windows.Forms.CheckBox
        Me.OPTO_CheckBox = New System.Windows.Forms.CheckBox
        Me.PWM_D10_ComboBox = New System.Windows.Forms.ComboBox
        Me.PWM_D9_ComboBox = New System.Windows.Forms.ComboBox
        Me.PWM_D6_ComboBox = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AbsPosNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RelPosUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(292, 182)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SaveLogCheckBox)
        Me.TabPage1.Controls.Add(Me.StopButton)
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.AbsPosNumericUpDown)
        Me.TabPage1.Controls.Add(Me.RelPosUpDown)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.DewPoint)
        Me.TabPage1.Controls.Add(Me.Humidity)
        Me.TabPage1.Controls.Add(Me.Temperature)
        Me.TabPage1.Controls.Add(Me.PositionMM)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PositionSteps)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(284, 156)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Monitor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(201, 69)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(74, 20)
        Me.StopButton.TabIndex = 27
        Me.StopButton.Text = "STOP"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(227, 97)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 49)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 26
        Me.PictureBox2.TabStop = False
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(244, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(31, 20)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "GO"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(255, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(166, 9)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "-"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Dew point"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Humidity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Temperature"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.Location = New System.Drawing.Point(119, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "C"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.Location = New System.Drawing.Point(119, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.Location = New System.Drawing.Point(120, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "C"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(119, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "mm"
        '
        'DewPoint
        '
        Me.DewPoint.BackColor = System.Drawing.SystemColors.Info
        Me.DewPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DewPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DewPoint.Location = New System.Drawing.Point(81, 110)
        Me.DewPoint.Name = "DewPoint"
        Me.DewPoint.Size = New System.Drawing.Size(38, 16)
        Me.DewPoint.TabIndex = 8
        Me.DewPoint.Text = "0.0"
        Me.DewPoint.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Humidity
        '
        Me.Humidity.BackColor = System.Drawing.SystemColors.Info
        Me.Humidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Humidity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Humidity.Location = New System.Drawing.Point(81, 88)
        Me.Humidity.Name = "Humidity"
        Me.Humidity.Size = New System.Drawing.Size(38, 16)
        Me.Humidity.TabIndex = 7
        Me.Humidity.Text = "0"
        Me.Humidity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Temperature
        '
        Me.Temperature.BackColor = System.Drawing.SystemColors.Info
        Me.Temperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Temperature.Location = New System.Drawing.Point(81, 65)
        Me.Temperature.Name = "Temperature"
        Me.Temperature.Size = New System.Drawing.Size(38, 16)
        Me.Temperature.TabIndex = 6
        Me.Temperature.Text = "0.0"
        Me.Temperature.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PositionMM
        '
        Me.PositionMM.BackColor = System.Drawing.SystemColors.Info
        Me.PositionMM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PositionMM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PositionMM.Location = New System.Drawing.Point(69, 29)
        Me.PositionMM.Name = "PositionMM"
        Me.PositionMM.Size = New System.Drawing.Size(50, 16)
        Me.PositionMM.TabIndex = 10
        Me.PositionMM.Text = "0.000"
        Me.PositionMM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(119, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "steps"
        '
        'PositionSteps
        '
        Me.PositionSteps.BackColor = System.Drawing.SystemColors.Info
        Me.PositionSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PositionSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PositionSteps.Location = New System.Drawing.Point(69, 8)
        Me.PositionSteps.Name = "PositionSteps"
        Me.PositionSteps.Size = New System.Drawing.Size(50, 16)
        Me.PositionSteps.TabIndex = 9
        Me.PositionSteps.Text = "0"
        Me.PositionSteps.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Position"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.ADCLabel)
        Me.TabPage2.Controls.Add(Me.OPTOLabel)
        Me.TabPage2.Controls.Add(Me.PWM10)
        Me.TabPage2.Controls.Add(Me.PWM9)
        Me.TabPage2.Controls.Add(Me.PWM6)
        Me.TabPage2.Controls.Add(Me.ADC_CheckBox)
        Me.TabPage2.Controls.Add(Me.OPTO_CheckBox)
        Me.TabPage2.Controls.Add(Me.PWM_D10_ComboBox)
        Me.TabPage2.Controls.Add(Me.PWM_D9_ComboBox)
        Me.TabPage2.Controls.Add(Me.PWM_D6_ComboBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(284, 156)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Control"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(227, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(225, 30)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 21)
        Me.Button4.TabIndex = 35
        Me.Button4.Text = "Setup"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(50, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 13)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "PWM outputs"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "ADC1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "OPTO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "D10"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "D9"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "D6"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label16.Location = New System.Drawing.Point(88, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(16, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label11.Location = New System.Drawing.Point(88, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "%"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label17.Location = New System.Drawing.Point(88, 82)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "%"
        '
        'ADCLabel
        '
        Me.ADCLabel.BackColor = System.Drawing.SystemColors.Info
        Me.ADCLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ADCLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ADCLabel.Location = New System.Drawing.Point(53, 34)
        Me.ADCLabel.Name = "ADCLabel"
        Me.ADCLabel.Size = New System.Drawing.Size(60, 16)
        Me.ADCLabel.TabIndex = 20
        Me.ADCLabel.Text = "0"
        Me.ADCLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'OPTOLabel
        '
        Me.OPTOLabel.BackColor = System.Drawing.SystemColors.Info
        Me.OPTOLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OPTOLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.OPTOLabel.Location = New System.Drawing.Point(53, 10)
        Me.OPTOLabel.Name = "OPTOLabel"
        Me.OPTOLabel.Size = New System.Drawing.Size(38, 16)
        Me.OPTOLabel.TabIndex = 19
        Me.OPTOLabel.Text = "OFF"
        Me.OPTOLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PWM10
        '
        Me.PWM10.BackColor = System.Drawing.SystemColors.Info
        Me.PWM10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PWM10.Location = New System.Drawing.Point(53, 131)
        Me.PWM10.Name = "PWM10"
        Me.PWM10.Size = New System.Drawing.Size(35, 16)
        Me.PWM10.TabIndex = 21
        Me.PWM10.Text = "0"
        Me.PWM10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PWM9
        '
        Me.PWM9.BackColor = System.Drawing.SystemColors.Info
        Me.PWM9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PWM9.Location = New System.Drawing.Point(53, 107)
        Me.PWM9.Name = "PWM9"
        Me.PWM9.Size = New System.Drawing.Size(35, 16)
        Me.PWM9.TabIndex = 23
        Me.PWM9.Text = "0"
        Me.PWM9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PWM6
        '
        Me.PWM6.BackColor = System.Drawing.SystemColors.Info
        Me.PWM6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PWM6.Location = New System.Drawing.Point(53, 81)
        Me.PWM6.Name = "PWM6"
        Me.PWM6.Size = New System.Drawing.Size(35, 16)
        Me.PWM6.TabIndex = 22
        Me.PWM6.Text = "0"
        Me.PWM6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SaveLogCheckBox
        '
        Me.SaveLogCheckBox.AutoSize = True
        Me.SaveLogCheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.SaveLog
        Me.SaveLogCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "SaveLog", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SaveLogCheckBox.Location = New System.Drawing.Point(11, 136)
        Me.SaveLogCheckBox.Name = "SaveLogCheckBox"
        Me.SaveLogCheckBox.Size = New System.Drawing.Size(96, 17)
        Me.SaveLogCheckBox.TabIndex = 28
        Me.SaveLogCheckBox.Text = "Save log to file"
        Me.SaveLogCheckBox.UseVisualStyleBackColor = True
        '
        'AbsPosNumericUpDown
        '
        Me.AbsPosNumericUpDown.DataBindings.Add(New System.Windows.Forms.Binding("Maximum", Global.ASCOM.JoloFocuser.My.MySettings.Default, "FocuserMax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AbsPosNumericUpDown.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "MonitorAbsolute", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AbsPosNumericUpDown.Location = New System.Drawing.Point(166, 39)
        Me.AbsPosNumericUpDown.Maximum = Global.ASCOM.JoloFocuser.My.MySettings.Default.FocuserMax
        Me.AbsPosNumericUpDown.Name = "AbsPosNumericUpDown"
        Me.AbsPosNumericUpDown.Size = New System.Drawing.Size(73, 20)
        Me.AbsPosNumericUpDown.TabIndex = 19
        Me.AbsPosNumericUpDown.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.MonitorAbsolute
        '
        'RelPosUpDown
        '
        Me.RelPosUpDown.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.ASCOM.JoloFocuser.My.MySettings.Default, "MonitorRelative", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RelPosUpDown.Location = New System.Drawing.Point(192, 9)
        Me.RelPosUpDown.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.RelPosUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RelPosUpDown.Name = "RelPosUpDown"
        Me.RelPosUpDown.Size = New System.Drawing.Size(58, 20)
        Me.RelPosUpDown.TabIndex = 19
        Me.RelPosUpDown.Value = Global.ASCOM.JoloFocuser.My.MySettings.Default.MonitorRelative
        '
        'ADC_CheckBox
        '
        Me.ADC_CheckBox.AutoSize = True
        Me.ADC_CheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.ADC_Read
        Me.ADC_CheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "ADC_Read", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ADC_CheckBox.Location = New System.Drawing.Point(133, 33)
        Me.ADC_CheckBox.Name = "ADC_CheckBox"
        Me.ADC_CheckBox.Size = New System.Drawing.Size(72, 17)
        Me.ADC_CheckBox.TabIndex = 34
        Me.ADC_CheckBox.Text = "ADC read"
        Me.ADC_CheckBox.UseVisualStyleBackColor = True
        '
        'OPTO_CheckBox
        '
        Me.OPTO_CheckBox.AutoSize = True
        Me.OPTO_CheckBox.Checked = Global.ASCOM.JoloFocuser.My.MySettings.Default.OPTO_On
        Me.OPTO_CheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.ASCOM.JoloFocuser.My.MySettings.Default, "OPTO_On", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.OPTO_CheckBox.Location = New System.Drawing.Point(133, 11)
        Me.OPTO_CheckBox.Name = "OPTO_CheckBox"
        Me.OPTO_CheckBox.Size = New System.Drawing.Size(73, 17)
        Me.OPTO_CheckBox.TabIndex = 34
        Me.OPTO_CheckBox.Text = "OPTO On"
        Me.OPTO_CheckBox.UseVisualStyleBackColor = True
        '
        'PWM_D10_ComboBox
        '
        Me.PWM_D10_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "PWM_10", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PWM_D10_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PWM_D10_ComboBox.FormattingEnabled = True
        Me.PWM_D10_ComboBox.Items.AddRange(New Object() {"0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "AUTO"})
        Me.PWM_D10_ComboBox.Location = New System.Drawing.Point(133, 129)
        Me.PWM_D10_ComboBox.Name = "PWM_D10_ComboBox"
        Me.PWM_D10_ComboBox.Size = New System.Drawing.Size(60, 21)
        Me.PWM_D10_ComboBox.TabIndex = 33
        Me.PWM_D10_ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.PWM_10
        '
        'PWM_D9_ComboBox
        '
        Me.PWM_D9_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "PWM_9", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PWM_D9_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PWM_D9_ComboBox.FormattingEnabled = True
        Me.PWM_D9_ComboBox.Items.AddRange(New Object() {"0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "AUTO"})
        Me.PWM_D9_ComboBox.Location = New System.Drawing.Point(133, 104)
        Me.PWM_D9_ComboBox.Name = "PWM_D9_ComboBox"
        Me.PWM_D9_ComboBox.Size = New System.Drawing.Size(60, 21)
        Me.PWM_D9_ComboBox.TabIndex = 33
        Me.PWM_D9_ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.PWM_9
        '
        'PWM_D6_ComboBox
        '
        Me.PWM_D6_ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "PWM_6", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PWM_D6_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PWM_D6_ComboBox.FormattingEnabled = True
        Me.PWM_D6_ComboBox.Items.AddRange(New Object() {"0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "AUTO"})
        Me.PWM_D6_ComboBox.Location = New System.Drawing.Point(133, 79)
        Me.PWM_D6_ComboBox.Name = "PWM_D6_ComboBox"
        Me.PWM_D6_ComboBox.Size = New System.Drawing.Size(60, 21)
        Me.PWM_D6_ComboBox.TabIndex = 33
        Me.PWM_D6_ComboBox.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.PWM_6
        '
        'MonitorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 185)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MonitorForm"
        Me.Text = "Jolo Focuser Monitor"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AbsPosNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RelPosUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DewPoint As System.Windows.Forms.Label
    Friend WithEvents Humidity As System.Windows.Forms.Label
    Friend WithEvents Temperature As System.Windows.Forms.Label
    Friend WithEvents PositionMM As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PositionSteps As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PWM_D6_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ADCLabel As System.Windows.Forms.Label
    Friend WithEvents OPTOLabel As System.Windows.Forms.Label
    Friend WithEvents PWM10 As System.Windows.Forms.Label
    Friend WithEvents PWM9 As System.Windows.Forms.Label
    Friend WithEvents PWM6 As System.Windows.Forms.Label
    Friend WithEvents PWM_D10_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PWM_D9_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents OPTO_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ADC_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RelPosUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents AbsPosNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents SaveLogCheckBox As System.Windows.Forms.CheckBox
End Class
