namespace TheCodeBookProject.Web.App
{
    using System;
    using System.Linq;
    using System.Web.UI;
    
    using Data.Models;
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
                .GetAllInEarlyStage()
                .OrderByDescending(p => p.DateCreated)
                .Take(8);
        }

        private IQueryable<User> GetTopRatedDevelopers()
        {

            return this.Users
                .GetAllUsersInRole("developer")
                .OrderByDescending(d => Math.Round((double)d.Rating / (d.Votes == 0 ? 1 : d.Votes), 1))
                .Take(8);
        }
    }
}