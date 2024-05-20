Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Public Class Connection
    Private client As TcpClient
    Private ip As String
    Private socket As String

    Public Event GotInfo(ByVal client As Connection, ByVal message As String)
    Public Event Disconnected(ByVal client As Connection)

    Public Sub New(ByVal client As TcpClient)
        Me.client = client
        client.GetStream().BeginRead(New Byte() {0}, 0, 0, AddressOf Read, Nothing)
        ip = client.Client.RemoteEndPoint.ToString().Remove(client.Client.RemoteEndPoint.ToString().LastIndexOf(":"))
        socket = client.Client.RemoteEndPoint.ToString().Split(":"c)(1)
    End Sub

    Private Sub Read(ByVal ar As IAsyncResult)
        Dim message As String
        Try
            Dim reader As New StreamReader(client.GetStream())
            message = reader.ReadLine()
            RaiseEvent GotInfo(Me, message)
            client.GetStream().BeginRead(New Byte() {0}, 0, 0, AddressOf Read, Nothing)
        Catch ex As Exception
            RaiseEvent Disconnected(Me)
        End Try
    End Sub

    Public Sub Send(ByVal message As String)
        Try
            Dim writer As New StreamWriter(client.GetStream())
            writer.WriteLine(message)
            writer.Flush()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public ReadOnly Property IPAddress As String
        Get
            Return ip
        End Get
    End Property

    Public ReadOnly Property RemoteSocket As String
        Get
            Return socket
        End Get
    End Property
End Class
