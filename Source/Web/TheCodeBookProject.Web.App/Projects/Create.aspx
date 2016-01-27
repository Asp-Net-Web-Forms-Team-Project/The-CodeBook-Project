<%@ Page
    Title="Create Project"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Create.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Projects.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="well bs-component">
                <fieldset>
                    <legend class="text-center">Create a new project</legend>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger text-left" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" placeholder="Project name" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Display="None" ErrorMessage="Project name is required" />
                        </div>
                        <span class="material-input"></span>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Description" CssClass="form-control" TextMode="MultiLine" placeholder="Description" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                                CssClass="text-danger" Display="None" ErrorMessage="Description is required" />
                        </div>
                    </div>
                    <%
                        if (this.UserCompany == null)
                        {
                    %>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Company" CssClass="col-md-2 control-label">Company name:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Company" CssClass="form-control" TextMode="SingleLine" placeholder="Company name" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Company" Display="None" ErrorMessage="You do not have a company to your name. It is required" />
                        </div>
                    </div>
                    <%
                        }
                    %>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DevsNeeded" CssClass="col-md-2 control-label">Developers</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="DevsNeeded" TextMode="Number" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DevsNeeded" Display="None" CssClass="text-danger" ErrorMessage="Number of devs should be specified" />
                            <asp:RangeValidator runat="server" ControlToValidate="DevsNeeded" Display="None" MinimumValue="2" MaximumValue="100000" Type="Integer" ErrorMessage="Number of devs must be at leats 2" />
                        </div>
                    </div>
                    <div class="col-md-offset-2 col-md-6">
                        <asp:UpdatePanel runat="server" ID="DeveloperBusinessUpdatePanel">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="KnowledgePanel" Visible="true">
                                    <h5 style="color: #BDBDBD;">What knowledge do you require?</h5>
                                    <asp:ListBox runat="server" ID="DeveloperKnowledgeRequiredListBox"
                                        SelectionMode="Multiple" Rows="6">
                                        <asp:ListItem Text="C#" Value="C#" />
                                        <asp:ListItem Text="Python" Value="Python" />
                                        <asp:ListItem Text="JavaScript" Value="JavaScript" />
                                        <asp:ListItem Text="Java" Value="Java" />
                                        <asp:ListItem Text="Visual Basic" Value="Visual Basic" />
                                        <asp:ListItem Text="PHP" Value="PHP" />
                                        <asp:ListItem Text="HTML" Value="HTLM" />
                                        <asp:ListItem Text="CSS" Value="CSS" />
                                        <asp:ListItem Text="Turbo Pascal" Value="Turbo Pascal" />
                                        <asp:ListItem Text="SQL" Value="SQL" />
                                        <asp:ListItem Text="jQuery" Value="jQuery" />
                                        <asp:ListItem Text="AngularJS" Value="AngularJS" />
                                        <asp:ListItem Text="NodeJS" Value="NodeJS" />
                                    </asp:ListBox>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="SkillsPanel" Visible="true">
                                    <h5 style="color: #BDBDBD;">What skills do you require?</h5>
                                    <asp:ListBox runat="server" ID="DeveloperSkillsRequiredListBox"
                                        SelectionMode="Multiple" Rows="6">
                                        <asp:ListItem Text="Project Management" Value="Project Management" />
                                        <asp:ListItem Text="Db Management" Value="Db Management" />
                                        <asp:ListItem Text="ASP.NET Web Forms" Value="ASP.NET Web Forms" />
                                        <asp:ListItem Text="ASP.NET MVC" Value="ASP.NET MVC" />
                                        <asp:ListItem Text="MEAN" Value="MEAN" />
                                        <asp:ListItem Text="SPA" Value="SPA" />
                                        <asp:ListItem Text="Native Mobile Apps Development" Value="Native Mobile Apps Development" />
                                        <asp:ListItem Text="Hybrid Mobile Apps Development" Value="Hybrid Mobile Apps Development" />
                                        <asp:ListItem Text="Windows Universal Apps" Value="Windows Universal Apps" />
                                    </asp:ListBox>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <br />
                    <div class="form-group" style="clear: left">
                        <asp:Label runat="server" AssociatedControlID="Reward" CssClass="col-md-2 control-label">Developers</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Reward" TextMode="Number" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Reward" CssClass="text-danger" ErrorMessage="Reward should be specified" />
                            <asp:RangeValidator runat="server" ControlToValidate="Reward" Display="None" ErrorMessage="Monetary award must be at least 1" MinimumValue="1" MaximumValue="1000000" Type="Integer" />
                        </div>
                    </div>
                    <div class="form-group text-center">
                        <asp:Button runat="server" ID="Submit" OnClick="SubmitClick" CssClass="btn btn-default btn-raised" Text="Submit" />
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
