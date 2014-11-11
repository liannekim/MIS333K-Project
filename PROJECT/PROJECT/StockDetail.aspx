<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StockDetail.aspx.vb" Inherits="PROJECT.StockDetail" %>

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

            <strong>Show More Stock Detail</strong></div>
    <div id="right">
        <strong>Stock price details:</strong><asp:GridView ID="gvAllStocks" runat="server">
        </asp:GridView>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">Return to Buy/Sell</asp:LinkButton>
        <br />
    </div>
        
    
    </div>
    </form>
</body>
</html>
