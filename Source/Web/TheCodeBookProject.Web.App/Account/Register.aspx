<%@ Page Title="Register"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger hidden">
        <asp:Literal runat="server"  ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="col-md-6">
            <div class="well bs-component">
                <fieldset>
                    <legend>Create a new account</legend>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" placeholder="First name"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" Display="None"
                                CssClass="text-danger" ErrorMessage="The first name field is required." />
                        </div>
                        <span class="material-input"></span>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" placeholder="Last name"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" Display="None"
                                CssClass="text-danger" ErrorMessage="The last name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Email"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" Display="None"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" Display="None"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Calendar" CssClass="col-md-2 control-label">Birthday:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="Calendar" runat="server" CssClass="form-control" placeholder="Choose birthdate" />
                            <ajaxToolkit:CalendarExtender TargetControlID="Calendar" ID="CalendarExtender" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserStatusContainer" CssClass="col-md-2 control-label">You are:</asp:Label>
                        <div runat="server" class="col-md-10" id="UserStatusContainer">
                            <asp:UpdatePanel runat="server" ID="UserStatusUpdatePanel">
                                <ContentTemplate>
                                    <asp:RadioButton runat="server" ID="IsDeveloperRadioButton"
                                        Text="A developer" AutoPostBack="true"
                                        OnCheckedChanged="DeveloperCheckedChanged"
                                        GroupName="UserStatusGroup" />
                                    <br />
                                    <asp:RadioButton runat="server" ID="IsBusinessRadioButton"
                                        Text="A business person" AutoPostBack="true"
                                        OnCheckedChanged="BusinessCheckedChanged"
                                        GroupName="UserStatusGroup"
                                        Checked="true" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel runat="server" ID="DeveloperBusinessUpdatePanel">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="KnowledgePanel" Visible="false">
                                        <h5 style="color: #BDBDBD;">What is your specific knowledge?</h5>
                                        <asp:ListBox runat="server" ID="DeveloperKnowledgeListBox"
                                            SelectionMode="Multiple">
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
                                    <asp:Panel runat="server" ID="SkillsPanel" Visible="false">
                                        <h5 style="color: #BDBDBD;">What are your skills?</h5>
                                        <asp:ListBox runat="server" ID="DeveloperSkillsListBox"
                                            SelectionMode="Multiple" AutoPostBack="true">
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
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="AboutMe" CssClass="col-md-2 control-label">About Me</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="AboutMe" CssClass="form-control" TextMode="MultiLine" placeholder="About me"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AboutMe" Display="None"
                                CssClass="text-danger" ErrorMessage="The about me field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" Display="None"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm password"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="None" ErrorMessage="The confirm password field is required." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="None" ErrorMessage="The password and confirmation password do not match." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Style="display: inline-block; margin-left: 100px; margin-right: auto" AssociatedControlID="UploadImage" CssClass="col-md-6 btn btn-raised btn-primary">Upload profile picture</asp:Label>
                        <div class="col-md-2">
                            <asp:FileUpload runat="server" ID="UploadImage" placeholder="Choose image" accept=".png,.jpg,.gif" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:HyperLink runat="server" NavigateUrl="~/Home" Text="Cancel" CssClass="btn btn-default" />
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
