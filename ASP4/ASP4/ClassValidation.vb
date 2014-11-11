'Name: Kelley Wang
'Date: 18 September 2014
'Assignment: ASP2
'Description: Show customer information after loggin in


Option Strict On
Public Class ClassValidation

    Public Function CheckDigits(strInput As String) As Boolean
        'purpose: check if string is made up of digits
        'input: any string
        'returns: false if not made up of digits
        'author: Kelley Wang

        'check to see that each character is 0-9
        Dim i As Integer
        Dim strOne As String

        For i = 0 To Len(strInput) - 1
            'get one character from the string
            strOne = strInput.Substring(i, 1)
            Select Case strOne
                'if character is 0-9, then keep going
                Case "0" To "9"
                    'if the character is anything else, stop looking and return false
                Case Else
                    'if bad data, return false
                    Return False
            End Select
        Next

        'if we made it through the loop, return true
        Return True

    End Function

    Public Function CheckLetters(strInput As String) As Boolean
        'purpose: check if string is made up of letters
        'input: any string
        'returns: false if not made up of letters
        'author: Kelley Wang

        'check to see that each character is a-z
        Dim i As Integer
        Dim strOne As String

        For i = 0 To Len(strInput) - 1
            'get one character from the string
            strOne = strInput.Substring(i, 1)
            Select Case strOne.ToLower
                'if character is a-z, then keep going
                Case "a" To "z"
                    'if the character is anything else, stop looking and return false
                Case Else
                    'if bad data, return false
                    Return False
            End Select
        Next

        'if we made it through the loop, return true
        Return True

    End Function

    Public Function CheckPhone(strInput As String) As Boolean
        'purpose: check if string is 10 digits long
        'input: any string
        'returns: false if not a 10 character long string of digits
        'author: Kelley Wang

        'check length
        If strInput.Length <> 10 Then
            Return False
        End If

        'check to make sure all digits
        If CheckDigits(strInput) = False Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CheckZip(strInput As String) As Boolean
        'purpose: check if string is 5 digits long
        'input: any string
        'returns: false if not a 5 character long string of digits
        'author: Kelley Wang

        'check length
        If strInput.Length <> 5 And strInput.Length <> 9 Then
            Return False
        End If

        'check to make sure all digits
        If CheckDigits(strInput) = False Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CheckMI(strInput As String) As Boolean
        'purpose: check if string is 1 letter long
        'input: any string
        'returns: false if not a 1 character long string
        'author: Kelley Wang

        'check length
        If strInput.Length <> 1 Then
            Return False
        End If

        'check to make sure string is a letter
        If CheckLetters(strInput) = False Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function CheckState(strInput As String) As Boolean
        'purpose: check if string is 2 letters long
        'input: any string
        'returns: false if not a 2 character long string
        'author: Kelley Wang

        'check length
        If strInput.Length <> 2 Then
            Return False
        End If

        'check to make sure string is a letter
        If CheckLetters(strInput) = False Then
            Return False
        Else
            Return True
        End If
    End Function



    Public Function CheckPassword(strInput As String) As Boolean
        'purpose: test a string and see if it’s the correct password
        'input: any string 
        'returns: false if string is not correct, true if string is correct
        'author: Kelley Wang

        '6-10 characters, start with letter, contain at least one letter and one number

        'check length
        If strInput.Length < 6 Or strInput.Length > 10 Then
            Return False
        End If

        'check to see if first character is a letter
        If CheckLetters(strInput.Substring(0, 1)) = False Then
            Return False
        End If

        'check to see that remainder of string has one digit
        Dim i As Integer
        Dim strOne As String
        Dim intDigitCount As Integer

        For i = 1 To Len(strInput) - 1
            'get one character from the string
            strOne = strInput.Substring(i, 1)
            Select Case strOne.ToLower
                'if character is 0-9, then keep going
                Case "0" To "9"
                    intDigitCount += 1
                Case "a" To "z"
                    'keeps going
                Case Else
                    Return False
            End Select
        Next

        'was there at least 1 digit in the string
        If intDigitCount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function CheckFormattedPhone(strInput As String) As Boolean
        'check to see if phone number is formatted (###) ###-####

        'check for "(" as first substring
        If strInput.Substring(0, 1) <> "(" Then
            Return False
        End If

        'check for next three digits as second substring
        If CheckDigits(strInput.Substring(1, 3)) = False Then
            Return False
        End If

        'check next character is " " as third substring
        If strInput.Substring(5, 1) <> " " Then
            Return False
        End If

        'check for next three digits as fourth substring
        If CheckDigits(strInput.Substring(6, 3)) = False Then
            Return False
        End If

        'check next character is "-" as fifth substring
        If strInput.Substring(9, 1) <> "-" Then
            Return False
        End If

        'check for last four digits as last substring
        If CheckDigits(strInput.Substring(10, 4)) = False Then
            Return False
        Else
            Return True
        End If


    End Function

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
        Catch ex As Exception
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

    

End Class
