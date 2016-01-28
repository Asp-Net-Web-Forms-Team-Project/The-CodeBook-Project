<%@ Page Title="Invitations" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Invitations.aspx.cs" 
    Inherits="TheCodeBookProject.Web.App.Business.Invitations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (this.User.IsInRole("developer"))
        {
    %>
    <div class="panel panel-default user-projects" style="width: 600px; margin-left: auto; margin-right: auto">
        <div class="panel-heading text-center">Invitations Received</div>
        <div class="panel-body">
            <%
                if (this.HasInvitationsReceived)
                {
            %>
            <asp:GridView runat="server"
                ID="ReceivedInvitationsGridView"
                CssClass="table table-striped table-hover"
                DataKeyNames="Id"
                ItemType="TheCodeBookProject.Data.Models.ProjectNotification"
                SelectMethod="GetReceivedInvitations"
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
                            <asp:HyperLink runat="server" CssClass="btn btn-success btn-raised" NavigateUrl='<%# "~/Business/Invitations?Accept=true&InvitationId=" + Item.Id + "&UserId=" + Item.ReceiverId + "&ProjectId=" + Item.ProjectId %>'>Accept</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Decline">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" CssClass="btn btn-danger btn-raised" NavigateUrl='<%# "~/Business/Invitations?Accept=false&InvitationId=" + Item.Id %>'>Decline</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%
                }
                else
                {
            %>
            <h1 class="text-center">You have not been sent any invitations</h1>
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
        <div class="panel-heading text-center">Invitations Sent</div>
        <div class="panel-body">
            <%
                if (this.HasInvitationsSent)
                {
            %>
            <asp:GridView runat="server"
                ID="SentInvitationsGridView"
                DataKeyNames="Id"
                CssClass="table table-striped table-hover"
                ItemType="TheCodeBookProject.Data.Models.ProjectNotification"
                SelectMethod="GetSentInvitations"
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
            <h1 class="text-center">You have not sent any invitations</h1>
            <%
                }
            %>
        </div>
    </div>
    <%
        }
    %>
</asp:Content>
