Imports System.ComponentModel

Public Class CStyle
    Dim IsHover As Boolean = False
    Dim IsDown As Boolean = False
    Private _Checked As Boolean = True
    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
     InitializeComponent()
    End Sub

    <DefaultValue(True)>
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            UpdateImage()
        End Set
    End Property

    Public Property StyleName As String
        Get
            Return LblTitle.Text
        End Get
        Set(ByVal value As String)
            LblTitle.Text = value
        End Set
    End Property

    Private _NormalIcons As New List(Of String)
    Public Property NormalIcons As List(Of String)
        Get
            Return _NormalIcons
        End Get
        Set(ByVal value As List(Of String))
            _NormalIcons = value
        End Set
    End Property

    Private _ChargeIcons As New List(Of String)
    Public Property ChargeIcons As List(Of String)
        Get
            Return _ChargeIcons
        End Get
        Set(ByVal value As List(Of String))
            _ChargeIcons = value
        End Set
    End Property

    Private Sub CStyle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        IsHover = True
        UpdateImage()
    End Sub

    Private Sub CStyle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        IsHover = False
        UpdateImage()
    End Sub

    Private Sub CStyle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Or e.KeyCode = Keys.Enter Then
            Checked = Not Checked
            UpdateImage()
        End If
    End Sub

    Private Sub CStyle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateImage()
    End Sub

    Private Sub CStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, LblTitle.Click, PicNormal.Click, PicCharge.Click, PictureBox1.Click
        If Me.Parent IsNot Nothing Then
            On Error Resume Next
            Me.Parent.Select()
            TryCast(Me.Parent, Object).ScrollControlIntoView(Me)
        End If
        Checked = Not Checked
        UpdateImage()
    End Sub

    Private Sub CStyle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, LblTitle.MouseDown, PicNormal.MouseDown, PicCharge.MouseDown, PictureBox1.MouseDown
        IsDown = True
        UpdateImage()
    End Sub

    Private Sub CStyle_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, LblTitle.MouseLeave, PicNormal.MouseLeave, PicCharge.MouseLeave, PictureBox1.MouseLeave
        IsHover = False
        UpdateImage()
        TmrCharge.Enabled = False
        TmrNormal.Enabled = False
        If Me.PointToClient(MousePosition).X <= 0 OrElse Me.PointToClient(MousePosition).X >= Me.Width OrElse _
            Me.PointToClient(MousePosition).Y <= 0 OrElse Me.PointToClient(MousePosition).Y >= Me.Height Then
            PicNormal.Image = Image.FromFile(NormalIcons(NormalIcons.Count / 2))
            PicCharge.Image = Image.FromFile(ChargeIcons(ChargeIcons.Count / 2))
        End If
    End Sub

    Private Sub CStyle_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, LblTitle.MouseMove, PicNormal.MouseMove, PicCharge.MouseMove, PictureBox1.MouseMove
        If Not IsHover And Not IsDown Then UpdateImage()
        IsHover = True
        UpdateImage()
        TmrCharge.Enabled = True
        TmrNormal.Enabled = True
    End Sub

    Private Sub CStyle_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, LblTitle.MouseUp, PicNormal.MouseUp, PicCharge.MouseUp, PictureBox1.MouseUp
        IsDown = False
        UpdateImage()
    End Sub

    Private Sub UpdateImage()
        If Checked Then
            If IsDown Then
                PictureBox1.Image = ImageList1.Images(3)
            Else
                If IsHover Then
                    PictureBox1.Image = ImageList1.Images(5)
                Else
                    PictureBox1.Image = ImageList1.Images(2)
                End If
            End If
        Else
            If IsDown Then
                PictureBox1.Image = ImageList1.Images(1)
            Else
                If IsHover Then
                    PictureBox1.Image = ImageList1.Images(4)
                Else
                    PictureBox1.Image = ImageList1.Images(0)
                End If
            End If
        End If
    End Sub

    Dim Id1 As Integer = 0
    Private Sub TmrNormal_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrNormal.Tick
        If Not Me.DesignMode Then
            If NormalIcons.Count > 0 Then
                If PicNormal.Image IsNot Nothing Then PicNormal.Image.Dispose()
                PicNormal.Image = Image.FromFile(NormalIcons(Id1))
                Id1 += 1
                If Id1 >= NormalIcons.Count Then Id1 = 0
            Else
                PicNormal.Image = Nothing
            End If
        End If
    End Sub

    Dim Id2 As Integer = 0
    Private Sub TmrCharge_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrCharge.Tick
        If Not Me.DesignMode Then
            If ChargeIcons.Count > 0 Then
                If PicCharge.Image IsNot Nothing Then PicCharge.Image.Dispose()
                PicCharge.Image = Image.FromFile(ChargeIcons(Id2))
                Id2 += 1
                If Id2 >= ChargeIcons.Count Then Id2 = 0
            Else
                PicCharge.Image = Nothing
            End If
        End If
    End Sub

End Class
