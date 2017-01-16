<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.grpLogin = New System.Windows.Forms.GroupBox()
        Me.lblFailure = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.grpSign = New System.Windows.Forms.GroupBox()
        Me.grpLogin.SuspendLayout()
        Me.grpOptions.SuspendLayout()
        Me.grpSign.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLogin
        '
        Me.grpLogin.Controls.Add(Me.lblFailure)
        Me.grpLogin.Controls.Add(Me.btnLogin)
        Me.grpLogin.Controls.Add(Me.lblPassword)
        Me.grpLogin.Controls.Add(Me.txtPass)
        Me.grpLogin.Controls.Add(Me.lblUsername)
        Me.grpLogin.Controls.Add(Me.txtUser)
        Me.grpLogin.Location = New System.Drawing.Point(21, 12)
        Me.grpLogin.Name = "grpLogin"
        Me.grpLogin.Size = New System.Drawing.Size(254, 113)
        Me.grpLogin.TabIndex = 0
        Me.grpLogin.TabStop = False
        Me.grpLogin.Text = "Login"
        '
        'lblFailure
        '
        Me.lblFailure.AutoSize = True
        Me.lblFailure.ForeColor = System.Drawing.Color.Red
        Me.lblFailure.Location = New System.Drawing.Point(29, 68)
        Me.lblFailure.Name = "lblFailure"
        Me.lblFailure.Size = New System.Drawing.Size(200, 13)
        Me.lblFailure.TabIndex = 7
        Me.lblFailure.Text = "Your username or password are incorrect"
        Me.lblFailure.Visible = False
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(89, 84)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "&Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(10, 48)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "Password:"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(74, 45)
        Me.txtPass.MaxLength = 25
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(171, 20)
        Me.txtPass.TabIndex = 4
        Me.txtPass.UseSystemPasswordChar = True
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(10, 22)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 13)
        Me.lblUsername.TabIndex = 3
        Me.lblUsername.Text = "Username:"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(74, 19)
        Me.txtUser.MaxLength = 25
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(171, 20)
        Me.txtUser.TabIndex = 2
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.btnDelete)
        Me.grpOptions.Controls.Add(Me.btnClear)
        Me.grpOptions.Controls.Add(Me.btnLogout)
        Me.grpOptions.Controls.Add(Me.btnEdit)
        Me.grpOptions.Controls.Add(Me.btnInfo)
        Me.grpOptions.Controls.Add(Me.lblUser)
        Me.grpOptions.Controls.Add(Me.Label4)
        Me.grpOptions.Location = New System.Drawing.Point(21, 131)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(375, 119)
        Me.grpOptions.TabIndex = 1
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "User Options"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(278, 32)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "&Delete User"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(278, 77)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "&Clear Users"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(54, 77)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 4
        Me.btnLogout.Text = "&Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        Me.btnLogout.Visible = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(94, 48)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "&Edit Info"
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnInfo
        '
        Me.btnInfo.Location = New System.Drawing.Point(13, 48)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(75, 23)
        Me.btnInfo.TabIndex = 2
        Me.btnInfo.Text = "&View Info"
        Me.btnInfo.UseVisualStyleBackColor = True
        Me.btnInfo.Visible = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(74, 32)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(0, 13)
        Me.lblUser.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Username:"
        Me.Label4.Visible = False
        '
        'btnSign
        '
        Me.btnSign.Location = New System.Drawing.Point(18, 45)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(75, 23)
        Me.btnSign.TabIndex = 7
        Me.btnSign.Text = "&Sign Up"
        Me.btnSign.UseVisualStyleBackColor = True
        '
        'grpSign
        '
        Me.grpSign.Controls.Add(Me.btnSign)
        Me.grpSign.Location = New System.Drawing.Point(281, 12)
        Me.grpSign.Name = "grpSign"
        Me.grpSign.Size = New System.Drawing.Size(115, 113)
        Me.grpSign.TabIndex = 8
        Me.grpSign.TabStop = False
        Me.grpSign.Text = "No Account?"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 262)
        Me.Controls.Add(Me.grpSign)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.grpLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "MS SQL User DB"
        Me.grpLogin.ResumeLayout(False)
        Me.grpLogin.PerformLayout()
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.grpSign.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpLogin As GroupBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPass As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUser As TextBox
    Friend WithEvents grpOptions As GroupBox
    Friend WithEvents btnSign As Button
    Friend WithEvents grpSign As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnInfo As Button
    Friend WithEvents lblFailure As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
End Class
