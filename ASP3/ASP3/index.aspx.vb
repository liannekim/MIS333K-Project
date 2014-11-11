'Name: Kelley Wang
'Date: 18 September 2014
'Assignment: ASP2
'Description: Show customer information after loggin in

Public Class index
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB
    Dim Phone As New classFormat


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'make panel invisible
        Panel1.Visible = False


    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        'declare local variables
        Dim bolUsername As Boolean
        Dim bolPassword As Boolean
        Dim strUsername As String
        Dim strPassword As String


        'get username
        strUsername = txtUsernameLogin.Text

        'validate username
        bolUsername = DB.CheckUsername(strUsername)
        If bolUsername = False Then
            'error message and exit
            lblError.Text = "Invalid Username"
            Exit Sub
        End If

        'get password password
        strPassword = txtPasswordLogin.Text

        'validate password
        bolPassword = DB.CheckPassword(strPassword)
        If bolPassword = False Then
            'error message and exit

            lblError.Text = "Invalid Password"
            Exit Sub
        End If

        'clear error label 
        lblError.Text = ""

        'clear username textbox
        txtUsernameLogin.Text = ""

        'fill textboxes with data
        txtLastName.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("lastname").ToString
        txtFirstName.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("firstname").ToString
        txtInitial.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("MI").ToString
        txtUsername.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("username").ToString
        txtPassword.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("password").ToString
        txtAddress.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("address").ToString
        txtCity.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("city").ToString
        txtState.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("state").ToString
        txtZip.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("zipcode").ToString
        txtEmail.Text = DB.CustDataset.Tables("tblCustomers").Rows(0).Item("emailaddr").ToString
        txtPhone.Text = Phone.FormatPhone(DB.CustDataset.Tables("tblCustomers").Rows(0).Item("phone").ToString)

        'make panel visible
        Panel1.Visible = True
    End Sub
End Class