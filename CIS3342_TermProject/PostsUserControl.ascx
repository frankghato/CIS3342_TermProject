<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostsUserControl.ascx.cs" Inherits="CIS3342_TermProject.PostsUserControl" %>

<div style="padding-bottom: 25px">
    <asp:Label ID="lblUsername" runat="server" style="color:#edc04e"></asp:Label><br />
    <asp:Label ID="lblContent" runat="server"></asp:Label><br />
    <asp:Label runat="server">Likes:</asp:Label>
    <asp:Label ID="lblLikes" runat="server"></asp:Label><br />
    <asp:Label runat="server">Disikes:</asp:Label>
    <asp:Label ID="lblDislikes" runat="server"></asp:Label><br />
    <asp:Button ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click"/>
    <asp:Button ID="btnDislike" runat="server" Text="Dislike" OnClick="btnDislike_Click"/>
    <asp:Button ID="btnFollow" runat="server" Text="FollowUser" OnClick="btnFollow_Click" />
</div>