namespace TheCodeBookProject.Web.App.UserControls
{
    using System;
    using System.Web.UI;

    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public partial class UserCards : UserControl
    {
        public User User { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new TheCodeBookProjectDbContext())
            {
                string userId = this.Request.QueryString["UserId"];
                if (userId == null)
                {
                    userId = this.Context.User.Identity.GetUserId();
                }

                this.User = db.Users.Find(userId);
                this.userImage.ImageUrl = this.User.ImageUrl;
            }
        }
    }
}