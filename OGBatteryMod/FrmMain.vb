Imports System.Linq

Public Class FrmMain

    Public Cmd As New CMD
    Dim FrameworkFiles As New Hashtable
    Dim RecourceFiles As New List(Of String)
    Public Ver As Integer
    Dim Odex As Boolean = False
    Dim Img As Integer = 0
    Dim Rights As Integer = 0
    Private SystemUI As String = "systemui"
    Private Settings As String = "secsettings"
    Private SelectedDevice As String = ""
    Private Selected As Integer = 0
    Private SelectOption As Boolean = False
    Private ModSettings As Boolean = True
    Private ModExisting As Boolean = False
    Public Styles As New List(Of String)
    Public StylesChanged As Boolean = False
    Dim Files As FrmFiles

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Cmd.ExecuteCommand("adb kill-server")
        Cmd.StopCMD()
        Cmd.SaveLog()
        End
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If SelectOption Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    Selected = 1
                Case Keys.D2, Keys.NumPad2
                    Selected = 2
                Case Keys.D3, Keys.NumPad3
                    Selected = 3
            End Select
        End If
    End Sub

    Public Sub CreateFlashabel()
        My.Computer.FileSystem.WriteAllBytes("Tools\dist\OGBattreyMod_Flashable.zip", My.Resources.BatteryMod, False)
        My.Computer.FileSystem.CopyFile("Tools\dist\OGBatteryMod.apk", "Tools\system\app\OGBatteryMod.apk", True)
        AddFile("dist\OGBattreyMod_Flashable.zip", "system\app\OGBatteryMod.apk")
        My.Computer.FileSystem.CopyFile("Tools\dist\" & SystemUI, "Tools\system\app\" & SystemUI, True)
        AddFile("dist\OGBattreyMod_Flashable.zip", "system\app\" & SystemUI)
        If ModSettings Then
            My.Computer.FileSystem.CopyFile("Tools\dist\" & Settings, "Tools\system\app\" & Settings, True)
            AddFile("dist\OGBattreyMod_Flashable.zip", "system\app\" & Settings)
        End If
        My.Computer.FileSystem.DeleteDirectory("Tools\system\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.CreateDirectory("Tools\META-INF\com\google\android\")
        Dim Sett As String = "ui_print(""Removing old Settings"");" & vbNewLine & _
                             "delete(""/system/app/" & Settings & """);" & vbNewLine & _
                             "delete(""/system/app/" & Settings.Substring(0, Settings.Length - 3) & "odex" & """);" & vbNewLine
        Dim Text As String = String.Format(My.Resources.Script, SystemUI, SystemUI.Substring(0, SystemUI.Length - 3) & "odex", If(ModSettings, Sett, ""), If(ModSettings, String.Format("set_perm(0, 0, 0644, ""/system/app/{0}"");", Settings), ""))
        Text = Text.Replace(vbNewLine, Chr(10))
        My.Computer.FileSystem.WriteAllText("Tools\META-INF\com\google\android\updater-script", Text, False, System.Text.Encoding.ASCII)
        AddFile("dist\OGBattreyMod_Flashable.zip", "META-INF\com\google\android\updater-script")

        My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Cmd.ExecuteCommand("java -Xmx1024m -jar signapk.jar -w testkey.x509.pem testkey.pk8 dist\OGBattreyMod_Flashable.zip dist\OGBattreyMod_FlashableS.zip")
        My.Computer.FileSystem.MoveFile("Tools\dist\OGBattreyMod_FlashableS.zip", "Tools\dist\OGBattreyMod_Flashable.zip", True)
        CreateBFlashabel()
    End Sub

    Public Sub CreateBFlashabel()
        My.Computer.FileSystem.WriteAllBytes("Tools\dist\Backup_Flashable.zip", My.Resources.BatteryMod, False)
        My.Computer.FileSystem.CopyFile("Tools\" & SystemUI, "Tools\system\app\" & SystemUI, True)
        AddFile("dist\Backup_Flashable.zip", "system\app\" & SystemUI)
        If ModSettings Then
            My.Computer.FileSystem.CopyFile("Tools\" & Settings, "Tools\system\app\" & Settings, True)
            AddFile("dist\Backup_Flashable.zip", "system\app\" & Settings)
        End If

        My.Computer.FileSystem.DeleteDirectory("Tools\system\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.CreateDirectory("Tools\META-INF\com\google\android\")
        Dim Sett As String = "ui_print(""Removing old Settings"");" & vbNewLine & _
"delete(""/system/app/" & Settings & """);" & vbNewLine & _
"delete(""/system/app/" & Settings.Substring(0, Settings.Length - 3) & "odex" & """);" & vbNewLine
        Dim Text As String = String.Format(My.Resources.BackupScript, SystemUI, SystemUI.Substring(0, SystemUI.Length - 3) & "odex", If(ModSettings, Sett, ""), If(ModSettings, String.Format("set_perm(0, 0, 0644, ""/system/app/{0}"");", Settings), ""))
        Text = Text.Replace(vbNewLine, Chr(10))
        My.Computer.FileSystem.WriteAllText("Tools\META-INF\com\google\android\updater-script", Text, False, System.Text.Encoding.ASCII)

        AddFile("dist\Backup_Flashable.zip", "META-INF\com\google\android\updater-script")

        My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Cmd.ExecuteCommand("java -Xmx1024m -jar signapk.jar -w testkey.x509.pem testkey.pk8 dist\Backup_Flashable.zip dist\Backup_FlashableS.zip")
        My.Computer.FileSystem.MoveFile("Tools\dist\Backup_FlashableS.zip", "Tools\dist\Backup_Flashable.zip", True)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Folders = My.Computer.FileSystem.GetDirectories("Styles", FileIO.SearchOption.SearchTopLevelOnly)
        For Each Folder In Folders
            Styles.Add(Folder.Replace(Application.StartupPath & "\Styles\", ""))
        Next
        Cmd.Start(Application.StartupPath + "\Tools\")
        If Process.GetProcessesByName("adb").Length = 0 Then Cmd.ExecuteCommand("adb start-server")
    End Sub

    Private Sub LblSteps_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LblSteps.MouseClick
        If SelectOption Then
            Dim Size As Size = TextRenderer.MeasureText(LblSteps.Text, LblSteps.Font)
            Dim Text As New TextBox
            Text.Multiline = True
            Text.Size = LblSteps.Size
            Text.Location = LblSteps.Location
            Text.TextAlign = HorizontalAlignment.Center
            Text.Font = LblSteps.Font
            Text.Text = LblSteps.Text
            If e.Y - ((Text.Height - Size.Height) / 2) > 0 AndAlso e.Y - ((Text.Height - Size.Height) / 2) < Size.Height Then
                Dim p = New Point(e.X, e.Y - ((Text.Height - Size.Height) / 2))
                Selected = Text.GetLineFromCharIndex(Text.GetCharIndexFromPosition(p)) + 1
            End If
        End If
        If LblSteps.Tag = "Start" Then
            LblTitle.Text = "Step 1"
            LblSteps.Tag = "Step1"
            LblSteps.Text = "1. Download && Mod Apps from connected device" & vbNewLine & "2. Mod an existing files" & vbNewLine & "3. Add && Delete styles"
            Dim Thread As New Threading.Thread(AddressOf Step1)
            Thread.Start()
            SelectOption = True
        ElseIf LblSteps.Tag = "Step2" Then
            LblTitle.Text = "Step 2"
            LblSteps.Text = "Downloading necessary files"
            LblSteps.Tag = "Step3"
            Dim Thread As New Threading.Thread(AddressOf Step2)
            Thread.Start()
        ElseIf LblSteps.Tag = "Exit" Then
            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ kill-server")
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
        Dim A2 As New Animate(LblRights)
        If Rights = 0 Then
            A2.Properties("Text") = "Programmed by : Osama Ghareeb"
        ElseIf Rights = 1 Then
            A2.Properties("Text") = "Please be patient..."
        ElseIf Rights = 2 Then
            A2.Properties("Text") = "Enjoy ^__^"
        End If
        A2.Animate(Animates.LitterLitter)
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TmrAnimate.Enabled = True
    End Sub

    Public Sub Step1()
        Try
Back:
            Do While Selected = 0
                Application.DoEvents()
                Threading.Thread.Sleep(100)
            Loop
            SelectOption = False
            If Selected = 1 Then
                Me.Invoke(Sub()
                              LblSteps.Text = "Please enable USB debugging on your mobile" & vbNewLine & "Settings >> Developer options >> USB debugging" & vbNewLine & "Then plug it to pc"
                          End Sub)
                Dim Thread As New Threading.Thread(AddressOf Step1_2)
                Thread.Start()
            ElseIf Selected = 2 Then
                ModExisting = True
                Dim Files As New FrmFiles
                Dim Exited As Boolean = False
                Me.Invoke(Sub()
                              Me.Files = Files
                              If Files.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                                  LastStep(False, "", 3)
                                  Call LblSteps_MouseClick(Nothing, Nothing)
                                  Exited = True
                              End If
                          End Sub)
                If Exited Then
                    Exit Sub
                End If
                Me.Invoke(Sub()
                              LblSteps.Text = "Preparing files..."
                          End Sub)
                If Files.TxtSettings.Text = "" Then
                    ModSettings = False
                Else
                    ModSettings = True
                    Dim Info1 = My.Computer.FileSystem.GetFileInfo(Files.TxtSettings.Text)
                    Settings = Info1.Name
                    My.Computer.FileSystem.CopyFile(Files.TxtSettings.Text, "Tools\" & Settings, True)
                End If
                Dim Info = My.Computer.FileSystem.GetFileInfo(Files.TxtSystemUI.Text)
                SystemUI = Info.Name
                My.Computer.FileSystem.CopyFile(Files.TxtSystemUI.Text, "Tools\" & SystemUI, True)

                For Each File In My.Computer.FileSystem.GetFiles(Files.TxtFwRs.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.apk")
                    Cmd.ExecuteCommand("apktool if " & File)
                Next
                For Each File In My.Computer.FileSystem.GetFiles(Files.TxtFwRs.Text, FileIO.SearchOption.SearchTopLevelOnly, New String() {"*.jar", "*.odex"})
                    Dim F = My.Computer.FileSystem.GetFileInfo(File)
                    My.Computer.FileSystem.CopyFile(File, "Tools\Framework\" & F.Name)
                Next
                If Not CheckIfDeodxed("Tools\" & SystemUI) Then
                    Info = My.Computer.FileSystem.GetFileInfo(Files.TxtSystemUI.Text.Substring(0, Files.TxtSystemUI.Text.Length - 3) & "odex")
                    My.Computer.FileSystem.CopyFile(Info.FullName, "Tools\" & Info.Name, True)
                End If
                If Not CheckIfDeodxed("Tools\" & SystemUI) Then
                    Info = My.Computer.FileSystem.GetFileInfo(Files.TxtSystemUI.Text.Substring(0, Files.TxtSystemUI.Text.Length - 3) & "odex")
                    My.Computer.FileSystem.CopyFile(Info.FullName, "Tools\" & Info.Name, True)
                    Me.Invoke(Sub()
                                  LblSteps.Text = "Deodexing " & SystemUI
                              End Sub)
                    DeodexSystemUI()
                    My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                    My.Computer.FileSystem.DeleteFile("tools\" & Info.Name)
                End If
                If ModSettings Then
                    If Not CheckIfDeodxed("Tools\" & Settings) Then
                        Info = My.Computer.FileSystem.GetFileInfo(Files.TxtSettings.Text.Substring(0, Files.TxtSettings.Text.Length - 3) & "odex")
                        My.Computer.FileSystem.CopyFile(Info.FullName, "Tools\" & Info.Name, True)
                        Me.Invoke(Sub()
                                      LblSteps.Text = "Deodexing " & Settings
                                  End Sub)
                        DeodexSettings()
                        My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                        My.Computer.FileSystem.DeleteFile("tools\" & Info.Name)
                    End If
                End If
                Me.Invoke(Sub()
                              LblSteps.Text = "Preparing files..."
                          End Sub)
                My.Computer.FileSystem.DeleteDirectory("tools\framework", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.DeleteDirectory("tools\code", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Dim Thread As New Threading.Thread(AddressOf Step3)
                Thread.Start()
            ElseIf Selected = 3 Then
                Dim Styles As New FrmStyles
                Me.Invoke(Sub()
                              Me.Hide()
                              Styles.ShowDialog()
                              Me.Show()
                          End Sub)
                Selected = 0
                SelectOption = True
                GoTo Back
            End If
            Selected = 0
        Catch ex As Exception
            SaveError(ex)
        End Try
    End Sub

    Public Sub Step1_2()
        Try
            Dim Devices As String() = GetConnectedDevices()
            Do While Devices.Count = 0
                Application.DoEvents()
                Threading.Thread.Sleep(100)
                Devices = GetConnectedDevices()
            Loop
            If Devices.Count = 1 Then
                SelectedDevice = Devices(0)
            Else
                Dim Frm As New FrmChoose
                Frm.LblTitle.Text = "Please select your device :"
                Frm.Text = "Devices List"
                For Each Device In Devices
                    Frm.ComboBox1.Items.Add(Device)
                Next
                Frm.ShowDialog()
                SelectedDevice = Frm.ComboBox1.Text
            End If
            Me.Invoke(Sub()
                          LblSteps.Tag = "Step2"
                      End Sub)
            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/build.prop build.prop")
            If My.Computer.FileSystem.FileExists("tools\build.prop") Then
                TmrCheck.Enabled = False
                Dim Text As String = My.Computer.FileSystem.ReadAllText("tools\build.prop")
                My.Computer.FileSystem.DeleteFile("tools\build.prop")
                Dim Ver As String = JustAfter(Text, "ro.build.version.sdk=", Chr(10))
                Dim Brand As String = JustAfter(Text, "ro.product.brand=", Chr(10))
                Me.Ver = Ver
                If Not Ver >= 9 AndAlso MsgBox("Sorry : This MOD for android 2.3 ~ 4.2.2 only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = MsgBoxResult.Ok Then
                    LastStep(False, "", 3)
                    Me.Invoke(Sub()
                                  Call LblSteps_MouseClick(Nothing, Nothing)
                              End Sub)
                    Exit Sub
                End If
                Me.Invoke(Sub()
                              LblSteps.Text = String.Format("{0}{1}{2}{3}{4}", Brand.ToUpper, " " & JustAfter(Text, "ro.product.model=", Chr(10)), " Found", vbNewLine, "Press to continue")
                          End Sub)
            Else
                MsgBox("Failed to checking device info")
            End If
        Catch ex As Exception
            SaveError(ex)
        End Try
    End Sub

    Public Sub Step2()
        Try
            Rights = 1
            If MsgBox("Did you want to add 'Battery Style' option in 'Setting>>Display' ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                ModSettings = False
            End If
            Cmd.Result = ""
            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ shell")
            Cmd.ExecuteCommand("cd system")
            Cmd.ExecuteCommand("cd app")
            Cmd.ExecuteCommand("pwd")
            If Cmd.Result.Contains("/system/app") Then
                Cmd.Result = ""
                Cmd.ExecuteCommand("ls")
                Cmd.Result = Cmd.Result.Replace("[0m", "")
                Cmd.Result = Cmd.Result.Replace("[0;0m", "")
                Dim ApkFiles As String() = ReadFiles(Cmd.Result, New String() {"apk"})
                Dim OdexFiles As String() = ReadFiles(Cmd.Result, New String() {"odex"})
                Dim SystemUI As String = (From App In ApkFiles Select App Where App.ToLower.Contains("systemui"))(0)
                Dim SystemUIOdex As String = (From App In OdexFiles Select App Where App.ToLower.Contains("systemui"))(0)
                Dim Settings As String = (From App In ApkFiles Select App Where App.ToLower.Contains("settings.apk") AndAlso Not App.ToLower.Contains("provider"))(0)
                Dim SettingsOdex As String = (From App In OdexFiles Select App Where App.ToLower.Contains("settings.odex") AndAlso Not App.ToLower.Contains("provider"))(0)
                If ModSettings AndAlso (From App In ApkFiles Select App Where App.ToLower.Contains("settings") AndAlso Not App.ToLower.Contains("provider")).Count > 0 Then
                    Dim Text As String = ""
                    Dim Frm As New FrmChoose
                    For Each SettingFile In (From App In ApkFiles Select App Where App.ToLower.Contains("settings") AndAlso Not App.ToLower.Contains("provider"))
                        Frm.ComboBox1.Items.Add(SettingFile)
                    Next
                    Frm.ShowDialog()
                    Settings = Frm.ComboBox1.Text
                    If Array.IndexOf(OdexFiles, Settings.Replace("apk", "odex")) Then
                        SettingsOdex = (From App In OdexFiles Select App Where App.ToLower = Settings.ToLower.Replace(".apk", ".odex"))(0)
                    End If
                End If
                If SystemUI Is Nothing Then
                    MsgBox("SystemUI.apk not found")
                    LastStep(True)
                    Exit Sub
                End If
                If ModSettings AndAlso Settings Is Nothing Then
                    MsgBox("Settings.apk not found")
                    LastStep(True)
                    Exit Sub
                End If
                Me.SystemUI = SystemUI
                Me.Settings = Settings
                Cmd.ExecuteCommand("cd ..")
                Cmd.ExecuteCommand("cd framework")
                Cmd.ExecuteCommand("pwd")
                If Cmd.Result.Contains("/system/framework") Then
                    Cmd.Result = ""
                    Cmd.ExecuteCommand("ls")
                    Cmd.Result = Cmd.Result.Replace("[0m", "")
                    Cmd.Result = Cmd.Result.Replace("[0;0m", "")
                    SaveFrameworkFiles(Cmd.Result)
                    Cmd.ExecuteCommand("exit")
                    For Each File In RecourceFiles
                        If File.ToString.ToLower.EndsWith("apk") Then
                            ChangeStep("Downloading necessary files" & vbNewLine & File)
                            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/framework/" & File & " " & File)
                            If Not My.Computer.FileSystem.FileExists("tools\" & File) Then MsgBox("Failed to download files") : LastStep(True) : Exit Sub
                            Cmd.ExecuteCommand("apktool if """ & File & """")
                        End If
                    Next
                    ChangeStep("Downloading necessary files")
                Else
                    MsgBox("Failed to download from '/system/framework'")
                    LastStep(True)
                    Exit Sub
                End If
                If SystemUIOdex IsNot Nothing OrElse (ModSettings AndAlso SettingsOdex IsNot Nothing) Then
                    Odex = True
                    ChangeStep("Downloading necessary files" & vbNewLine & "init.rc")
                    Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /init.rc init.rc")
                    If My.Computer.FileSystem.FileExists("tools\init.rc") Then
                        Dim Framework As String = JustAfter(My.Computer.FileSystem.ReadAllText("tools\init.rc"), "BOOTCLASSPATH", Chr(10))
                        Framework = Replace(Framework, "/system/framework/", "")
                        DownloadFrameworkFiles(Framework)
                        My.Computer.FileSystem.DeleteFile("tools\init.rc")
                    Else
                        DownloadFrameworkFiles("")
                    End If
                    ChangeStep("Downloading necessary files" & vbNewLine & SystemUI)
                    Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/app/" & SystemUI & " " & SystemUI)
                    If Not CheckIfDeodxed(SystemUI) Then
                        If My.Computer.FileSystem.DirectoryExists("tools\code") Then My.Computer.FileSystem.DeleteDirectory("tools\code", FileIO.DeleteDirectoryOption.DeleteAllContents)
                        ChangeStep("Downloading necessary files" & vbNewLine & SystemUIOdex)
                        Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/app/" & SystemUIOdex & " " & SystemUIOdex)
                        If My.Computer.FileSystem.FileExists("tools\" & SystemUI) AndAlso My.Computer.FileSystem.FileExists("tools\" & SystemUIOdex) Then
                            ChangeStep("Downloading necessary files" & vbNewLine & "Deodexing")
                            DeodexSystemUI()
                            My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                            My.Computer.FileSystem.DeleteFile("tools\" & SystemUIOdex)
                        Else
                            MsgBox("Failed to download & deodexing '" & Me.SystemUI & "' & '" & Me.Settings & "'")
                            LastStep(True)
                            Exit Sub
                        End If
                    End If
                    If ModSettings Then
                        ChangeStep("Downloading necessary files" & vbNewLine & Settings)
                        Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/app/" & Settings & " " & Settings)
                        If Not CheckIfDeodxed(Settings) Then
                            If My.Computer.FileSystem.DirectoryExists("tools\code") Then My.Computer.FileSystem.DeleteDirectory("tools\code", FileIO.DeleteDirectoryOption.DeleteAllContents)
                            ChangeStep("Downloading necessary files" & vbNewLine & SettingsOdex)
                            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/app/" & SettingsOdex & " " & SettingsOdex)
                            If (My.Computer.FileSystem.FileExists("tools\" & Settings) AndAlso My.Computer.FileSystem.FileExists("tools\" & SettingsOdex)) Then
                                ChangeStep("Downloading necessary files" & vbNewLine & "Deodexing")
                                DeodexSettings()
                                My.Computer.FileSystem.DeleteFile("tools\classes.dex")
                                My.Computer.FileSystem.DeleteFile("tools\" & SettingsOdex)
                            Else
                                MsgBox("Failed to download '" & Me.SystemUI & "' & '" & Me.Settings & "'")
                                LastStep(True)
                                Exit Sub
                            End If
                        End If
                    End If
                    If My.Computer.FileSystem.DirectoryExists("tools\framework") Then My.Computer.FileSystem.DeleteDirectory("tools\framework", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    If My.Computer.FileSystem.DirectoryExists("tools\code") Then My.Computer.FileSystem.DeleteDirectory("tools\code", FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Me.Invoke(Sub()
                                  LblTitle.Text = "Step 3"
                                  LblSteps.Text = "Adding OGBatteryMod"
                                  LblSteps.Tag = "Step3"
                                  Dim Thread As New Threading.Thread(AddressOf Step3)
                                  Thread.Start()
                              End Sub)
                Else
                    Cmd.Result = ""
                    ChangeStep("Downloading necessary files" & vbNewLine & SystemUI)
                    Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/app/" & SystemUI & " " & SystemUI)
                    If ModSettings Then
                        ChangeStep("Downloading necessary files" & vbNewLine & Settings)
                        Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/app/" & Settings & " " & Settings)
                    End If
                    If My.Computer.FileSystem.FileExists("tools\" & SystemUI) AndAlso (Not ModSettings OrElse My.Computer.FileSystem.FileExists("tools\" & Settings)) Then
                        Me.Invoke(Sub()
                                      LblTitle.Text = "Step 3"
                                      LblSteps.Text = "Adding OGBatteryMod"
                                      LblSteps.Tag = "Step3"
                                      Dim Thread As New Threading.Thread(AddressOf Step3)
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
        Catch ex As Exception
            SaveError(ex)
        End Try
E:
    End Sub

    Public Sub Step3()
        Try
            Application.DoEvents()
            For Each File In RecourceFiles
                My.Computer.FileSystem.DeleteFile("Tools\" & File)
            Next
            If SystemUI.ToLower.Contains("miui") Then
                My.Computer.FileSystem.CopyFile("Tools\aapt-miui.exe", "Tools\aapt.exe", True)
            Else
                My.Computer.FileSystem.CopyFile("Tools\aapt-default.exe", "Tools\aapt.exe", True)
            End If
            Dim SysPath As String = SystemUI.ToLower.Replace(".apk", "")
            Dim SetPath As String = Settings.ToLower.Replace(".apk", "")
            If My.Computer.FileSystem.DirectoryExists("Tools\OGBatteryMod") Then My.Computer.FileSystem.DeleteDirectory("Tools\OGBatteryMod", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.DirectoryExists("Tools\" & SysPath) Then My.Computer.FileSystem.DeleteDirectory("Tools\" & SysPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.DirectoryExists("Tools\" & SetPath) Then My.Computer.FileSystem.DeleteDirectory("Tools\" & SetPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.DirectoryExists("Tools\dist") Then My.Computer.FileSystem.DeleteDirectory("Tools\dist", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If StylesChanged Then My.Computer.FileSystem.WriteAllBytes("Tools\OGBatteryMod.apk", My.Resources.OGBatteryMod1, False)
            ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling " & SystemUI)
            Decompile(SystemUI)
            If ModSettings Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling " & Settings)
                Decompile(Settings)
            End If
            If StylesChanged Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "Decompiling OGBatteryMod")
                Decompile("OGBatteryMod.apk")
            End If
            Application.DoEvents()
            ChangeStep("Adding OGBatteryMod" & vbNewLine & "Modding...")
            If My.Computer.FileSystem.FileExists("Tools\" & SysPath & "\apktool.yml") Then
                Dim PhoneStatusBar As String = "Tools\" & SysPath & "\smali\com\android\systemui\statusbar\phone\PhoneStatusBar.smali"
                Dim TabletStatusBar As String = "Tools\" & SysPath & "\smali\com\android\systemui\statusbar\tablet\TabletStatusBar.smali"
                If Ver >= 14 OrElse (My.Computer.FileSystem.FileExists(PhoneStatusBar) OrElse My.Computer.FileSystem.FileExists(TabletStatusBar)) Then
                    'Android 4.*
                    Dim Files = My.Computer.FileSystem.GetFiles("Tools\" & SysPath & "\", FileIO.SearchOption.SearchAllSubDirectories, New String() {"*.smali", "*.xml"})
                    For Each File In Files
                        Dim Text As String = My.Computer.FileSystem.ReadAllText(File)
                        Dim NewText As String = Text
                        NewText = Replace(NewText, "Lcom/android/systemui/statusbar/policy/BatteryController", "Lcom/ghareeb/BatteryMod/BatteryController")
                        NewText = Replace(NewText, "Lcom/android/systemui/statusbar/policy/BatteryController$BatteryStateChangeCallback", "Lcom/ghareeb/BatteryMod/BatteryController$BatteryStateChangeCallback")

                        If Not Text.Contains(".source ""BatteryController.java""") AndAlso Not Text.Equals(NewText) Then
                            My.Computer.FileSystem.WriteAllText(File, NewText, False, System.Text.Encoding.ASCII)
                        End If
                    Next
                ElseIf My.Computer.FileSystem.FileExists("Tools\" & SysPath & "\smali\com\android\systemui\statusbar\StatusBarService.smali") Then
                    'Android 2.3.*
                    Dim File As String = "Tools\" & SysPath & "\smali\com\android\systemui\statusbar\StatusBarService.smali"
                    Dim bController As String = ".field bController:Lcom/ghareeb/BatteryMod/BatteryController;"
                    Dim Text As String = My.Computer.FileSystem.ReadAllText(File)
                    Dim NewText As String = Text
                    If Not NewText.Contains(bController) Then
                        If NewText.Contains("# direct methods") Then
                            NewText = Replace(NewText, "# direct methods", bController & vbNewLine & vbNewLine & "# direct methods")
                        ElseIf NewText.Contains("# instance fields") Then
                            NewText = Replace(NewText, "# instance fields", "# instance fields" & vbNewLine & vbNewLine & bController)
                        Else
                            MsgBox("Failed to mod 2.3 " & SystemUI)
                            LastStep(True)
                            Exit Sub
                        End If
                    End If
                    NewText = Replace(NewText, ".method public addIcon" & JustAfter(NewText, ".method public addIcon", ".end method") & ".end method", My.Resources.addIcon)
                    NewText = Replace(NewText, ".method public updateIcon" & JustAfter(NewText, ".method public updateIcon", ".end method") & ".end method", My.Resources.updateIcon)
                    My.Computer.FileSystem.WriteAllText(File, NewText, False, System.Text.Encoding.ASCII)
                Else
                    MsgBox("Unknown '" & SystemUI & "' version")
                    LastStep(True)
                    Exit Sub
                End If
            Else
                MsgBox("Failed to decompiling '" & SystemUI & "'")
                LastStep(True)
                Exit Sub
            End If
            If ModSettings Then
                If My.Computer.FileSystem.FileExists("Tools\" & SetPath & "\apktool.yml") Then
                    Dim Text As String = ""
                    Dim Lines As String()
                    Lines = IO.File.ReadAllLines("Tools\" & SetPath & "\res\xml\display_settings.xml")
                    If (From Line As String In Lines Select Line Where Line.Contains("BatteryMod.BatteryList")).Count > 0 Then
                        Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("BatteryMod.BatteryList"))(0))
                        Lines(Int) = My.Resources.SettingsXML
                    Else
                        Dim Int As Integer = Array.IndexOf(Lines, (From Line As String In Lines Select Line Where Line.Contains("touch_key_light_values"))(0))
                        Dim List As New List(Of String)
                        List.AddRange(Lines)
                        If Int = -1 Then
                            Dim PS = (From Line As String In Lines Select Line Where Line.Contains("</PreferenceScreen>"))
                            Int = Array.LastIndexOf(Lines, PS(PS.Count - 1))
                            List.Insert(Int, My.Resources.SettingsXML)
                            Lines = List.ToArray
                        Else
                            List.Insert(Int + 1, My.Resources.SettingsXML)
                            Lines = List.ToArray
                        End If
                    End If
                    My.Computer.FileSystem.DeleteFile("Tools\" & SetPath & "\res\xml\display_settings.xml")
                    IO.File.WriteAllLines("Tools\" & SetPath & "\res\xml\display_settings.xml", Lines)
                    Lines = IO.File.ReadAllLines("Tools\" & SetPath & "\res\values\strings.xml")
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
                    My.Computer.FileSystem.DeleteFile("Tools\" & SetPath & "\res\values\strings.xml")
                    IO.File.WriteAllLines("Tools\" & SetPath & "\res\values\strings.xml", Lines)
                Else
                    MsgBox("Failed to decompiling '" & Settings & "'")
                    LastStep(True)
                    Exit Sub
                End If
            End If
            If StylesChanged Then
                If My.Computer.FileSystem.FileExists("Tools\OGBatteryMod\apktool.yml") Then
                    Dim Text As String = IO.File.ReadAllText("Tools\OGBatteryMod\res\values\arrays.xml")
                    Dim Val As String = "<string-array name=""BatteryStyle" & JustAfter(Text, "<string-array name=""BatteryStyle", "</string-array>") & "</string-array>"
                    Dim StrStyles As String = ""
                    For Each Style In Styles
                        StrStyles += "        <item>" & Style & "</item>" & vbNewLine
                    Next
                    StrStyles = My.Resources.Styles.Replace("{0}", StrStyles)
                    Text = Text.Replace(Val, StrStyles)
                    My.Computer.FileSystem.DeleteFile("Tools\OGBatteryMod\res\values\arrays.xml")
                    IO.File.WriteAllText("Tools\OGBatteryMod\res\values\arrays.xml", Text)
                    ChangeStep("Adding OGBatteryMod" & vbNewLine & "Copying Styles...")
                    Dim DistFolder As String = "Tools\OGBatteryMod\res\drawable-hdpi\"
                    For Each Style In Styles
                        Dim S As String = Style.Replace(" ", "_").ToLower
                        For N = 0 To 100
                            If My.Computer.FileSystem.FileExists("Styles\" & Style & "\stat_sys_battery_" & S & "_" & N & ".png") Then
                                Dim FileName As String = "Styles\" & Style & "\stat_sys_battery_" & S & "_" & N & ".png"
                                My.Computer.FileSystem.CopyFile(FileName, DistFolder & "stat_sys_battery_" & S & "_" & N & ".png", True)
                            ElseIf My.Computer.FileSystem.FileExists("Styles\" & Style & "\stat_sys_battery_" & N & ".png") Then
                                Dim FileName As String = "Styles\" & Style & "\stat_sys_battery_" & N & ".png"
                                My.Computer.FileSystem.CopyFile(FileName, DistFolder & "stat_sys_battery_" & S & "_" & N & ".png", True)
                            End If
                            If My.Computer.FileSystem.FileExists("Styles\" & Style & "\stat_sys_battery_" & S & "_charge_anim" & N & ".png") Then
                                Dim FileName As String = "Styles\" & Style & "\stat_sys_battery_" & S & "_charge_anim" & N & ".png"
                                My.Computer.FileSystem.CopyFile(FileName, DistFolder & "stat_sys_battery_" & S & "_charge_anim" & N & ".png", True)
                            ElseIf My.Computer.FileSystem.FileExists("Styles\" & Style & "\stat_sys_battery_charge_anim" & N & ".png") Then
                                Dim FileName As String = "Styles\" & Style & "\stat_sys_battery_charge_anim" & N & ".png"
                                My.Computer.FileSystem.CopyFile(FileName, DistFolder & "stat_sys_battery_" & S & "_charge_anim" & N & ".png", True)
                            End If
                        Next
                    Next
                Else
                    MsgBox("Failed to decompiling 'OGBatteryMod'")
                    LastStep(True)
                    Exit Sub
                End If
            End If
            Application.DoEvents()
            ChangeStep("Adding OGBatteryMod" & vbNewLine & "Modding...")
            Cmd.Result = ""
            My.Computer.FileSystem.WriteAllBytes("Tools\Battery.zip", My.Resources.Battery1, False)
            If My.Computer.FileSystem.DirectoryExists("Tools\" & SysPath & "\smali\com\ghareeb\") Then My.Computer.FileSystem.DeleteDirectory("Tools\SystemUI\smali\com\ghareeb\", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.DirectoryExists("Tools\" & SetPath & "\smali\com\ghareeb\") Then My.Computer.FileSystem.DeleteDirectory("Tools\SecSettings\smali\com\ghareeb\", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Extract(SysPath & "\smali\com\ghareeb\", "Battery.zip")
            My.Computer.FileSystem.DeleteFile("Tools\Battery.zip")
            ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling " & SystemUI)
            Compile(SysPath)
            If Not My.Computer.FileSystem.FileExists("Tools\" & SysPath & "\dist\" & SystemUI) Then
                MsgBox("Failed to compiling " & SystemUI)
                LastStep(True)
                Exit Sub
            End If
            If ModSettings Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling " & Settings)
                Compile(SetPath)
            End If
            If ModSettings AndAlso Not My.Computer.FileSystem.FileExists("Tools\" & SetPath & "\dist\" & Settings) Then
                MsgBox("Failed to compiling " & Settings)
                LastStep(True)
                Exit Sub
            End If
            If StylesChanged Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "Compiling OGBatteryMod")
                Compile("OGBatteryMod")
            End If
            If StylesChanged AndAlso Not My.Computer.FileSystem.FileExists("Tools\OGBatteryMod\dist\OGBatteryMod.apk") Then
                MsgBox("Failed to compiling 'OGBatteryMod'")
                LastStep(True)
                Exit Sub
            End If
            ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing " & SystemUI)
            If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
            ExtractFile("META-INF", SystemUI, "META-INF")
            ExtractFile("", SystemUI, "AndroidManifest.xml")
            AddFile(SysPath & "\dist\" & SystemUI, "META-INF\CERT.RSA")
            AddFile(SysPath & "\dist\" & SystemUI, "META-INF\CERT.SF")
            AddFile(SysPath & "\dist\" & SystemUI, "META-INF\MANIFEST.MF")
            AddFile(SysPath & "\dist\" & SystemUI, "AndroidManifest.xml")
            If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
            Application.DoEvents()
            If ModSettings Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing " & Settings)
                Threading.Thread.Sleep(100)
                If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
                If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
                ExtractFile("META-INF", Settings, "META-INF")
                ExtractFile("", Settings, "AndroidManifest.xml")
                AddFile(SetPath & "\dist\" & Settings, "META-INF\CERT.RSA")
                AddFile(SetPath & "\dist\" & Settings, "META-INF\CERT.SF")
                AddFile(SetPath & "\dist\" & Settings, "META-INF\MANIFEST.MF")
                AddFile(SetPath & "\dist\" & Settings, "AndroidManifest.xml")
            End If
            If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")

            If StylesChanged Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "Signing OGBatteryMod")
                Threading.Thread.Sleep(100)
                If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
                If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
                ExtractFile("META-INF", "OGBatteryMod.apk", "META-INF")
                ExtractFile("", "OGBatteryMod.apk", "AndroidManifest.xml")
                AddFile("OGBatteryMod\dist\OGBatteryMod.apk", "META-INF\CERT.RSA")
                AddFile("OGBatteryMod\dist\OGBatteryMod.apk", "META-INF\CERT.SF")
                AddFile("OGBatteryMod\dist\OGBatteryMod.apk", "META-INF\MANIFEST.MF")
                AddFile("OGBatteryMod\dist\OGBatteryMod.apk", "AndroidManifest.xml")
            End If
            If My.Computer.FileSystem.DirectoryExists("Tools\META-INF") Then My.Computer.FileSystem.DeleteDirectory("Tools\META-INF", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If My.Computer.FileSystem.FileExists("Tools\AndroidManifest.xml") Then My.Computer.FileSystem.DeleteFile("Tools\AndroidManifest.xml")
            Dim Zip1 As Boolean = True
            Dim Zip2 As Boolean = True
            Dim Zip3 As Boolean = True
            Cmd.Result = ""
            ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning " & SystemUI)
            Zip1 = ZipAlign(Application.StartupPath & "\Tools\" & SysPath & "\dist\" & SystemUI)
            If ModSettings Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning " & Settings)
                Zip2 = ZipAlign(Application.StartupPath & "\Tools\" & SetPath & "\dist\" & Settings)
            End If
            If StylesChanged Then
                ChangeStep("Adding OGBatteryMod" & vbNewLine & "ZipAligning OGBatteryMod")
                Zip3 = ZipAlign(Application.StartupPath & "\Tools\OGBatteryMod\dist\OGBatteryMod.apk")
            End If
            ChangeStep("Adding OGBatteryMod")
            If Zip1 AndAlso Zip2 AndAlso Zip3 Then
                My.Computer.FileSystem.MoveFile("Tools\" & SysPath & "\dist\" & SystemUI, "Tools\dist\" & SystemUI, True)
                If ModSettings Then My.Computer.FileSystem.MoveFile("Tools\" & SetPath & "\dist\" & Settings, "Tools\dist\" & Settings, True)
                If StylesChanged Then My.Computer.FileSystem.MoveFile("Tools\OGBatteryMod\dist\OGBatteryMod.apk", "Tools\dist\OGBatteryMod.apk", True)
            Else
                MsgBox("Failed to ZipAligning")
                LastStep(True)
            End If
            My.Computer.FileSystem.DeleteDirectory("Tools\" & SysPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            If ModSettings Then My.Computer.FileSystem.DeleteDirectory("Tools\" & SetPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            If StylesChanged Then My.Computer.FileSystem.DeleteDirectory("Tools\OGBatteryMod", FileIO.DeleteDirectoryOption.DeleteAllContents)
            If Zip1 AndAlso Zip2 AndAlso Zip3 Then
                Me.Invoke(Sub()
                              LblTitle.Text = "Step 4"
                              LblSteps.Text = "Applying changes"
                              LblSteps.Tag = "Step4"
                              Dim Thread As New Threading.Thread(AddressOf Step4)
                              Thread.Start()
                          End Sub)
            End If
        Catch ex As Exception
            SaveError(ex)
        End Try
    End Sub

    Public Sub Step4()
        Try
            Rights = 0
            Cmd.Result = ""
            SelectOption = True
            If Not StylesChanged Then My.Computer.FileSystem.WriteAllBytes("Tools\dist\OGBatteryMod.apk", My.Resources.OGBatteryMod, False)
            If ModExisting Then
                ChangeStep("Creating Flashabel Zip")
                CreateFlashabel()
                Process.Start(Application.StartupPath & "\Tools\dist\")
                GoTo LastStep
            End If
            ChangeStep("1. Apply changes && restart device" & vbNewLine & "2. Copy new files to '/sdcard/og' " & vbNewLine & "3. Create Flashable Zip") ' & vbNewLine & "4. Create flashable zip"
            Do While Selected = 0
                Threading.Thread.Sleep(500)
            Loop
            If Selected = 1 OrElse Selected = 2 Then
                ChangeStep("Applying changes" & vbNewLine & "Copying Files to /sdcard/og")
                Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ shell mkdir /sdcard/og/")
                Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ shell mkdir /sdcard/og/backup")
                Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ push dist\" & SystemUI & " /sdcard/og/" & SystemUI)
                Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ push " & SystemUI & " /sdcard/og/backup/" & SystemUI)
                If ModSettings Then
                    Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ push dist\" & Settings & " /sdcard/og/" & Settings)
                    Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ push " & Settings & " /sdcard/og/backup/" & Settings)
                End If
                Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ push dist\OGBatteryMod.apk /sdcard/og/OGBatteryMod.apk")
                Cmd.Result = ""
                Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ shell")
                Cmd.ExecuteCommand("cd sdcard")
                Cmd.ExecuteCommand("cd og")
                Cmd.ExecuteCommand("ls")
                Cmd.ExecuteCommand("exit")
                If Cmd.Result.Contains(SystemUI) AndAlso (Not ModSettings OrElse Cmd.Result.Contains(Settings)) Then
                    If Selected = 2 Then GoTo LastStep
                    ChangeStep("Applying changes" & vbNewLine & "Asking for ROOT access")
                    AppActivate(Process.GetCurrentProcess.Id)
                    Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ shell")
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
                    Cmd.ExecuteCommand("rm /system/app/" & SystemUI.Replace("apk", "odex"))
                    If ModSettings Then
                        Cmd.ExecuteCommand("rm /system/app/" & Settings)
                        Cmd.ExecuteCommand("rm /system/app/" & Settings.Replace("apk", "odex"))
                    End If
                    Cmd.ExecuteCommand("rm /system/app/OGBatteryMod.apk")
                    Cmd.ExecuteCommand("cp /sdcard/og/" & SystemUI & " /system/app/" & SystemUI)
                    If ModSettings Then Cmd.ExecuteCommand("cp /sdcard/og/" & Settings & " /system/app/" & Settings)
                    Cmd.ExecuteCommand("cp /sdcard/og/OGBatteryMod.apk /system/app/OGBatteryMod.apk")

                    Cmd.ExecuteCommand("chmod 644 /system/app/" & SystemUI)
                    If ModSettings Then Cmd.ExecuteCommand("chmod 644 /system/app/" & Settings)
                    Cmd.ExecuteCommand("chmod 644 /system/app/OGBatteryMod.apk")
                    Cmd.ExecuteCommand("mount -o rw,remount /system/ /system")
                    Cmd.ExecuteCommand("reboot")
                Else
                    MsgBox("Failed to copy files to phone")
                    LastStep(True)
                    Exit Sub
                End If
            ElseIf Selected = 3 Then
                ChangeStep("Creating Flashabel Zip")
                CreateFlashabel()
                Process.Start(Application.StartupPath & "\Tools\dist\")
            End If
LastStep:
            Me.Invoke(Sub()
                          Img = 1
                          LblTitle.Text = "Modding Complate"
                          LblSteps.Text = "Programmed by : Osama Ghareeb" & vbNewLine & _
                              "Twitter : @OsGhareeb" & vbNewLine & _
                              "Enjoy ^_^"
                          LblSteps.Tag = "Exit"
                      End Sub)
        Catch ex As Exception
            SaveError(ex)
        End Try
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

    Public Sub DeodexSettings()
        Application.DoEvents()
        Dim Jar As String = ""
        For Each File In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Tools\Framework", FileIO.SearchOption.SearchTopLevelOnly, "*.jar")
            Jar += String.Format(":{0}", File.Replace(Application.StartupPath & "\Tools\Framework\", "").ToLower)
        Next
        Baksmali(Settings.Substring(0, Settings.Length - 3) & "odex", Jar)
        Smali()
        AddFile(Settings, Application.StartupPath & "\tools\classes.dex")
        Application.DoEvents()
    End Sub

    Public Sub DeodexSystemUI()
        Application.DoEvents()
        Dim Jar As String = ""
        For Each File In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Tools\Framework", FileIO.SearchOption.SearchTopLevelOnly, "*.jar")
            Jar += String.Format(":{0}", File.Replace(Application.StartupPath & "\Tools\Framework\", "").ToLower)
        Next
        Baksmali(SystemUI.Substring(0, SystemUI.Length - 3) & "odex", Jar)
        Smali()
        AddFile(SystemUI, Application.StartupPath & "\tools\classes.dex")
        Application.DoEvents()
    End Sub

    Public Sub DownloadFrameworkFiles(ByVal Framework As String)
        For Each File In If(Framework.Length > 0, Split(Framework, ":"), FrameworkFiles.Keys)
            Application.DoEvents()
            File = FrameworkFiles(File.Trim)
            Cmd.Result = ""
            ChangeStep("Downloading necessary files" & vbNewLine & File)
            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/framework/" & File & " Framework\" & File)
            ChangeStep("Downloading necessary files" & vbNewLine & Replace(File, ".jar", ".odex"))
            Cmd.ExecuteCommand("adb -s """ & SelectedDevice & """ pull /system/framework/" & Replace(File, ".jar", ".odex") & " Framework\" & Replace(File, ".jar", ".odex"))
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
        Cmd.ExecuteCommand(String.Format("java -Xmx1024m -jar baksmali.jar -a " & Ver & " -c {0} -d ""{1}"" -o {2} -x ""{3}""", JarFiles, Application.StartupPath & "\tools\framework", "code", File))
    End Sub

    Private Function ZipAlign(ByVal File As String) As Boolean
        Application.DoEvents()
        Dim Cmd As String = String.Format("""" & Application.StartupPath & "\Tools\zipalign.exe"" -v 4 ""{0}"" ""{1}""", File, File & "_za")
        Shell(Cmd, AppWinStyle.Hide, True)
        Try
            My.Computer.FileSystem.MoveFile(File & "_za", File, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Decompile(ByVal File As String)
        Cmd.ExecuteCommand(String.Format("apktool d -f ""{0}""", File))
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

    Public Function GetConnectedDevices() As String()
        Dim Devices As New List(Of String)
        Try
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

            Do While Results(Index) IsNot Nothing AndAlso Results(Index).Trim.Length > 3
                Results(Index) = Results(Index).Trim
                If Results(Index).Contains("device") Then
                    Dim Name As String = Strings.Left(Results(Index).Trim, InStr(Results(Index).Trim, "device") - 2)
                    Devices.Add(Name)
                End If
                Index += 1
            Loop
        Catch ex As Exception
        End Try
        Return Devices.ToArray
    End Function

    Private Sub TmrClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrClose.Tick
        End
    End Sub

    Public Function CheckIfDeodxed(ByVal File As String) As Boolean
        If My.Computer.FileSystem.FileExists("Tools\classes.dex") Then My.Computer.FileSystem.DeleteFile("Tools\classes.dex")
        Dim Command As String = String.Format("7z e ""{0}""{1} ""{2}""", File, "", "classes.dex")
        Cmd.ExecuteCommand(Command)
        If My.Computer.FileSystem.FileExists("Tools\classes.dex") Then
            My.Computer.FileSystem.DeleteFile("Tools\classes.dex")
            Return True
        Else
            Return False
        End If
    End Function
End Class
