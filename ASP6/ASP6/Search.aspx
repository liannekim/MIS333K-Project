<%@ Page Title="James's Flower Shop" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Search.aspx.vb" Inherits="ASP6.ShowAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="right">
        <br />
        Enter Search Criteria:
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <br />
        <br />
        Search by:
        <asp:Button ID="btnUsername" runat="server" Text="Username" />
        <asp:Button ID="btnLastname" runat="server" Text="Lastname" />
        <asp:Button ID="btnCity" runat="server" Text="City" />
        <asp:Button ID="btnState" runat="server" Text="State" />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All" />
        <br />
        <asp:RadioButtonList ID="radSort" runat="server">
            <asp:ListItem Selected="True">Sort By Name</asp:ListItem>
            <asp:ListItem>Sort By Username</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        Record count: <asp:Label ID="lblCount" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        Kelley Wang<br />
    <asp:GridView ID="gvCustomers" runat="server">
    </asp:GridView>
        <br />
        </div>
</asp:Content>
