<%@ Page
    Title="Applications"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Applications.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Business.Applications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (this.User.IsInRole("developer"))
        {
    %>
    <div class="panel panel-default user-projects" style="width: 600px; margin-left: auto; margin-right: auto">
        <div class="panel-heading text-center">Applications Sent</div>
        <div class="panel-body">
            <%
                if (this.HasApplicationsSent)
                {
            %>
            <asp:GridView runat="server"
                ID="SentApplicationsGridView"
                CssClass="table table-striped table-hover"
                DataKeyNames="Id"
                ItemType="TheCodeBookProject.Data.Models.ProjectNotification"
                SelectMethod="GetSentApplications"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Sender">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Account/Profile?UserId=" + Item.SenderId %>'>
                                <%# 
                                    this.Users.GetById(Item.SenderId).UserName 
                                %>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Receiver">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Account/Profile?UserId=" + Item.ReceiverId %>'>
                                <%# 
                                    this.Users.GetById(Item.ReceiverId).UserName 
                                %>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Status" DataField="Status" />
                </Columns>
            </asp:GridView>
            <%
                }
                else
                {
            %>
            <h1 class="text-center">You have not applied for any projects</h1>
            <%
                }
            %>
        </div>
    </div>
    <%
        }

        if (this.User.IsInRole("business"))
        {
    %>
    <div class="panel panel-default user-projects" style="width: 600px; margin-left: auto; margin-right: auto">
        <div class="panel-heading text-center">Applications Received</div>
        <div class="panel-body">
            <%
                if (this.HasApplicationsReceived)
                {
            %>
            <asp:GridView runat="server"
                ID="ReceivedApplicationsGridView"
                DataKeyNames="Id"
                CssClass="table table-striped table-hover"
                ItemType="TheCodeBookProject.Data.Models.ProjectNotification"
                SelectMethod="GetReceivedApplications"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Sender">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Account/Profile?UserId=" + Item.SenderId %>'>
                                <%# 
                                    this.Users.GetById(Item.SenderId).UserName 
                                %>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Receiver">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Account/Profile?UserId=" + Item.ReceiverId %>'>
                                <%# 
                                    this.Users.GetById(Item.ReceiverId).UserName 
                                %>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Status" DataField="Status" />
                    <asp:TemplateField HeaderText="Accept">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" CssClass="btn btn-success btn-raised" NavigateUrl='<%# "~/Business/Applications?Accept=true&ApplicationId=" + Item.Id + "&UserId=" + Item.SenderId + "&ProjectId=" + Item.ProjectId %>'>Accept</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Decline">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" CssClass="btn btn-danger btn-raised" NavigateUrl='<%# "~/Business/Applications?Accept=false&ApplicationId=" + Item.Id %>'>Decline</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%
                }
                else
                {
            %>
            <h1 class="text-center">No applications to accept or decline</h1>
            <%
                }
            %>
        </div>
    </div>
    <%
        }
    %>
</asp:Content>
