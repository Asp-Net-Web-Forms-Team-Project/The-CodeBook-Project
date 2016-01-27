<%@ Page
    Title="Developers"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="View.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Developers.View" %>

<%@ Register Src="~/UserControls/RatingVisualizer.ascx" TagPrefix="codebook" TagName="RatingVisualizer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12 text-center">
        <div class="alert alert-primary" style="font-size: 25px; color: white">All Developers</div>
        <asp:GridView runat="server" ID="AllDevelopersGridView"
            CssClass="table table-striped table-hover"
            ItemType="TheCodeBookProject.Data.Models.User"
            AllowSorting="true"
            AllowPaging="true"
            SelectMethod="AllDevelopersGridView_GetData"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="First name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last name" SortExpression="LastName" />
                <asp:BoundField DataField="Knowledge" HeaderText="Knowledge" SortExpression="Knowledge" />
                <asp:TemplateField HeaderText="Rating" SortExpression="Rating">
                    <ItemTemplate>
                        <codebook:RatingVisualizer runat="server" ID="RatingVisualizer"
                            RatingSum="<%# Item.Rating %>"
                            VotesCount="<%# Item.Votes %>" />
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
</asp:Content>
