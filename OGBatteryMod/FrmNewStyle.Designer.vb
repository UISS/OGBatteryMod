<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewStyle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewStyle))
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BtnOpen1 = New System.Windows.Forms.PictureBox()
        Me.TxtNormal = New System.Windows.Forms.TextBox()
        Me.LblNormal = New System.Windows.Forms.Label()
        Me.BtnOpen2 = New System.Windows.Forms.PictureBox()
        Me.TxtCharge = New System.Windows.Forms.TextBox()
        Me.LblCharge = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PicHelp2 = New System.Windows.Forms.PictureBox()
        Me.PicHelp1 = New System.Windows.Forms.PictureBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblCount1 = New System.Windows.Forms.Label()
        Me.LblCount2 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.BtnOpen1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnOpen2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicHelp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicHelp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnCancel.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(39, 209)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(130, 40)
        Me.BtnCancel.TabIndex = 20
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnOk.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOk.Location = New System.Drawing.Point(187, 209)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(130, 40)
        Me.BtnOk.TabIndex = 19
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnOpen1
        '
        Me.BtnOpen1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpen1.BackColor = System.Drawing.Color.Transparent
        Me.BtnOpen1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOpen1.Image = CType(resources.GetObject("BtnOpen1.Image"), System.Drawing.Image)
        Me.BtnOpen1.Location = New System.Drawing.Point(313, 100)
        Me.BtnOpen1.Name = "BtnOpen1"
        Me.BtnOpen1.Size = New System.Drawing.Size(32, 32)
        Me.BtnOpen1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BtnOpen1.TabIndex = 23
        Me.BtnOpen1.TabStop = False
        '
        'TxtNormal
        '
        Me.TxtNormal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNormal.BackColor = System.Drawing.Color.White
        Me.TxtNormal.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNormal.Location = New System.Drawing.Point(19, 103)
        Me.TxtNormal.Name = "TxtNormal"
        Me.TxtNormal.Size = New System.Drawing.Size(288, 25)
        Me.TxtNormal.TabIndex = 22
        '
        'LblNormal
        '
        Me.LblNormal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNormal.AutoEllipsis = True
        Me.LblNormal.AutoSize = True
        Me.LblNormal.BackColor = System.Drawing.Color.Transparent
        Me.LblNormal.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblNormal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNormal.Location = New System.Drawing.Point(13, 73)
        Me.LblNormal.Name = "LblNormal"
        Me.LblNormal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblNormal.Size = New System.Drawing.Size(193, 25)
        Me.LblNormal.TabIndex = 21
        Me.LblNormal.Text = "Normal icons Folder :"
        Me.LblNormal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnOpen2
        '
        Me.BtnOpen2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOpen2.BackColor = System.Drawing.Color.Transparent
        Me.BtnOpen2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOpen2.Image = CType(resources.GetObject("BtnOpen2.Image"), System.Drawing.Image)
        Me.BtnOpen2.Location = New System.Drawing.Point(313, 169)
        Me.BtnOpen2.Name = "BtnOpen2"
        Me.BtnOpen2.Size = New System.Drawing.Size(32, 32)
        Me.BtnOpen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.BtnOpen2.TabIndex = 26
        Me.BtnOpen2.TabStop = False
        '
        'TxtCharge
        '
        Me.TxtCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCharge.BackColor = System.Drawing.Color.White
        Me.TxtCharge.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCharge.Location = New System.Drawing.Point(19, 172)
        Me.TxtCharge.Name = "TxtCharge"
        Me.TxtCharge.Size = New System.Drawing.Size(288, 25)
        Me.TxtCharge.TabIndex = 25
        '
        'LblCharge
        '
        Me.LblCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCharge.AutoEllipsis = True
        Me.LblCharge.AutoSize = True
        Me.LblCharge.BackColor = System.Drawing.Color.Transparent
        Me.LblCharge.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblCharge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblCharge.Location = New System.Drawing.Point(13, 142)
        Me.LblCharge.Name = "LblCharge"
        Me.LblCharge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCharge.Size = New System.Drawing.Size(187, 25)
        Me.LblCharge.TabIndex = 24
        Me.LblCharge.Text = "Charge icons Folder :"
        Me.LblCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicHelp2
        '
        Me.PicHelp2.BackColor = System.Drawing.Color.Transparent
        Me.PicHelp2.Image = CType(resources.GetObject("PicHelp2.Image"), System.Drawing.Image)
        Me.PicHelp2.Location = New System.Drawing.Point(205, 143)
        Me.PicHelp2.Name = "PicHelp2"
        Me.PicHelp2.Size = New System.Drawing.Size(24, 24)
        Me.PicHelp2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicHelp2.TabIndex = 27
        Me.PicHelp2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicHelp2, "Select the folder that contains :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "stat_sys_battery_charge_anim***.png files")
        '
        'PicHelp1
        '
        Me.PicHelp1.BackColor = System.Drawing.Color.Transparent
        Me.PicHelp1.Image = CType(resources.GetObject("PicHelp1.Image"), System.Drawing.Image)
        Me.PicHelp1.Location = New System.Drawing.Point(205, 74)
        Me.PicHelp1.Name = "PicHelp1"
        Me.PicHelp1.Size = New System.Drawing.Size(24, 24)
        Me.PicHelp1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicHelp1.TabIndex = 27
        Me.PicHelp1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicHelp1, "Select the folder that contains :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "stat_sys_battery_***.png files")
        '
        'TxtName
        '
        Me.TxtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtName.BackColor = System.Drawing.Color.White
        Me.TxtName.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(20, 39)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(325, 25)
        Me.TxtName.TabIndex = 29
        '
        'LblName
        '
        Me.LblName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblName.AutoEllipsis = True
        Me.LblName.AutoSize = True
        Me.LblName.BackColor = System.Drawing.Color.Transparent
        Me.LblName.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblName.Location = New System.Drawing.Point(14, 9)
        Me.LblName.Name = "LblName"
        Me.LblName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblName.Size = New System.Drawing.Size(115, 25)
        Me.LblName.TabIndex = 28
        Me.LblName.Text = "Style name :"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCount1
        '
        Me.LblCount1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCount1.AutoEllipsis = True
        Me.LblCount1.BackColor = System.Drawing.Color.Transparent
        Me.LblCount1.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCount1.ForeColor = System.Drawing.Color.White
        Me.LblCount1.Location = New System.Drawing.Point(271, 80)
        Me.LblCount1.Name = "LblCount1"
        Me.LblCount1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCount1.Size = New System.Drawing.Size(32, 18)
        Me.LblCount1.TabIndex = 30
        Me.LblCount1.Text = "0"
        Me.LblCount1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.LblCount1, "Number of icons that found in selected folder")
        '
        'LblCount2
        '
        Me.LblCount2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCount2.AutoEllipsis = True
        Me.LblCount2.BackColor = System.Drawing.Color.Transparent
        Me.LblCount2.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCount2.ForeColor = System.Drawing.Color.White
        Me.LblCount2.Location = New System.Drawing.Point(271, 149)
        Me.LblCount2.Name = "LblCount2"
        Me.LblCount2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCount2.Size = New System.Drawing.Size(32, 18)
        Me.LblCount2.TabIndex = 31
        Me.LblCount2.Text = "0"
        Me.LblCount2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.LblCount2, "Number of icons that found in selected folder")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmNewStyle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(356, 258)
        Me.Controls.Add(Me.LblCount2)
        Me.Controls.Add(Me.LblCount1)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.PicHelp1)
        Me.Controls.Add(Me.PicHelp2)
        Me.Controls.Add(Me.BtnOpen2)
        Me.Controls.Add(Me.TxtCharge)
        Me.Controls.Add(Me.LblCharge)
        Me.Controls.Add(Me.BtnOpen1)
        Me.Controls.Add(Me.TxtNormal)
        Me.Controls.Add(Me.LblNormal)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNewStyle"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Style"
        CType(Me.BtnOpen1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnOpen2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicHelp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicHelp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnOpen1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtNormal As System.Windows.Forms.TextBox
    Friend WithEvents LblNormal As System.Windows.Forms.Label
    Friend WithEvents BtnOpen2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCharge As System.Windows.Forms.TextBox
    Friend WithEvents LblCharge As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PicHelp2 As System.Windows.Forms.PictureBox
    Friend WithEvents PicHelp1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents LblCount1 As System.Windows.Forms.Label
    Friend WithEvents LblCount2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
