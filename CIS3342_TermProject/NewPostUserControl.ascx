<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewPostUserControl.ascx.cs" Inherits="CIS3342_TermProject.NewPostUserControl" %>

<asp:TextBox ID="txtNewPost" runat="server" TextMode="MultiLine" Height="75px" Width="200px"></asp:TextBox><br />
<asp:Button ID="btnPost" runat="server" Text="Post!" OnClick="btnPost_Click"/>