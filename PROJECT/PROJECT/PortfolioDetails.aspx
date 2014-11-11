<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PortfolioDetails.aspx.vb" Inherits="PROJECT.PortfolioDetails" %>

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
        <strong>
        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
        &#39;s Portfolio&nbsp;Details</strong></div>
        
        <div id ="right">
            <strong>Account Number: </strong>
        <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
            <strong>
            <br />
            <br />
            Status of Portfolio:</strong>
            <asp:Label ID="lblBalanced" runat="server"></asp:Label>
            <br />
            <strong>Total current value of Portfolio:
            </strong>
            <asp:Label ID="lblValue" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="btnBuySell" runat="server" style="font-weight: 700">Buy or Sell Stocks</asp:LinkButton>
            <br />
            <br />
            <strong>Cash-value portion:<br />
            Gains:<br />
            Bonuses:<br />
            Available Cash:<br />
            Total Fees Incurred:</strong><asp:GridView ID="gvFees" runat="server">
            </asp:GridView>
            <br />
            <strong>Currently held stocks:</strong><asp:GridView ID="gvStocks" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </div>
    </form>
</body>
</html>
