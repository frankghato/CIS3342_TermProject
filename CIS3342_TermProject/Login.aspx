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
            Username:
            <asp:TextBox ID="tboxUsername" runat="server"></asp:TextBox><br />
            Password:
            <asp:TextBox ID="tboxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </div>


        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center; ">
            <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" OnClick="btnForgotPassword_Click" /><br />
            <asp:Button ID="btnForgotUsername" runat="server" Text="Forgot Username" OnClick="btnForgotUsername_Click" />
            <br />
            <asp:Button ID="btnCreateAccount" runat="server" OnClick="Button1_Click" Text="Create an Account" />
            <br />
        </div>

        <div id="retrieveInfoDiv" runat="server" style="visibility:hidden; padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center; ">
            Enter your email:
            <asp:TextBox ID="tboxEmail" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSubmitEmail" runat="server" Text="Submit Email" OnClick="btnSubmitEmail_Click" /><br />
        </div>

        <div id="securityQuestionDiv" runat="server" style="visibility:hidden; padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center;">
                <p id="securityQuestion" runat="server"></p>
                <asp:TextBox ID="tboxSecurityQuestionAnswer" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnSubmitAnswer" runat="server" Text="Submit Answer" OnClick ="btnSubmitAnswer_Click" />
            </div>

    </form>
</body>
</html>
