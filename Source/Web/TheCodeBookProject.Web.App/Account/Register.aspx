﻿<%@ Page Title="Register"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="TheCodeBookProject.Web.App.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="row">
        <div class="col-md-6">
            <div class="well bs-component">
                <fieldset>
                    <legend>Create a new account</legend>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" placeholder="First name" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                CssClass="text-danger" ErrorMessage="The first name field is required." />
                        </div>
                        <span class="material-input"></span>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="LastName" CssClass="form-control" TextMode="SingleLine" placeholder="Last name" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                                CssClass="text-danger" ErrorMessage="The last name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Email" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" TextMode="SingleLine" placeholder="Username" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserStatus" CssClass="col-md-2 control-label">Status</asp:Label>
                        <div class="col-md-10">
                            <asp:RadioButtonList runat="server" ID="UserStatus">
                                <asp:ListItem runat="server" Value="developer">Developer</asp:ListItem>
                                <asp:ListItem runat="server" Value="business">Business person</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="AboutMe" CssClass="col-md-2 control-label">About Me</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="AboutMe" CssClass="form-control" TextMode="MultiLine" placeholder="About me" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="AboutMe"
                                CssClass="text-danger" ErrorMessage="The about me field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm password" required="required" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
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