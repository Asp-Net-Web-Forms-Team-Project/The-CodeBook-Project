<%@ Page Title="Home Page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Home" %>

<%@ Register Src="~/UserControls/RatingVisualizer.ascx" TagPrefix="codebook" TagName="RatingVisualizer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row text-center">
        <div class="col-md-12 jumbotron">
            <h1 style="font-size:36px">Welcome to The CodeBook Project</h1>
            <h2>The place where developers and business people meet</h2>
        </div>
        <div class="col-md-6">
        <div class="alert alert-primary" style="font-size:25px;color:white">Most recent projects</div>
            <asp:GridView runat="server" ID="MostRecentProjectsGridView"
                CssClass="table table-striped table-hover"
                ItemType="TheCodeBookProject.Data.Models.Project"
                AllowPaging="true"
                SelectMethod="MostRecentProjectsGridView_GetData"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="DevelopersNeeded" HeaderText="Developers needed" />
                    <asp:BoundField DataField="AverageMonetaryAwardPerDeveloper" HeaderText="Average reward" DataFormatString="{0:c}"/>
                    <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" 
                                CssClass="btn btn-default btn-raised"  
                                NavigateUrl=<%#: "~/Projects/View?ProjectId=" +  Item.Id %>>Details</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-6">
        <div class="alert alert-primary" style="font-size:25px;color:white">Top rated developers</div>
            <asp:GridView runat="server" ID="TopRatedDevelopersGridView"
                CssClass="table table-striped table-hover"
                ItemType="TheCodeBookProject.Data.Models.User"
                AllowPaging="true"
                SelectMethod="TopRatedDevelopersGridView_GetData"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="Username" />
                    <asp:BoundField DataField="FirstName" HeaderText="First name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last name" />
                    <asp:TemplateField HeaderText="Rating">
                        <ItemTemplate>
                            <codebook:RatingVisualizer runat="server" ID="RatingVisualizer" 
                                RatingSum="<%# Item.Rating %>" 
                                VotesCount="<%# Item.Votes %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" 
                                CssClass="btn btn-default btn-raised"  
                                NavigateUrl=<%#: "~/Account/Profile?UserId=" +  Item.Id %>>Details</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
