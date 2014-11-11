Public Class ShowAll
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'get all customers
        DB.GetAllCustomers()

        'show all customers in grid
        gvCustomers.DataSource = DB.CustDataset
        gvCustomers.DataBind()


        'show record count
        lblCount.Text = DB.CustDataset.Tables("tblCustomers").Rows.Count.ToString

    End Sub

End Class