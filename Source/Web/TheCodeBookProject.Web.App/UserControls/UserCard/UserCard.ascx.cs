namespace TheCodeBookProject.Web.App.UserControls
{
    using System;
    using System.Web.UI;
    using Data.Models;

    public partial class UserCards : UserControl
    {
        public User User { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.User = new User { };
        }
    }
}