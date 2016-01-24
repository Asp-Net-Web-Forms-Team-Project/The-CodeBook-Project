<%@ Page
    Title="My Profile"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Account.Manage" %>

<%@ Register Src="~/UserControls/UserCard/UserCard.ascx" TagPrefix="codebook" TagName="UserCard" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <codebook:UserCard runat="server" ID="UserCard" />
</asp:Content>
