Public Class FrmNewStyle

    Private Sub BtnOpen1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen1.Click
        Dim Folder As New FolderBrowserDialog
        If TxtCharge.Text <> "" Then Folder.SelectedPath = TxtCharge.Text
        Folder.Description = "Select the folder that contains :" & vbNewLine & _
                             "stat_sys_battery_***.png files"
        If Folder.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtNormal.Text = Folder.SelectedPath
            LblCount1.Text = 0
            For I = 0 To 100
                If My.Computer.FileSystem.FileExists(Folder.SelectedPath & "\stat_sys_battery_" & I & ".png") Then
                    LblCount1.Text += 1
                End If
            Next
       End If
    End Sub

    Private Sub BtnOpen2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen2.Click
        Dim Folder As New FolderBrowserDialog
        If TxtNormal.Text <> "" Then Folder.SelectedPath = TxtNormal.Text
        Folder.Description = "Select the folder that contains :" & vbNewLine & _
                             "stat_sys_battery_charge_anim***.png files"
        If Folder.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtCharge.Text = Folder.SelectedPath
            LblCount2.Text = 0
            For I = 0 To 100
                If My.Computer.FileSystem.FileExists(Folder.SelectedPath & "\stat_sys_battery_charge_anim" & I & ".png") Then
                    LblCount2.Text += 1
                End If
            Next
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        ErrorProvider1.Clear()
        If TxtName.Text.Trim = "" Then ErrorProvider1.SetError(LblName, "Please enter style name")
        If LblCount1.Text = 0 Then ErrorProvider1.SetError(PicHelp1, "Please select folder")
        If LblCount2.Text = 0 Then ErrorProvider1.SetError(PicHelp2, "Please select folder")
        If My.Computer.FileSystem.DirectoryExists("Styles\" & TxtName.Text) Then ErrorProvider1.SetError(LblName, "There is already a style with the same name") : Exit Sub
        If TxtName.Text <> "" AndAlso LblCount1.Text > 0 AndAlso LblCount2.Text > 0 Then
            TxtNormal.Text = If(TxtNormal.Text.EndsWith("\"), TxtNormal.Text, TxtNormal.Text & "\")
            TxtCharge.Text = If(TxtCharge.Text.EndsWith("\"), TxtCharge.Text, TxtCharge.Text & "\")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtNormal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNormal.TextChanged
        If My.Computer.FileSystem.DirectoryExists(TxtNormal.Text) Then
            Dim Folder As String = If(TxtNormal.Text.EndsWith("\"), TxtNormal.Text, TxtNormal.Text & "\")
            LblCount1.Text = 0
            For I = 0 To 100
                If My.Computer.FileSystem.FileExists(Folder & "stat_sys_battery_" & I & ".png") Then
                    LblCount1.Text += 1
                End If
            Next
        Else
            LblCount1.Text = 0
        End If
    End Sub

    Private Sub TxtCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCharge.TextChanged
        If My.Computer.FileSystem.DirectoryExists(TxtCharge.Text) Then
            Dim Folder As String = If(TxtCharge.Text.EndsWith("\"), TxtCharge.Text, TxtCharge.Text & "\")
            LblCount2.Text = 0
            For I = 0 To 100
                If My.Computer.FileSystem.FileExists(Folder & "stat_sys_battery_charge_anim" & I & ".png") Then
                    LblCount2.Text += 1
                End If
            Next
        Else
            LblCount2.Text = 0
        End If
    End Sub
End Class