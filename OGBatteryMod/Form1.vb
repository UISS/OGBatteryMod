Imports System.Linq

Public Class Form1

    Dim Cmd As New CMD
    Dim FrameworkFiles As New Hashtable
    Dim RecourceFiles As New List(Of String)
    Dim Ver As Integer
    Dim Odex As Boolean = False
    Dim Img As Integer = 0
    Dim Rights As Integer = 0
    Private SystemUI As String = "systemui"
    Private Settings As String = "secsettings"

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
            If Not Ver >= 15 AndAlso MsgBox("Sorry : This MOD for android 4.* only", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                LastStep(False, "", 3)
                Exit Sub
            End If
            If Not Brand = "samsung" AndAlso MsgBox("Warning : This MOD tested on SAMSUNG only and not tested on " & Brand.ToUpper & "... " & vbNewLine & "Continue anyway?", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                LastStep(False, "", 3)
                Exit Sub
            End If
            Select Case Brand.ToLower
                Case "samsung"
                    SystemUI = Samsung.SystemUI.ToLower
                    Settings = Samsung.Settings.ToLower
                Case "motorola"
                    SystemUI = Motorola.SystemUI.ToLower
                    Settings = Motorola.Settings.ToLower
                Case Else
                    SystemUI = "systemui"
                    Settings = "secsettings"
            End Select

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
            Dim SystemUI As String = InStr(Cmd.Result.ToLower, Me.SystemUI & ".apk")
            Dim SystemUIOdex As String = InStr(Cmd.Result.ToLower, Me.SystemUI & ".odex")
            Dim Settings As String = InStr(Cmd.Result.ToLower, Me.Settings & ".apk")
            Dim SettingsOdex As String = InStr(Cmd.Result.ToLower, Me.Settings & ".odex")
            If SystemUI > 0 Then SystemUI = Cmd.Result.Substring(SystemUI - 1, 12)
            If SystemUIOdex > 0 Then SystemUIOdex = Cmd.Result.Substring(SystemUIOdex - 1, 13)
            If Settings > 0 Then Settings = Cmd.Result.Substring(Settings - 1, 15)
            If SettingsOdex > 0 Then SettingsOdex = Cmd.Result.Substring(SettingsOdex - 1, 16)
            Me.SystemUI = SystemUI
            Me.Settings = Settings
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
                ChangeStep("Downloading necessary files" & vbNewLine & SystemUI)
                Cmd.ExecuteCommand("adb pull /system/app/" & SystemUI & " " & SystemUI)
                ChangeStep("Downloading necessary files" & vbNewLine & SystemUIOdex)
                Cmd.ExecuteCommand("adb pull /system/app/" & SystemUIOdex & " " & SystemUIOdex)
                ChangeStep("Downloading necessary files" & vbNewLine & Settings)
                Cmd.ExecuteCommand("adb pull /system/app/" & Settings & " " & Settings)
                ChangeStep("Downloading necessary files" & vbNewLine & SettingsOdex)
                Cmd.ExecuteCommand("adb pull /system/app/" & SettingsOdex & " " & SettingsOdex)
                If My.Computer.FileSystem.FileExists("tools\" & SystemUI) AndAlso My.Computer.FileSystem.FileExists("tools\" & SystemUIOdex) AndAlso _
                    My.Computer.FileSystem.FileExists("tools\" & Settings) AndAlso My.Computer.FileSystem.FileExists("tools\" & SettingsOdex) Then
                    ChangeStep("Downloading necessary files" & vbNewLine & "Deodexing")
                    DeodexSystemUI()
                    My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                    My.Computer.FileSystem.DeleteFile("tools\" & SystemUIOdex)
                    DeodexSecSettings()
                    My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                    My.Computer.FileSystem.DeleteFile("tools\" & SettingsOdex)
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
                    MsgBox("Failed to download '" & Me.SystemUI & "' & '" & Me.Settings & "'")
                    LastStep(True)
                End If
            Else
                Cmd.Result = ""
                ChangeStep("Downloading necessary files" & vbNewLine & SystemUI)
                Cmd.ExecuteCommand("adb pull /system/app/" & SystemUI & " " & SystemUI)
                ChangeStep("Downloading necessary files" & vbNewLine & Settings)
                Cmd.ExecuteCommand("adb pull /system/app/" & Settings & " " & Settings)
                If My.Computer.FileSystem.FileExists("tools\" & SystemUI) AndAlso My.Computer.FileSystem.FileExists("tools\" & Settings) Then
                    Me.Invoke(Sub()
                                  LblTitle.Text = "Step 4"
                                  LblSteps.Text = "Adding OGBatteryMod"
                                  LblSteps.Tag = "Step4"
                                  Dim Thread As New Threading.Thread(AddressOf Step4)
                                  Thread.Start()
                              End Sub)
                    GoTo E
                Else
                    MsgBox("Failed to download '" & Me.SystemUI & "' & '" & Me.Settings & "'")
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

        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling " & SystemUI)
        Decompile(SystemUI)
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling " & Settings)
        Decompile(Settings)
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Installing OGBatteryMod")

        If My.Computer.FileSystem.FileExists("Tools\" & SystemUI.ToLower.Replace(".apk", "") & "\apktool.yml") Then
            Dim Files = My.Computer.FileSystem.GetFiles("Tools\" & SystemUI.ToLower.Replace(".apk", "") & "\", FileIO.SearchOption.SearchAllSubDirectories, New String() {"*.smali", "*.xml"})
            For Each File In Files
                Dim Text As String = My.Computer.FileSystem.ReadAllText(File)
                Dim NewText As String = Text
                'Android 4.*
                NewText = Replace(NewText, "Lcom/android/systemui/statusbar/policy/BatteryController", "Lcom/ghareeb/BatteryMod/BatteryController")
                'Android 2.*
                'Coming Soon :)
                If Not Text.Contains(".source ""BatteryController.java""") AndAlso Not Text.Equals(NewText) Then
                    My.Computer.FileSystem.WriteAllText(File, NewText, False, System.Text.Encoding.ASCII)
                End If
            Next
        Else
            MsgBox("Failed to decompiling '" & SystemUI & "'")
            LastStep(True)
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists("Tools\" & Settings.ToLower.Replace(".apk", "") & "\apktool.yml") Then
            Dim Text As String = ""
            Dim Lines As String()
            Lines = IO.File.ReadAllLines("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\xml\display_settings.xml")
            If (From Line As String In Lines Select Line Where Line.Contains("BatteryMod.BatteryList")).Count > 0 Then
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("BatteryMod.BatteryList"))(0))
                Lines(Int) = My.Resources.SettingsXML
            Else
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("touch_key_light_values"))(0))
                Dim List As New List(Of String)
                List.AddRange(Lines)
                If Int = -1 Then
                    Int = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("</PreferenceScreen>"))(0))
                    List.Insert(Int + 1, My.Resources.SettingsXML)
                    Lines = List.ToArray
                Else
                    List.Insert(Int + 1, My.Resources.SettingsXML)
                    Lines = List.ToArray
                End If
            End If
            My.Computer.FileSystem.DeleteFile("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\xml\display_settings.xml")
            IO.File.WriteAllLines("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\xml\display_settings.xml", Lines)
            Lines = IO.File.ReadAllLines("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\strings.xml")
            If (From Line As String In Lines Select Line Where Line.Contains("battry_style_title")).Count > 0 Then
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("battry_style_title"))(0))
                Lines(Int) = "<string name=""battry_style_title"">Battery Style</string>"
                Int = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("battry_style_summary"))(0))
                Lines(Int) = "<string name=""battry_style_summary"">By Osama Ghareeb</string>"
            Else
                Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("</resources>"))(0))
                Dim List As New List(Of String)
                List.AddRange(Lines)
                List.Insert(Int, "  <string name=""battry_style_summary"">By Osama Ghareeb</string>")
                List.Insert(Int, "  <string name=""battry_style_title"">Battery Style</string>")
                Lines = List.ToArray
            End If
            My.Computer.FileSystem.DeleteFile("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\strings.xml")
            IO.File.WriteAllLines("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\strings.xml", Lines)
            Text = IO.File.ReadAllText("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\arrays.xml")
            If Text.Contains("BatteryStyles") Then
                Dim Val As String = "<string-array name=""BatteryStyles" & JustAfter(Text, "<string-array name=""BatteryStyle", "</string-array>") & "</string-array>"
                Text = Text.Replace(Val, My.Resources.Styles)
            Else
                Text = Text.Replace("</resources>", My.Resources.Styles & vbNewLine & "</resources>")
            End If
            My.Computer.FileSystem.DeleteFile("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\arrays.xml")
            IO.File.WriteAllText("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\arrays.xml", Text)
            Text = IO.File.ReadAllText("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\ids.xml")
            If Not Text.Contains("OG_Battery") Then
                Text = Text.Replace("</resources>", My.Resources.IDs & vbNewLine & "</resources>")
            End If
            My.Computer.FileSystem.DeleteFile("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\ids.xml")
            IO.File.WriteAllText("Tools\" & Settings.ToLower.Replace(".apk", "") & "\res\values\ids.xml", Text)
        Else
            MsgBox("Failed to decompiling '" & Settings & "'")
            LastStep(True)
            Exit Sub
        End If
        Cmd.Result = ""
        My.Computer.FileSystem.WriteAllBytes("Tools\Battery1.zip", My.Resources.Battery1, False)
        My.Computer.FileSystem.WriteAllBytes("Tools\Battery2.zip", My.Resources.Battery2, False)
        If My.Computer.FileSystem.DirectoryExists("Tools\" & SystemUI.ToLower.Replace(".apk", "") & "\smali\com\ghareeb\") Then My.Computer.FileSystem.DeleteDirectory("Tools\SystemUI\smali\com\ghareeb\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.DirectoryExists("Tools\" & Settings.ToLower.Replace(".apk", "") & "\smali\com\ghareeb\") Then My.Computer.FileSystem.DeleteDirectory("Tools\SecSettings\smali\com\ghareeb\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Extract(SystemUI.ToLower.Replace(".apk", "") & "\smali\com\ghareeb\", "Battery1.zip")
        Extract(Settings.ToLower.Replace(".apk", "") & "\", "Battery2.zip")
        My.Computer.FileSystem.DeleteFile("Tools\Battery1.zip")
        My.Computer.FileSystem.DeleteFile("Tools\Battery2.zip")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling " & SystemUI)
        Compile(SystemUI.ToLower.Replace(".apk", ""))
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling " & Settings)
        Compile(Settings.ToLower.Replace(".apk", ""))
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing " & SystemUI)
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        ExtractFile("META-INF", SystemUI, "META-INF")
        ExtractFile("", SystemUI, "AndroidManifest.xml")
        AddFile(SystemUI.ToLower.Replace(".apk", "") & "\dist\" & SystemUI, "META-INF\CERT.RSA")
        AddFile(SystemUI.ToLower.Replace(".apk", "") & "\dist\" & SystemUI, "META-INF\CERT.SF")
        AddFile(SystemUI.ToLower.Replace(".apk", "") & "\dist\" & SystemUI, "META-INF\MANIFEST.MF")
        AddFile(SystemUI.ToLower.Replace(".apk", "") & "\dist\" & SystemUI, "AndroidManifest.xml")
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing " & Settings)
        Threading.Thread.Sleep(500)
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        ExtractFile("META-INF", Settings, "META-INF")
        ExtractFile("", Settings, "AndroidManifest.xml")
        AddFile(Settings.ToLower.Replace(".apk", "") & "\dist\" & Settings, "META-INF\CERT.RSA")
        AddFile(Settings.ToLower.Replace(".apk", "") & "\dist\" & Settings, "META-INF\CERT.SF")
        AddFile(Settings.ToLower.Replace(".apk", "") & "\dist\" & Settings, "META-INF\MANIFEST.MF")
        AddFile(Settings.ToLower.Replace(".apk", "") & "\dist\" & Settings, "AndroidManifest.xml")
        If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
        Cmd.Result = ""
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning " & SystemUI)
        ZipAlign(SystemUI.ToLower.Replace(".apk", "") & "\dist\" & SystemUI)
        ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning " & Settings)
        ZipAlign(Settings.ToLower.Replace(".apk", "") & "\dist\" & Settings)

        ChangeStep("Adding OGBatteryMod")
        If Cmd.Result.Contains("succesful") Then
            My.Computer.FileSystem.MoveFile("Tools\" & SystemUI.ToLower.Replace(".apk", "") & "\dist\" & SystemUI, "Tools\dist\" & SystemUI, True)
            My.Computer.FileSystem.MoveFile("Tools\" & Settings.ToLower.Replace(".apk", "") & "\dist\" & Settings, "Tools\dist\" & Settings, True)
        Else
            LastStep(True)
        End If
        My.Computer.FileSystem.DeleteDirectory("Tools\" & SystemUI.ToLower.Replace(".apk", ""), FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.DeleteDirectory("Tools\" & Settings.ToLower.Replace(".apk", ""), FileIO.DeleteDirectoryOption.DeleteAllContents)
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
        Cmd.ExecuteCommand("adb push dist\" & SystemUI & " /sdcard/og/" & SystemUI)
        Cmd.ExecuteCommand("adb push " & SystemUI & " /sdcard/og/backup/" & SystemUI)
        Cmd.ExecuteCommand("adb push dist\" & Settings & " /sdcard/og/" & Settings)
        Cmd.ExecuteCommand("adb push " & Settings & " /sdcard/og/backup/" & Settings)
        Cmd.ExecuteCommand("adb push dist\OGBatteryMod.apk /sdcard/og/OGBatteryMod.apk")
        Cmd.Result = ""
        Cmd.ExecuteCommand("adb shell")
        Cmd.ExecuteCommand("cd sdcard")
        Cmd.ExecuteCommand("cd og")
        Cmd.ExecuteCommand("ls")
        Cmd.ExecuteCommand("exit")
        If Cmd.Result.Contains(SystemUI) AndAlso Cmd.Result.Contains(Settings) Then
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
            Cmd.ExecuteCommand("rm /system/app/" & SystemUI)
            Cmd.ExecuteCommand("rm /system/app/" & Settings)
            Cmd.ExecuteCommand("rm /system/app/" & SystemUI.Replace("apk", "odex"))
            Cmd.ExecuteCommand("rm /system/app/" & Settings.Replace("apk", "odex"))
            Cmd.ExecuteCommand("rm /system/app/OGBatteryMod.apk")
            Cmd.ExecuteCommand("cp /sdcard/og/" & SystemUI & " /system/app/" & SystemUI)
            Cmd.ExecuteCommand("cp /sdcard/og/" & Settings & " /system/app/" & Settings)
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
