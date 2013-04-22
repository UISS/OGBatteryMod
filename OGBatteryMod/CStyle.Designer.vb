<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CStyle
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CStyle))
        Me.PicNormal = New System.Windows.Forms.PictureBox()
        Me.PicCharge = New System.Windows.Forms.PictureBox()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TmrNormal = New System.Windows.Forms.Timer(Me.components)
        Me.TmrCharge = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PicNormal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicNormal
        '
        Me.PicNormal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PicNormal.Location = New System.Drawing.Point(61, 28)
        Me.PicNormal.Name = "PicNormal"
        Me.PicNormal.Size = New System.Drawing.Size(68, 68)
        Me.PicNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicNormal.TabIndex = 0
        Me.PicNormal.TabStop = False
        '
        'PicCharge
        '
        Me.PicCharge.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PicCharge.Location = New System.Drawing.Point(135, 28)
        Me.PicCharge.Name = "PicCharge"
        Me.PicCharge.Size = New System.Drawing.Size(68, 68)
        Me.PicCharge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicCharge.TabIndex = 1
        Me.PicCharge.TabStop = False
        '
        'LblTitle
        '
        Me.LblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTitle.BackColor = System.Drawing.Color.Transparent
        Me.LblTitle.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblTitle.Size = New System.Drawing.Size(210, 25)
        Me.LblTitle.TabIndex = 3
        Me.LblTitle.Text = "Name"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "btn_check_off_holo_dark.png")
        Me.ImageList1.Images.SetKeyName(1, "btn_check_off_pressed_holo_dark.png")
        Me.ImageList1.Images.SetKeyName(2, "btn_check_on_holo_dark.png")
        Me.ImageList1.Images.SetKeyName(3, "btn_check_on_pressed_holo_dark.png")
        Me.ImageList1.Images.SetKeyName(4, "btn_check_off_focused_holo_dark.png")
        Me.ImageList1.Images.SetKeyName(5, "btn_check_on_focused_holo_dark.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'TmrNormal
        '
        Me.TmrNormal.Interval = 40
        '
        'TmrCharge
        '
        Me.TmrCharge.Interval = 40
        '
        'CStyle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblTitle)
        Me.Controls.Add(Me.PicCharge)
        Me.Controls.Add(Me.PicNormal)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "CStyle"
        Me.Size = New System.Drawing.Size(210, 100)
        CType(Me.PicNormal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCharge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PicNormal As System.Windows.Forms.PictureBox
    Friend WithEvents PicCharge As System.Windows.Forms.PictureBox
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Private WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TmrNormal As System.Windows.Forms.Timer
    Friend WithEvents TmrCharge As System.Windows.Forms.Timer

End Class
