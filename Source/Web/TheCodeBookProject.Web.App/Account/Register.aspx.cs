﻿namespace TheCodeBookProject.Web.App.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using Common.Identity;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.Request.IsAuthenticated)
                {
                    this.Response.Redirect("~/Home.aspx");
                }
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            this.Upload_Image();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new User()
            {
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                UserName = this.UserName.Text,
                Email = this.Email.Text,
                DateOfBirth = new DateTime(),
                AboutMe = this.AboutMe.Text,
                ImageUrl = "~/Images/" + this.UserName.Text + "/avatar" + this.Request.Files[0].FileName.Substring(this.Request.Files[0].FileName.LastIndexOf('.'))
            };

            IdentityResult result = manager.Create(user, this.Password.Text);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"] ?? "~/Home", Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void Upload_Image()
        {
            foreach (string fileKey in HttpContext.Current.Request.Files.Keys)
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[fileKey];
                if (file.ContentLength <= 0) continue; //Skip unused file controls.

                var fileExtension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);

                ImageResizer.ImageJob i = new ImageResizer.ImageJob(file, "~/Images/" + this.UserName.Text + "/avatar." + fileExtension, new ImageResizer.Instructions(
                            "width=250;height=250;format=" + fileExtension + ";mode=max;"));
                i.CreateParentDirectory = true; //Auto-create the uploads directory.
                i.Build();
            }
        }
    }
}