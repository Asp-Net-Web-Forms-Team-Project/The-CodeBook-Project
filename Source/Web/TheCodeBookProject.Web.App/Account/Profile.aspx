<%@ Page
    Title="My Profile"
    Language="C#"
    MasterPageFile="~/Account/UserDetails.Master"
    AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Account.Profile" %>

<asp:Content ContentPlaceHolderID="UserDetailsContent" runat="server">
    <div class="panel panel-default user-projects" style="width: 600px; margin-left: auto; margin-right: auto">
        <div class="panel-heading text-center">My Projects</div>
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
                                NavigateUrl='<%#:"~/Projects/View?ProjectId=" + Item.Id%>'>
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
            <h4 class="text-center">You have not participated in any projects</h4>
            <%
                }
            %>
        </div>
    </div>
</asp:Content>
