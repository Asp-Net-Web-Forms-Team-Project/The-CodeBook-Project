<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="HomeStatistics.ascx.cs"
    Inherits="TheCodeBookProject.Web.App.UserControls.HomeStatistics.HomeStatistics" %>

<%@ OutputCache Duration=600 VaryByParam="None" %>
<%@ Register Src="~/UserControls/RatingVisualizer.ascx" TagPrefix="codebook" TagName="RatingVisualizer" %>

<div class="col-md-6">
    <div class="alert alert-primary" style="font-size: 25px; color: white">Top 8 most recent projects</div>
    <asp:GridView runat="server" ID="MostRecentProjectsGridView"
        CssClass="table table-striped table-hover"
        ItemType="TheCodeBookProject.Data.Models.Project"
        AllowPaging="true"
        SelectMethod="MostRecentProjectsGridView_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="DevelopersNeeded" HeaderText="Developers needed" />
            <asp:BoundField DataField="AverageMonetaryAwardPerDeveloper" HeaderText="Average reward" DataFormatString="{0:c}" />
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:HyperLink runat="server"
                        CssClass="btn btn-default btn-raised"
                        NavigateUrl='<%#: "~/Projects/Details?ProjectId=" +  Item.Id %>'>Details</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="col-md-6">
    <div class="alert alert-primary" style="font-size: 25px; color: white">Top 8 best rated developers</div>
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
                    <codebook:ratingvisualizer runat="server" id="RatingVisualizer"
                        ratingsum="<%# Item.Rating %>"
                        votescount="<%# Item.Votes %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:HyperLink runat="server"
                        CssClass="btn btn-default btn-raised"
                        NavigateUrl='<%#: "~/Account/Profile?UserId=" +  Item.Id %>'>Details</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
