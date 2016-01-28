<%@ Page
    Title="Project Details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Details.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Projects.Details" %>

<%@ Register Src="~/UserControls/RatingVisualizer.ascx" TagPrefix="codebook" TagName="RatingVisualizer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center jumbotron" style="margin-left: auto; margin-right: auto; width: 600px!important">Project details</h1>
    <asp:DetailsView AutoGenerateRows="false" runat="server" ItemType="TheCodeBookProject.Data.Models.Project" Style="margin-left: auto; margin-right: auto; width: 600px!important" CssClass="table table-striped table-hover" ID="ProjectDetailsView">
        <Fields>
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Name:" DataField="Name" />
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Description:" DataField="Description" />
            <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderText="Created by:">
                <ItemTemplate>
                    <%#: this.Users.GetById(Item.CreatorId).UserName %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Organizer:" DataField="Organizer.Name" />
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Average reward:" DataField="AverageMonetaryAwardPerDeveloper" DataFormatString="{0:c}" />
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Developers needed" DataField="DevelopersNeeded" />
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Created on:" DataField="DateCreated" />
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Skills required:" DataField="SkillsRequired" />
            <asp:BoundField HeaderStyle-Font-Bold="true" HeaderText="Knowledge required:" DataField="KnowledgeRequired" />
        </Fields>
    </asp:DetailsView>
    <div class="panel panel-default user-projects" style="width: 600px; margin-left: auto; margin-right: auto">
        <div class="panel-heading text-center project-developers">Participants</div>
        <div class="panel-body">
            <% if (this.HasDevelopers)
                {
            %>
            <asp:GridView runat="server" ID="ProjectDevelopersGridView" CssClass="table table-hover"
                ItemType="TheCodeBookProject.Data.Models.User" DataKeyNames="Id"
                SelectMethod="GetProjectDevelopersGridViewData"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:DynamicField DataField="FirstName" />
                    <asp:DynamicField DataField="LastName" />
                    <asp:DynamicField DataField="UserName" />
                    <asp:TemplateField HeaderText="Rating">
                        <ItemTemplate>
                            <codebook:RatingVisualizer runat="server" ID="RatingVisualizer"
                                RatingSum="<%# Item.Rating %>"
                                VotesCount="<%# Item.Votes %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink
                                runat="server"
                                CssClass="btn btn-default btn-raised"
                                NavigateUrl='<%#:"~/Account/Profile?UserId=" + Item.Id%>'>
                                Details
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%
                }
                else
                {
            %>
            <h4 class="text-center">No developers to display</h4>
            <%
                }
            %>
        </div>
    </div>
    <%
        if (this.User.IsInRole("developer") && !this.IsParticipator)
        {
    %>
    <div class="text-center">
        <asp:Button runat="server" ID="ApplyButton" style="color:black!important;font-weight:600" CssClass="btn btn-primary btn-raised" Text="Apply" OnClick="ApplyButtonClick" />
    </div>
    <%
        }

        if (this.User.IsInRole("business") && this.IsOwner)
        {
    %>
    <div class="text-center">
        <asp:Button runat="server" ID="InviteButton" style="color:black!important;font-weight:600" CssClass="btn btn-primary btn-raised" Text="Choose developer to invite" OnClick="InviteButtonClick" />
    </div>
    <%
        }
    %>
</asp:Content>
