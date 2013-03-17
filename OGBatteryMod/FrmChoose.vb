Public Class FrmChoose
    Dim BClose As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text.Trim <> "" Then
            BClose = True
            Me.Close()
        End If
     
    End Sub

    Private Sub FrmChoose_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not BClose Then e.Cancel = True
    End Sub
End Class