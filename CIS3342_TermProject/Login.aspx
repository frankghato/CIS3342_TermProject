<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CIS3342_TermProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background:#1e1f21; color:white;">
    <form id="form1" runat="server">
        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center;">
            <h1>Login to your account:</h1>
            <p style="color: #ed5151;">
                <asp:Label ID="lblErrors" runat="server" Text="Label"></asp:Label>
            </p>
        </div>

        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center;">
            Email Address:
            <asp:TextBox ID="tboxEmailAddress" runat="server"></asp:TextBox><br />
            Password:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>


        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center; ">
            <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" OnClick="btnForgotPassword_Click" /><br />
            <asp:Button ID="btnForgotUsername" runat="server" Text="Forgot Username" OnClick="btnForgotUsername_Click" />
            <br />
        </div>

    </form>
</body>
</html>
