<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageCustomers.aspx.vb" Inherits="ASP5.ManageCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">  
    
        <br />
        <br />
        <br />
    
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
        <br />
        <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <br />
    Kelley Wang<br />

</div>

<div id="right">
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
        <asp:TextBox ID="txtInitial" runat="server" Width="220px" MaxLength="1"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtUsername" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtAddress" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtCity" runat="server" Width="220px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtState" runat="server" Width="220px" MaxLength="2"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtZip" runat="server" Width="220px" MaxLength="9" style="height: 22px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="220px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ClientIDMode="Static" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br />
        <asp:TextBox ID="txtPhone" runat="server" Width="220px" MaxLength="14"></asp:TextBox>
        <br />
        <br />
	</div>

    <div id="buttons">
        
    <br />
    <br />
    <asp:Button ID="btnModify" runat="server" Text="Modify" CausesValidation="False" style="height: 26px" />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:Button ID="btnAbortModify" runat="server" Text="Abort" CausesValidation="False" />
    <br />
    <br />
        <br />

    <asp:Button ID="btnDelete" runat="server" Text="Delete Current Record" CausesValidation="False" />
    <br />
    <asp:Button ID="btnConfirmDelete" runat="server" Text="Confirm Delete" CausesValidation="False" />
    <asp:Button ID="btnAbortDelete" runat="server" Text="Abort" CausesValidation="False" />
    <br />
    <br />
        <asp:Label ID="lblUsername" runat="server"></asp:Label>
        <br />

        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <br />
        <br /><br />
        <asp:LinkButton ID="lnkShowAll" runat="server" CausesValidation="False" PostBackUrl="~/ViewCustomers.aspx">Return to Grid</asp:LinkButton>
    <br />
    <br />
    <br />
    <br />

    </div>
        

</div>
</asp:Content>
