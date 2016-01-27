namespace TheCodeBookProject.Web.App.UserControls
{
    using System;
    using System.Web.UI;
    
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class UserCards : UserControl
    {
        [Inject]
        public IUsersService Users { get; set; }

        public User User { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = this.Request.QueryString["UserId"];
            if (userId == null)
            {
                userId = this.Context.User.Identity.GetUserId();
            }

            this.User = this.Users.GetById(userId);
            this.userImage.ImageUrl = this.User.ImageUrl;
        }
    }
}