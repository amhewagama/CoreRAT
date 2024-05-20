<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuild
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_build = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_generate = New System.Windows.Forms.Button()
        Me.tb_assemblyfileversion = New System.Windows.Forms.MaskedTextBox()
        Me.tb_assemblyversion = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_assemblytrademark = New System.Windows.Forms.TextBox()
        Me.tb_assemblycopyright = New System.Windows.Forms.TextBox()
        Me.tb_assemblyproduct = New System.Windows.Forms.TextBox()
        Me.tb_assemblycompany = New System.Windows.Forms.TextBox()
        Me.tb_assemblydescription = New System.Windows.Forms.TextBox()
        Me.tb_assemblytitle = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tb_ip = New System.Windows.Forms.ComboBox()
        Me.tb_mutex = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.btn_build)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 670)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.PictureBox1)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 439)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(230, 78)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Icon"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(65, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = " Drag & Drop"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.PictureBox1.Location = New System.Drawing.Point(9, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btn_build
        '
        Me.btn_build.Image = Global.coreRAT.My.Resources.Resources.arrow_270
        Me.btn_build.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_build.Location = New System.Drawing.Point(371, 579)
        Me.btn_build.Name = "btn_build"
        Me.btn_build.Size = New System.Drawing.Size(116, 48)
        Me.btn_build.TabIndex = 6
        Me.btn_build.Text = "Build EXE"
        Me.btn_build.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 537)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 121)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Log"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 20)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(326, 89)
        Me.TextBox1.TabIndex = 4
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_generate)
        Me.GroupBox5.Controls.Add(Me.tb_assemblyfileversion)
        Me.GroupBox5.Controls.Add(Me.tb_assemblyversion)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.tb_assemblytrademark)
        Me.GroupBox5.Controls.Add(Me.tb_assemblycopyright)
        Me.GroupBox5.Controls.Add(Me.tb_assemblyproduct)
        Me.GroupBox5.Controls.Add(Me.tb_assemblycompany)
        Me.GroupBox5.Controls.Add(Me.tb_assemblydescription)
        Me.GroupBox5.Controls.Add(Me.tb_assemblytitle)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 188)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(476, 237)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Assembly Information"
        '
        'btn_generate
        '
        Me.btn_generate.Location = New System.Drawing.Point(376, 193)
        Me.btn_generate.Name = "btn_generate"
        Me.btn_generate.Size = New System.Drawing.Size(88, 32)
        Me.btn_generate.TabIndex = 37
        Me.btn_generate.Text = "Generate"
        Me.btn_generate.UseVisualStyleBackColor = True
        '
        'tb_assemblyfileversion
        '
        Me.tb_assemblyfileversion.Location = New System.Drawing.Point(157, 205)
        Me.tb_assemblyfileversion.Mask = "0.0.0.0"
        Me.tb_assemblyfileversion.Name = "tb_assemblyfileversion"
        Me.tb_assemblyfileversion.Size = New System.Drawing.Size(132, 20)
        Me.tb_assemblyfileversion.TabIndex = 36
        Me.tb_assemblyfileversion.Text = "0000"
        '
        'tb_assemblyversion
        '
        Me.tb_assemblyversion.Location = New System.Drawing.Point(157, 179)
        Me.tb_assemblyversion.Mask = "0.0.0.0"
        Me.tb_assemblyversion.Name = "tb_assemblyversion"
        Me.tb_assemblyversion.Size = New System.Drawing.Size(132, 20)
        Me.tb_assemblyversion.TabIndex = 35
        Me.tb_assemblyversion.Text = "0000"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 208)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Assembly File Version: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 182)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Assembly Version: "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 156)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Assembly Trademark: "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Assembly Copyright: "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Assembly Product: "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Assembly Company: "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Assembly Description: "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Assembly Title: "
        '
        'tb_assemblytrademark
        '
        Me.tb_assemblytrademark.Location = New System.Drawing.Point(157, 153)
        Me.tb_assemblytrademark.Name = "tb_assemblytrademark"
        Me.tb_assemblytrademark.Size = New System.Drawing.Size(237, 20)
        Me.tb_assemblytrademark.TabIndex = 26
        '
        'tb_assemblycopyright
        '
        Me.tb_assemblycopyright.Location = New System.Drawing.Point(157, 127)
        Me.tb_assemblycopyright.Name = "tb_assemblycopyright"
        Me.tb_assemblycopyright.Size = New System.Drawing.Size(237, 20)
        Me.tb_assemblycopyright.TabIndex = 25
        '
        'tb_assemblyproduct
        '
        Me.tb_assemblyproduct.Location = New System.Drawing.Point(157, 101)
        Me.tb_assemblyproduct.Name = "tb_assemblyproduct"
        Me.tb_assemblyproduct.Size = New System.Drawing.Size(237, 20)
        Me.tb_assemblyproduct.TabIndex = 24
        '
        'tb_assemblycompany
        '
        Me.tb_assemblycompany.Location = New System.Drawing.Point(157, 75)
        Me.tb_assemblycompany.Name = "tb_assemblycompany"
        Me.tb_assemblycompany.Size = New System.Drawing.Size(237, 20)
        Me.tb_assemblycompany.TabIndex = 23
        '
        'tb_assemblydescription
        '
        Me.tb_assemblydescription.Location = New System.Drawing.Point(157, 49)
        Me.tb_assemblydescription.Name = "tb_assemblydescription"
        Me.tb_assemblydescription.Size = New System.Drawing.Size(237, 20)
        Me.tb_assemblydescription.TabIndex = 22
        '
        'tb_assemblytitle
        '
        Me.tb_assemblytitle.Location = New System.Drawing.Point(157, 23)
        Me.tb_assemblytitle.Name = "tb_assemblytitle"
        Me.tb_assemblytitle.Size = New System.Drawing.Size(237, 20)
        Me.tb_assemblytitle.TabIndex = 21
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDelay)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.tb_ip)
        Me.GroupBox1.Controls.Add(Me.tb_mutex)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Basic Info:"
        '
        'txtDelay
        '
        Me.txtDelay.Location = New System.Drawing.Point(106, 116)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(153, 20)
        Me.txtDelay.TabIndex = 26
        Me.txtDelay.Text = "5000"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(375, 79)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 22)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Generate"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tb_ip
        '
        Me.tb_ip.FormattingEnabled = True
        Me.tb_ip.Location = New System.Drawing.Point(106, 19)
        Me.tb_ip.Name = "tb_ip"
        Me.tb_ip.Size = New System.Drawing.Size(154, 21)
        Me.tb_ip.TabIndex = 24
        Me.tb_ip.Text = "127.0.0.1"
        '
        'tb_mutex
        '
        Me.tb_mutex.Location = New System.Drawing.Point(106, 81)
        Me.tb_mutex.Name = "tb_mutex"
        Me.tb_mutex.Size = New System.Drawing.Size(263, 20)
        Me.tb_mutex.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Delay (Secons): "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Mutex: "
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(106, 50)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(154, 20)
        Me.NumericUpDown2.TabIndex = 20
        Me.NumericUpDown2.Value = New Decimal(New Integer() {4440, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Port: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "IP/DNS: "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(253, 439)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(233, 78)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Source"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(38, 32)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "VB"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(102, 32)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "C#"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(166, 32)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "Java"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'frmBuild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 670)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmBuild"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client Build"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDelay As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tb_ip As System.Windows.Forms.ComboBox
    Friend WithEvents tb_mutex As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_generate As System.Windows.Forms.Button
    Friend WithEvents tb_assemblyfileversion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tb_assemblyversion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_assemblytrademark As System.Windows.Forms.TextBox
    Friend WithEvents tb_assemblycopyright As System.Windows.Forms.TextBox
    Friend WithEvents tb_assemblyproduct As System.Windows.Forms.TextBox
    Friend WithEvents tb_assemblycompany As System.Windows.Forms.TextBox
    Friend WithEvents tb_assemblydescription As System.Windows.Forms.TextBox
    Friend WithEvents tb_assemblytitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btn_build As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
