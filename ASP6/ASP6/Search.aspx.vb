Public Class ShowAll
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check to see if employee logged in properly
        'check existence of session EmpType (see p. 60)
        If Session("EmpType") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        'get all customers and fill DS and Dataview
        DB.GetAllUsingSP()

        If IsPostBack = False Then
            'bind the grid to the dataview
            gvCustomers.DataSource = DB.MyView()
            gvCustomers.DataBind()

            'show row count
            lblCount.Text = gvCustomers.Rows.Count.ToString
        End If

    End Sub

    Private Sub SortAndBind()
        'check for empty search
        If txtSearch.Text = "" Then
            lblError.Text = "Please enter search criteria."
            Exit Sub
        End If

        'check to see if search found anything
        If DB.MyView.Count = 0 Then
            lblError.Text = "No records match search criteria."
            'if exit sub is put, then grid and lblCount won't change
            Exit Sub
        End If

        'sort the view
        DB.DoSort(radSort.SelectedItem.ToString)

        'bind the grid to the dataview
        gvCustomers.DataSource = DB.MyView()
        gvCustomers.DataBind()

        'show row count
        lblCount.Text = gvCustomers.Rows.Count.ToString

        'clear lblerror
        lblError.Text = ""

    End Sub

    
    Protected Sub btnState_Click(sender As Object, e As EventArgs) Handles btnState.Click
        'using dataview and NOT a SP with a parameter
        'filter the view for this state
        DB.SearchByState(txtSearch.Text)

        SortAndBind()
    End Sub

    Protected Sub btnUsername_Click(sender As Object, e As EventArgs) Handles btnUsername.Click
        'filter the view for username
        DB.SearchByPartialUsername(txtSearch.Text)

        SortAndBind()
    End Sub

    Protected Sub btnLastname_Click(sender As Object, e As EventArgs) Handles btnLastname.Click
        'filter the view for lastname
        DB.SearchByPartialLastname(txtSearch.Text)

        SortAndBind()
    End Sub


    Protected Sub btnCity_Click(sender As Object, e As EventArgs) Handles btnCity.Click
        'filter the view for city
        DB.SearchByPartialCity(txtSearch.Text)

        SortAndBind()
    End Sub

    Protected Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        'get all customers and fill DS and Dataview
        DB.GetAllUsingSP()

        'bind the grid to the dataview
        gvCustomers.DataSource = DB.MyView()
        gvCustomers.DataBind()

        'show row count
        lblCount.Text = gvCustomers.Rows.Count.ToString

        'clear search textbox
        txtSearch.Text = ""

        'clear lblerror
        lblError.Text = ""
    End Sub

End Class