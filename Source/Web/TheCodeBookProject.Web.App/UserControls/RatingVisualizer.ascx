<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="RatingVisualizer.ascx.cs" 
    Inherits="TheCodeBookProject.Web.App.UserControls.RatingVisualizer" %>
<div style="display:inline-block;margin-left:auto;margin-right:auto;">
    <div style="position:relative">
        <i style="color:#009688;position:relative" class="material-icons md-72">grade</i>
        <span style="position:absolute;color:white;top:23px;left:23px;font-family: 'Changa One', cursive;font-size:18px">
            <%: ((double)this.RatingSum / (this.VotesCount == 0 ? 1 : this.VotesCount)).ToString(format: "0.0") %>
        </span>
    </div>
</div>
