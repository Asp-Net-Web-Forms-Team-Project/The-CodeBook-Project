<%@ Page Title="Administrator" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Tools.aspx.cs" 
    Inherits="TheCodeBookProject.Web.App.Admin.Tools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1 class="text-center">Administrator panel</h1>
    <hr />
    <p class="text-center">
        <asp:HyperLink runat="server" CssClass="btn btn-info btn-raised" NavigateUrl="~/Admin/Users.aspx">Users</asp:HyperLink>
    </p>
</asp:Content>
