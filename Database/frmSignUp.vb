'******************* FORM ELEMENT NAMES *********************
' LABELS:
' lblUser, lblPass, lblEmail, lblSalary, Label1, Label2,
' Label3, Label4
' 
' BUTTONS:
' btnCancel
'************************************************************

Public Class frmSignUp

    '******************** DECLARE VARIABLES *********************



    '******************* FORM ELEMENT EVENTS ********************


    '************************************************************
    ' btnCancel click event closes the form
    '************************************************************

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '************************************************************
    ' Form load event sets this location to the proper
    ' one.
    '************************************************************

    Private Sub frmSignUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.Show()
        frmMain.Location = Me.Location
    End Sub

    '************************************************************
    ' btnSignUp click event runs the SignUp sub procedure
    '************************************************************

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        SignUp()
    End Sub

    '************************************************************
    ' chbShow CheckedChanged event changes the hidden value of
    ' the password textbox
    '************************************************************
    Private Sub chbShow_CheckedChanged(sender As Object, e As EventArgs) Handles chbShow.CheckedChanged
        txtPass.UseSystemPasswordChar = Not chbShow.Checked
    End Sub

    '************************************************************
    ' Form load event sets this location to the proper
    ' one.
    '************************************************************

    Private Sub frmSignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = frmMain.Location
    End Sub


    '**************** USER-DEFINED SUB PROCEDURES ***************


    '*********************** Description ************************
    '
    ' SignUp sub checks the form for empty sources of data,
    ' then runs the AddUser sub procedure from the SQL module.
    '
    '******************** FORM ELEMENTS USED ********************
    '
    ' Textboxes: lblUser, lblPass, lblEmail, lblSalary
    '
    ' Labels: lblUser, lblPass, lblEmail, lblSalary
    '
    '************************************************************

    Private Sub SignUp()
        Dim username, password, email, salary As String
        Dim sal As Double

        username = txtUser.Text
        password = txtPass.Text
        email = txtEmail.Text
        salary = txtSalary.Text

        If username <> "" Then
            lblUser.ForeColor = Color.Black
            If password <> "" Then
                lblPass.ForeColor = Color.Black
                If email <> "" Then
                    lblEmail.ForeColor = Color.Black
                    If salary <> "" Then
                        lblSalary.ForeColor = Color.Black
                        If Double.TryParse(salary, sal) Then
                            salary = FormatCurrency(sal)
                            If AddUser(username, password, GetID(), email, salary) Then
                                Me.Close()
                            Else
                                MessageBox.Show("Error: User already exists!",
                                                "Error!",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error)
                            End If
                        Else
                            lblSalary.ForeColor = Color.Red
                        End If
                    End If
                Else
                    lblEmail.ForeColor = Color.Red
                End If
            Else
                lblPass.ForeColor = Color.Red
            End If
        Else
            lblUser.ForeColor = Color.Red
        End If
    End Sub
End Class