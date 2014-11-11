<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Checkout.aspx.vb" Inherits="ASP1.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Website Name</title>
    <link href="global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            Mike&#39;s Donut Shop<br />
            Customer Checkout<br />
            <br />
        </div>
        <div id="content">
            <div id="maincontent">
                <div id="product_label">
                    <asp:Label ID="Label2" runat="server" Text="Regular: "></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Iced: "></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Mocha: "></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Glazed: "></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Chocolate: "></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Raspberry: "></asp:Label>
                </div>
                <div id="quantity">
                    
                    <asp:TextBox ID="txtReguQuant" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtIcedQuant" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtMochQuant" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtGlazQuant" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtChocQuant" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtRaspQuant" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                </div>
                <div id="prices">
                    <asp:Label ID="lblReguPrice" runat="server" Text="$1.00"></asp:Label>
                    <br />
                    <asp:Label ID="lblIcedPrice" runat="server" Text="$1.50"></asp:Label>
                    <br />
                    <asp:Label ID="lblMochPrice" runat="server" Text="$2.00"></asp:Label>
                    <br />
                    <asp:Label ID="lblGlazPrice" runat="server" Text="$1.00"></asp:Label>
                    <br />
                    <asp:Label ID="lblChocPrice" runat="server" Text="$1.50"></asp:Label>
                    <br />
                    <asp:Label ID="lblRaspPrice" runat="server" Text="$2.00"></asp:Label>
                    <br />
                </div>
                <div id="totals">
                    <asp:Label ID="Label8" runat="server" Text="Subtotal = "></asp:Label>
                    <asp:Label ID="lblSubtotal" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Tax = "></asp:Label>
                    <asp:Label ID="lblTax" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Total = "></asp:Label>
                    <asp:Label ID="LblTotal" runat="server" Text="0"></asp:Label>
                    <br />
                </div>
            </div>
            <div id="footer">
                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="buttons" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="buttons" />
                <br />
                <asp:Label ID="lblError" runat="server" Text="[Error]"></asp:Label>
                <br />
                <br />
                <br />
                Kelley Wang</div>
        </div>
    </form>
</body>
</html>