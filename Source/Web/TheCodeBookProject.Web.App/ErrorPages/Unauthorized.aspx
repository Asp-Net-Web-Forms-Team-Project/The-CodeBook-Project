<%@ Page Title="Unauthorized" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Unauthorized.aspx.cs" 
    Inherits="TheCodeBookProject.Web.App.ErrorPages.Unauthorized" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-danger text-center">
        <strong>The page you requested could not be found!</strong>
    </div>
</asp:Content>
