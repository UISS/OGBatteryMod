
Public Class Animate
    Public Property Control As Control
    Public Event AnimateComplate(ByVal sender As System.Object, ByVal e As AnimateComplateEvantArgs)
    Private ControlPicture As Bitmap
    Private HelperPicture1 As New PictureBox
    Private HelperPicture2 As New PictureBox
    Private HelperControl1 As Control
    Private HelperControl2 As Control
    Private m_Animate As Animates
    Private Is1st As Boolean = True
    Private WithEvents AnimateTimer As New Timer
    Public Properties As New Hashtable
    Dim img As Image


    Public Structure AnimateComplateEvantArgs
        Dim Animate As Animates
        Dim Control As Control
        Public Sub New(ByVal Animate As Animates, ByVal Control As Control)
            Me.Animate = Animate
            Me.Control = Control
        End Sub
    End Structure

    Public Sub New(ByVal Control As Control)
        Me.Control = Control
    End Sub

    Public Sub Animate(ByVal Animate As Animates, Optional ByVal Text As Integer = 20, Optional ByVal Speed As Integer = 20)
        Dim Bit As New Bitmap(Control.Width, Control.Height)
        Is1st = True
        m_Animate = Animate
        Control.DrawToBitmap(Bit, New Rectangle(0, 0, Control.Width, Control.Height))
        ControlPicture = Bit
        AnimateTimer = New Timer
        AnimateTimer.Interval = Speed
        AnimateTimer.Enabled = True
    End Sub

    Public Sub Animate(ByVal X As Integer, Optional ByVal Speed As Integer = 50)
        Is1st = True
        m_Animate = 51
        Properties("X") = X
        AnimateTimer = New Timer
        AnimateTimer.Interval = Speed
        AnimateTimer.Enabled = True
    End Sub

    Public Sub Animate(ByVal Width As Integer, ByVal ToLeft As Boolean, Optional ByVal Speed As Integer = 20)
        Is1st = True
        m_Animate = 50
        Properties("Width") = Width
        Properties("ToLeft") = ToLeft
        AnimateTimer = New Timer
        AnimateTimer.Interval = Speed
        AnimateTimer.Enabled = True
    End Sub

    Private Sub AnimateTimer_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles AnimateTimer.Disposed
        If ControlPicture IsNot Nothing Then ControlPicture.Dispose()
    End Sub

    Private Sub AnimateTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AnimateTimer.Tick
        Select Case m_Animate
            Case Animates.TopToDown
                If Is1st Then
                    Is1st = False
                    Control.Top = 0
                    Control.Visible = True
                Else
                    If Control.Top + 10 >= Control.Parent.Height Then
                        AnimateTimer.Dispose()
                        Control.Top = Control.Parent.Height + 1
                        Control.Visible = False
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Top += 10
                    End If
                End If
            Case Animates.DownToTop
                If Is1st Then
                    Is1st = False
                    Control.Top = Control.Parent.Height
                    Control.Visible = True
                Else
                    If Control.Top - 10 <= -Control.Height Then
                        AnimateTimer.Dispose()
                        Control.Top = -Control.Height
                        Control.Visible = False
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Top -= 10
                    End If
                End If
            Case Animates.RightToLeft
                If Is1st Then
                    Is1st = False
                    Control.Left = Control.Parent.Width
                    Control.Visible = True
                Else
                    If Control.Left - 10 <= -Control.Width Then
                        AnimateTimer.Dispose()
                        Control.Left = -Control.Width
                        Control.Visible = False
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Left -= 10
                    End If
                End If
            Case Animates.LeftToRight
                If Is1st Then
                    Is1st = False
                    Control.Left = 0
                    Control.Visible = True
                Else
                    If Control.Left + 10 >= Control.Parent.Width Then
                        AnimateTimer.Dispose()
                        Control.Left = Control.Parent.Width
                        Control.Visible = False
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Left += 10
                    End If
                End If
            Case Animates.FromTop
                If Is1st Then
                    Is1st = False
                    Properties("ControlTop") = Control.Top
                    Control.Top = -Control.Height
                    Control.Visible = True
                Else
                    If Control.Top + 10 >= Properties("ControlTop") Then
                        AnimateTimer.Dispose()
                        Control.Top = Properties("ControlTop")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Top += 10
                    End If
                End If
            Case Animates.FromDown
                If Is1st Then
                    Is1st = False
                    Properties("ControlTop") = Control.Top
                    Control.Top = Control.Parent.Height
                    Control.Visible = True
                Else
                    If Control.Top - 10 <= Properties("ControlTop") Then
                        AnimateTimer.Dispose()
                        Control.Top = Properties("ControlTop")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Top -= 10
                    End If
                End If
            Case Animates.FromRight
                If Is1st Then
                    Is1st = False
                    Properties("ControlLeft") = Control.Left
                    Control.Left = Control.Parent.Width
                    Control.Visible = True
                Else
                    If Control.Left - 10 <= Properties("ControlLeft") Then
                        AnimateTimer.Dispose()
                        Control.Left = Properties("ControlLeft")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Left -= 10
                    End If
                End If
            Case Animates.FromLeft
                If Is1st Then
                    Is1st = False
                    Properties("ControlLeft") = Control.Left
                    Control.Left = -Control.Width
                    Control.Visible = True
                Else
                    If Control.Left + 10 >= Properties("ControlLeft") Then
                        AnimateTimer.Dispose()
                        Control.Left = Properties("ControlLeft")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Left += 10
                    End If
                End If

            Case Animates.ToTop
                If Is1st Then
                    Is1st = False
                    Properties("ControlTop") = Control.Top
                Else
                    If Control.Top - 10 <= -Control.Height Then
                        AnimateTimer.Dispose()
                        Control.Top = -Control.Height - 5
                        Control.Visible = False
                        Control.Top = Properties("ControlTop")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Top -= 10
                    End If
                End If
            Case Animates.ToDown
                If Is1st Then
                    Is1st = False
                    Properties("ControlTop") = Control.Top
                Else
                    If Control.Top + 10 >= Control.Parent.Height Then
                        AnimateTimer.Dispose()
                        Control.Top = Control.Parent.Height + 5
                        Control.Visible = False
                        Control.Top = Properties("ControlTop")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Top += 10
                    End If
                End If
            Case Animates.ToRight
                If Is1st Then
                    Is1st = False
                    Properties("ControlLeft") = Control.Left
                Else
                    If Control.Left + 10 >= Control.Parent.Width + Control.Width Then
                        AnimateTimer.Dispose()
                        Control.Left = Control.Parent.Width + Control.Width + 5
                        Control.Visible = False
                        Control.Left = Properties("ControlLeft")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Left += 10
                    End If
                End If
            Case Animates.ToLeft
                If Is1st Then
                    Is1st = False
                    Properties("ControlLeft") = Control.Left
                Else
                    If Control.Left - 10 <= -Control.Width Then
                        AnimateTimer.Dispose()
                        Control.Left = -Control.Width - 5
                        Control.Visible = False
                        Control.Left = Properties("ControlLeft")
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Control.Left -= 10
                    End If
                End If
            Case Animates.HideFromRight
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Left += HelperControl1.Width
                    HelperControl1.Width = 0
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                Else
                    If HelperControl1.Width + 5 >= Control.Width Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        Control.Visible = False
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Left -= 5
                        HelperControl1.Width += 5
                    End If
                End If
            Case Animates.HideFromLeft
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Width = 0
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                Else
                    If HelperControl1.Width + 5 >= Control.Width Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        Control.Visible = False
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Width += 5
                    End If
                End If
            Case Animates.TranseveRight
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                    Control.Visible = True
                Else
                    If HelperControl1.Width - 5 <= 0 Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Width -= 5
                    End If
                End If
            Case Animates.TranseveLeft
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                    Control.Visible = True
                Else
                    If HelperControl1.Width - 5 <= 0 Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Left += 5
                        HelperControl1.Width -= 5
                    End If
                End If
            Case Animates.TranseveTop
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                    Control.Visible = True
                Else
                    If HelperControl1.Height - 5 <= 0 Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Top += 5
                        HelperControl1.Height -= 5
                    End If
                End If
            Case Animates.TranseveDown
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                    Control.Visible = True
                Else
                    If HelperControl1.Height - 5 <= 0 Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Height -= 5
                    End If
                End If
            Case Animates.TranseveCenter
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor
                    HelperControl2 = New PictureBox
                    Control.Parent.Controls.Add(HelperControl1)
                    Control.Parent.Controls.Add(HelperControl2)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl2.Bounds = Control.Bounds
                    HelperControl1.Width = Control.Width / 2
                    HelperControl2.Width = Control.Width / 2
                    HelperControl2.Left += Control.Width / 2
                    HelperControl1.Visible = True
                    HelperControl2.Visible = True
                    HelperControl1.BringToFront()
                    HelperControl2.BringToFront()
                    Control.Visible = True
                Else
                    If HelperControl1.Width - 4 <= 0 Then
                        AnimateTimer.Dispose()
                        HelperControl1.Dispose()
                        HelperControl2.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl2.Left += 4
                        HelperControl2.Width -= 4
                        HelperControl1.Width -= 4
                    End If
                End If
            Case Animates.HideFromCenter
                If Is1st Then
                    Is1st = False
                    HelperControl1 = New PictureBox : HelperControl1.BackColor = Control.BackColor

                    Control.Parent.Controls.Add(HelperControl1)
                    HelperControl1.Bounds = Control.Bounds
                    HelperControl1.Left += Control.Width / 2
                    HelperControl1.Width = 0
                    HelperControl1.Visible = True
                    HelperControl1.BringToFront()
                Else
                    If HelperControl1.Width + 8 >= Control.Width Then
                        AnimateTimer.Dispose()
                        Control.Visible = False
                        HelperControl1.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperControl1.Left -= 4
                        HelperControl1.Width += 8
                    End If
                End If

            Case Animates.Underline
                If Is1st Then
                    Is1st = False
                    HelperPicture1 = New PictureBox
                    HelperPicture2 = New PictureBox
                    Control.Parent.Controls.Add(HelperPicture1)
                    Control.Parent.Controls.Add(HelperPicture2)
                    HelperPicture1.Bounds = Control.Bounds
                    HelperPicture2.Bounds = Control.Bounds
                    HelperPicture1.Visible = True
                    HelperPicture2.Visible = True
                    HelperPicture1.Image = ControlPicture.Clone
                    Control.Font = New Font(Control.Font, Control.Font.Style Or FontStyle.Underline)
                    Control.DrawToBitmap(ControlPicture, New Rectangle(0, 0, Control.Width, Control.Height))
                    HelperPicture2.Image = ControlPicture
                    HelperPicture1.BringToFront()
                    HelperPicture2.BringToFront()
                    HelperPicture2.Width = 0
                Else
                    If HelperPicture2.Width + 5 >= HelperPicture1.Width Then
                        AnimateTimer.Dispose()
                        HelperPicture1.Dispose()
                        HelperPicture2.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        HelperPicture2.Width += 5
                    End If
                End If
            Case Animates.LitterLitter
                If Is1st Then
                    Is1st = False
                    If Properties("Text") = Nothing Then
                        Properties("Text") = Control.Text
                    End If
                    Properties("Index") = 1
                    Control.Text = Properties("Text").Substring(0, 1)
                    Control.Visible = True
                Else
                    If Properties("Index") = Properties("Text").ToString.Length Then
                        AnimateTimer.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Properties("Index") += 1
                        Control.Text = Properties("Text").Substring(0, Properties("Index"))
                    End If
                End If
            Case Animates.RemoveLitterLitter
                If Is1st Then
                    Is1st = False
                    If Properties("Text") = Nothing Then
                        Properties("Text") = Control.Text
                    End If
                    Properties("Index") = Control.Text.Length - 1
                    Control.Text = Properties("Text").Substring(0, Properties("Index"))
                    Control.Visible = True
                Else
                    If Properties("Index") = 0 Then
                        AnimateTimer.Dispose()
                        Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                        'Control.Visible = False
                        RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                    Else
                        Properties("Index") -= 1
                        Control.Text = Properties("Text").Substring(0, Properties("Index"))
                    End If
                End If
            Case 50
                If (Control.Width + 10 >= Properties("Width")) AndAlso (Control.Width - 10 <= Properties("Width")) Then
                    If Properties("ToLeft") = True Then Control.Left -= Properties("Width") - Control.Width
                    Control.Width = Properties("Width")

                    AnimateTimer.Dispose()
                    Dim AnimateComplateEvantArgs As New AnimateComplateEvantArgs(m_Animate, Control)
                    RaiseEvent AnimateComplate(Me, AnimateComplateEvantArgs)
                Else
                    If Control.Width > Properties("Width") Then
                        If Properties("ToLeft") = True Then Control.Left += 10 : Control.Width -= 10 Else Control.Width -= 10
                    Else
                        If Properties("ToLeft") = True Then Control.Left -= 10 : Control.Width += 10 Else Control.Width += 10
                        '     Control.Width += 10
                    End If
                End If
            Case 51
                If Is1st Then
                    Properties("ControlFont ") = Control.Font
                    Control.Left -= Properties("X")
                    Control.Width += Properties("X") * 2
                    Control.Top -= Properties("X")
                    Control.Height += Properties("X") * 2
                    Control.Font = New Font(Control.Font.FontFamily.Name, Control.Font.Size + Properties("X"), Control.Font.Style Or FontStyle.Bold)
                    Is1st = False
                Else
                    Control.Left += Properties("X")
                    Control.Width -= Properties("X") * 2
                    Control.Top += Properties("X")
                    Control.Height -= Properties("X") * 2
                    Control.Font = Properties("ControlFont ")
                    AnimateTimer.Dispose()
                End If
        End Select
    End Sub

End Class

Public Enum Animates
    TopToDown
    DownToTop
    RightToLeft
    LeftToRight
    FromTop
    FromDown
    FromRight
    FromLeft
    ToTop
    ToDown
    ToRight
    ToLeft
    TranseveRight
    TranseveLeft
    TranseveDown
    TranseveTop
    TranseveCenter
    HideFromCenter
    HideFromLeft
    HideFromRight
    LitterLitter
    RemoveLitterLitter
    Underline
End Enum