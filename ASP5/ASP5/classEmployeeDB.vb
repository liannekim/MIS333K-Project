'Name: Kelley Wang
'Date: 13 October 2014
'Assignment: ASP2
'Description: Show Employee information after loggin in

Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class classEmployeeDB
    'module variables internal to object
    Dim mDatasetEmployee As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096; data source=MISSQL.mccombs.utexas.edu; integrated security=False;initial catalog=mis333k_msbcn350;user id=msbcn350;password=kwMIS333k"

    'define public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property EmployeeDataset() As DataSet
        Get
            'return dataset to user
            Return mDatasetEmployee
        End Get
    End Property

    Public Sub GetAllEmployee()
        'purpose: return all Employee records
        'inputs: none
        mstrQuery = "Select*, (lastname + ', ' + firstname) as fullname from tblEmployee order by lastname, firstname"
        SelectQuery(mstrQuery)
    End Sub


    'Public Sub AddEmployee(strLastName As String, strFirstName As String, strInitial As String, strUsername As String, strPassword As String, strAddress As String, strCity As String, strState As String, strZip As String, strEmail As String, strPhone As String)
    '    'purpose: add a Employee to the dataset
    '    'inputs: 11 string inputs for each Employee

    '    'declare query string
    '    Dim strQuery As String

    '    'populate query
    '    strQuery = "INSERT INTO tblEmployee (Username, Password, LastName, FirstName, MI, Address, City, State, ZipCode, Phone, EmailAddr) VALUES (" & _
    '        "'" & strUsername & "', " & _
    '        "'" & strPassword & "', " & _
    '        "'" & strLastName & "', " & _
    '        "'" & strFirstName & "', " & _
    '        "'" & strInitial & "', " & _
    '        "'" & strAddress & "', " & _
    '        "'" & strCity & "', " & _
    '        "'" & strState & "', " & _
    '        "'" & strZip & "', " & _
    '        "'" & strPhone & "', " & _
    '        "'" & strEmail & "')"

    '    'add new record to DB
    '    UpdateDB(strQuery)

    'End Sub

    'Public Sub ModifyEmployee(strLastName As String, strFirstName As String, strInitial As String, strUsername As String, strPassword As String, strAddress As String, strCity As String, strState As String, strZip As String, strEmail As String, strPhone As String, strRecordID As String)
    '    'purpose: modify Employee in the dataset
    '    'inputs: 11 string inputs for the Employee

    '    'declare query sring
    '    Dim strQuery As String

    '    'populate query
    '    strQuery = "UPDATE tblEmployee " & _
    '        "SET username='" & strUsername & "', " & _
    '        "Password='" & strPassword & "', " & _
    '        "LastName='" & strLastName & "', " & _
    '        "FirstName='" & strFirstName & "', " & _
    '        "MI='" & strInitial & "', " & _
    '        "Address='" & strAddress & "', " & _
    '        "City='" & strCity & "', " & _
    '        "State='" & strState & "', " & _
    '        "ZipCode='" & strZip & "', " & _
    '        "Phone='" & strPhone & "', " & _
    '        "EmailAddr='" & strEmail & ",' " & _
    '        "WHERE RecordID='" & strRecordID & "';"

    '    'update DB
    '    UpdateDB(strQuery)
    'End Sub

    Public Sub DeleteEmployee(strEmpID As String)
        'purpose: delete Employee from dataset
        'input: recordID string

        'declare query string
        Dim strQuery As String

        'populate query
        strQuery = "DELETE FROM tblEmployee WHERE empID=" & strEmpID

        'update DB
        UpdateDB(strQuery)

    End Sub


    Public Sub UpdateDB(strQuery As String)
        'purpose: run given query to update database
        'argument: one string (any SQL statement)

        Try
            'make connection using the connection string aboce
            mdbConn = New SqlConnection(mstrConnection)
            Dim dbCommand As New SqlCommand(strQuery, mdbConn)

            'open the connection
            mdbConn.Open()

            'run the query
            dbCommand.ExecuteNonQuery()

            'close the connection
            mdbConn.Close()
        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & " error is " & ex.Message)

        End Try
    End Sub

    Public Function CheckEmpID(strEmpID As String) As Boolean
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: checks for valid employee ID
        'arguments: EmpID input string
        'returns: boolean, true if valid, false if not valid

        mstrQuery = "select * from tblEmployee where empID = '" & strEmpID & "'"
        SelectQuery(mstrQuery)

        'check number of records in dataset
        If mDatasetEmployee.Tables("tblEmployee").Rows.Count = 0 Then
            'if 0, return false, no rows with that EmpID found
            Return False
        Else
            Return True
        End If
    End Function

    Public Function GetByEmpID(strEmpID As String) As String
        'name: Kelley Wang
        'date: 7 October 2014
        'purpose: retrieve records by empID

        mstrQuery = "select * from tblEmployee where EmpID = '" & strEmpID & "'"
        SelectQuery(mstrQuery)


    End Function

    Public Function CheckPassword(strPassword As String) As Boolean
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: checks for valid password
        'arguments: password input string
        'returns: boolean, true if valid, false if not valid

        'compare password on the form to password in row 0 of the dataset
        'if passwords match, return true
        If strPassword = EmployeeDataset.Tables("tblEmployee").Rows(0).Item("password").ToString Then
            Return True
            'else return false
        Else
            Return False
        End If

    End Function



    'define a public sub that will handle running any select query
    Public Sub SelectQuery(strQuery As String)
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: run any select query and fill dataset
        'arguments: query string

        Try
            'define data connection and data adapter
            mdbConn = New SqlConnection(mstrConnection)
            mdbDataAdapter = New SqlDataAdapter(strQuery, mdbConn)

            'open the connection and dataset
            mdbConn.Open()


            'clear the dataset before filling
            mDatasetEmployee.Clear()

            'fill the dataset
            mdbDataAdapter.Fill(mDatasetEmployee, "tblEmployee")

            'close the connection
            mdbConn.Close()

        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub

End Class
