Public Class ManageCustomers
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB
    Dim valid As New ClassValidation
    Dim format As New classFormat


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check session RecordID
        'if not there, redirect to login
        If Session("RecordID") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        'get recordID from the session variable
        Dim strRecordID As String
        strRecordID = Session("RecordID").ToString

        'get that customers record
        DB.GetByRecordID(strRecordID)

        If IsPostBack = False Then
            'call fill textboxes to show fields on the form
            FillTextboxes()
            SetFormNormal()
            lblError.Text = ""
        End If

    End Sub

    Sub FillTextboxes()

        'put info from selected customer into text boxes on form
        Dim intIndex As Integer

        'get index from drop down to use as index in dataset
        intIndex = 0

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

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'declare local variables
        Dim bolValid As Boolean

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
        If txtUsername.Text <> DB.CustDataset.Tables("tblCustomers").Rows(0).Item("Username").ToString Then
            If DB.CheckUsername(txtUsername.Text) = True Then
                lblError.Text = ("Duplicate Username")
                Exit Sub
            End If
        End If


        'modify record
        DB.ModifyCustomer(txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtUsername.Text, txtPassword.Text, _
                       txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtEmail.Text, txtPhone.Text, Session("RecordID"))

        'display phone in proper format
        If txtPhone.Text.Length = 10 Then
            txtPhone.Text = format.FormatPhone(txtPhone.Text)
        End If


        'display zipcode in proper format if 9 digits
        If txtZip.Text.Length = 9 Then
            txtZip.Text = format.FormatZip(txtZip.Text)
        End If

        ''save customer's record ID in a variable
        'intRecordID = 0

        'set form back to normal (what it looks like when opened)
        SetFormNormal()

        'reload dataset
        DB.GetAllCustomers()

        ''reload ddl and show record being modified (using the recordID variable)
        'LoadDDL(intRecordID)


        'show record modified
        lblError.Text = "Record saved."


        Response.AddHeader("Refresh", "2; URL=ViewCustomers.aspx")

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


        'textboxes NOT readonly
        txtAddress.ReadOnly = False
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
        btnDelete.Enabled = False
        'show confirm and abort delete
        btnConfirmDelete.Visible = True
        btnAbortDelete.Visible = True

        'confirm in label
        lblError.Text = "Are you sure you want to delete?"
    End Sub

    Protected Sub btnAbortModify_Click(sender As Object, e As EventArgs) Handles btnAbortModify.Click
        'reload original data
        FillTextboxes()

        'set form to normal?
        SetFormNormal()

    End Sub

    Protected Sub btnAbortDelete_Click(sender As Object, e As EventArgs) Handles btnAbortDelete.Click
        'reload original data for this customer
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
                txtPhone.Text = format.FormatPlainPhone(txtPhone.Text)
            End If
        End If

        lblError.Text = ""
    End Sub

    Protected Sub btnConfirmDelete_Click(sender As Object, e As EventArgs) Handles btnConfirmDelete.Click
        'Delete the record
        DB.DeleteCustomer(Session("RecordID"))


        'reload dataset
        DB.GetAllCustomers()


        'empty textboxes
        txtAddress.Text = ""
        txtCity.Text = ""
        txtEmail.Text = ""
        txtFirstName.Text = ""
        txtInitial.Text = ""
        txtLastName.Text = ""
        txtPassword.Text = ""
        txtPhone.Text = ""
        txtState.Text = ""
        txtUsername.Text = ""
        txtZip.Text = ""


        lblError.Text = Convert.ToString("Record Deleted")

        Response.AddHeader("Refresh", "2; URL=ViewCustomers.aspx")
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        SetFormDelete()

    End Sub
End Class