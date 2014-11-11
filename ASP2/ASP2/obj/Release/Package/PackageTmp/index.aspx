<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="ASP2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>James's Flower Shop</title>
    <link href="ASP2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 170px;
            height: 220px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div id="banner">

       James&#39;s Flower Shop<br />
       Customer Login<br />
        </div>

<div id="left">

    <br />
    <br />
    Username<br />
    <asp:TextBox ID="txtUsernameLogin" runat="server"></asp:TextBox>
    <br />
    <br />
    Password<br />
    <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <br />

</div>

<div id="right">
    <asp:Panel ID="Panel1" runat="server">
	<div id="label">
        Last Name  <br />
        First Name  <br />
        Initial  <br />
        Username  <br />
        Password  <br />
        Address  <br />
        City  <br />
        State  <br />
        Zip  <br />
        Email  <br />
        Phone  <br />
        <br />
        <br />
        <br />
        <br />
        <br />
	</div>
	
	<div id="textbox">
        <asp:TextBox ID="txtLastName" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtFirstName" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtInitial" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtUsername" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtAddress" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtCity" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtState" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtZip" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPhone" runat="server" Width="220px"></asp:TextBox>
        <br />
        <br />
	</div>
        
	
	
	<div id="image">
	    <br />
        <img alt="" class="auto-style1" src="images.jpg" />

	</div>
        </asp:Panel>

</div>
  
    </form>
</body>
</html>
