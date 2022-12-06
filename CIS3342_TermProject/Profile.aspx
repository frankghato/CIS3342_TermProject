<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CIS3342_TermProject.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Profile</title>
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body style="background:#1e1f21; color:white;">
    <style>
        nav
        {
            display:flex;
            justify-content: center;
        }

        nav ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }

        nav li
        {
            display: inline-block;
            margin-left: 50px;
            padding-top: 25px;
            padding-right: 20px;
            position: relative;
        }

        nav a
        {
            color: #e7dfdd;
            text-decoration: none;
            text-transform: uppercase;
            font-size: 15px;
            font-family: 'Lato', sans-serif;

        }

        nav a::before
        {
            content: '';
            display: block;
            height: 5px;
            width: 100%;
            background-color: #edc04e;
            position: absolute;
            top:0;
            width:0%;
            transition: all ease-in-out 300ms;
        }

        nav a:hover::before
        {
            width:100%;
        }

        nav a:hover
        {
            color:#edc04e;
        }
    </style>
    <form id="form1" runat="server">
        <div>
        <nav>
            <ul>
                <li><a href="Posts.aspx">View Posts</a></li>
                <li><a href="Profile.aspx">View Your Profile</a></li>
                <li><asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click"/></li>
            </ul>
        </nav>
    </div>
        <asp:Label runat="server" ID="lbltest"></asp:Label>
        <h1 style="background:#1e1f21;">Your followed accounts:</h1>
        <asp:Repeater ID="rptAccounts" runat="server" OnItemCommand="rptAccounts_ItemCommand">
            <ItemTemplate>
                <div style="padding-bottom: 25px">
                    <asp:Label runat="server">Name: </asp:Label>
                    <asp:Label runat="server" ID="lblFirstName" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>' style="color:#edc04e">
                    </asp:Label>
                    <asp:Label runat="server" ID="lblLastName" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>' style="color:#edc04e">
                    </asp:Label><br />
                   <asp:Label runat="server">Username: </asp:Label>
                    <asp:Label runat="server" ID="lblUsername" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>' style="color:#edc04e">
                    </asp:Label><br />
                    <asp:Button runat="server" ID="btnUnfollow" Text="Unfollow" />
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <h1 style="background:#1e1f21;">Your posts:</h1>
        <asp:Repeater ID="rptPosts" runat="server" OnItemCommand="rptPosts_ItemCommand">
            <ItemTemplate>
                <div style="padding-bottom: 25px">
                    <asp:Label runat="server" ID="lblID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                   </asp:Label>
                   <asp:Label runat="server">Username: </asp:Label>
                   <asp:Label runat="server" ID="lblUsername" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>' style="color:#edc04e">
                   </asp:Label><br />
                   <asp:Label runat="server" ID="lblContent" Text='<%# DataBinder.Eval(Container.DataItem, "Content") %>'>
                   </asp:Label><br />
                   <asp:Button runat="server" ID="btnDelete" Text="Delete" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
