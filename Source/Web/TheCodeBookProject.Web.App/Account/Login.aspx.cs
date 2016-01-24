namespace TheCodeBookProject.Web.App.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Common.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                ApplicationUserManager manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationSignInManager signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                SignInStatus result = signinManager.PasswordSignIn(UserName.Text, Password.Text, isPersistent: false, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"] ?? "~/Home", Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(
                            string.Format(
                                "/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                Request.QueryString["ReturnUrl"],
                                false),
                            true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}