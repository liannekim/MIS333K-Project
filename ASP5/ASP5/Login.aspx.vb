Public Class Login
    Inherits System.Web.UI.Page

    Dim DB As New classEmployeeDB
    Dim valid As New ClassValidation

    Dim mintCount As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'create session for count
            Session("Count") = 0
        End If

        txtCount.Visible = False


    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'check login for credentials for employee
        Dim strEmpID As String
        Dim strPassword As String

        'get empID and password
        strEmpID = txtEmpID.Text
        strPassword = txtPassword.Text

        'each time login is clicked, add 1 to session count
        mintCount = CInt(Session("Count"))
        mintCount += 1
        txtCount.Text = mintCount.ToString
        Session("Count") = mintCount
        'if not good login... locked out after 3 attempts
        'if 3 or greater then, give error message
        If CInt(txtCount.Text) >= 3 Then
            lblError.Text = "Too many login attempts, try again later."
            btnLogin.Enabled = False
            txtCount.Text = "3"
            Exit Sub
        End If

        'validations
        If valid.CheckDigits(txtEmpID.Text) = False Then
            lblError.Text = "Invalid Employee ID"
            Exit Sub
        End If
        If DB.CheckEmpID(strEmpID) = False Then
            lblError.Text = "Invalid Employee ID"
            Exit Sub
        End If
        If DB.CheckPassword(strPassword) = False Then
            lblError.Text = "Invalid Password"
            Exit Sub
        End If

        'good login, set emptype
        Session("EmpType") = DB.EmployeeDataset.Tables("tblEmployee").Rows(0).Item("EmpType").ToString

        'reset session variable
        Session("Count") = 0

        'Call view customers
        Response.Redirect("ViewCustomers.aspx")

    End Sub
End Class