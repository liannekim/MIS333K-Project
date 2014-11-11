Public Class ClassValidation
    Public Function CheckDecimal(strInput As String) As Decimal
        'purpose: test a string and see if it’s a positive decimal value
        'input: any string
        'returns: -1 if string is NOT a positive value, positive amount if string is okay
        'author: Kelley Wang

        'declare variables
        Dim decResult As Decimal

        'if blank string
        If strInput = "" Then
            Return 0
        End If

        'test for numeric
        Try
            decResult = Convert.ToDecimal(strInput)
        Catch ex As Exception
            'value is not numeric, so return -1
            Return -1
        End Try

        'test for numeric greater than 0
        If decResult < 0 Then
            'value is less than or equal to 0, so return -1
            Return -1
        End If

        'if code gets this far, the input is valid, so return the result
        Return decResult

    End Function

    Public Function CheckInteger(strInput As String) As Integer
        'purpose: test a string and see if it’s a positive integer value
        'input: any string 
        'returns: -1 if string is NOT a positive value, positive amount if string is okay
        'author: Kelley Wang

        'declare variables
        Dim intResult As Integer

        'if blank string
        If strInput = "" Then
            Return 0
        End If

        'test for numeric
        Try
            intResult = Convert.ToInt32(strInput)
        Catch ex As exception
            'value is not numeric, so return -1
            Return -1
        End Try

        'test for numeric greater than 0
        If intResult < 0 Then
            'value is less than or equal to 0, so return -1
            Return -1
        End If

        'if code gets this far, the input is valid, so return the result
        Return intResult
    End Function

    Public Function CheckPassword(strInput As String) As Boolean
        'purpose: test a string and see if it’s the correct password
        'input: any string 
        'returns: false if string is not correct, true if string is correct
        'author: Kelley Wang

        If strInput = "donut" Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
