<%@ Page Title="Home Page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Home" %>

<%@ Register Src="~/UserControls/HomeStatistics/HomeStatistics.ascx" TagPrefix="codebook" TagName="HomeStatistics" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row text-center">
        <div class="col-md-12 jumbotron">
            <h1 style="font-size:36px">Welcome to The CodeBook Project</h1>
            <h2>The place where developers and business people meet</h2>
        </div>
        <codebook:HomeStatistics runat="server" id="HomeStatistics" />
    </div>
</asp:Content>
