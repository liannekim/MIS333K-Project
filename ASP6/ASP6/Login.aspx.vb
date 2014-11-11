Public Class Login
    Inherits System.Web.UI.Page

    Dim DB As New classEmployeeDB
    Dim valid As New ClassValidation

    Dim mintCount As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DB.GetAllUsingSP()

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'check login for credentials for employee
        Dim strEmpID As String
        Dim strPassword As String

        'get empID and password
        strEmpID = txtEmpID.Text
        strPassword = txtPassword.Text

        'validations
        If valid.CheckDigits(txtEmpID.Text) = False Then
            lblError.Text = "Invalid Employee ID"
            Exit Sub
        End If

        If DB.GetByEmpIDUsingView(strEmpID) = False Then
            lblError.Text = "Invalid Employee ID"
            Exit Sub
        End If

        If DB.CheckPasswordUsingView(strPassword) = False Then
            lblError.Text = "Invalid Password"
            Exit Sub
        End If

        'good login, set emptype
        Session("EmpType") = DB.MyView(0).Item("EmpType").ToString

        'Call search
        Response.Redirect("Search.aspx")

    End Sub
End Class