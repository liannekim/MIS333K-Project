﻿'Name: Kelley Wang
'Date: 16 September 2014
'Assignment: ASP2
'Description: show customer information after logging in 

Public Class classFormat
    Public Function FormatPhone(strInput As String) As String
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: change a 10-digit string to phone number format
        'arguments: string
        'returns: string formatted as phone number

        Dim dblPhone As Double
        Dim strPhone As String

        'take strInput and put into double
        dblPhone = Convert.ToDouble(strInput)

        'return string in phone format
        strPhone = dblPhone.ToString("(###) ###-####")

        Return strPhone

    End Function
End Class