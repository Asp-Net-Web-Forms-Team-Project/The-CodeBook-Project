<%@ Page
    Title="Not Found"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="NotFound.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.ErrorPages.NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-danger text-center">
        <strong>The page you requested could not be found!</strong>
    </div>
</asp:Content>
