namespace TheCodeBookProject.Web.App.Account
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
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new User()
            {
                FirstName = this.FirstName.Text,
                LastName = this.LastName.Text,
                UserName = this.UserName.Text,
                Email = this.Email.Text,
                Age = Convert.ToInt32(this.Age.Text),
                AboutMe = this.AboutMe.Text
            };

            IdentityResult result = manager.Create(user, this.Password.Text);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}