Public Class ClassCalculation

    'declare variables for results 
    Const TAX_Constant As Decimal = 0.0825D
    Dim mdecSubtotal As Decimal
    Dim mdecTax As Decimal
    Dim mdecTotal As Decimal


    'make properties readonly
    Public ReadOnly Property subtotal() As Decimal
        Get
            Return mdecSubtotal
        End Get
    End Property

    Public ReadOnly Property Tax() As Decimal
        Get
            Return mdecTax
        End Get
    End Property

    Public ReadOnly Property Total() As Decimal
        Get
            Return mdecTotal
        End Get
    End Property


    Public Sub DoCalculations(intRegular As Integer, decregularprice As Decimal, intMocha As Integer, decMochaPrice As Decimal, intIced As Integer,
        decIcedPrice As Decimal, intGlazed As Integer, decGlazedPrice As Decimal, intChocolate As Integer, decChocolatePrice As Decimal,
        intRaspberry As Integer, decRaspberryPrice As Decimal)
        'purpose: calculate subtotal, tax, and total
        'input: coffee and donut quantities (6) and prices (6)
        'returns: subtotal, tax, subtotal (using properties)
        'author: Kelley Wang

        'compute subtotal
        mdecSubtotal = (intRegular * decregularprice) + (intMocha * decMochaPrice) + (intIced * decIcedPrice) + (intGlazed * decGlazedPrice) +
        (intChocolate * decChocolatePrice) + (intRaspberry * decRaspberryPrice)

        'compute tax
        mdecTax = mdecSubtotal * TAX_Constant

        'compute total
        mdecTotal = mdecTax + mdecSubtotal

    End Sub
End Class
