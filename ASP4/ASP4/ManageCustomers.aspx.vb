'Name: Kelley Wang
'Date: 23 September 2014
'Assignment: ASP3
'Description: Add new customer profile

Public Class ManageCustomers
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB
    Dim Valid As New ClassValidation
    Dim Phone As New classFormat


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Get all the customers
        DB.GetAllCustomers()

        'run code only when page loads for the first time
        If IsPostBack = False Then
            'fill ddl
            ReloadDDL()

            FillTextboxes()
            SetFormNormal()
            lblError.Text = ""
        End If

        CheckButtons()
    End Sub

    Sub FillTextboxes()

        'put info from selected customer into text boxes on form
        Dim intIndex As Integer

        'get index from drop down to use as index in dataset
        intIndex = ddlCustomer.SelectedIndex

        'move fields from dataset to form
        txtFirstName.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("FirstName").ToString
        txtLastName.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("LastName").ToString
        txtAddress.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("Address").ToString
        txtCity.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("City").ToString
        txtEmail.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("EmailAddr").ToString
        txtInitial.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("MI").ToString
        txtPassword.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("Password").ToString
        txtPhone.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("Phone").ToString
        txtState.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("State").ToString
        txtUsername.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("Username").ToString
        txtZip.Text = DB.CustDataset.Tables("tblCustomers").Rows(intIndex).Item("ZipCode").ToString

        'call check button
        CheckButtons()

    End Sub

    Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
        FillTextboxes()
        SetFormNormal()
    End Sub

    Private Sub CheckButtons()

        'if on first record
        If ddlCustomer.SelectedIndex = 0 Then
            'disable first and previous buttons
            btnFirst.Enabled = False
            btnPrevious.Enabled = False
            btnNext.Enabled = True
            btnLast.Enabled = True
            'if on last record
        ElseIf ddlCustomer.SelectedIndex = ddlCustomer.Items.Count - 1 Then
            'disable last and next buttons
            btnLast.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
        Else
            'enable all 4 buttons
            btnFirst.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            btnPrevious.Enabled = True
        End If

    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'declare local variables
        Dim bolValid As Boolean
        Dim intRecordID As Integer


        'validations
        'required fields: lastname, firstname, username, password, email 
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtFirstName.Text = "" Or txtLastName.Text = "" Or txtEmail.Text = "" Then
            lblError.Text = "Required Fields are missing"
            Exit Sub
        End If

        'check phone
        If txtPhone.Text <> "" Then
            'If txtPhone.Text.Length = 10 Then
            bolValid = Valid.CheckPhone(txtPhone.Text)
            If bolValid = False Then
                'error message and exit
                lblError.Text = "Invalid Phone"
                Exit Sub
            End If
            'Else
            '    bolValid = Valid.CheckFormattedPhone(txtPhone.Text)
            '    If bolValid = False Then
            '        lblError.Text = "Invalid Phone"
            '        Exit Sub
            '    End If
            'End If
        End If

        'check state
        If txtState.Text <> "" Then
            bolValid = Valid.CheckState(txtState.Text)
            If bolValid = False Then
                'error message and exit
                lblError.Text = "Invalid State"
                Exit Sub
            End If
        End If

        'check MI
        If txtInitial.Text <> "" Then
            bolValid = Valid.CheckMI(txtInitial.Text)
            If bolValid = False Then
                'error message and exit
                lblError.Text = "Invalid MI"
                Exit Sub
            End If
        End If

        'check zipcode
        If txtZip.Text <> "" Then
            bolValid = Valid.CheckZip(txtZip.Text)
            If bolValid = False Then
                'error message and exit
                lblError.Text = "Invalid Zip"
                Exit Sub
            End If
        End If

        'check password
        bolValid = Valid.CheckPassword(txtPassword.Text)
        If bolValid = False Then
            'error message and exit
            lblError.Text = "Invalid Password"
            Exit Sub
        End If

        'check username
        If txtUsername.Text <> DB.CustDataset.Tables("tblCustomers").Rows(ddlCustomer.SelectedIndex).Item("Username").ToString Then
            If DB.CheckUsername(txtUsername.Text) = True Then
                lblError.Text = ("Duplicate Username")
                Exit Sub
            End If
        End If


        'modify record
        DB.ModifyCustomer(txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtUsername.Text, txtPassword.Text, _
                       txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtEmail.Text, txtPhone.Text, ddlCustomer.SelectedValue.ToString)

        'display phone in proper format
        If txtPhone.Text.Length = 10 Then
            txtPhone.Text = Phone.FormatPhone(txtPhone.Text)
        End If


        'display zipcode in proper format if 9 digits
        If txtZip.Text.Length = 9 Then
            txtZip.Text = Phone.FormatZip(txtZip.Text)
        End If

        'save customer's record ID in a variable
        intRecordID = ddlCustomer.SelectedValue

        'set form back to normal (what it looks like when opened)
        SetFormNormal()

        'reload dataset
        DB.GetAllCustomers()

        'reload ddl and show record being modified (using the recordID variable)
        LoadDDL(intRecordID)


        'show record modified
        lblError.Text = "Record saved."

    End Sub

    Sub LoadDDL(intrecordID)
        ddlCustomer.DataSource = DB.CustDataset
        ddlCustomer.SelectedValue = intRecordID
        ddlCustomer.DataTextField = "fullname"
        ddlCustomer.DataValueField = "RecordID"
        ddlCustomer.DataBind()
        FillTextboxes()
    End Sub

    Sub ReloadDDL()
        ddlCustomer.DataSource = DB.CustDataset.Tables("tblCustomers")
        ddlCustomer.DataTextField = "FullName"
        ddlCustomer.DataValueField = "RecordID"
        ddlCustomer.DataBind()
    End Sub

    Sub SetFormNormal()
        'set correct buttons to enabled/disabled
        'readonly, enabled, disabled, etc.
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtInitial.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPassword.ReadOnly = True
        txtPhone.ReadOnly = True
        txtState.ReadOnly = True
        txtUsername.ReadOnly = True
        txtZip.ReadOnly = True


        'save, delete and abort invisible
        btnSave.Visible = False
        btnAbortModify.Visible = False
        btnConfirmDelete.Visible = False
        btnAbortDelete.Visible = False

        'enable buttons
        btnModify.Enabled = True
        btnDelete.Enabled = True
        btnFirst.Enabled = True
        btnPrevious.Enabled = True
        btnNext.Enabled = True
        btnLast.Enabled = True

        'clear label
        lblError.Text = ""
    End Sub

    Sub SetFormModify()
        'make save and modify abort buttons visible
        btnSave.Visible = True
        btnAbortModify.Visible = True
        btnConfirmDelete.Visible = False
        btnAbortDelete.Visible = False

        'everything diabled but save and abort
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnFirst.Enabled = False
        btnPrevious.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False


        'textboxes NOT readonly
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFirstName.ReadOnly = False
        txtInitial.ReadOnly = False
        txtLastName.ReadOnly = False
        txtPassword.ReadOnly = False
        txtPhone.ReadOnly = False
        txtState.ReadOnly = False
        txtUsername.ReadOnly = False
        txtZip.ReadOnly = False

    End Sub

    Sub SetFormDelete()
        btnModify.Enabled = False
        btnFirst.Enabled = False
        btnPrevious.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'fill textboxes with first record in db
        ddlCustomer.SelectedIndex = 0
        FillTextboxes()

    End Sub

    Protected Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        ddlCustomer.SelectedIndex -= 1
        FillTextboxes()

    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ddlCustomer.SelectedIndex += 1
        FillTextboxes()

    End Sub

    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        ddlCustomer.SelectedIndex = ddlCustomer.Items.Count - 1
        FillTextboxes()
    End Sub


    Protected Sub btnAbortModify_Click(sender As Object, e As EventArgs) Handles btnAbortModify.Click
        'reload original data
        FillTextboxes()

        'set form to normal?
        SetFormNormal()

    End Sub


    Protected Sub btnAbortDelete_Click(sender As Object, e As EventArgs) Handles btnAbortDelete.Click
        'reload orifinal data for this customer
        FillTextboxes()

        'set form to normal
        SetFormNormal()

    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'set up form for modifying record
        SetFormModify()

        'change phone number to ########## if in (###) ###-#### format
        If txtPhone.Text <> "" Then
            If txtPhone.Text.Length <> 10 Then
                txtPhone.Text = Phone.FormatPlainPhone(txtPhone.Text)
            End If
        End If

        lblError.Text = ""
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'show confirm and abort delete
        btnConfirmDelete.Visible = True
        btnAbortDelete.Visible = True

        'confirm in label
        lblError.Text = "Are you sure you want to delete?"

        SetFormDelete()
    End Sub

    Protected Sub btnConfirmDelete_Click(sender As Object, e As EventArgs) Handles btnConfirmDelete.Click
        'Delete the record
        DB.DeleteCustomer(ddlCustomer.SelectedValue)

        'The first customer's record should be loaded on the form
        ddlCustomer.SelectedIndex = 0
        ReloadDDL()
        FillTextboxes()
        SetFormNormal()

        lblError.Text = Convert.ToString("Record Deleted")


    End Sub
End Class