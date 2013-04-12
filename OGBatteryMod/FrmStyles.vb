Imports System.Linq

Public Class FrmStyles
    Dim T As Integer = 59
    Dim L As Integer = 14
    Private Sub FrmStyles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim NewStyle As New FrmNewStyle
        If NewStyle.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Control As CStyle = New CStyle
            Dim Name As String = NewStyle.TxtName.Text
            Control.StyleName = Name
            My.Computer.FileSystem.CreateDirectory("Styles\" & Name)
            For N = 0 To 100
                If My.Computer.FileSystem.FileExists(NewStyle.TxtNormal.Text & "stat_sys_battery_" & N & ".png") Then
                    Dim File As String = NewStyle.TxtNormal.Text & "stat_sys_battery_" & N & ".png"
                    My.Computer.FileSystem.CopyFile(File, "Styles\" & Name & "\stat_sys_battery_" & N & ".png")
                    Control.NormalIcons.Add("Styles\" & Name & "\stat_sys_battery_" & N & ".png")
                End If
                If My.Computer.FileSystem.FileExists(NewStyle.TxtCharge.Text & "stat_sys_battery_charge_anim" & N & ".png") Then
                    Dim File As String = NewStyle.TxtNormal.Text & "stat_sys_battery_charge_anim" & N & ".png"
                    My.Computer.FileSystem.CopyFile(File, "Styles\" & Name & "\stat_sys_battery_charge_anim" & N & ".png")
                    Control.ChargeIcons.Add("Styles\" & Name & "\stat_sys_battery_charge_anim" & N & ".png")
                End If
            Next
            Control.PicNormal.Image = Image.FromFile(Control.NormalIcons(Control.NormalIcons.Count / 2))
            Control.PicCharge.Image = Image.FromFile(Control.ChargeIcons(Control.ChargeIcons.Count / 2))
            Control.Left = L
            Control.Top = T
            L += 210 + 6
            If L > 500 Then
                L = 14
                T += 100 + 6
            End If
            Me.Controls.Add(Control)
        End If
    End Sub

    Private Sub FrmStyles_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Bounds As New Rectangle
        Bounds.X = Me.Width / 2 - PictureBox1.Image.Width / 2
        Bounds.Y = Me.Height / 2 - PictureBox1.Image.Height / 2
        Bounds.Width = PictureBox1.Image.Width
        Bounds.Height = PictureBox1.Image.Height
        e.Graphics.DrawImage(PictureBox1.Image, Bounds)
    End Sub

    Private Sub FrmStyles_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll
        Me.Invalidate()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim Styles As New List(Of String)
        For Each Control As CStyle In (From Ctl As Control In Me.Controls Select Ctl Where Ctl.GetType = GetType(CStyle))
            If Control.Checked Then
                Styles.Add(Control.StyleName)
            End If
        Next
        FrmMain.StylesChanged = True
        FrmMain.Styles = Styles
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim Folders = My.Computer.FileSystem.GetDirectories("Styles", FileIO.SearchOption.SearchTopLevelOnly)
        For I = 0 To Folders.Count - 1
            Dim Folder As String = Folders(I).Replace(Application.StartupPath & "\Styles\", "")
            Dim Control As CStyle = New CStyle
            Control.StyleName = Folder
            For N = 0 To 100
                If My.Computer.FileSystem.FileExists("Styles\" & Folder & "\stat_sys_battery_" & Folder.Replace(" ", "_").ToLower & "_" & N & ".png") Then
                    Control.NormalIcons.Add("Styles\" & Folder & "\stat_sys_battery_" & Folder.Replace(" ", "_").ToLower & "_" & N & ".png")
                ElseIf My.Computer.FileSystem.FileExists("Styles\" & Folder & "\stat_sys_battery_" & N & ".png") Then
                    Control.NormalIcons.Add("Styles\" & Folder & "\stat_sys_battery_" & N & ".png")
                End If
                If My.Computer.FileSystem.FileExists("Styles\" & Folder & "\stat_sys_battery_" & Folder.Replace(" ", "_").ToLower & "_charge_anim" & N & ".png") Then
                    Control.ChargeIcons.Add("Styles\" & Folder & "\stat_sys_battery_" & Folder.Replace(" ", "_").ToLower & "_charge_anim" & N & ".png")
                ElseIf My.Computer.FileSystem.FileExists("Styles\" & Folder & "\stat_sys_battery_charge_anim" & N & ".png") Then
                    Control.ChargeIcons.Add("Styles\" & Folder & "\stat_sys_battery_charge_anim" & N & ".png")
                End If
            Next
            Try
                If FrmMain.StylesChanged Then
                    If FrmMain.Styles.Contains(Folder) Then Control.Checked = True Else Control.Checked = False
                Else
                    Control.Checked = True
                End If
                Control.PicNormal.Image = Image.FromFile(Control.NormalIcons(Control.NormalIcons.Count / 2))
                Control.PicCharge.Image = Image.FromFile(Control.ChargeIcons(Control.ChargeIcons.Count / 2))
                Control.Left = L
                Control.Top = T
                L += 210 + 6
                If L > 500 Then
                    L = 14
                    T += 100 + 6
                End If
                Me.Invoke(Sub()
                              Me.Controls.Add(Control)
                          End Sub)

            Catch ex As Exception

            End Try
        Next
    End Sub
End Class