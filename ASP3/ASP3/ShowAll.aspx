<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShowAll.aspx.vb" Inherits="ASP3.ShowAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>James's Flower Shop</title>
    <link href="ASP2.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">

<div id="banner">

       James&#39;s Flower Shop<br />
       All Customers<br />
</div>

<div id="left">

            <br />
            There are
            <asp:Label ID="lblCount" runat="server" Text="[count]"></asp:Label>

    &nbsp;records.<br />
            <br />
            <asp:LinkButton ID="lnkHome" runat="server" PostBackUrl="~/index.aspx">Home</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lnkAddCustomer" runat="server" PostBackUrl="~/AddCustomer.aspx">New Customers Sign Up</asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
            <br />
            Kelley Wang<br />

</div>

<div id ="right">
        <br />

        <asp:GridView ID="gvCustomers" runat="server"></asp:GridView>

</div>


</form>
</body>
</html>
