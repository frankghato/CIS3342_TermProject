<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="CIS3342_TermProject.RegisterAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email Address:
            <asp:TextBox ID="tboxEmailAddress" runat="server"></asp:TextBox>
        </div>
        <p>
            Username:
            <asp:TextBox ID="tboxUsername" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="tboxPassword" runat="server"></asp:TextBox>
        </p>
        <p>
            Phone Number:
            <asp:TextBox ID="tboxPhoneNumber" runat="server"></asp:TextBox>
        </p>
        <p>
            Home Address:
            <asp:TextBox ID="tboxHomeAddress" runat="server"></asp:TextBox>
        </p>
        <p>
            Billing Address:
            <asp:TextBox ID="tboxBillingAddress" runat="server"></asp:TextBox>
        </p>
        <p>
            Security Questions: </p>
        <p>
            Question1:
        </p>
        <p>
            <asp:TextBox ID="tboxQuestion1" runat="server"></asp:TextBox>
        </p>
        <p>
            Question2:
        </p>
        <p>
            <asp:TextBox ID="tboxQuestion2" runat="server"></asp:TextBox>
        </p>
        <p>
            Question3:</p>
        <p>
            <asp:TextBox ID="tboxQuestion3" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
</html>
