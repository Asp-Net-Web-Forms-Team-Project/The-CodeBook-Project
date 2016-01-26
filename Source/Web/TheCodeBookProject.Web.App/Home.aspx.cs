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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.HomeStatistics != null)
            {
                this.HomeStatistics.Users = this.GetTopRatedDevelopers();
                this.HomeStatistics.Projects = this.GetMostRecentProjects();
            }
        }

        private IQueryable<Project> GetMostRecentProjects()
        {
            return this.Projects
                .GetAll()
                .OrderByDescending(p => p.DateCreated)
                .Take(8);
        }

        private IQueryable<User> GetTopRatedDevelopers()
        {
            var userStore = new UserStore<User>(new TheCodeBookProjectDbContext());
            var userManager = new UserManager<User>(userStore);

            return this.Users
                .GetAll()
                .ToList()
                .Where(u => userManager.IsInRole(u.Id, "developer"))
                .OrderByDescending(d => Math.Round((double)d.Rating / d.Votes, 1))
                .Take(8)
                .AsQueryable();
        }
    }
}