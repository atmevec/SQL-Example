'******************* FORM ELEMENT NAMES *********************
' LABELS:
' lblUsername, lblPassword, lblFailure, Label4
' 
' BUTTONS:
' btnLogin, btnSign, btnInfo, btnEdit, btnLogout,
' btnDelete, btnClear
'
' GROUP BOXES:
' grpLogin, grpOptions, grpSign
'************************************************************


Public Class frmMain

    '******************** DECLARE VARIABLES *********************



    '******************* FORM ELEMENT EVENTS ********************


    '************************************************************
    ' btnLogin click event runs the login sub procedure.
    '************************************************************

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    '************************************************************
    ' btnSign click event shows the form frmSignUp and hides
    ' the main one.
    '************************************************************

    Private Sub btnSign_Click(sender As Object, e As EventArgs) Handles btnSign.Click
        frmSignUp.Show()
        Me.Hide()
    End Sub

    '************************************************************
    ' btnLogout click event runs the logout sub.
    '************************************************************

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Logout()
    End Sub

    '************************************************************
    ' btnClear click event asks the user for confirmation, then
    ' runs the Logout and ClearDatabse sub procedures.
    '************************************************************

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MessageBox.Show("Are you sure you want to delete ALL users? This cannot be undone",
                           "Alert!",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Exclamation) = DialogResult.Yes Then
            Logout()
            ClearDatabase()
        End If
    End Sub

    '************************************************************
    ' btnInfo click event creates an info screen for the logged
    ' in user then hides the main form and shows the info form.
    '************************************************************

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        Dim Form1 As frmInfo = New frmInfo(lblUser.Text)
        Me.Hide()
        Form1.Show()
    End Sub

    '************************************************************
    ' btnDelete click event asks the user for confirmation, then
    ' removes the user and logs out with the RemoveUser and
    ' Logout sub procedures.
    '************************************************************

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure you want to delete this user?",
                           "Delete Confirmation",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then
            RemoveUser(lblUser.Text)
            Logout()
        End If
    End Sub

    '************************************************************
    ' btnEdit click event creates an edit screen for the logged
    ' in user then hides the main form and shows the edit form.
    '************************************************************

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim Form1 As frmEdit = New frmEdit(lblUser.Text)
        Me.Hide()
        Form1.Show()
    End Sub

    '************************************************************
    ' txtPass key press event allows someone to log in by pressing
    ' enter when in the password box.
    '************************************************************

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Login()
            e.Handled = True
        End If
    End Sub


    '**************** USER-DEFINED SUB PROCEDURES ***************


    '*********************** Description ************************
    '
    ' Login sub checks validity of the text fields, displays
    ' failure, and/or logs the user in.
    '
    '******************** FORM ELEMENTS USED ********************
    '
    ' Textboxes: txtUser, txtPass
    ' Buttons: btnLogin, btnInfo, btnEdit, btnClear, btnDelete,
    ' btnLogout, btnSign
    ' Labels: lblFailure, lblUser, Label4, lblPassword,
    ' lblUsername
    '
    '************************************************************

    Private Sub Login()
        Dim username, password As String
        username = txtUser.Text
        password = txtPass.Text

        If username <> "" Then
            lblUsername.ForeColor = Color.Black
            If password <> "" Then
                lblPassword.ForeColor = Color.Black
                If Authenticate(username, password) Then
                    lblFailure.Visible = False
                    btnLogin.Enabled = False
                    txtUser.Enabled = False
                    txtPass.Enabled = False
                    txtUser.Text = ""
                    txtPass.Text = ""
                    btnInfo.Visible = True
                    btnEdit.Visible = True
                    btnClear.Visible = True
                    btnDelete.Visible = True
                    btnLogout.Visible = True
                    lblUser.Text = username
                    Label4.Visible = True
                    btnSign.Enabled = False
                Else
                    lblFailure.Visible = True
                End If
            Else
                lblPassword.ForeColor = Color.Red
            End If
        Else
            lblUsername.ForeColor = Color.Red
        End If
    End Sub

    '*********************** Description ************************
    '
    ' Logout sub resets the form by hiding all of the logged
    ' in options and re-enabling all of the logging in options.
    '
    '******************** FORM ELEMENTS USED ********************
    '
    ' Textboxes: txtUser, txtPass
    ' Buttons: btnLogin, btnInfo, btnEdit, btnClear, btnDelete,
    ' btnLogout, btnSign
    ' Labels: lblUser, Label4
    '
    '************************************************************

    Private Sub Logout()
        btnLogin.Enabled = True
        txtUser.Enabled = True
        txtPass.Enabled = True
        btnInfo.Visible = False
        btnEdit.Visible = False
        btnLogout.Visible = False
        btnClear.Visible = False
        btnDelete.Visible = False
        lblUser.Text = ""
        Label4.Visible = False
        btnSign.Enabled = True
    End Sub
End Class
