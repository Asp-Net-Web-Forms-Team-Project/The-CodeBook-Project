namespace TheCodeBookProject.Web.App.Account
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data;

    public partial class Profile : Page
    {
        [Inject]
        public IUsersService Users { get; set; }

        [Inject]
        public IProjectsService Projects { get; set; }

        public bool HasProjects { get; set; }

        public bool IsMe { get; set; }

        protected void Page_Load()
        {
            string userId = this.Request.QueryString["UserId"];
            if (userId == null)
            {
                userId = this.Context.User.Identity.GetUserId();
            }
            
            this.IsMe = this.User.Identity.GetUserId() == userId;
        }

        public IQueryable<Project> GetUserProjectsGrid()
        {
            string currentUserId = this.Request.QueryString["UserId"];
            if (currentUserId == null)
            {
                currentUserId = this.Context.User.Identity.GetUserId();
            }

            IQueryable<Project> userProjects = this.Projects.GetByUserId(currentUserId);
            this.HasProjects = userProjects.Count() > 0;

            return userProjects;
        }

        protected void MakeAdminButton_Click(object sender, EventArgs e)
        {
            string userId = this.Request.QueryString["UserId"];
            var userStore = new UserStore<User>(new TheCodeBookProjectDbContext());
            var userManager = new UserManager<User>(userStore);
            userManager.AddToRole(userId, "admin");
            this.Response.Redirect("~/Admin/Users.aspx");
        }

        protected void EditUserButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}