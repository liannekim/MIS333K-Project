'Name: Kelley Wang
'Date: 23 September 2014
'Assignment: ASP3
'Description: Add new customer profile

Public Class AddCustomer
    Inherits System.Web.UI.Page

    Dim DB As New classCustomerDB
    Dim Valid As New ClassValidation
    Dim Phone As New classFormat


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'declare local variables
        Dim bolValid As Boolean

        'validations
        'required fields: lastname, firstname, username, password, email (use RequiredFieldValidator)

        'check phone
        If txtPhone.Text <> "" Then
            bolValid = Valid.CheckPhone(txtPhone.Text)
            If bolValid = False Then
                'error message and exit
                lblError.Text = "Invalid Phone"
                Exit Sub
            End If
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
        bolValid = DB.CheckUsername(txtUsername.Text)
        If bolValid = True Then
            'username has already been taken
            'error message and exit
            lblError.Text = "Username taken"
            Exit Sub
        End If


        'add record
        DB.AddCustomer(txtLastName.Text, txtFirstName.Text, txtInitial.Text, txtUsername.Text, txtPassword.Text, _
                       txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtEmail.Text, txtPhone.Text)

        'show record added
        lblError.Text = "Record Added."

        'display phone in proper format
        If txtPhone.Text <> "" Then
            txtPhone.Text = Phone.FormatPhone(txtPhone.Text)
        End If


        'display zipcode in proper format if 9 digits
        If txtZip.Text.Length = 9 Then
            txtZip.Text = Phone.FormatZip(txtZip.Text)
        End If


    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'clear all textboxes
        txtLastName.Text = ""
        txtFirstName.Text = ""
        txtInitial.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtState.Text = ""
        txtZip.Text = ""
        txtEmail.Text = ""
        txtPhone.Text = ""

    End Sub
End Class