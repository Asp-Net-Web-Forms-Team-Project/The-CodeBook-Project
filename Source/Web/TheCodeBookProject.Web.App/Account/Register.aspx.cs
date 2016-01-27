namespace TheCodeBookProject.Web.App.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Common.Identity;
    using Data.Models;
    using ImageResizer;
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
            ApplicationUserManager manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationSignInManager signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var birthday = new DateTime();
            DateTime.TryParse(this.Calendar.Text, out birthday);

            string imageUrl = "~/Images/";
            if (!string.IsNullOrEmpty(this.Request.Files[0].FileName))
            {
                imageUrl += this.UserName.Text +
                           "/avatar" +
                           this.Request
                            .Files[0]
                            .FileName
                            .Substring(this.Request
                                .Files[0].FileName
                                .LastIndexOf('.'));
            }
            else
            {
                imageUrl += "default.jpg";
            }


            var user = new User()
            {
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                UserName = this.UserName.Text,
                Email = this.Email.Text,
                DateOfBirth = birthday,
                AboutMe = this.AboutMe.Text,
                ImageUrl = imageUrl
            };

            var userKnowledge = new List<string>();

            foreach (ListItem item in this.DeveloperKnowledgeListBox.Items)
            {
                if (item.Selected)
                {
                    userKnowledge.Add(item.Value);
                }
            }

            var userSkills = new List<string>();

            foreach (ListItem item in this.DeveloperSkillsListBox.Items)
            {
                if (item.Selected)
                {
                    userSkills.Add(item.Value);
                }
            }

            user.Knowledge = string.Join(", ", userKnowledge);
            user.Skills = string.Join(", ", userSkills);

            IdentityResult result = manager.Create(user, this.Password.Text);
            if (result.Succeeded)
            {
                User registeredUser = manager.FindByName(user.UserName);

                if (this.IsDeveloperRadioButton.Checked)
                {
                    manager.AddToRole(registeredUser.Id, "developer");
                }
                else if (this.IsBusinessRadioButton.Checked)
                {
                    manager.AddToRole(registeredUser.Id, "business");
                }

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
                if (file.ContentLength <= 0)
                {
                    continue;
                }

                string fileExtension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);

                var job = new ImageJob(
                    file,
                    "~/Images/" + this.UserName.Text + "/avatar." + fileExtension,
                    new Instructions("width=250;height=250;format=" + fileExtension + ";mode=max;"));
                job.CreateParentDirectory = true;
                job.Build();
            }
        }

        protected void DeveloperCheckedChanged(object sender, EventArgs e)
        {
            this.KnowledgePanel.Visible = true;
            this.SkillsPanel.Visible = true;
        }

        protected void BusinessCheckedChanged(object sender, EventArgs e)
        {
            this.KnowledgePanel.Visible = false;
            this.SkillsPanel.Visible = false;
        }
    }
}