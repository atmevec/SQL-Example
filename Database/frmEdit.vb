'******************* FORM ELEMENT NAMES *********************
' LABELS:
' lblUser, lblPass, lblEmail, lblSalary
' 
' BUTTONS:
' btnUpdate, btnCancel
'
' CHECKBOXES:
' chbShow
'************************************************************

Public Class frmEdit

    '******************** DECLARE VARIABLES *********************


    Private user As String  'Stores username from frmMain


    '******************* FORM ELEMENT EVENTS ********************


    '************************************************************
    ' Form closing event shows the main form then closes.
    '************************************************************

    Private Sub frmEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.Show()
        frmMain.Location = Me.Location
    End Sub

    '************************************************************
    ' Form load event sets this location to the proper
    ' one.
    '************************************************************

    Private Sub frmEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = frmMain.Location
    End Sub

    '************************************************************
    ' chbShow CheckedChanged event changes the hidden value of
    ' the password textbox
    '************************************************************

    Private Sub chbShow_CheckedChanged(sender As Object, e As EventArgs) Handles chbShow.CheckedChanged
        txtPass.UseSystemPasswordChar = Not chbShow.Checked
    End Sub

    '************************************************************
    ' btnCancel click event closes the window.
    '************************************************************

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '************************************************************
    ' btnUpdate click event runs the UpdateUser sub procedure
    '************************************************************

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateUser()
    End Sub


    '**************** USER-DEFINED SUB PROCEDURES ***************


    '*********************** Description ************************
    '
    ' New sub is a modified sub procedure which initializes this
    ' form with certain data already filled when it is declared.
    ' It is required to have an parameter for form creation.
    '
    '******************** FORM ELEMENTS USED ********************
    '
    ' Textboxes: txtUser, txtPass, txtEmail, txtSalary
    '
    '******************** FORM VARIABLES USED *******************
    '
    ' Strings: user
    '
    '*********************** PARAMETERS *************************
    '
    ' Strings: username
    '
    '************************************************************

    Public Sub New(ByVal username As String)
        Dim email As String = String.Empty
        Dim salary As String = String.Empty
        Dim password As String = String.Empty
        Dim ID As Integer

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetUser(username, password, email, salary, ID)

        txtUser.Text = username
        txtPass.Text = password
        txtEmail.Text = email
        txtSalary.Text = salary
        user = username
    End Sub

    '*********************** Description ************************
    '
    ' UpdateUser sub checks the form for empty sources of data,
    ' then runs the EditUser sub procedure from the SQL module.
    '
    '******************** FORM ELEMENTS USED ********************
    '
    ' Textboxes: txtUser, txtPass, txtEmail, txtSalary
    ' 
    ' Labels: lblUser, lblPass, lblEmail, lblSalary
    '
    '************************************************************

    Private Sub UpdateUser()
        Dim username, password, email, salary As String
        username = txtUser.Text
        password = txtPass.Text
        email = txtEmail.Text
        salary = FormatCurrency(txtSalary.Text)

        If username <> "" Then
            lblUser.ForeColor = Color.Black
            If password <> "" Then
                lblPass.ForeColor = Color.Black
                If email <> "" Then
                    lblEmail.ForeColor = Color.Black
                    If salary <> "" Then
                        lblSalary.ForeColor = Color.Black
                        If EditUser(user, username, password, email, salary) Then
                            Me.Close()
                        Else
                            MessageBox.Show("Error editing user!",
                                            "Error!",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error)
                        End If
                    Else
                        lblSalary.ForeColor = Color.Red
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