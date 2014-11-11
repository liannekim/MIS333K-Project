Public Class ViewCustomers
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to see if employee logged in properly
        'check existence of session EmpType (see p. 60)
        If Session("EmpType") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        DB.GetAllCustomers()

        gvcustomers.datasource = DB.CustDataset
        gvCustomers.DataBind()

        'get session EmpType and see if it is < 400
        Dim intEmpType As Integer
        intEmpType = CInt(Session("EmpType"))

        If intEmpType < 400 Then
            'make first column invisible
            gvCustomers.Columns(0).Visible = False
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCustomers.SelectedIndexChanged
        'create a session with recordID for next form
        Session("RecordID") = gvCustomers.SelectedRow.Cells(1).Text

        'call the next form
        Response.Redirect("ManageCustomers.aspx")

        'no code after this because directed to another page and will not come back

    End Sub
End Class