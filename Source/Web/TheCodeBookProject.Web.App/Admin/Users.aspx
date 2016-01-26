<%@ Page Title="Users"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Users.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h3 class="text-center alert alert-dismissable alert-primary">Users</h3>

            <asp:GridView CssClass="table table-striped table-hover table-bordered table-responsive text-center"
                ID="UsersGridView" runat="server"
                SelectMethod="UsersGridView_GetData"
                UpdateMethod="UsersGridView_UpdateItem"
                DeleteMethod="UsersGridView_DeleteItem"
                ItemType="TheCodeBookProject.Data.Models.User"
                AllowPaging="True"
                AllowSorting="True"
                DataKeyNames="Id"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:DynamicField DataField="UserName" HeaderText="Username" SortExpression="UserName"></asp:DynamicField>
                    <asp:DynamicField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:DynamicField>
                    <asp:DynamicField DataField="FirstName" HeaderText="First name" SortExpression="FirstName"></asp:DynamicField>
                    <asp:DynamicField DataField="LastName" HeaderText="Last name" SortExpression="LastName"></asp:DynamicField>
                    <asp:CheckBoxField ControlStyle-CssClass="checkbox-primary" DataField="IsDeactivated" HeaderText="Deactivated" SortExpression="IsDeactivated" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="true" ControlStyle-CssClass="btn btn-default btn-raised" />
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:HyperLink
                                runat="server"
                                CssClass="btn btn-default btn-raised"
                                NavigateUrl='<%#:"~/Account/Profile?UserId=" + Item.Id%>'>
                                View
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
