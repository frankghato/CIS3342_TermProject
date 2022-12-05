<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CIS3342_TermProject.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
