<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConfirmStockTransaction.aspx.vb" Inherits="PROJECT.ConfirmStockTransaction" %>

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

            <strong>Transaction Summary</strong></div>
    <div id="right">
        Stock to be sold: <asp:Label ID="lblStockSold" runat="server"></asp:Label>
        <br />
        Number of shares to be sold: <asp:Label ID="lblNumberSold" runat="server"></asp:Label>
        <br />
        Number of shares remaining after sale:
        <asp:Label ID="lblNumberRemaining" runat="server"></asp:Label>
        <br />
        Net profit from sale:
        <asp:Label ID="lblNetProfit" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnConfirmSale" runat="server" Text="Confirm" />
        <asp:Button ID="btnCancelSale" runat="server" Text="Cancel" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">Return to Portfolio Detail Page</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
    </div>
        
    
    </div>
    </form>
</body>
</html>
