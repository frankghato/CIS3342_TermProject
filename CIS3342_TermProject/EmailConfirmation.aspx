<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailConfirmation.aspx.cs" Inherits="CIS3342_TermProject.EmailConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background:#1e1f21; color:white;">
    <form id="form1" runat="server">
        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center;">
            <h1>Thank you for confirming your account.</h1>
            <p id="welcomeMessage" runat="server"></p>
            <a style="color:white;" href="Login.aspx">Click here to go to the login page.</a>
        </div>
    </form>
</body>
</html>
