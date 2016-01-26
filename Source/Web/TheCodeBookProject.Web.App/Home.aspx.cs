namespace TheCodeBookProject.Web.App
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Home : Page
    {
        [Inject]
        public IProjectsService Projects { get; set; }

        [Inject]
        public IUsersService Users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Project> MostRecentProjectsGridView_GetData()
        {
            return this.Projects
                .GetAll()
                .OrderByDescending(p => p.DateCreated);
        }

        public IQueryable<User> TopRatedDevelopersGridView_GetData()
        {
            var userStore = new UserStore<User>(new TheCodeBookProjectDbContext());
            var userManager = new UserManager<User>(userStore);

            return this.Users
                .GetAll()
                .ToList()
                .Where(u => userManager.IsInRole(u.Id, "developer"))
                .AsQueryable();
        }
    }
}