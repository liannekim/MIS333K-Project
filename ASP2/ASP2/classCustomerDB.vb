'Name: Kelley Wang
'Date: 18 September 2014
'Assignment: ASP2
'Description: Show customer information after loggin in

Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class classCustomerDB
    'module variables internal to object
    Dim mDatasetCustomer As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As New SqlConnection
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096; data source=MISSQL.mccombs.utexas.edu; integrated security=False;initial catalog=mis333k_msbcn350;user id=msbcn350;password=kwMIS333k"

    'define public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property CustDataset() As DataSet
        Get
            'return dataset to user
            Return mDatasetCustomer
        End Get
    End Property

    Public Sub GetAllCustomers()
        mstrQuery = "select * from tblCustomers"
        SelectQuery(mstrQuery)
    End Sub

    Public Function CheckUsername(strUsername As String) As Boolean
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: checks for valid username
        'arguments: username input string
        'returns: boolean, true if valid, false if not valid

        mstrQuery = "select * from tblCustomers where username = '" & strUsername & "'"
        SelectQuery(mstrQuery)

        'check number of records in dataset
        If mDatasetCustomer.Tables("tblCustomers").Rows.Count = 0 Then
            'if 0, return false, no rows with that username found
            Return False
        Else
            Return True
        End If

    End Function

    Public Function CheckPassword(strPassword As String) As Boolean
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: checks for valid password
        'arguments: username input string
        'returns: boolean, true if valid, false if not valid

        'compare password on the form to password in row 0 of the dataset
        'if passwords match, return true
        If strPassword = CustDataset.Tables("tblCustomers").Rows(0).Item("password").ToString Then
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
            mDatasetCustomer.Clear()

            'fill the dataset
            mdbDataAdapter.Fill(mDatasetCustomer, "tblCustomers")

            'close the connection
            mdbConn.Close()

        Catch ex As Exception
            Throw New Exception("query is " & strQuery.ToString & "error is " & ex.Message)
        End Try

    End Sub

End Class
