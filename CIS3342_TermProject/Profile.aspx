<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CIS3342_TermProject.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="lbltest"></asp:Label>
        <h1>Your followed accounts:</h1>
        <asp:Repeater ID="rptAccounts" runat="server" OnItemCommand="rptAccounts_ItemCommand">
            <ItemTemplate>
                <div>
                    <asp:Label runat="server">Name: </asp:Label>
                    <asp:Label runat="server" ID="lblFirstName" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'>
                    </asp:Label>
                    <asp:Label runat="server" ID="lblLastName" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'>
                    </asp:Label><br />
                   <asp:Label runat="server">Username: </asp:Label>
                    <asp:Label runat="server" ID="lblUsername" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'>
                    </asp:Label><br />
                    <asp:Button runat="server" ID="btnUnfollow" Text="Unfollow" />
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <h1>Your posts:</h1>
        <asp:Repeater ID="rptPosts" runat="server" OnItemCommand="rptPosts_ItemCommand">
            <ItemTemplate>
                <div>
                    <asp:Label runat="server" ID="lblID" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Id") %>'>
                   </asp:Label>
                   <asp:Label runat="server">Username: </asp:Label>
                   <asp:Label runat="server" ID="lblUsername" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'>
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
