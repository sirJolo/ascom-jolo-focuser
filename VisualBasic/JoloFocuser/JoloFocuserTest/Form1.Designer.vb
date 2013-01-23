<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.buttonConnect = New System.Windows.Forms.Button
        Me.buttonChoose = New System.Windows.Forms.Button
        Me.labelDriverId = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buttonConnect
        '
        Me.buttonConnect.Location = New System.Drawing.Point(316, 36)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(72, 23)
        Me.buttonConnect.TabIndex = 4
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'buttonChoose
        '
        Me.buttonChoose.Location = New System.Drawing.Point(316, 7)
        Me.buttonChoose.Name = "buttonChoose"
        Me.buttonChoose.Size = New System.Drawing.Size(72, 23)
        Me.buttonChoose.TabIndex = 3
        Me.buttonChoose.Text = "Choose"
        Me.buttonChoose.UseVisualStyleBackColor = True
        '
        'labelDriverId
        '
        Me.labelDriverId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelDriverId.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ASCOM.JoloFocuser.My.MySettings.Default, "DriverId", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.labelDriverId.Location = New System.Drawing.Point(12, 37)
        Me.labelDriverId.Name = "labelDriverId"
        Me.labelDriverId.Size = New System.Drawing.Size(291, 21)
        Me.labelDriverId.TabIndex = 5
        Me.labelDriverId.Text = Global.ASCOM.JoloFocuser.My.MySettings.Default.DriverId
        Me.labelDriverId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(12, 94)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(166, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Set pos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(270, 94)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Read pos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 473)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.labelDriverId)
        Me.Controls.Add(Me.buttonConnect)
        Me.Controls.Add(Me.buttonChoose)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents labelDriverId As System.Windows.Forms.Label
    Private WithEvents buttonConnect As System.Windows.Forms.Button
    Private WithEvents buttonChoose As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
