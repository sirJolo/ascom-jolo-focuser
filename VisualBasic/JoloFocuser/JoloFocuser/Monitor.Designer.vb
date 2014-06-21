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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
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
        Me.Label15 = New System.Windows.Forms.Label
        Me.PWM = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.OPTO = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(292, 163)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.DewPoint)
        Me.TabPage1.Controls.Add(Me.Humidity)
        Me.TabPage1.Controls.Add(Me.OPTO)
        Me.TabPage1.Controls.Add(Me.PWM)
        Me.TabPage1.Controls.Add(Me.Temperature)
        Me.TabPage1.Controls.Add(Me.PositionMM)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PositionSteps)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(284, 137)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Monitor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(284, 169)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Control"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Dew point"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Humidity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Temperature"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label14.Location = New System.Drawing.Point(125, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "C"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label13.Location = New System.Drawing.Point(125, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label12.Location = New System.Drawing.Point(126, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "C"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label5.Location = New System.Drawing.Point(125, 29)
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
        Me.DewPoint.Location = New System.Drawing.Point(87, 114)
        Me.DewPoint.Name = "DewPoint"
        Me.DewPoint.Size = New System.Drawing.Size(38, 16)
        Me.DewPoint.TabIndex = 8
        Me.DewPoint.Text = "-19.2"
        Me.DewPoint.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Humidity
        '
        Me.Humidity.BackColor = System.Drawing.SystemColors.Info
        Me.Humidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Humidity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Humidity.Location = New System.Drawing.Point(87, 92)
        Me.Humidity.Name = "Humidity"
        Me.Humidity.Size = New System.Drawing.Size(38, 16)
        Me.Humidity.TabIndex = 7
        Me.Humidity.Text = "78"
        Me.Humidity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Temperature
        '
        Me.Temperature.BackColor = System.Drawing.SystemColors.Info
        Me.Temperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Temperature.Location = New System.Drawing.Point(87, 69)
        Me.Temperature.Name = "Temperature"
        Me.Temperature.Size = New System.Drawing.Size(38, 16)
        Me.Temperature.TabIndex = 6
        Me.Temperature.Text = "-12.3"
        Me.Temperature.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PositionMM
        '
        Me.PositionMM.BackColor = System.Drawing.SystemColors.Info
        Me.PositionMM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PositionMM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PositionMM.Location = New System.Drawing.Point(75, 29)
        Me.PositionMM.Name = "PositionMM"
        Me.PositionMM.Size = New System.Drawing.Size(50, 16)
        Me.PositionMM.TabIndex = 10
        Me.PositionMM.Text = "12.334"
        Me.PositionMM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(125, 9)
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
        Me.PositionSteps.Location = New System.Drawing.Point(75, 8)
        Me.PositionSteps.Name = "PositionSteps"
        Me.PositionSteps.Size = New System.Drawing.Size(50, 16)
        Me.PositionSteps.TabIndex = 9
        Me.PositionSteps.Text = "3788"
        Me.PositionSteps.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Position"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(166, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "PWM"
        '
        'PWM
        '
        Me.PWM.BackColor = System.Drawing.SystemColors.Info
        Me.PWM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PWM.Location = New System.Drawing.Point(206, 68)
        Me.PWM.Name = "PWM"
        Me.PWM.Size = New System.Drawing.Size(35, 16)
        Me.PWM.TabIndex = 6
        Me.PWM.Text = "60"
        Me.PWM.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label17.Location = New System.Drawing.Point(241, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "%"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(166, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "OPTO"
        '
        'OPTO
        '
        Me.OPTO.BackColor = System.Drawing.SystemColors.Info
        Me.OPTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.OPTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.OPTO.Location = New System.Drawing.Point(206, 92)
        Me.OPTO.Name = "OPTO"
        Me.OPTO.Size = New System.Drawing.Size(35, 16)
        Me.OPTO.TabIndex = 6
        Me.OPTO.Text = "OFF"
        Me.OPTO.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MonitorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 169)
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
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents OPTO As System.Windows.Forms.Label
    Friend WithEvents PWM As System.Windows.Forms.Label
End Class
