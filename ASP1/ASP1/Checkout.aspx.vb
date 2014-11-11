Public Class Checkout
    Inherits System.Web.UI.Page

    'declare instances of classes
    Dim calc As New ClassCalculation
    Dim valid As New ClassValidation

    'declare price constants
    Const REGULAR_PRICE As Decimal = 1D
    Const ICED_PRICE As Decimal = 1.5D
    Const MOCHA_PRICE As Decimal = 2D
    Const GLAZED_PRICE As Decimal = 1D
    Const CHOCOLATE_PRICE As Decimal = 1.5D
    Const RASPBERRY_PRICE As Decimal = 2D

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        'declare local variables
        Dim intRegular As Integer
        Dim intMocha As Integer
        Dim intIced As Integer
        Dim intGlazed As Integer
        Dim intChocolate As Integer
        Dim intRaspberry As Integer

        'validate input
        intRegular = valid.CheckInteger(txtReguQuant.Text)
        If intRegular = -1 Then
            'error msg and exit
            lblError.Text = ("Invalid Regular quantity")
            Exit Sub
        End If

        intMocha = valid.CheckInteger(txtMochQuant.Text)
        If intMocha = -1 Then
            'error msg and exit
            lblError.Text = ("Invalid Mocha quantity")
            Exit Sub
        End If

        intIced = valid.CheckInteger(txtIcedQuant.Text)
        If intIced = -1 Then
            'error msg and exit
            lblError.Text = ("Invalid Iced quantity")
            Exit Sub
        End If

        intGlazed = valid.CheckInteger(txtGlazQuant.Text)
        If intGlazed = -1 Then
            'error msg and exit
            lblError.Text = ("Invalid Glazed quantity")
            Exit Sub
        End If

        intChocolate = valid.CheckInteger(txtChocQuant.Text)
        If intChocolate = -1 Then
            'error msg and exit
            lblError.Text = ("Invalid Chocolate quantity")
            Exit Sub
        End If

        intRaspberry = valid.CheckInteger(txtRaspQuant.Text)
        If intRaspberry = -1 Then
            'error msg and exit
            lblError.Text = ("Invalid Raspberry quantity")
            Exit Sub
        End If


        'do calculations
        calc.DoCalculations(intRegular, REGULAR_PRICE, intMocha, MOCHA_PRICE, intIced, ICED_PRICE, intGlazed, GLAZED_PRICE,
        intChocolate, CHOCOLATE_PRICE, intRaspberry, RASPBERRY_PRICE)

        'show results on form/output
        lblSubtotal.Text = calc.subtotal.ToString("C")
        lblTax.Text = calc.Tax.ToString("C")
        LblTotal.Text = calc.Total.ToString("C")
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'clear textboxes
        txtReguQuant.Text = ""
        txtIcedQuant.Text = ""
        txtMochQuant.Text = ""
        txtGlazQuant.Text = ""
        txtChocQuant.Text = ""
        txtRaspQuant.Text = ""

        'clear totals
        lblSubtotal.Text = "0"
        lblTax.Text = "0"
        LblTotal.Text = "0"

        'clear error label
        lblError.Text = ""


    End Sub
End Class