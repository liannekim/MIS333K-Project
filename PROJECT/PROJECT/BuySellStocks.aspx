<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BuySellStocks.aspx.vb" Inherits="PROJECT.BuySellStocks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
     <link href="ASP2.css" rel="stylesheet" type="text/css" />
<body>
    <form id="form1" runat="server">
    <div>
        <div id="center">

            <strong>Buy and Sell Stocks</strong></div>
    <div id="right">
        <strong>BUY STOCKS</strong><br />
        <strong>Stocks available for purchase:</strong><asp:GridView ID="gvAllStocks" runat="server">
            <Columns>
                <asp:CheckBoxField HeaderText="Select Stock" />
            </Columns>
        </asp:GridView>
        Enter number of shares to purchase:
        <asp:TextBox ID="txtSharesToPurchase" runat="server"></asp:TextBox>
        <br />
        Select account to fund purchase:
        <asp:DropDownList ID="ddlAccounts" runat="server">
        </asp:DropDownList>
        <br />
        Enter purchase date:
        <asp:TextBox ID="txtPurhcaseDate" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnConfirmPurchase" runat="server" Text="Confirm Purchase" />
        <br />
        <asp:Label ID="lblPurchaseMessage" runat="server"></asp:Label>
        <br />
        <br />
        <strong>SELL STOCKS</strong><br />
        <strong>Stocks available for sale:</strong><asp:GridView ID="gvCustomerStocks" runat="server">
            <Columns>
                <asp:CommandField HeaderText="Show details" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        Select stock to sell:
        <asp:DropDownList ID="ddlCustomerStocks" runat="server">
        </asp:DropDownList>
        <br />
        Enter number of shares to sell: <asp:TextBox ID="txtSharesToSell" runat="server"></asp:TextBox>
        <br />
        Enter sale date:
        <asp:TextBox ID="txtSaleDate" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSellStocks" runat="server" Text="Sell Stocks" />
        <br />
        <asp:Label ID="lblSaleMessage" runat="server"></asp:Label>
        <br />
    </div>
        
    
    </div>
    </form>
</body>
</html>
