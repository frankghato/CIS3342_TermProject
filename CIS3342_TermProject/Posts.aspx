<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="CIS3342_TermProject.Posts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body style="background:#1e1f21; color:white;">
    <form id="form1" runat="server">
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
            background-color: #bd0661;
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
            color:#bd0661;
        }
    </style>
        <div>
        <nav>
            <ul>
                <li><a href="Posts.aspx">View Posts</a></li>
                <li><a href="Profile.aspx">View Your Profile</a></li>
                <li><asp:Button ID="btnLogout" runat="server" Text="Logout"/></li>
            </ul>
        </nav>
    </div>
        <h1>Posts</h1>
        <div>
        </div>
    </form>
</body>
</html>
