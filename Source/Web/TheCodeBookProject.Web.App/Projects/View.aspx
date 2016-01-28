<%@ Page 
    Title="Projects"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="View.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Projects.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-8 col-md-offset-2">
        <div class="alert alert-primary col-md-12 text-center" style="font-size: 25px; color: white">All projects</div>
        <asp:GridView runat="server" ID="AllProjectsGridView"
            CssClass="table table-striped table-hover text-center"
            ItemType="TheCodeBookProject.Data.Models.Project"
            OnDataBound="OnDataBound"
            AllowPaging="true"
            AllowSorting="true"
            SelectMethod="GetProjectsGridViewData"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="DevelopersNeeded" HeaderText="Developers needed" SortExpression="DevelopersNeeded" />
                <asp:BoundField DataField="AverageMonetaryAwardPerDeveloper" HeaderText="Average reward" SortExpression="AverageMonetaryAwardPerDeveloper" DataFormatString="{0:c}" />
                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:HyperLink runat="server"
                            CssClass="btn btn-default btn-raised"
                            NavigateUrl='<%#: "~/Projects/Details?ProjectId=" +  Item.Id %>'>Details</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apply">
                    <ItemTemplate>
                        <asp:HyperLink runat="server"
                            CssClass="btn btn-default btn-raised"
                            NavigateUrl='<%# "~/Projects/View?ProjectId=" +  Item.Id + "&Apply=true&DeveloperId=" + this.User.Identity.GetUserId() %>'>Apply</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
