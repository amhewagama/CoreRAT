Public Class FormfileManager
    Public connected As Connection

    Private Sub ChangeFont(ByVal container As Control)
        For Each ctrl As Control In container.Controls
            ' Change font for the control
            ctrl.Font = New Font("Comic Sans MS", 9, FontStyle.Regular)

            ' If the control has children, recursively change their fonts
            If ctrl.HasChildren Then
                ChangeFont(ctrl)
            End If
        Next
    End Sub

#Region "FileManager"
    Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.Click
        ComboBox1.Items.Clear()
        connected.Send(New Encryption().AES_Encrypt("ListDrives", Form1.enckey))
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView_Files.Items.Clear()
        connected.Send(New Encryption().AES_Encrypt("ListFiles" & ComboBox1.SelectedItem, Form1.enckey))
    End Sub
    Private Sub ListView_Files_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ListView_Files.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                ListView_Files.ContextMenuStrip = rightclick_filemanagerfolders
            ElseIf ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "0" Then
                ListView_Files.ContextMenuStrip = rightclick_filemanagerfiles
            Else
                ListView_Files.ContextMenuStrip = rightclick_nothing
            End If
        Catch
        End Try
    End Sub
    Private Sub ListView_Files_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles ListView_Files.DoubleClick
        Try
            If ListView_Files.SelectedItems.Item(0).Text = "[...]" Then
                Dim i As Integer = Form1.CountCharacter(TextBox1.Text, "\")
                Dim text As String = TextBox1.Text
                Dim x As String = ComboBox1.SelectedItem & text.Replace(text.Split("\")(i - 1) & "\", "")

                ListView_Files.Items.Clear()

                connected.Send(New Encryption().AES_Encrypt("ListFiles" & x, Form1.enckey))

                ListView_Files.Items.Add("[...]", 23)
            End If

            Dim curpath As String = Form1.path & ListView_Files.SelectedItems.Item(0).Text & "\"

            ListView_Files.Items.Clear()

            connected.Send(New Encryption().AES_Encrypt("ListFiles" & curpath, Form1.enckey))

            ListView_Files.Items.Add("[...]", 23)
        Catch
        End Try
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PictureBox2.Click
        Try
            ListView_Files.Items.Clear()
            connected.Send(New Encryption().AES_Encrypt("ListFiles" & ComboBox1.SelectedItem & TextBox1.Text, Form1.enckey))
            If Not TextBox1.Text = "" Then ListView_Files.Items.Add("[...]", 23)
        Catch
        End Try
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox2_Click(New Object(), New System.EventArgs())
        End If
    End Sub
    Private Sub RefreshToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        Try
            ListView_Files.Items.Clear()

            connected.Send(New Encryption().AES_Encrypt("ListFiles" & Form1.path, Form1.enckey))

            If Not TextBox1.Text = "" Then ListView_Files.Items.Add("[...]", 23)
        Catch
        End Try
    End Sub
    Private Sub RefreshToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RefreshToolStripMenuItem2.Click
        Try
            ListView_Files.Items.Clear()

            connected.Send(New Encryption().AES_Encrypt("ListFiles" & Form1.path, Form1.enckey))

            If Not TextBox1.Text = "" Then ListView_Files.Items.Add("[...]", 23)
        Catch
        End Try
    End Sub
    Private Sub RefreshToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RefreshToolStripMenuItem3.Click
        Try
            ListView_Files.Items.Clear()

            connected.Send(New Encryption().AES_Encrypt("ListFiles" & Form1.path, Form1.enckey))

            If Not TextBox1.Text = "" Then ListView_Files.Items.Add("[...]", 23)

        Catch
        End Try
    End Sub
    Private Sub CreateNewFolderToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateNewFolderToolStripMenuItem.Click
        Try
            Dim FolderName As String = InputBox("Please specify a Name for the folder you want to create!", "New Directory")
            If FolderName = "" Then
                MsgBox("No Folder was created, due empty name!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("mkdir" & Form1.path & FolderName, Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub CreateNewFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateNewFileToolStripMenuItem.Click
        Try
            Dim FolderName As String = InputBox("Please specify a Name for the folder you want to create!", "New Directory")
            If FolderName = "" Then
                MsgBox("No Folder was created, due empty name!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("mkdir" & Form1.path & FolderName, Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub CreateNewFolderToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateNewFolderToolStripMenuItem1.Click
        Try
            Dim FolderName As String = InputBox("Please specify a Name for the folder you want to create!", "New Directory")
            If FolderName = "" Then
                MsgBox("No Folder was created, due empty name!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("mkdir" & Form1.path & FolderName, Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub DeleteFolderToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteFolderToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "0" Then
                MsgBox("Please select a Folder!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("rmdir" & Form1.path & ListView_Files.SelectedItems.Item(0).Text, Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub RenameFolderToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RenameFolderToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "0" Then
                MsgBox("Please select a Folder!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim newname As String = InputBox("Please enter a new Name for the Directory", "Rename Folder")
            If newname = "" Then
                MsgBox("Rename failed, due empty name", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("rnfolder" & Form1.path & ListView_Files.SelectedItems.Item(0).Text & "|" & newname, Form1.enckey))
        Catch
        End Try
    End Sub

    Private Sub MoveThisFolderToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MoveThisFolderToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "0" Then
                MsgBox("Please select a Folder!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Form1.oldpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
            Form1.nam = ListView_Files.SelectedItems.Item(0).Text

            rightclick_filemanagerfolders.Items.RemoveByKey("Copy1")
            rightclick_filemanagerfiles.Items.RemoveByKey("Copy2")
            rightclick_filemanagerfolders.Items.RemoveByKey("Move1")
            rightclick_filemanagerfiles.Items.RemoveByKey("Move2")
            rightclick_nothing.Items.RemoveByKey("Copy3")
            rightclick_nothing.Items.RemoveByKey("Move3")

            Dim itm As New ToolStripMenuItem("Move Folder here")
            itm.Image = My.Resources.folder__arrow
            itm.Name = "Move1"
            rightclick_filemanagerfolders.Items.Add(itm)
            AddHandler itm.Click, AddressOf MoveHereItem_Click

            Dim itm2 As New ToolStripMenuItem("Move Folder here")
            itm2.Image = My.Resources.folder__arrow
            itm2.Name = "Move2"
            rightclick_filemanagerfiles.Items.Add(itm2)
            AddHandler itm2.Click, AddressOf MoveHereItem_Click

            Dim itm3 As New ToolStripMenuItem("Move Folder here")
            itm3.Image = My.Resources.folder__arrow
            itm3.Name = "Move2"
            rightclick_nothing.Items.Add(itm3)
            AddHandler itm3.Click, AddressOf MoveHereItem_Click
        Catch
        End Try
    End Sub
    Sub MoveHereItem_Click()
        Try
            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            connected.Send(New Encryption().AES_Encrypt("mvdir" & Form1.oldpath & "\|" & newpath & "\|" & Form1.nam, Form1.enckey))

            rightclick_filemanagerfolders.Items.RemoveByKey("Move1")
            rightclick_filemanagerfiles.Items.RemoveByKey("Move2")
            rightclick_nothing.Items.RemoveByKey("Move3")
        Catch
        End Try
    End Sub
    Sub PasteHereItem_Click()
        Try
            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            connected.Send(New Encryption().AES_Encrypt("cpdir" & Form1.oldpath & "\|" & newpath & "\|" & Form1.nam, Form1.enckey))

            rightclick_filemanagerfolders.Items.RemoveByKey("Copy1")
            rightclick_filemanagerfiles.Items.RemoveByKey("Copy2")
            rightclick_nothing.Items.RemoveByKey("Copy3")
        Catch
        End Try
    End Sub
    Private Sub CreateNewFileToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateNewFileToolStripMenuItem1.Click
        Try
            newfile.connected = connected

            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            newfile.path = newpath

            newfile.Show()
        Catch
        End Try
    End Sub
    Private Sub CreateNewFileToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateNewFileToolStripMenuItem2.Click
        Try
            newfile.connected = connected

            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            newfile.path = newpath

            newfile.Show()
        Catch
        End Try
    End Sub
    Private Sub CreateNewFileToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateNewFileToolStripMenuItem3.Click
        Try
            newfile.connected = connected

            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            newfile.path = newpath

            newfile.Show()
        Catch
        End Try
    End Sub
    Private Sub DeleteFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                MsgBox("Please select a File!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("rmfile" & Form1.path & ListView_Files.SelectedItems.Item(0).Text, Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub RenameFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RenameFileToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                MsgBox("Please select a File!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim newname As String = InputBox("Please enter a new Name for the File", "Rename File")
            If newname = "" Then
                MsgBox("Rename failed, due empty name", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("rnfile" & Form1.path & ListView_Files.SelectedItems.Item(0).Text & "|" & newname, Form1.enckey))
        Catch
        End Try
    End Sub

    Private Sub MoveFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MoveFileToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                MsgBox("Please select a File!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Form1.oldpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text
            Form1.nam = ListView_Files.SelectedItems.Item(0).Text

            rightclick_filemanagerfolders.Items.RemoveByKey("Copy1f")
            rightclick_filemanagerfiles.Items.RemoveByKey("Copy2f")
            rightclick_filemanagerfolders.Items.RemoveByKey("Move1f")
            rightclick_filemanagerfiles.Items.RemoveByKey("Move2f")
            rightclick_nothing.Items.RemoveByKey("Copy3f")
            rightclick_nothing.Items.RemoveByKey("Move3f")

            Dim itm As New ToolStripMenuItem("Move File here")
            itm.Image = My.Resources.document__arrow
            itm.Name = "Move1f"
            rightclick_filemanagerfolders.Items.Add(itm)
            AddHandler itm.Click, AddressOf MoveFileHere

            Dim itm2 As New ToolStripMenuItem("Move File here")
            itm2.Image = My.Resources.document__arrow
            itm2.Name = "Move2f"
            rightclick_filemanagerfiles.Items.Add(itm2)
            AddHandler itm2.Click, AddressOf MoveFileHere

            Dim itm3 As New ToolStripMenuItem("Move File here")
            itm3.Image = My.Resources.document__arrow
            itm3.Name = "Move2f"
            rightclick_nothing.Items.Add(itm3)
            AddHandler itm3.Click, AddressOf MoveFileHere
        Catch
        End Try
    End Sub
    Sub PasteFileHere()
        Try
            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text + "\"
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            connected.Send(New Encryption().AES_Encrypt("copyfile" & Form1.oldpath & "|" & newpath & "|" & Form1.nam, Form1.enckey))

            rightclick_filemanagerfolders.Items.RemoveByKey("Copy1f")
            rightclick_filemanagerfiles.Items.RemoveByKey("Copy2f")
            rightclick_nothing.Items.RemoveByKey("Copy3f")
        Catch
        End Try
    End Sub
    Sub MoveFileHere()
        Try
            Dim newpath As String
            Try
                If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                    newpath = Form1.path & ListView_Files.SelectedItems.Item(0).Text + "\"
                Else
                    newpath = Form1.path
                End If
            Catch
                newpath = Form1.path
            End Try

            connected.Send(New Encryption().AES_Encrypt("movefile" & Form1.oldpath & "|" & newpath & "|" & Form1.nam, Form1.enckey))

            rightclick_filemanagerfolders.Items.RemoveByKey("Move1f")
            rightclick_filemanagerfiles.Items.RemoveByKey("Move2f")
            rightclick_nothing.Items.RemoveByKey("Move3f")
        Catch
        End Try
    End Sub
    Private Sub DownloadFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DownloadFileToolStripMenuItem.Click
        Try
            Form1.filename = ListView_Files.SelectedItems.Item(0).Text
            connected.Send(New Encryption().AES_Encrypt("sharefile" & Form1.path & Form1.filename, Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub UploadFileToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UploadFileToolStripMenuItem2.Click
        Try
            Dim ofd As New OpenFileDialog
            With ofd
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
                .Multiselect = False
                .Title = "Select a File to upload!"
            End With
            Dim res = ofd.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then
                connected.Send(New Encryption().AES_Encrypt("FileUpload" & Form1.path & ListView_Files.SelectedItems.Item(0).Text & "\" & ofd.FileName.Split("\")(Form1.CountCharacter(ofd.FileName, "\")), Form1.enckey))
            Else
            End If
        Catch
        End Try
    End Sub
    Private Sub UploadFileToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UploadFileToolStripMenuItem1.Click
        Try
            Dim ofd As New OpenFileDialog
            With ofd
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
                .Multiselect = False
                .Title = "Select a File to upload!"
            End With
            Dim res = ofd.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then
                connected.Send(New Encryption().AES_Encrypt("FileUpload" & Form1.path & ofd.FileName.Split("\")(Form1.CountCharacter(ofd.FileName, "\")), Form1.enckey))
            Else
            End If
        Catch
        End Try
    End Sub
    Private Sub UploadFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UploadFileToolStripMenuItem.Click
        Try
            Dim ofd As New OpenFileDialog
            With ofd
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString
                .Multiselect = False
                .Title = "Select a File to upload!"
            End With
            Dim res = ofd.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then
                connected.Send(New Encryption().AES_Encrypt("FileUpload" & Form1.path & "|" & ofd.FileName.Split("\")(Form1.CountCharacter(ofd.FileName, "\") & "|" & New Encryption().EncryptBase64(IO.File.ReadAllBytes(ofd.FileName))), Form1.enckey))
            Else
            End If
        Catch
        End Try
    End Sub
#End Region

    Private Sub ListView_Files_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Files.SelectedIndexChanged

    End Sub

    Private Sub ExecuteFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteFileToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "1" Then
                MsgBox("Please select a File!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("exfile" & Form1.path & ListView_Files.SelectedItems.Item(0).Text, Form1.enckey))
        Catch
        End Try
    End Sub

    Private Sub ExecutePathToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecutePathToolStripMenuItem.Click
        Try
            If ListView_Files.SelectedItems.Item(0).SubItems(4).Text = "0" Then
                MsgBox("Please select a Folder!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            connected.Send(New Encryption().AES_Encrypt("exdir" & Form1.path & ListView_Files.SelectedItems.Item(0).Text, Form1.enckey))
        Catch
        End Try
    End Sub

    Private Sub FormfileManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChangeFont(Me)
    End Sub
End Class