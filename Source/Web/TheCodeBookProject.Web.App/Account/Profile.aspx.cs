namespace TheCodeBookProject.Web.App.Account
{
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Profile : Page
    {
        [Inject]
        public IProjectsService Projects { get; set; }

        public bool HasProjects { get; set; }

        protected void Page_Load()
        {
        }

        public IQueryable<Project> GetUserProjectsGrid()
        {
            string currentUserId = this.Context.User.Identity.GetUserId();
            IQueryable<Project> userProjects = this.Projects.GetByUserId(currentUserId);
            this.HasProjects = userProjects.Count() > 0;

            return userProjects;
        }
    }
}