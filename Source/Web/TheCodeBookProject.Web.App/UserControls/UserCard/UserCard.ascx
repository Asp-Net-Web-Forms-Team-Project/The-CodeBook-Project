<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UserCard.ascx.cs"
    Inherits="TheCodeBookProject.Web.App.UserControls.UserCards" %>

<div class="user-card">
    <h4 class="card-title"><%: this.User.UserName %></h4>
    <asp:Image runat="server" ID="userImage" />
    <h6 class="card-subtitle text-muted"><%: this.User.FirstName + " " + this.User.LastName %></h6>
    <div class="card-block">
        <p class="card-text"><%: this.User.AboutMe %></p>
    </div>
</div>
