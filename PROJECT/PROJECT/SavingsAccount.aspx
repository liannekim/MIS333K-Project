<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SavingsAccount.aspx.vb" Inherits="PROJECT.SavingsAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <link href="ASP2.css" rel="stylesheet" type="text/css" />
<body>
    <form id="form1" runat="server">
    <div>
    <div id="center">
        <strong>
        <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
        &#39;s Savings Account&nbsp;Transaction Details</strong></div>
        <div id="left">
            <br />
            <br />
            <strong>Current Balance:
            </strong>
            <br />
            <asp:Label ID="lblCurrentBalance" runat="server"></asp:Label>
            <br />
    
            <br />
            <asp:LinkButton ID="lnkDeposit" runat="server">Make A Deposit</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lnkTransfer" runat="server">Make A Transfer</asp:LinkButton>
        </div>
        <div id ="right">
            <strong>Account Number:</strong>
        <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
            <br />
            <br />
            <strong>Search transactions by:</strong><br />
            Description:
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            Transaction type:
            <asp:DropDownList ID="ddlTransactionType" runat="server">
                <asp:ListItem>Deposit</asp:ListItem>
                <asp:ListItem>Withdrawal</asp:ListItem>
                <asp:ListItem>Transfer</asp:ListItem>
                <asp:ListItem>Bill</asp:ListItem>
            </asp:DropDownList>
            <br />
            Price:
            <asp:DropDownList ID="ddlPriceRange" runat="server">
                <asp:ListItem>$0 - $100</asp:ListItem>
                <asp:ListItem>$101 - $200</asp:ListItem>
                <asp:ListItem>$201 - $300</asp:ListItem>
                <asp:ListItem>$301+</asp:ListItem>
                <asp:ListItem>Custom Range</asp:ListItem>
            </asp:DropDownList>
&nbsp;or between
            <asp:TextBox ID="txtPriceMin" runat="server"></asp:TextBox>
&nbsp;and
            <asp:TextBox ID="txtPriceMax" runat="server"></asp:TextBox>
            <br />
            Transaction Number:
            <asp:TextBox ID="txtTransactionNumber" runat="server"></asp:TextBox>
            <br />
            Date:
            <asp:DropDownList ID="ddlDateRange" runat="server">
                <asp:ListItem>Last 15 Days</asp:ListItem>
                <asp:ListItem>Last 30 Days</asp:ListItem>
                <asp:ListItem>Last 60 Days</asp:ListItem>
                <asp:ListItem>All Available</asp:ListItem>
                <asp:ListItem>Custom Date Range</asp:ListItem>
            </asp:DropDownList>
&nbsp;or between
            <asp:TextBox ID="txtBeginDate" runat="server"></asp:TextBox>
&nbsp;and
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btSearch" runat="server" Text="Search Transactions" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <br />
            Record Count:
            <asp:Label ID="lblCount" runat="server"></asp:Label>
            <asp:GridView ID="gvSavingsTransactions" runat="server">
            </asp:GridView>
            <br />
            <strong>Similar transactions:</strong><br />
            <asp:GridView ID="gvSimilarTransactions" runat="server">
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
