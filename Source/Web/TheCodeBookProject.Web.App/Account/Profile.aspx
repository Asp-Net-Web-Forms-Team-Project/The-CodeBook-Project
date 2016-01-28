<%@ Page
    Title="Profile"
    Language="C#"
    MasterPageFile="~/Account/UserDetails.Master"
    AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Account.Profile" %>

<asp:Content ContentPlaceHolderID="UserDetailsContent" runat="server">
    <%@ MasterType VirtualPath="~/Account/UserDetails.master" %>
    <div class="panel panel-default user-projects" style="width: 600px; margin-left: auto; margin-right: auto">
        <div class="panel-heading text-center">Projects</div>
        <div class="panel-body">
            <% if (this.HasProjects)
                {
            %>
            <asp:GridView runat="server" ID="userProjectsGrid" CssClass="table table-hover"
                ItemType="TheCodeBookProject.Data.Models.Project" DataKeyNames="Id"
                SelectMethod="GetUserProjectsGrid"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:DynamicField DataField="Name" />
                    <asp:DynamicField DataField="Description" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink
                                runat="server"
                                CssClass="btn btn-default btn-raised"
                                NavigateUrl='<%#:"~/Projects/Details?ProjectId=" + Item.Id%>'>
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
            <h4 class="text-center">No projects to display</h4>
            <%
                }
            %>
        </div>
    </div>
    <%if (this.User.IsInRole("admin") && !this.IsMe)
        {
    %>
    <div class="panel panel-warning text-center" style="width: 300px; margin-left: auto; margin-right: auto;">
        <div class="panel-heading">
            <h3 class="panel-title">Administrative tools</h3>
        </div>
        <div class="panel-body">
            <asp:Button runat="server" ID="MakeAdminButton" CssClass="btn btn-default btn-raised" Text="Make admin" OnClick="MakeAdminButton_Click"/>
            <br />
            <asp:Button runat="server" ID="EditUserButton" CssClass="btn btn-default btn-raised" Text="Edit" OnClick="EditUserButton_Click"/>
            <br />
            <asp:Button runat="server" ID="DeleteUserButton" CssClass="btn btn-default btn-raised" Text="Delete" OnClick="DeleteUserButton_Click"/>
        </div>
    </div>
    <%
        }
    %>
</asp:Content>
