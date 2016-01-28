namespace TheCodeBookProject.Web.App
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using ErrorHandlerControl;

    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            HttpCookie requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                this.antiXsrfTokenValue = requestCookie.Value;
                this.Page.ViewStateUserKey = antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                this.antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                this.Page.ViewStateUserKey = antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = this.antiXsrfTokenValue
                };

                if (FormsAuthentication.RequireSSL && this.Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }

                this.Response.Cookies.Set(responseCookie);
            }

            this.Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Set Anti-XSRF token
                this.ViewState[AntiXsrfTokenKey] = this.Page.ViewStateUserKey;
                this.ViewState[AntiXsrfUserNameKey] = this.Context.User.Identity.Name ?? string.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)this.ViewState[AntiXsrfTokenKey] != this.antiXsrfTokenValue
                    || (string)this.ViewState[AntiXsrfUserNameKey] != (this.Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            this.Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            ErrorSuccessNotifier.AddSuccessMessage("Successfully logged out");
        }

        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (this.ShouldRemoveItem(e.Item.Text))
            {
                e.Item.Parent.ChildItems.Remove(e.Item);
            }
        }

        private bool ShouldRemoveItem(string itemText)
        {
            string user = this.Context.User.Identity.GetUserName();

            if (string.IsNullOrEmpty(user))
            {
                if (itemText == "Home" || itemText == "About" || itemText == "Contact")
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}