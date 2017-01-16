Imports System.Data.SqlClient

'************************** SQL MODULE **********************
' 
' Description: This module is designed to provide a way
' to interface with the database.
'
' PORTFOLIO NOTE: I did my best to space the queries so they
' are readable and provide basic documentation that provided
' a general idea of the function purpose as well as the
' existing names of things that cannot be overridden.
'
'************************************************************


Module SQL

    '******************** DECLARE VARIABLES *********************

    Private SQLCon As New SqlConnection With {
        .ConnectionString = String.Format("Data Source=.\SQLExpress;" &
        "AttachDbFilename={0}\UserDB.mdf;" &
        "Integrated Security=True;" &
        "Connect Timeout=30;" &
        "User Instance=True",
        My.Application.Info.DirectoryPath)
    } ' Connection to the file (treated as a server from hereon out)

    Private SQLCmd As SqlCommand    ' Empty command for future queries
    Private SQLDA As SqlDataAdapter ' Empty data adapter for future data
    Private SQLDS As DataSet        ' Empty data set for future data


    '**************** USER-DEFINED SUB PROCEDURES ***************


    '*********************** Description ************************
    '
    ' TestCon function returns a boolean indicating whether the
    ' connection exists or not, and provides an error message.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    '
    '************************************************************

    Public Function TestCon() As Boolean

        Try
            SQLCon.Open()
            SQLCon.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("You have removed the database file or " &
                            "turned off/uninstalled localDB",
                            "Error!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '*********************** Description ************************
    '
    ' AddUser function returns a boolean indicating whether the
    ' user already exists or not.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    '
    ' SqlCommand: SQLCmd
    '
    '*********************** PARAMETERS *************************
    '
    ' Strings: username, password, email, salary
    '
    ' Integers: ID
    '
    '************** ***** QUERY PARAMETERS **********************
    '
    ' username: VarChar(25)
    ' password: VarChar(25)
    ' id: Int
    ' email: VarChar(25)
    ' salary: VarChar(15)
    '
    '************************************************************

    Public Function AddUser(username As String,
                            password As String,
                            ID As Integer,
                            email As String,
                            salary As String) As Boolean

        Dim query As String = "INSERT INTO members (" &
        "username, " &
        "password, " &
        "id, " &
        "email, " &
        "salary)  " &
        "VALUES (@username, @password, @id, @email, @salary)"

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.Add("@username",
                                    SqlDbType.VarChar,
                                    25).Value = username

                    .Parameters.Add("@password",
                                    SqlDbType.VarChar,
                                    25).Value = password

                    .Parameters.Add("@id",
                                    SqlDbType.Int).Value = ID

                    .Parameters.Add("@email",
                                    SqlDbType.VarChar,
                                    25).Value = email

                    .Parameters.Add("@salary",
                                    SqlDbType.VarChar,
                                    15).Value = salary
                End With
                SQLCon.Open()
                SQLCmd.ExecuteNonQuery()
                SQLCon.Close()
                Return True
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                Return False
            End Try

            SQLCon.Close()
        Else
            Return True
        End If
    End Function

    '*********************** Description ************************
    '
    ' ClearDatabase sub procedure clears the existing database in
    ' SQLCon.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    '
    ' SQLCommand: SQLCmd
    '
    '************************************************************

    Public Sub ClearDatabase()

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = "TRUNCATE TABLE members"
                End With
                SQLCon.Open()
                SQLCmd.ExecuteNonQuery()
                SQLCon.Close()
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                MessageBox.Show(ex.Message,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    '*********************** Description ************************
    '
    ' RemoveUser sub procedure removes the entry in the database
    ' with the selected username located at SQLCon.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    '
    ' SQLCommand: SQLCmd
    ' 
    '*********************** PARAMETERS *************************
    '
    ' Strings: username
    '
    '************** ***** QUERY PARAMETERS **********************
    '
    ' username: VarChar(25)
    '
    '************************************************************

    Public Sub RemoveUser(username As String)

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM members " &
                                    "WHERE username=@username"
                    .Parameters.Add("@username",
                                    SqlDbType.VarChar,
                                    25).Value = username
                End With
                SQLCon.Open()
                SQLCmd.ExecuteNonQuery()
                SQLCon.Close()
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                MessageBox.Show(ex.Message,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

            SQLCon.Close()
        End If

    End Sub

    '*********************** Description ************************
    '
    ' Authenticate function returns a boolean indicating whether the
    ' user and password combination exist. User is not case sensitive.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    ' SqlCommand: SQLCmd
    ' SqlDataAdapter: SQLDA
    ' DataSet: SQLDS
    '
    '*********************** PARAMETERS *************************
    '
    ' Strings: username, password
    '
    '************** ***** QUERY PARAMETERS **********************
    '
    ' username: VarChar(25)
    ' password: VarChar(25)
    '
    '************************************************************

    Public Function Authenticate(username As String,
                                 password As String) As Boolean

        Dim query As String = String.Empty
        query &= "SELECT Count(username) As UserCount " &
        "FROM members " &
        "WHERE username=@username And password=@password " &
        "COLLATE SQL_Latin1_General_CP1_CS_AS"

        If SQLDS IsNot Nothing Then
            SQLDS.Clear()
        End If

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.Add("@username",
                                    SqlDbType.VarChar,
                                    25).Value = username

                    .Parameters.Add("@password",
                                    SqlDbType.VarChar,
                                    25).Value = password
                End With
                SQLCon.Open()
                SQLDA = New SqlDataAdapter(SQLCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SQLCon.Close()
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                MessageBox.Show(ex.Message,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

            If SQLDS.Tables(0).Rows(0).Item("UserCount") = 1 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    '*********************** Description ************************
    '
    ' GetUser sub procedure returns the data stored for the
    ' username through the parameters.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    ' SqlCommand: SQLCmd
    ' SqlDataAdapter: SQLDA
    ' DataSet: SQLDS
    '
    '
    '*********************** PARAMETERS *************************
    '
    ' Strings: username, password, email, salary
    '
    ' Integers: ID
    '
    '************** ***** QUERY PARAMETERS **********************
    '
    ' username: VarChar(25)
    '
    '************************************************************

    Public Sub GetUser(ByVal username As String,
                       ByRef password As String,
                       ByRef email As String,
                       ByRef salary As String,
                       ByRef ID As Integer)

        Dim query As String = "SELECT email As userMail, " &
        "password As userPass, " &
        "salary As userSal, " &
        "id as userID " &
        "FROM members " &
        "WHERE username=@username"

        If SQLDS IsNot Nothing Then
            SQLDS.Clear()
        End If

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.Add("@username",
                                    SqlDbType.VarChar,
                                    25).Value = username
                End With
                SQLCon.Open()
                SQLDA = New SqlDataAdapter(SQLCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SQLCon.Close()
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                MessageBox.Show(ex.Message,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

            email = SQLDS.Tables(0).Rows(0).Item("userMail")
            salary = SQLDS.Tables(0).Rows(0).Item("userSal")
            password = SQLDS.Tables(0).Rows(0).Item("userPass")
            ID = SQLDS.Tables(0).Rows(0).Item("userID")
        End If
    End Sub

    '*********************** Description ************************
    '
    ' GetID function returns an integer for the ID of the newest
    ' user. It is used to set a default ID for the user when
    ' adding a new one. These are not keyed in this DB.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    ' SQLCommand: SQLCmd
    ' SqlDataAdapter: SQLDA
    ' DataSet: SQLDS
    '
    '************************************************************

    Public Function GetID() As Integer

        Dim query As String = String.Empty
        query &= "SELECT Count(username) As UserCount " &
            "FROM members"


        If SQLDS IsNot Nothing Then
            SQLDS.Clear()
        End If

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                SQLCon.Open()
                SQLDA = New SqlDataAdapter(SQLCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SQLCon.Close()
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                MessageBox.Show(ex.Message,
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

            Return SQLDS.Tables(0).Rows(0).Item("UserCount")
        Else
            Return -1
        End If

    End Function

    '*********************** Description ************************
    '
    ' EditUser function returns a boolean indicating whether the
    ' connection exists or not, and provides an error message.
    '
    '*********************** VARIABLES **************************
    '
    ' SqlConnection: SQLCon
    ' SqlCommand: SQLCmd
    '
    '************** ***** QUERY PARAMETERS **********************
    '
    ' username: VarChar(25)
    ' password: VarChar(25)
    ' email: VarChar(25)
    ' salary: VarChar(15)
    ' searchName: VarChar(25)
    '
    '************************************************************

    Public Function EditUser(ByVal username,
                             ByVal newUser,
                             ByVal password,
                             ByVal email,
                             ByVal salary) As Boolean

        Dim query As String = String.Empty
        query &= "UPDATE members SET username=@username, password=@password, "
        query &= "email=@email, salary=@salary WHERE username=@searchName"

        SQLCmd = New SqlCommand()

        If TestCon() Then
            Try
                With SQLCmd
                    .Connection = SQLCon
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.Add("@username",
                                    SqlDbType.VarChar,
                                    25).Value = newUser

                    .Parameters.Add("@password",
                                    SqlDbType.VarChar,
                                    25).Value = password

                    .Parameters.Add("@email",
                                    SqlDbType.VarChar,
                                    25).Value = email

                    .Parameters.Add("@salary",
                                    SqlDbType.VarChar,
                                    15).Value = salary

                    .Parameters.Add("@searchName",
                                    SqlDbType.VarChar,
                                    25).Value = username
                End With
                SQLCon.Open()
                SQLCmd.ExecuteNonQuery()
                SQLCon.Close()
                Return True
            Catch ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                MessageBox.Show(ex.Message)
                Return False
            End Try
            SQLCon.Close()
            Return True
        Else
            Return False
        End If
    End Function
End Module
