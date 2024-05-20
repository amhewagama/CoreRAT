<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RightclickMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SystemInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstalledSoftwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TCPConnectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartupManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileManagerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurveillanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteKeyloggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewThumbnailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrivilegsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsSystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServerOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FromURLToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteDesktopToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Notify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Rightclick_OnConnect = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenUrlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShoweMessageBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnableActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.compiler = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ipAddr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.login = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PCname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OSV = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Pvlg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ping = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListViewOnConnect = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_PlaySound = New System.Windows.Forms.CheckBox()
        Me.cb_ShowNotification = New System.Windows.Forms.CheckBox()
        Me.cb_autolistening = New System.Windows.Forms.CheckBox()
        Me.btn_stoplistening = New System.Windows.Forms.Button()
        Me.btn_startlistening = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RightclickMain.SuspendLayout()
        Me.Rightclick_OnConnect.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RightclickMain
        '
        Me.RightclickMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemInformationToolStripMenuItem, Me.SurveillanceToolStripMenuItem, Me.ToolStripMenuItem1, Me.FileManagerToolStripMenuItem1, Me.RemoteDesktopToolStripMenuItem1, Me.ViewThumbnailsToolStripMenuItem, Me.GroupByToolStripMenuItem, Me.WindowsSystemToolStripMenuItem, Me.ServerOptionsToolStripMenuItem})
        Me.RightclickMain.Name = "RightclickMain"
        Me.RightclickMain.Size = New System.Drawing.Size(179, 202)
        '
        'SystemInformationToolStripMenuItem
        '
        Me.SystemInformationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstalledSoftwareToolStripMenuItem, Me.TCPConnectionsToolStripMenuItem, Me.StartupManagerToolStripMenuItem})
        Me.SystemInformationToolStripMenuItem.Image = CType(resources.GetObject("SystemInformationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SystemInformationToolStripMenuItem.Name = "SystemInformationToolStripMenuItem"
        Me.SystemInformationToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SystemInformationToolStripMenuItem.Text = "System Information"
        '
        'InstalledSoftwareToolStripMenuItem
        '
        Me.InstalledSoftwareToolStripMenuItem.Image = CType(resources.GetObject("InstalledSoftwareToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InstalledSoftwareToolStripMenuItem.Name = "InstalledSoftwareToolStripMenuItem"
        Me.InstalledSoftwareToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.InstalledSoftwareToolStripMenuItem.Text = "Installed Software"
        '
        'TCPConnectionsToolStripMenuItem
        '
        Me.TCPConnectionsToolStripMenuItem.Image = Global.coreRAT.My.Resources.Resources.greenball
        Me.TCPConnectionsToolStripMenuItem.Name = "TCPConnectionsToolStripMenuItem"
        Me.TCPConnectionsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.TCPConnectionsToolStripMenuItem.Text = "TCP Connections"
        '
        'StartupManagerToolStripMenuItem
        '
        Me.StartupManagerToolStripMenuItem.Image = CType(resources.GetObject("StartupManagerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StartupManagerToolStripMenuItem.Name = "StartupManagerToolStripMenuItem"
        Me.StartupManagerToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.StartupManagerToolStripMenuItem.Text = "Startup Manager"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.coreRAT.My.Resources.Resources.page_white_gear
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem1.Text = "Task Manager"
        '
        'FileManagerToolStripMenuItem1
        '
        Me.FileManagerToolStripMenuItem1.Image = Global.coreRAT.My.Resources.Resources.folder
        Me.FileManagerToolStripMenuItem1.Name = "FileManagerToolStripMenuItem1"
        Me.FileManagerToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.FileManagerToolStripMenuItem1.Text = "File Manager"
        '
        'SurveillanceToolStripMenuItem
        '
        Me.SurveillanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoteKeyloggerToolStripMenuItem})
        Me.SurveillanceToolStripMenuItem.Image = CType(resources.GetObject("SurveillanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SurveillanceToolStripMenuItem.Name = "SurveillanceToolStripMenuItem"
        Me.SurveillanceToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SurveillanceToolStripMenuItem.Text = "Surveillance"
        '
        'RemoteKeyloggerToolStripMenuItem
        '
        Me.RemoteKeyloggerToolStripMenuItem.Image = CType(resources.GetObject("RemoteKeyloggerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoteKeyloggerToolStripMenuItem.Name = "RemoteKeyloggerToolStripMenuItem"
        Me.RemoteKeyloggerToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RemoteKeyloggerToolStripMenuItem.Text = "Remote Keylogger"
        '
        'ViewThumbnailsToolStripMenuItem
        '
        Me.ViewThumbnailsToolStripMenuItem.Image = CType(resources.GetObject("ViewThumbnailsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ViewThumbnailsToolStripMenuItem.Name = "ViewThumbnailsToolStripMenuItem"
        Me.ViewThumbnailsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ViewThumbnailsToolStripMenuItem.Text = "View Thumbnails"
        '
        'GroupByToolStripMenuItem
        '
        Me.GroupByToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CountryToolStripMenuItem, Me.PrivilegsToolStripMenuItem})
        Me.GroupByToolStripMenuItem.Image = CType(resources.GetObject("GroupByToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GroupByToolStripMenuItem.Name = "GroupByToolStripMenuItem"
        Me.GroupByToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.GroupByToolStripMenuItem.Text = "Group By"
        '
        'CountryToolStripMenuItem
        '
        Me.CountryToolStripMenuItem.Image = CType(resources.GetObject("CountryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CountryToolStripMenuItem.Name = "CountryToolStripMenuItem"
        Me.CountryToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.CountryToolStripMenuItem.Text = "Country"
        '
        'PrivilegsToolStripMenuItem
        '
        Me.PrivilegsToolStripMenuItem.Image = CType(resources.GetObject("PrivilegsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrivilegsToolStripMenuItem.Name = "PrivilegsToolStripMenuItem"
        Me.PrivilegsToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.PrivilegsToolStripMenuItem.Text = "Privilegs"
        '
        'WindowsSystemToolStripMenuItem
        '
        Me.WindowsSystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LockToolStripMenuItem, Me.RestartToolStripMenuItem1, Me.ShutDownToolStripMenuItem})
        Me.WindowsSystemToolStripMenuItem.Image = CType(resources.GetObject("WindowsSystemToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WindowsSystemToolStripMenuItem.Name = "WindowsSystemToolStripMenuItem"
        Me.WindowsSystemToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.WindowsSystemToolStripMenuItem.Text = "Windows System"
        '
        'LockToolStripMenuItem
        '
        Me.LockToolStripMenuItem.Name = "LockToolStripMenuItem"
        Me.LockToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.LockToolStripMenuItem.Text = "Logout"
        '
        'RestartToolStripMenuItem1
        '
        Me.RestartToolStripMenuItem1.Name = "RestartToolStripMenuItem1"
        Me.RestartToolStripMenuItem1.Size = New System.Drawing.Size(132, 22)
        Me.RestartToolStripMenuItem1.Text = "Restart"
        '
        'ShutDownToolStripMenuItem
        '
        Me.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem"
        Me.ShutDownToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ShutDownToolStripMenuItem.Text = "Shut Down"
        '
        'ServerOptionsToolStripMenuItem
        '
        Me.ServerOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteFileToolStripMenuItem, Me.PingToolStripMenuItem, Me.RestartToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.ServerOptionsToolStripMenuItem.Image = CType(resources.GetObject("ServerOptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ServerOptionsToolStripMenuItem.Name = "ServerOptionsToolStripMenuItem"
        Me.ServerOptionsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ServerOptionsToolStripMenuItem.Text = "Server Options"
        '
        'ExecuteFileToolStripMenuItem
        '
        Me.ExecuteFileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FromFileToolStripMenuItem1, Me.FromURLToolStripMenuItem1})
        Me.ExecuteFileToolStripMenuItem.Image = CType(resources.GetObject("ExecuteFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExecuteFileToolStripMenuItem.Name = "ExecuteFileToolStripMenuItem"
        Me.ExecuteFileToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExecuteFileToolStripMenuItem.Text = "Execute File"
        '
        'FromFileToolStripMenuItem1
        '
        Me.FromFileToolStripMenuItem1.Image = CType(resources.GetObject("FromFileToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.FromFileToolStripMenuItem1.Name = "FromFileToolStripMenuItem1"
        Me.FromFileToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.FromFileToolStripMenuItem1.Text = "From File"
        '
        'FromURLToolStripMenuItem1
        '
        Me.FromURLToolStripMenuItem1.Image = CType(resources.GetObject("FromURLToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.FromURLToolStripMenuItem1.Name = "FromURLToolStripMenuItem1"
        Me.FromURLToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.FromURLToolStripMenuItem1.Text = "From URL"
        '
        'PingToolStripMenuItem
        '
        Me.PingToolStripMenuItem.Image = CType(resources.GetObject("PingToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PingToolStripMenuItem.Name = "PingToolStripMenuItem"
        Me.PingToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PingToolStripMenuItem.Text = "Ping"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Image = CType(resources.GetObject("RestartToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = Global.coreRAT.My.Resources.Resources.redball
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'RemoteDesktopToolStripMenuItem1
        '
        Me.RemoteDesktopToolStripMenuItem1.Image = Global.coreRAT.My.Resources.Resources.monitor
        Me.RemoteDesktopToolStripMenuItem1.Name = "RemoteDesktopToolStripMenuItem1"
        Me.RemoteDesktopToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.RemoteDesktopToolStripMenuItem1.Text = "Remote Desktop"
        '
        'Notify
        '
        Me.Notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.Notify.Icon = CType(resources.GetObject("Notify.Icon"), System.Drawing.Icon)
        Me.Notify.Text = "coreRAT"
        Me.Notify.Visible = True
        '
        'Rightclick_OnConnect
        '
        Me.Rightclick_OnConnect.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenUrlToolStripMenuItem, Me.DownloadExecuteToolStripMenuItem, Me.ShoweMessageBoxToolStripMenuItem, Me.RemoveActionToolStripMenuItem, Me.DisableActionToolStripMenuItem, Me.EnableActionToolStripMenuItem})
        Me.Rightclick_OnConnect.Name = "Rightclick_OnConnect"
        Me.Rightclick_OnConnect.Size = New System.Drawing.Size(195, 136)
        '
        'OpenUrlToolStripMenuItem
        '
        Me.OpenUrlToolStripMenuItem.Image = CType(resources.GetObject("OpenUrlToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenUrlToolStripMenuItem.Name = "OpenUrlToolStripMenuItem"
        Me.OpenUrlToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.OpenUrlToolStripMenuItem.Text = "Open Url"
        '
        'DownloadExecuteToolStripMenuItem
        '
        Me.DownloadExecuteToolStripMenuItem.Image = CType(resources.GetObject("DownloadExecuteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DownloadExecuteToolStripMenuItem.Name = "DownloadExecuteToolStripMenuItem"
        Me.DownloadExecuteToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DownloadExecuteToolStripMenuItem.Text = "Download and Execute"
        '
        'ShoweMessageBoxToolStripMenuItem
        '
        Me.ShoweMessageBoxToolStripMenuItem.Image = CType(resources.GetObject("ShoweMessageBoxToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ShoweMessageBoxToolStripMenuItem.Name = "ShoweMessageBoxToolStripMenuItem"
        Me.ShoweMessageBoxToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ShoweMessageBoxToolStripMenuItem.Text = "Show MessageBox"
        '
        'RemoveActionToolStripMenuItem
        '
        Me.RemoveActionToolStripMenuItem.Image = CType(resources.GetObject("RemoveActionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RemoveActionToolStripMenuItem.Name = "RemoveActionToolStripMenuItem"
        Me.RemoveActionToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RemoveActionToolStripMenuItem.Text = "Remove Action"
        '
        'DisableActionToolStripMenuItem
        '
        Me.DisableActionToolStripMenuItem.Image = CType(resources.GetObject("DisableActionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DisableActionToolStripMenuItem.Name = "DisableActionToolStripMenuItem"
        Me.DisableActionToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DisableActionToolStripMenuItem.Text = "Disable Action"
        '
        'EnableActionToolStripMenuItem
        '
        Me.EnableActionToolStripMenuItem.Image = CType(resources.GetObject("EnableActionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EnableActionToolStripMenuItem.Name = "EnableActionToolStripMenuItem"
        Me.EnableActionToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EnableActionToolStripMenuItem.Text = "Enable Action"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.ToolStripButton2, Me.ToolStripLabel2, Me.ToolStripButton3, Me.ToolStripLabel3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 307)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(895, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Listen Port"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "Listen port"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.coreRAT.My.Resources.Resources.wrench_orange
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel2.Text = "Client Build"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.coreRAT.My.Resources.Resources._stop
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Segoe Print", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripLabel3.Text = "Stop Server"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "connect.png")
        Me.ImageList1.Images.SetKeyName(1, "disconnect.png")
        Me.ImageList1.Images.SetKeyName(2, "folder_magnify.png")
        Me.ImageList1.Images.SetKeyName(3, "user.png")
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(895, 307)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(887, 278)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clients"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.compiler, Me.Type, Me.ipAddr, Me.login, Me.PCname, Me.OS, Me.OSV, Me.Pvlg, Me.ping})
        Me.ListView1.ContextMenuStrip = Me.RightclickMain
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(881, 272)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'compiler
        '
        Me.compiler.Text = "Location"
        Me.compiler.Width = 62
        '
        'Type
        '
        Me.Type.Text = "Type"
        Me.Type.Width = 100
        '
        'ipAddr
        '
        Me.ipAddr.Text = "IP"
        Me.ipAddr.Width = 80
        '
        'login
        '
        Me.login.Text = "Login-Name"
        Me.login.Width = 100
        '
        'PCname
        '
        Me.PCname.Text = "PC-Name"
        Me.PCname.Width = 100
        '
        'OS
        '
        Me.OS.Text = "OS"
        Me.OS.Width = 168
        '
        'OSV
        '
        Me.OSV.Text = "OS -V"
        '
        'Pvlg
        '
        Me.Pvlg.Text = "OS -Pv"
        Me.Pvlg.Width = 70
        '
        'ping
        '
        Me.ping.Text = "Ping"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(887, 278)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(769, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 36)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Save Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListViewOnConnect)
        Me.GroupBox3.Location = New System.Drawing.Point(442, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(426, 208)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "On Connect"
        '
        'ListViewOnConnect
        '
        Me.ListViewOnConnect.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.ListViewOnConnect.ContextMenuStrip = Me.Rightclick_OnConnect
        Me.ListViewOnConnect.FullRowSelect = True
        Me.ListViewOnConnect.Location = New System.Drawing.Point(6, 28)
        Me.ListViewOnConnect.Name = "ListViewOnConnect"
        Me.ListViewOnConnect.Size = New System.Drawing.Size(414, 174)
        Me.ListViewOnConnect.TabIndex = 0
        Me.ListViewOnConnect.UseCompatibleStateImageBehavior = False
        Me.ListViewOnConnect.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Action"
        Me.ColumnHeader10.Width = 156
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Information"
        Me.ColumnHeader11.Width = 171
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Status"
        Me.ColumnHeader12.Width = 69
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_PlaySound)
        Me.GroupBox1.Controls.Add(Me.cb_ShowNotification)
        Me.GroupBox1.Controls.Add(Me.cb_autolistening)
        Me.GroupBox1.Controls.Add(Me.btn_stoplistening)
        Me.GroupBox1.Controls.Add(Me.btn_startlistening)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 259)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'cb_PlaySound
        '
        Me.cb_PlaySound.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb_PlaySound.AutoSize = True
        Me.cb_PlaySound.Location = New System.Drawing.Point(21, 188)
        Me.cb_PlaySound.Name = "cb_PlaySound"
        Me.cb_PlaySound.Size = New System.Drawing.Size(152, 17)
        Me.cb_PlaySound.TabIndex = 6
        Me.cb_PlaySound.Text = "Play Sound on Connection"
        Me.cb_PlaySound.UseVisualStyleBackColor = True
        '
        'cb_ShowNotification
        '
        Me.cb_ShowNotification.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb_ShowNotification.AutoSize = True
        Me.cb_ShowNotification.Location = New System.Drawing.Point(21, 165)
        Me.cb_ShowNotification.Name = "cb_ShowNotification"
        Me.cb_ShowNotification.Size = New System.Drawing.Size(181, 17)
        Me.cb_ShowNotification.TabIndex = 5
        Me.cb_ShowNotification.Text = "Show Notification on Connection"
        Me.cb_ShowNotification.UseVisualStyleBackColor = True
        '
        'cb_autolistening
        '
        Me.cb_autolistening.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb_autolistening.AutoSize = True
        Me.cb_autolistening.Checked = True
        Me.cb_autolistening.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_autolistening.Location = New System.Drawing.Point(21, 142)
        Me.cb_autolistening.Name = "cb_autolistening"
        Me.cb_autolistening.Size = New System.Drawing.Size(129, 17)
        Me.cb_autolistening.TabIndex = 4
        Me.cb_autolistening.Text = "Enable Auto Listening"
        Me.cb_autolistening.UseVisualStyleBackColor = True
        '
        'btn_stoplistening
        '
        Me.btn_stoplistening.Location = New System.Drawing.Point(308, 94)
        Me.btn_stoplistening.Name = "btn_stoplistening"
        Me.btn_stoplistening.Size = New System.Drawing.Size(100, 32)
        Me.btn_stoplistening.TabIndex = 3
        Me.btn_stoplistening.Text = "Stop Listening"
        Me.btn_stoplistening.UseVisualStyleBackColor = True
        '
        'btn_startlistening
        '
        Me.btn_startlistening.Location = New System.Drawing.Point(308, 44)
        Me.btn_startlistening.Name = "btn_startlistening"
        Me.btn_startlistening.Size = New System.Drawing.Size(100, 32)
        Me.btn_startlistening.TabIndex = 2
        Me.btn_startlistening.Text = "Start Listening"
        Me.btn_startlistening.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 93)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Socks"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(54, 28)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(59, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {465, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(119, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Status: Idle..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port: "
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 332)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(410, 200)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "coreRAT"
        Me.RightclickMain.ResumeLayout(False)
        Me.Rightclick_OnConnect.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RightclickMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Notify As System.Windows.Forms.NotifyIcon
    Friend WithEvents GroupByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CountryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrivilegsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SurveillanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Rightclick_OnConnect As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenUrlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadExecuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShoweMessageBoxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveActionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableActionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnableActionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServerOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecuteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteKeyloggerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewThumbnailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsSystemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents compiler As System.Windows.Forms.ColumnHeader
    Friend WithEvents Type As System.Windows.Forms.ColumnHeader
    Friend WithEvents ipAddr As System.Windows.Forms.ColumnHeader
    Friend WithEvents login As System.Windows.Forms.ColumnHeader
    Friend WithEvents PCname As System.Windows.Forms.ColumnHeader
    Friend WithEvents OS As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListViewOnConnect As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_PlaySound As System.Windows.Forms.CheckBox
    Friend WithEvents cb_ShowNotification As System.Windows.Forms.CheckBox
    Friend WithEvents cb_autolistening As System.Windows.Forms.CheckBox
    Friend WithEvents btn_stoplistening As System.Windows.Forms.Button
    Friend WithEvents btn_startlistening As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents InstalledSoftwareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TCPConnectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartupManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FileManagerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FromURLToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OSV As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pvlg As System.Windows.Forms.ColumnHeader
    Friend WithEvents ping As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteDesktopToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
