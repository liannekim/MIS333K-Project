<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.vb" Inherits="ASP5.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="center">

    <br />
        Employee Login<br />
        <br />
    <br />
        Employee ID<br />
    <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
    <br />
    <br />
    Password<br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
        <br />
        <asp:TextBox ID="txtCount" runat="server"></asp:TextBox>
    <br />

</div>
</asp:Content>
