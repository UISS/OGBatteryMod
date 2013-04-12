Public Class FrmFiles

    Private Sub BtnOpen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen1.Click
        Dim Open As New OpenFileDialog
        Open.Filter = "Android Packages(*.apk)|*.apk"
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtSystemUI.Text = Open.FileName
        End If
    End Sub

    Private Sub BtnOpen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen2.Click
        Dim Open As New OpenFileDialog
        Open.Filter = "Android Packages(*.apk)|*.apk"
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtSettings.Text = Open.FileName
        End If
    End Sub

    Private Sub BtnOpen3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen3.Click
        Dim Open As New FolderBrowserDialog
        Open.SelectedPath = TxtSettings.Text
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtFwRs.Text = Open.SelectedPath
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim Err As Boolean = False
        ErrorProvider1.Clear()
        If ComboBox1.SelectedIndex = -1 Then
            Err = True
            ErrorProvider1.SetError(LblVer, "Required")
        End If
        If Not TxtSystemUI.Text = "" Then
            If TxtSettings.Text <> "" AndAlso Not CheckIfDeodxed(TxtSettings.Text) Then
               Dim Info = My.Computer.FileSystem.GetFileInfo(TxtSettings.Text.Substring(0, TxtSettings.Text.Length - 3) & "odex")
                If Not Info.Exists Then
                    Err = True
                    ErrorProvider1.SetError(PicInfo1, "Can't find " & Info.Name & "!!" & vbNewLine & Info.DirectoryName)
                End If
                If TxtFwRs.Text = "" Then
                    Err = True
                    ErrorProvider1.SetError(PicInfo2, "Settings is odexed..." & vbNewLine & "Please set Framework path to deodexing it")
                End If
            End If
            If Not CheckIfDeodxed(TxtSystemUI.Text) Then
                Dim Info = My.Computer.FileSystem.GetFileInfo(TxtSystemUI.Text.Substring(0, TxtSystemUI.Text.Length - 3) & "odex")
                If Not Info.Exists Then
                    Err = True
                    ErrorProvider1.SetError(LblSys, "Can't find " & Info.Name & "!!" & vbNewLine & Info.DirectoryName)
                End If
                If TxtFwRs.Text = "" Then
                    Err = True
                    ErrorProvider1.SetError(PicInfo2, "SystemUI is odexed..." & vbNewLine & "Please set Framework path to deodexing it")
                End If
            End If
        Else
            Err = True
            ErrorProvider1.SetError(LblSys, "Required")
        End If
        If Not Err Then
            FrmMain.ver = ComboBox1.SelectedIndex + 9
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Public Function CheckIfDeodxed(ByVal File As String) As Boolean
        If My.Computer.FileSystem.FileExists("Tools\classes.dex") Then My.Computer.FileSystem.DeleteFile("Tools\classes.dex")
        Dim Command As String = String.Format("7z e ""{0}""{1} ""{2}""", File, "", "classes.dex")
        FrmMain.Cmd.ExecuteCommand(Command)
        If My.Computer.FileSystem.FileExists("Tools\classes.dex") Then
            My.Computer.FileSystem.DeleteFile("Tools\classes.dex")
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmFiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class