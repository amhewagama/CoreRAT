Public Class DarkModeHelper
    ' Define your dark mode colors
    Private Shared ReadOnly BackgroundColor As Color = Color.FromArgb(45, 45, 48)
    Private Shared ReadOnly ForegroundColor As Color = Color.White
    Private Shared ReadOnly ButtonColor As Color = Color.FromArgb(28, 28, 28)
    Private Shared ReadOnly ButtonTextColor As Color = Color.White

    ' Method to apply dark mode to a form and its controls
    Public Shared Sub ApplyDarkMode(ByVal form As Form)
        form.BackColor = BackgroundColor
        form.ForeColor = ForegroundColor

        ' Iterate through all controls and set their colors
        For Each control As Control In form.Controls
            ApplyDarkModeToControl(control)
        Next
    End Sub

    ' Recursive method to apply dark mode to controls and their child controls
    Private Shared Sub ApplyDarkModeToControl(ByVal control As Control)
        If TypeOf control Is Button Then
            control.BackColor = ButtonColor
            control.ForeColor = ButtonTextColor
        Else
            control.BackColor = BackgroundColor
            control.ForeColor = ForegroundColor
        End If

        ' Apply dark mode to child controls
        For Each childControl As Control In control.Controls
            ApplyDarkModeToControl(childControl)
        Next
    End Sub
End Class
