﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddCustomer.aspx.vb" Inherits="ASP3.AddCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
       New Profile<br />
        </div>

<div id="left">

    <br />
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <br />
    <br />
    <br />
    <asp:Button ID="btnClear" runat="server" CausesValidation="False" Text="Clear" />
    <br />
    <br />
    <asp:LinkButton ID="lnkHome" runat="server" PostBackUrl="~/index.aspx" CausesValidation="False">Home</asp:LinkButton>
    <br />
    <asp:LinkButton ID="lnkShowAll" runat="server" CausesValidation="False" PostBackUrl="~/ShowAll.aspx">Show All Customers</asp:LinkButton>
    <br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    Kelley Wang<br />

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
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Required" ClientIDMode="Static">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtFirstName" runat="server" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name Required" ClientIDMode="Static">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtInitial" runat="server" Width="220px" MaxLength="1"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtUsername" runat="server" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username Required" ClientIDMode="Static">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required" ClientIDMode="Static">*</asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtAddress" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtCity" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtState" runat="server" Width="220px" MaxLength="2"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtZip" runat="server" Width="220px" MaxLength="9"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required" ClientIDMode="Static">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="txtPhone" runat="server" Width="220px" MaxLength="10"></asp:TextBox>
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
