<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="CIS3342_TermProject.RegisterAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="scripts/FormValidation.js" type="text/javascript"></script>
</head>
<body style="background:#1e1f21; color:white;">
    <form id="form1" runat="server">
        
        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center;">
            <h1>All fields are required to create an account.</h1>
            <p style="color: #ed5151;">
                <asp:Label ID="lblErrors" runat="server" Text="Label"></asp:Label>
            </p>
        </div>
        
        <div style="padding-top:5px;padding-bottom:5px;background :#7485a1; color:white; width:55%; margin:0 auto;margin-top:25px; text-align:center;">
            <h1>Account Information</h1>
            <table>
                <tr>
                    <th>
                        Email Address:
                        <asp:TextBox ID="tboxEmailAddress" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        Username:
                        <asp:TextBox ID="tboxUsername" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th>
                        First Name:
                        <asp:TextBox ID="tboxFirstName" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        Last Name:
                        <asp:TextBox ID="tboxLastName" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th>
                        Password: <asp:TextBox ID="tboxPassword" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        Confirm Password: <asp:TextBox ID="tboxConfirmPassword" runat="server"></asp:TextBox>
                    </th>
                </tr>
            </table>
        </div>
        
        <div style="padding-top:5px;padding-bottom:5px;background :#7485a1; color:white; width:55%; margin:0 auto;margin-top:25px; text-align:center; ">
            <h1>Billing Information</h1>
            <table>
                <tr>
                    <th>
                        Phone Number: <asp:TextBox ID="tboxPhoneNumber" runat="server"></asp:TextBox>
                    </th>
                    <th>
                        Home Address:
                        <asp:TextBox ID="tboxHomeAddress" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th>
                        Billing Address:
                        <asp:TextBox ID="tboxBillingAddress" runat="server"></asp:TextBox>
                    </th>
                </tr>
            </table>
        </div>

        <div style="padding-top:5px;padding-bottom:5px;background :#7485a1; color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center; ">
            Select Profile Image:
            <asp:DropDownList ID="ddlProfileImage" runat="server" OnSelectedIndexChanged="ddlProfileImage_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <asp:Image runat="server" style="width:20%;" ID="profileImage" ImageUrl="assets/profileimages/1.bmp"/>
        </div>

        <div style="padding-top:5px;padding-bottom:5px;background :#7485a1; color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center; ">
            <h1>Security Questions</h1>
            <p id="question1Text" runat="server">Question 1: </p><asp:TextBox ID="tboxQuestion1" runat="server"></asp:TextBox><br />
            <p id="question2Text" runat="server">Question 1: </p><asp:TextBox ID="tboxQuestion2" runat="server"></asp:TextBox><br />
            <p id="question3Text" runat="server">Question 1: </p><asp:TextBox ID="tboxQuestion3" runat="server"></asp:TextBox>
        </div>
        
        <div style="padding-top:5px;padding-bottom:5px;color:white; width:50%; margin:0 auto;margin-top:25px; text-align:center; ">
            <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
            <br />
        </div>
    </form>
</body>
</html>
