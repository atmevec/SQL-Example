'******************* FORM ELEMENT NAMES *********************
' LABELS:
' lblUser, lblPass, lblEmail, lblSalary, Label1, Label2,
' Label3, Label4
' 
' BUTTONS:
' btnCancel
'************************************************************

Public Class frmInfo

    '******************** DECLARE VARIABLES *********************



    '******************* FORM ELEMENT EVENTS ********************


    '************************************************************
    ' Closing procedure which confirms the close of the form.
    '************************************************************
    Private Sub frmInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.Show()
        frmMain.Location = Me.Location
    End Sub

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

    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = frmMain.Location
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
    ' Labels: lblUser, lblEmail, lblSalary, lblID
    '
    '************************************************************


    Public Sub New(ByVal username As String)
        Dim email As String = String.Empty
        Dim salary As String = String.Empty
        Dim password As String = String.Empty
        Dim ID As Integer

        ' This call is required by the designer and MUST BE FIRST.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetUser(username, password, email, salary, ID)

        lblUser.Text = username
        lblEmail.Text = email
        lblSalary.Text = salary
        lblID.Text = ID

    End Sub
End Class