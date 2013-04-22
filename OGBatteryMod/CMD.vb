Public Class CMD
    Dim WithEvents CMD As New Process
    Dim ReadThread As Threading.Thread
    Dim ErrThread As Threading.Thread
    Dim Reader As IO.StreamReader
    Dim ErrReader As IO.StreamReader
    Dim Writer As IO.StreamWriter
    Dim LastText As String = ""
    Dim LastText2 As String = ""
    Dim BResult As String = ""
    Public Result As String = ""
    Dim WritengErr As Boolean = False
    Public IsWriting As Boolean = False
    Public WriteLog As Boolean = True
    Public WriteResult As Boolean = True
    Dim Log As String = ""

    Public Sub ReadStream()
        Dim Buffer(1) As Byte
        Do While Reader.BaseStream.Read(Buffer, 0, 1)
            IsWriting = True
            Do While WritengErr
                Threading.Thread.Sleep(10)
            Loop
            If WriteResult Then
                Result += Chr(Buffer(0))
            Else
                If Chr(Buffer(0)) = "\" Then
                    WriteResult = True
                    Result += Chr(Buffer(0))
                End If
            End If
            If WriteLog Then Log += Chr(Buffer(0))
            IsWriting = False
        Loop
    End Sub

    Public Sub ErrorStream()
        Dim Buffer(1) As Byte
        Do While ErrReader.BaseStream.Read(Buffer, 0, 1)
            WritengErr = True
            IsWriting = True
            If WriteResult Then
                Result += Chr(Buffer(0))
            End If
            If WriteLog Then Log += Chr(Buffer(0))
            WritengErr = False
            IsWriting = False
        Loop
    End Sub

    Public Sub Start(Optional ByVal WorkDir As String = "")
        Dim cmdinfo As New System.Diagnostics.ProcessStartInfo
        Application.DoEvents()
        cmdinfo.FileName = "cmd.exe"
        cmdinfo.RedirectStandardError = True
        cmdinfo.RedirectStandardInput = True
        cmdinfo.RedirectStandardOutput = True
        cmdinfo.UseShellExecute = False
        cmdinfo.CreateNoWindow = True
        cmdinfo.WorkingDirectory = WorkDir
        cmdinfo.WindowStyle = ProcessWindowStyle.Hidden
        CMD.StartInfo = cmdinfo
        CMD.Start()
        ErrReader = CMD.StandardError
        Reader = CMD.StandardOutput
        Writer = CMD.StandardInput
        ErrThread = New Threading.Thread(AddressOf ErrorStream)
        ErrThread.Start()
        ReadThread = New Threading.Thread(AddressOf ReadStream)
        ReadThread.Start()

    End Sub

    Public Sub StopCMD()
        If CMD.HasExited = False Then
            ReadThread.Abort()
            ErrThread.Abort()
            CMD.Kill()
        End If
    End Sub

    Public Sub ExecuteCommand(ByVal cmd As String)
        SaveLog()
        If cmd = "adb devices" Then
            WriteLog = False
        Else
            WriteLog = True
        End If
        IsWriting = True
        BResult = Result
        Result = ""
        Writer.WriteLine(cmd)
        WaitForResault()
        Result = BResult & Result
    End Sub

    Public Sub SaveLog()
        My.Computer.FileSystem.WriteAllText("Log.txt", Log, False)
    End Sub

    Private Sub WaitForResault()
        Do While (Not Result.Contains(">") OrElse Not Result.Contains("\")) AndAlso Not Result.Contains("$") AndAlso Not Result.Contains("#")
            Application.DoEvents()
            Threading.Thread.Sleep(50)
        Loop
        SaveLog()
    End Sub

    Public Function ExecuteCommand(ByVal command As String, ByRef B As Boolean)
        Dim output As String = ""
        Dim err As String = String.Empty
        Dim psi As ProcessStartInfo = New ProcessStartInfo("cmd.exe", command)
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.RedirectStandardInput = True
        psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        psi.UseShellExecute = False
        psi.CreateNoWindow = True
        Dim cmd As System.Diagnostics.Process
        cmd = System.Diagnostics.Process.Start(psi)
        cmd.StandardInput.WriteLine(command)
        cmd.StandardInput.WriteLine("exit")

        cmd.WaitForExit()
        Using myOutput As System.IO.StreamReader = cmd.StandardOutput
            output = myOutput.ReadToEnd()
        End Using
        Using myError As System.IO.StreamReader = cmd.StandardError
            err = myError.ReadToEnd()
        End Using
        Return output & vbNewLine & err
    End Function
End Class
