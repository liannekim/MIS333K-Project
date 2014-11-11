'Name: Kelley Wang
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
        If strInput <> "" Then
            dblPhone = Convert.ToDouble(strInput)
        End If


        'return string in phone format
        strPhone = dblPhone.ToString("(###) ###-####")

        Return strPhone
    End Function

    Public Function FormatPlainPhone(strInput As String) As String
        Dim strPhone As String
        Dim strOne As String
        Dim strTwo As String
        Dim strThree As String

        'take the 3 sets of digits from the (###) ###-#### and put into three substrings
        strOne = strInput.Substring(1, 3)
        strTwo = strInput.Substring(6, 3)
        strThree = strInput.Substring(10, 4)

        'combine three substrings to one string
        strPhone = strOne + strTwo + strThree

        'return string as ##########
        Return strPhone

    End Function

    Public Function FormatZip(StrInput As String) As String
        'name: Kelley Wang
        'date: 16 September 2014
        'purpose: change a 9-digit string to zipcode format
        'arguments: string
        'returns: string formatted as zipcode

        Dim intZip As Integer
        Dim strZip As String

        'take string and put into integer
        intZip = Convert.ToInt32(StrInput)

        'return string in zip format
        strZip = intZip.ToString("#####-####")

        Return strZip

    End Function
End Class
