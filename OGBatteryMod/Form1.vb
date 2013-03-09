Imports System.Linq

Public Class Form1

    Dim Cmd As New CMD
    Dim FrameworkFiles As New Hashtable
    Dim RecourceFiles As New List(Of String)
    Dim Ver As Integer
    Dim Odex As Boolean = False
    Dim Img As Integer = 0
    Dim Rights As Integer = 0

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Cmd.ExecuteCommand("adb kill-server")
        Cmd.StopCMD()
        Cmd.SaveLog()
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cmd.Start(Application.StartupPath + "\Tools\")
        If Process.GetProcessesByName("adb").Length = 0 Then Cmd.ExecuteCommand("adb start-server")
    End Sub

    Private Sub LblSteps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblSteps.Click
        If LblSteps.Tag = "Start" Then
            LblTitle.Text = "Step 1"
            LblSteps.Text = "Please enable USB debugging on your mobile" & vbNewLine & "Settings >> Developer options >> USB debugging" & vbNewLine & "Then plug it to pc"
            LblSteps.Tag = "Step1"
            Dim Thread As New Threading.Thread(AddressOf Step2)
            Thread.Start()
        ElseIf LblSteps.Tag = "Step2" Then
            LblTitle.Text = "Step 2"
            LblSteps.Text = "Downloading necessary files"
            LblSteps.Tag = "Step3"
            Dim Thread As New Threading.Thread(AddressOf Step3)
            Thread.Start()
        ElseIf LblSteps.Tag = "Exit" Then
            Cmd.ExecuteCommand("adb kill-server")
            Cmd.StopCMD()
            Cmd.SaveLog()
            LblSteps.Visible = False
            If Img = 1 Then
                PictureBox2.Visible = True
            ElseIf Img = 2 Then
                PictureBox3.Visible = True
            ElseIf Img = 3 Then
                PictureBox4.Visible = True
            Else
                End
            End If
            TmrClose.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrAnimate.Tick
        Dim A1 As New Animate(Me)
        Dim A2 As New Animate(LblRights)
        A1.Properties("Text") = "OG Battery Mod"
        If Rights = 0 Then
            A2.Properties("Text") = "Programmed by : Osama Ghareeb"
        ElseIf Rights = 1 Then
            A2.Properties("Text") = "Please be patient..."
        ElseIf Rights = 2 Then
            A2.Properties("Text") = "Enjoy ^__^"
        End If
        A1.Animate(Animates.LitterLitter)
        A2.Animate(Animates.LitterLitter)
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TmrAnimate.Enabled = True
    End Sub

    Private Sub LblRights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblRights.Click
        MsgBox(Cmd.Result)
    End Sub

    Public Sub Step2()
        Do While CheckIfDeviceIsConnected() = False
            Threading.Thread.Sleep(100)
        Loop
        Me.Invoke(Sub()
                      LblSteps.Tag = "Step2"
                  End Sub)
        Cmd.ExecuteCommand("adb pull /system/build.prop build.prop")
        If My.Computer.FileSystem.FileExists("tools\build.prop") Then
            TmrCheck.Enabled = False
            Dim Text As String = My.Computer.FileSystem.ReadAllText("tools\build.prop")
            My.Computer.FileSystem.DeleteFile("tools\build.prop")
            Dim Ver As String = JustAfter(Text, "ro.build.version.sdk=", Chr(10))
            Dim Brand As String = JustAfter(Text, "ro.product.brand=", Chr(10))
            Me.Ver = Ver
            If Not Ver = 10 AndAlso Not Ver = 15 AndAlso Not Ver = 16 AndAlso MsgBox("Warning : This MOD for android 4.1.2 only continue anyway?", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                LastStep(False, "", 3)
                Exit Sub
            End If
            If Not Brand = "samsung" AndAlso MsgBox("Warning : This MOD tested on SAMSUNG only and not tested on " & Brand.ToUpper & "... " & vbNewLine & "Continue anyway?", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                LastStep(False, "", 3)
                Exit Sub
            End If
            Me.Invoke(Sub()
                          LblSteps.Text = String.Format("{0}{1}{2}{3}{4}", Brand.ToUpper, " " & JustAfter(Text, "ro.product.model=", Chr(10)), " Found", vbNewLine, "Press to continue")
                      End Sub)
        Else
            MsgBox("Failed : checking system info")
        End If
    End Sub

    Public Sub Step3()
        Rights = 1
        Cmd.Result = ""
        Cmd.ExecuteCommand("adb shell")
        Cmd.ExecuteCommand("cd system")
        Cmd.ExecuteCommand("cd app")
        Cmd.ExecuteCommand("pwd")
        If Cmd.Result.Contains("/system/app") Then
            Cmd.Result = ""
            Cmd.ExecuteCommand("ls")
            Dim SystemUI As String = InStr(Cmd.Result.ToLower, "systemui.apk")
            Dim SystemUIOdex As String = InStr(Cmd.Result.ToLower, "systemui.odex")
            Dim SecSettings As String = InStr(Cmd.Result.ToLower, "secsettings.apk")
            Dim SecSettingsOdex As String = InStr(Cmd.Result.ToLower, "secsettings.odex")
            If SystemUI > 0 Then SystemUI = Cmd.Result.Substring(SystemUI - 1, 12)
            If SystemUIOdex > 0 Then SystemUIOdex = Cmd.Result.Substring(SystemUIOdex - 1, 13)
            If SecSettings > 0 Then SecSettings = Cmd.Result.Substring(SecSettings - 1, 15)
            If SecSettingsOdex > 0 Then SecSettingsOdex = Cmd.Result.Substring(SecSettingsOdex - 1, 16)
            Cmd.ExecuteCommand("cd ..")
            Cmd.ExecuteCommand("cd framework")
            Cmd.ExecuteCommand("pwd")
            If Cmd.Result.Contains("/system/framework") Then
                Cmd.Result = ""
                Cmd.ExecuteCommand("ls")
                SaveFrameworkFiles(Cmd.Result)
                Cmd.ExecuteCommand("exit")
                For Each File In RecourceFiles
                    If File.ToString.ToLower.EndsWith("apk") Then
                        ChangeStep("Downloading necessary files" & vbNewLine & File)
                        Cmd.ExecuteCommand("adb pull /system/framework/" & File & " " & File)
                        If Not My.Computer.FileSystem.FileExists("tools\" & File) Then MsgBox("Failed to download files") : LastStep(True) : Exit Sub
                        Cmd.ExecuteCommand("apktool if " & File)
                    End If
                Next
                ChangeStep("Downloading necessary files")
            Else
                MsgBox("Failed to download from '/system/framework'")
                LastStep(True)
                Exit Sub
            End If
            If SystemUIOdex.Length > 5 Then
                Odex = True
                ChangeStep("Downloading necessary files" & vbNewLine & "init.rc")
                Cmd.ExecuteCommand("adb pull /init.rc init.rc")
                If My.Computer.FileSystem.FileExists("tools\init.rc") Then
                    Dim Framework As String = JustAfter(My.Computer.FileSystem.ReadAllText("tools\init.rc"), "BOOTCLASSPATH", Chr(10))
                    Framework = Replace(Framework, "/system/framework/", "")
                    DownloadFrameworkFiles(Framework)
                    My.Computer.FileSystem.DeleteFile("tools\init.rc")
                Else
                    DownloadFrameworkFiles("")
                End If
                ChangeStep("Downloading necessary files" & vbNewLine & "SystemUI.apk")
                Cmd.ExecuteCommand("adb pull /system/app/" & SystemUI & " systemui.apk")
                ChangeStep("Downloading necessary files" & vbNewLine & "SystemUI.odex")
                Cmd.ExecuteCommand("adb pull /system/app/" & SystemUIOdex & " systemui.odex")
                ChangeStep("Downloading necessary files" & vbNewLine & "SecSettings.apk")
                Cmd.ExecuteCommand("adb pull /system/app/" & SecSettings & " secsettings.apk")
                ChangeStep("Downloading necessary files" & vbNewLine & "SecSettings.odex")
                Cmd.ExecuteCommand("adb pull /system/app/" & SecSettingsOdex & " secsettings.odex")
                If My.Computer.FileSystem.FileExists("tools\systemui.apk") AndAlso My.Computer.FileSystem.FileExists("tools\systemui.odex") AndAlso _
                    My.Computer.FileSystem.FileExists("tools\secsettings.apk") AndAlso My.Computer.FileSystem.FileExists("tools\secsettings.odex") Then
                    ChangeStep("Downloading necessary files" & vbNewLine & "Deodexing")
                    DeodexSystemUI()
                    My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                    My.Computer.FileSystem.DeleteFile("tools\systemui.odex")
                    DeodexSecSettings()
                    My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                    My.Computer.FileSystem.DeleteFile("tools\secsettings.odex")
                    My.Computer.FileSystem.DeleteDirectory("tools\framework", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    My.Computer.FileSystem.DeleteDirectory("tools\code", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Me.Invoke(Sub()
                                  LblTitle.Text = "Step 4"
                                  LblSteps.Text = "Adding OGBatteryMod"
                                  LblSteps.Tag = "Step4"
                                  Dim Thread As New Threading.Thread(AddressOf Step4)
                                  Thread.Start()
                              End Sub)
                    GoTo E
                Else
                    MsgBox("Failed to download 'SystemUI' & 'SecSettings'")
                    LastStep(True)
                End If
            Else
                Cmd.Result = ""
                ChangeStep("Downloading necessary files" & vbNewLine & "SystemUI.apk")
                Cmd.ExecuteCommand("adb pull /system/app/" & SystemUI & " systemui.apk")
                ChangeStep("Downloading necessary files" & vbNewLine & "SecSettings.apk")
                Cmd.ExecuteCommand("adb pull /system/app/" & SecSettings & " secsettings.apk")
                If My.Computer.FileSystem.FileExists("tools\systemui.apk") Then
                    Me.Invoke(Sub()
                                  LblTitle.Text = "Step 4"
                                  LblSteps.Text = "Adding OGBatteryMod"
                                  LblSteps.Tag = "Step4"
                                  Dim Thread As New Threading.Thread(AddressOf Step4)
                                  Thread.Start()
                              End Sub)
                    GoTo E
                Else
                    MsgBox("Failed to download 'SystemUI.apk' & 'SecSettings.apk'")
                    LastStep(True)
                End If
            End If
        Else
            MsgBox("Failed to download from '/system/app'")
            LastStep(True)
        End If
E:
    End Sub

    Public Sub Step4()
        For Each File In RecourceFiles
            My.Computer.FileSystem.DeleteFile("Tools\" & File)
        Next
        If My.Computer.FileSystem.DirectoryExists("Tools\SystemUI") Then My.Computer.FileSystem.DeleteDirectory("Tools\SystemUI", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.DirectoryExists("Tools\SecSettings") Then My.Computer.FileSystem.DeleteDirectory("Tools\SecSettings", FileIO.DeleteDirectoryOption.DeleteAllContents)
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling SystemUI")
        Decompile("SystemUI.apk")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling SecSettings")
        Decompile("SecSettings.apk")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Installing OGBatteryMod")

        If My.Computer.FileSystem.FileExists("Tools\SystemUI\apktool.yml") Then
            Dim Files = My.Computer.FileSystem.GetFiles("Tools\SystemUI\", FileIO.SearchOption.SearchAllSubDirectories, New String() {"*.smali", "*.xml"})
            For Each File In Files
                Dim Text As String = My.Computer.FileSystem.ReadAllText(File)
                Dim NewText As String = Text
                NewText = Replace(NewText, "Lcom/android/systemui/statusbar/policy/BatteryController", "Lcom/ghareeb/BatteryMod/BatteryController")
                If Not Text.Contains(".source ""BatteryController.java""") AndAlso Not Text.Equals(NewText) Then
                    My.Computer.FileSystem.WriteAllText(File, NewText, False, System.Text.Encoding.ASCII)
                End If
            Next
        Else
            MsgBox("Failed to decompiling 'SystemUI.apk'")
            LastStep(True)
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists("Tools\SecSettings\apktool.yml") Then
            Dim Text As String = ""
            Dim Lines As String()
            Lines = IO.File.ReadAllLines("Tools\SecSettings\res\xml\display_settings.xml")
            If (From Line As String In Lines Select Line Where Line.Contains("BatteryMod.BatteryList")).Count > 0 Then
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("BatteryMod.BatteryList"))(0))
                Lines(Int) = My.Resources.SettingsXML
            Else
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("touch_key_light_values"))(0))
                Dim List As New List(Of String)
                List.AddRange(Lines)
                List.Insert(Int + 1, My.Resources.SettingsXML)
                Lines = List.ToArray
            End If
            My.Computer.FileSystem.DeleteFile("Tools\SecSettings\res\xml\display_settings.xml")
            IO.File.WriteAllLines("Tools\SecSettings\res\xml\display_settings.xml", Lines)
            Lines = IO.File.ReadAllLines("Tools\SecSettings\res\values\strings.xml")
            If (From Line As String In Lines Select Line Where Line.Contains("battry_style_title")).Count > 0 Then
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("battry_style_title"))(0))
                Lines(Int) = "<string name=""battry_style_title"">Battery Style v1.0</string>"
                Int = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("battry_style_summary"))(0))
                Lines(Int) = "<string name=""battry_style_summary"">By Osama Ghareeb</string>"
            Else
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("</resources>"))(0))
                Dim List As New List(Of String)
                List.AddRange(Lines)
                List.Insert(Int, "  <string name=""battry_style_summary"">By Osama Ghareeb</string>")
                List.Insert(Int, "  <string name=""battry_style_title"">Battery Style v1.0</string>")
                Lines = List.ToArray
            End If
            My.Computer.FileSystem.DeleteFile("Tools\SecSettings\res\values\strings.xml")
            IO.File.WriteAllLines("Tools\SecSettings\res\values\strings.xml", Lines)
            Text = IO.File.ReadAllText("Tools\SecSettings\res\values\arrays.xml")
            If Text.Contains("BatteryStyles") Then
                Dim Val As String = "<string-array name=""BatteryStyles" & JustAfter(Text, "<string-array name=""BatteryStyle", "</string-array>") & "</string-array>"
                Text = Text.Replace(Val, My.Resources.Styles)
            Else
                Text = Text.Replace("</resources>", My.Resources.Styles & vbNewLine & "</resources>")
            End If
            My.Computer.FileSystem.DeleteFile("Tools\SecSettings\res\values\arrays.xml")
            IO.File.WriteAllText("Tools\SecSettings\res\values\arrays.xml", Text)
            Text = IO.File.ReadAllText("Tools\SecSettings\res\values\ids.xml")
            If Not Text.Contains("OG_Battery") Then
                Text = Text.Replace("</resources>", My.Resources.IDs & vbNewLine & "</resources>")
            End If
            My.Computer.FileSystem.DeleteFile("Tools\SecSettings\res\values\ids.xml")
            IO.File.WriteAllText("Tools\SecSettings\res\values\ids.xml", Text)
        Else
            MsgBox("Failed to decompiling 'SecSettings.apk'")
            LastStep(True)
            Exit Sub
        End If
        Cmd.Result = ""
        My.Computer.FileSystem.WriteAllBytes("Tools\Battery1.zip", My.Resources.Battery1, False)
        My.Computer.FileSystem.WriteAllBytes("Tools\Battery2.zip", My.Resources.Battery2, False)
        If My.Computer.FileSystem.DirectoryExists("Tools\SystemUI\smali\com\ghareeb\") Then My.Computer.FileSystem.DeleteDirectory("Tools\SystemUI\smali\com\ghareeb\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.DirectoryExists("Tools\SecSettings\smali\com\ghareeb\") Then My.Computer.FileSystem.DeleteDirectory("Tools\SecSettings\smali\com\ghareeb\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Extract("SystemUI\smali\com\ghareeb\", "Battery1.zip")
        Extract("SecSettings\", "Battery2.zip")
        My.Computer.FileSystem.DeleteFile("Tools\Battery1.zip")
        My.Computer.FileSystem.DeleteFile("Tools\Battery2.zip")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling SystemUI")
        Compile("SystemUI")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling SecSettings")
        Compile("SecSettings")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing SystemUI")
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        ExtractFile("META-INF", "systemui.apk", "META-INF")
        ExtractFile("", "systemui.apk", "AndroidManifest.xml")
        AddFile("SystemUI\dist\systemui.apk", "META-INF\CERT.RSA")
        AddFile("SystemUI\dist\systemui.apk", "META-INF\CERT.SF")
        AddFile("SystemUI\dist\systemui.apk", "META-INF\MANIFEST.MF")
        AddFile("SystemUI\dist\systemui.apk", "AndroidManifest.xml")
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing SecSettings")
        Threading.Thread.Sleep(500)
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        ExtractFile("META-INF", "SecSettings.apk", "META-INF")
        ExtractFile("", "SecSettings.apk", "AndroidManifest.xml")
        AddFile("SecSettings\dist\SecSettings.apk", "META-INF\CERT.RSA")
        AddFile("SecSettings\dist\SecSettings.apk", "META-INF\CERT.SF")
        AddFile("SecSettings\dist\SecSettings.apk", "META-INF\MANIFEST.MF")
        AddFile("SecSettings\dist\SecSettings.apk", "AndroidManifest.xml")
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        Cmd.Result = ""
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning SystemUI")
        ZipAlign("SystemUI\dist\systemui.apk")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning SecSettings")
        ZipAlign("SecSettings\dist\SecSettings.apk")

        ChangeStep("Adding OGBatteryMod")
        If Cmd.Result.Contains("succesful") Then
            My.Computer.FileSystem.MoveFile("Tools\SystemUI\dist\systemui.apk", "Tools\dist\SystemUI.apk", True)
            My.Computer.FileSystem.MoveFile("Tools\SecSettings\dist\SecSettings.apk", "Tools\dist\SecSettings.apk", True)
        Else
            LastStep(True)
        End If
        My.Computer.FileSystem.DeleteDirectory("Tools\SystemUI", FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.DeleteDirectory("Tools\SecSettings", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If Cmd.Result.Contains("succesful") Then
            Me.Invoke(Sub()
                          LblTitle.Text = "Step 5"
                          LblSteps.Text = "Applying changes"
                          LblSteps.Tag = "Step5"
                          Dim Thread As New Threading.Thread(AddressOf Step5)
                          Thread.Start()
                      End Sub)
        End If
    End Sub

    Public Sub Step5()
        Rights = 0
        Cmd.Result = ""
        My.Computer.FileSystem.WriteAllBytes("Tools\dist\OGBatteryMod.apk", My.Resources.OGBatteryMod, False)
        ChangeStep("Applying changes" & vbNewLine & "Copying Files to /sdcard/og")
        Cmd.ExecuteCommand("adb shell mkdir /sdcard/og/")
        Cmd.ExecuteCommand("adb shell mkdir /sdcard/og/backup")
        Cmd.ExecuteCommand("adb push dist\SystemUI.apk /sdcard/og/SystemUI.apk")
        Cmd.ExecuteCommand("adb push systemui.apk /sdcard/og/backup/SystemUI.apk")
        Cmd.ExecuteCommand("adb push dist\SecSettings.apk /sdcard/og/SecSettings.apk")
        Cmd.ExecuteCommand("adb push SecSettings.apk /sdcard/og/backup/SecSettings.apk")
        Cmd.ExecuteCommand("adb push dist\OGBatteryMod.apk /sdcard/og/OGBatteryMod.apk")
        Cmd.Result = ""
        Cmd.ExecuteCommand("adb shell")
        Cmd.ExecuteCommand("cd sdcard")
        Cmd.ExecuteCommand("cd og")
        Cmd.ExecuteCommand("ls")
        Cmd.ExecuteCommand("exit")
        If Cmd.Result.Contains("SystemUI.apk") AndAlso Cmd.Result.Contains("SecSettings.apk") Then
            ChangeStep("Applying changes" & vbNewLine & "Asking for ROOT access")
            AppActivate(Process.GetCurrentProcess.Id)
            Cmd.ExecuteCommand("adb shell")
            Cmd.ExecuteCommand("su")
            If Not Cmd.Result.Contains("#") Then
                MsgBox("Failed to get ROOT access")
                LastStep(True)
                Exit Sub
            End If
            ChangeStep("Applying changes" & vbNewLine & "Stoping && Restarting Device")
            Cmd.ExecuteCommand("stop")
            Cmd.ExecuteCommand("mount -o rw,remount /system/ /system/")
            Cmd.ExecuteCommand("rm /system/app/SystemUI.apk")
            Cmd.ExecuteCommand("rm /system/app/SecSettings.apk")
            Cmd.ExecuteCommand("rm /system/app/SystemUI.odex")
            Cmd.ExecuteCommand("rm /system/app/SecSettings.odex")
            Cmd.ExecuteCommand("rm /system/app/OGBatteryMod.apk")
            Cmd.ExecuteCommand("cp /sdcard/og/SystemUI.apk /system/app/SystemUI.apk")
            Cmd.ExecuteCommand("cp /sdcard/og/SecSettings.apk /system/app/SecSettings.apk")
            Cmd.ExecuteCommand("cp /sdcard/og/OGBatteryMod.apk /system/app/OGBatteryMod.apk")
            Cmd.ExecuteCommand("mount -o rw,remount /system/ /system")
            Cmd.ExecuteCommand("reboot")
        Else
            MsgBox("Failed to copy files to phone")
            LastStep(True)
            Exit Sub
        End If
        Me.Invoke(Sub()
                      Img = 1
                      LblTitle.Text = "Modding Complate"
                      LblSteps.Text = "Programmed by : Osama Ghareeb" & vbNewLine & _
                          "Twitter : @OsGhareeb" & vbNewLine & _
                          "Enjoy ^_^"
                      LblSteps.Tag = "Exit"
                  End Sub)
    End Sub

    Public Sub LastStep(ByVal ShowLog As Boolean, Optional ByVal Title As String = "t", Optional ByVal Img As Integer = 2)
        Me.Invoke(Sub()
                      Rights = 2
                      Call Timer1_Tick(Nothing, Nothing)
                      Me.Img = Img
                      LblTitle.Text = If(Title = "t", "Sorry.. Modding failed :(", Title)
                      LblSteps.Text = If(ShowLog, "Please help me improve this app by sending Log.txt to me" & vbNewLine & "Twitter : @OsGhareeb" & vbNewLine & "XDA : OsamaGhareeb", "")
                      LblSteps.Tag = "Exit"
                  End Sub)
    End Sub

    Public Sub DeodexSecSettings()
        Dim Jar As String = ""
        For Each File In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Tools\Framework", FileIO.SearchOption.SearchTopLevelOnly, "*.jar")
            Jar += String.Format(":{0}", File.Replace(Application.StartupPath & "\Tools\Framework\", "").ToLower)
        Next
        Baksmali("SecSettings.odex", Jar)
        Smali()
        AddFile("SecSettings.apk", Application.StartupPath & "\tools\classes.dex")
        ZipAlign("SecSettings.apk")
    End Sub

    Public Sub DeodexSystemUI()
        Dim Jar As String = ""
        For Each File In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Tools\Framework", FileIO.SearchOption.SearchTopLevelOnly, "*.jar")
            Jar += String.Format(":{0}", File.Replace(Application.StartupPath & "\Tools\Framework\", "").ToLower)
        Next
        Baksmali("SystemUI.odex", Jar)
        Smali()
        AddFile("SystemUI.apk", Application.StartupPath & "\tools\classes.dex")
        ZipAlign("SystemUI.apk")
    End Sub

    Public Sub DownloadFrameworkFiles(ByVal Framework As String)
        For Each File In If(Framework.Length > 0, Split(Framework, ":"), FrameworkFiles.Keys)
            File = FrameworkFiles(File.Trim)
            Cmd.Result = ""
            ChangeStep("Downloading necessary files" & vbNewLine & File)
            Cmd.ExecuteCommand("adb pull /system/framework/" & File & " Framework\" & File)
            ChangeStep("Downloading necessary files" & vbNewLine & Replace(File, ".jar", ".odex"))
            Cmd.ExecuteCommand("adb pull /system/framework/" & Replace(File, ".jar", ".odex") & " Framework\" & Replace(File, ".jar", ".odex"))
            If My.Computer.FileSystem.FileExists("Tools\Framework\" & File) = False AndAlso My.Computer.FileSystem.FileExists("Tools\Framework\" & Replace(File, ".jar", ".odex")) = False Then
                MsgBox("Failed to download framework files")
                LastStep(True)
                Exit Sub
            End If
        Next
        ChangeStep("Downloading necessary files")
    End Sub

    Public Sub SaveFrameworkFiles(ByVal str As String)
        str = str.Replace(" ", vbNewLine)
        For Each Line In ReadLines(str)
            If Line.Trim.ToLower.EndsWith("jar") Then
                FrameworkFiles(Line.Trim.ToLower) = Line.Trim
            ElseIf Line.Trim.ToLower.EndsWith("apk") Then
                RecourceFiles.Add(Line.Trim)
            End If
        Next
    End Sub

    Private Sub Baksmali(ByVal File As String, ByVal JarFiles As String)
        Cmd.ExecuteCommand(String.Format("java -Xmx1024m -jar baksmali.jar -c {0} -d ""{1}"" -o {2} -x ""{3}""", JarFiles, Application.StartupPath & "\tools\framework", "code", File))
    End Sub

    Private Sub ZipAlign(ByVal File As String)
        Cmd.Result = ""
        Cmd.ExecuteCommand(String.Format("zipalign -v 4 ""{0}"" ""{1}""", File, File & "_za"))
        My.Computer.FileSystem.MoveFile("tools\" & File & "_za", "tools\" & File, True)
    End Sub

    Private Sub Decompile(ByVal File As String)
        Cmd.ExecuteCommand(String.Format("apktool d ""{0}""", File))
    End Sub

    Private Sub Compile(ByVal Folder As String)
        Cmd.ExecuteCommand(String.Format("apktool b ""{0}""", Folder))
    End Sub

    Public Sub AddFile(ByVal ArchivePath As String, ByVal FilePath As String)
        Cmd.ExecuteCommand("7z a """ & ArchivePath & """ """ & FilePath & """")
    End Sub

    Public Sub Extract(ByVal ExtractPath As String, ByVal ZipFile As String)
        Cmd.ExecuteCommand("7z x -y -o""" & ExtractPath & """ """ & ZipFile & """")
    End Sub

    Public Sub ExtractFile(ByVal ExtractPath As String, ByVal ZipFile As String, ByVal Filename As String)
        Dim Command As String = String.Format("7z e ""{0}""{1} ""{2}""", ZipFile, If(ExtractPath.Length > 0, " -o""" & ExtractPath & """", ""), Filename)
        Cmd.ExecuteCommand(Command)
    End Sub

    Private Sub Smali()
        Cmd.ExecuteCommand("java -Xmx1024m -jar smali.jar code -o classes.dex")
    End Sub

    Private Sub ChangeStep(ByVal Str As String)
        Me.Invoke(Sub()
                      LblSteps.Text = Str
                  End Sub)
    End Sub

    Public Function CheckIfDeviceIsConnected() As Boolean
        Cmd.Result = ""
        Cmd.ExecuteCommand("adb devices")
        Dim Results As String() = Cmd.Result.Split(vbNewLine)
        Dim Index As Integer = -1
        For i = 0 To Results.Length - 1
            If (Results(i).Contains("List of devices")) Then
                Index = i + 1
                Exit For
            End If
        Next
        If Index > -1 AndAlso Results(Index) IsNot Nothing AndAlso Results(Index).Trim.Length > 20 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub TmrClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrClose.Tick
        End
    End Sub

End Class
