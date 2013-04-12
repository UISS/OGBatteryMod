<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFiles
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFiles))
        Me.LblSys = New System.Windows.Forms.Label()
        Me.LblSet = New System.Windows.Forms.Label()
        Me.LblFR = New System.Windows.Forms.Label()
        Me.TxtSystemUI = New System.Windows.Forms.TextBox()
        Me.BtnOpen1 = New System.Windows.Forms.PictureBox()
        Me.BtnOpen2 = New System.Windows.Forms.PictureBox()
        Me.TxtSettings = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PicInfo1 = New System.Windows.Forms.PictureBox()
        Me.PicInfo2 = New System.Windows.Forms.PictureBox()
        Me.BtnOpen3 = New System.Windows.Forms.PictureBox()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtFwRs = New System.Windows.Forms.TextBox()
        Me.LblVer = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.BtnOpen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOpen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicInfo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOpen3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblSys
        '
        Me.LblSys.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSys.AutoEllipsis = True
        Me.LblSys.AutoSize = True
        Me.LblSys.BackColor = System.Drawing.Color.Transparent
        Me.LblSys.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblSys.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblSys.Location = New System.Drawing.Point(12, 66)
        Me.LblSys.Name = "LblSys"
        Me.LblSys.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblSys.Size = New System.Drawing.Size(144, 25)
        Me.LblSys.TabIndex = 2
        Me.LblSys.Text = "SystemUI.apk :"
        Me.LblSys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSet
        '
        Me.LblSet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSet.AutoEllipsis = True
        Me.LblSet.AutoSize = True
        Me.LblSet.BackColor = System.Drawing.Color.Transparent
        Me.LblSet.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblSet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblSet.Location = New System.Drawing.Point(12, 127)
        Me.LblSet.Name = "LblSet"
        Me.LblSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblSet.Size = New System.Drawing.Size(129, 25)
        Me.LblSet.TabIndex = 3
        Me.LblSet.Text = "Settings.apk :"
        Me.LblSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblFR
        '
        Me.LblFR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFR.AutoEllipsis = True
        Me.LblFR.AutoSize = True
        Me.LblFR.BackColor = System.Drawing.Color.Transparent
        Me.LblFR.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblFR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblFR.Location = New System.Drawing.Point(12, 187)
        Me.LblFR.Name = "LblFR"
        Me.LblFR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblFR.Size = New System.Drawing.Size(266, 25)
        Me.LblFR.TabIndex = 4
        Me.LblFR.Text = "Framework && Resource Files :"
        Me.LblFR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSystemUI
        '
        Me.TxtSystemUI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSystemUI.BackColor = System.Drawing.Color.White
        Me.TxtSystemUI.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSystemUI.Location = New System.Drawing.Point(18, 96)
        Me.TxtSystemUI.Name = "TxtSystemUI"
        Me.TxtSystemUI.ReadOnly = True
        Me.TxtSystemUI.Size = New System.Drawing.Size(401, 25)
        Me.TxtSystemUI.TabIndex = 6
        '
        'BtnOpen1
        '
        Me.BtnOpen1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpen1.BackColor = System.Drawing.Color.Transparent
        Me.BtnOpen1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOpen1.Image = CType(resources.GetObject("BtnOpen1.Image"), System.Drawing.Image)
        Me.BtnOpen1.Location = New System.Drawing.Point(427, 92)
        Me.BtnOpen1.Name = "BtnOpen1"
        Me.BtnOpen1.Size = New System.Drawing.Size(32, 32)
        Me.BtnOpen1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BtnOpen1.TabIndex = 7
        Me.BtnOpen1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnOpen1, "Browse...")
        '
        'BtnOpen2
        '
        Me.BtnOpen2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpen2.BackColor = System.Drawing.Color.Transparent
        Me.BtnOpen2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOpen2.Image = CType(resources.GetObject("BtnOpen2.Image"), System.Drawing.Image)
        Me.BtnOpen2.Location = New System.Drawing.Point(427, 151)
        Me.BtnOpen2.Name = "BtnOpen2"
        Me.BtnOpen2.Size = New System.Drawing.Size(32, 32)
        Me.BtnOpen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BtnOpen2.TabIndex = 9
        Me.BtnOpen2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnOpen2, "Browse...")
        '
        'TxtSettings
        '
        Me.TxtSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSettings.BackColor = System.Drawing.Color.White
        Me.TxtSettings.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSettings.Location = New System.Drawing.Point(18, 155)
        Me.TxtSettings.Name = "TxtSettings"
        Me.TxtSettings.ReadOnly = True
        Me.TxtSettings.Size = New System.Drawing.Size(401, 25)
        Me.TxtSettings.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoEllipsis = True
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(162, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(0, 25)
        Me.Label3.TabIndex = 14
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicInfo1
        '
        Me.PicInfo1.BackColor = System.Drawing.Color.Transparent
        Me.PicInfo1.Image = CType(resources.GetObject("PicInfo1.Image"), System.Drawing.Image)
        Me.PicInfo1.Location = New System.Drawing.Point(147, 128)
        Me.PicInfo1.Name = "PicInfo1"
        Me.PicInfo1.Size = New System.Drawing.Size(24, 24)
        Me.PicInfo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicInfo1.TabIndex = 15
        Me.PicInfo1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicInfo1, "Needed if you want to add BatteryStyle option in 'Settings >> Display'")
        '
        'PicInfo2
        '
        Me.PicInfo2.BackColor = System.Drawing.Color.Transparent
        Me.PicInfo2.Image = CType(resources.GetObject("PicInfo2.Image"), System.Drawing.Image)
        Me.PicInfo2.Location = New System.Drawing.Point(284, 187)
        Me.PicInfo2.Name = "PicInfo2"
        Me.PicInfo2.Size = New System.Drawing.Size(24, 24)
        Me.PicInfo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicInfo2.TabIndex = 16
        Me.PicInfo2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicInfo2, "All files in '/system/framework/' folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Framework : Not needed if your files al" & _
                "ready deodexed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Resources : Not needed if you already installed it")
        '
        'BtnOpen3
        '
        Me.BtnOpen3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpen3.BackColor = System.Drawing.Color.Transparent
        Me.BtnOpen3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOpen3.Image = CType(resources.GetObject("BtnOpen3.Image"), System.Drawing.Image)
        Me.BtnOpen3.Location = New System.Drawing.Point(426, 214)
        Me.BtnOpen3.Name = "BtnOpen3"
        Me.BtnOpen3.Size = New System.Drawing.Size(32, 32)
        Me.BtnOpen3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BtnOpen3.TabIndex = 20
        Me.BtnOpen3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.BtnOpen3, "Browse...")
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnOk.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOk.Location = New System.Drawing.Point(243, 251)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(130, 40)
        Me.BtnOk.TabIndex = 17
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnCancel.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(95, 251)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(130, 40)
        Me.BtnCancel.TabIndex = 18
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TxtFwRs
        '
        Me.TxtFwRs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFwRs.BackColor = System.Drawing.Color.White
        Me.TxtFwRs.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFwRs.Location = New System.Drawing.Point(17, 218)
        Me.TxtFwRs.Name = "TxtFwRs"
        Me.TxtFwRs.ReadOnly = True
        Me.TxtFwRs.Size = New System.Drawing.Size(401, 25)
        Me.TxtFwRs.TabIndex = 19
        '
        'LblVer
        '
        Me.LblVer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblVer.AutoEllipsis = True
        Me.LblVer.AutoSize = True
        Me.LblVer.BackColor = System.Drawing.Color.Transparent
        Me.LblVer.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblVer.Location = New System.Drawing.Point(7, 9)
        Me.LblVer.Name = "LblVer"
        Me.LblVer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblVer.Size = New System.Drawing.Size(160, 25)
        Me.LblVer.TabIndex = 21
        Me.LblVer.Text = "Android Version :"
        Me.LblVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Android 2.3–2.3.2 Gingerbread (API level 9)", "Android 2.3.3–2.3.7 Gingerbread (API level 10)", "Android 3.0 Honeycomb (API level 11)", "Android 3.1 Honeycomb (API level 12)", "Android 3.2 Honeycomb (API level 13)", "Android 4.0–4.0.2 Ice Cream Sandwich (API level 14)", "Android 4.0.3–4.0.4 Ice Cream Sandwich (API level 15)", "Android 4.1 Jelly Bean (API level 16)", "Android 4.2 Jelly Bean (API level 17)"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 37)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(446, 26)
        Me.ComboBox1.TabIndex = 22
        '
        'FrmFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(469, 301)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.LblVer)
        Me.Controls.Add(Me.BtnOpen3)
        Me.Controls.Add(Me.TxtFwRs)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.PicInfo2)
        Me.Controls.Add(Me.PicInfo1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnOpen2)
        Me.Controls.Add(Me.TxtSettings)
        Me.Controls.Add(Me.BtnOpen1)
        Me.Controls.Add(Me.TxtSystemUI)
        Me.Controls.Add(Me.LblFR)
        Me.Controls.Add(Me.LblSet)
        Me.Controls.Add(Me.LblSys)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFiles"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Files"
        CType(Me.BtnOpen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOpen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicInfo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOpen3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblSys As System.Windows.Forms.Label
    Friend WithEvents LblSet As System.Windows.Forms.Label
    Friend WithEvents LblFR As System.Windows.Forms.Label
    Friend WithEvents TxtSystemUI As System.Windows.Forms.TextBox
    Friend WithEvents BtnOpen1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnOpen2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtSettings As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PicInfo1 As System.Windows.Forms.PictureBox
    Friend WithEvents PicInfo2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtnOpen3 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtFwRs As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents LblVer As System.Windows.Forms.Label
End Class
