namespace TheCodeBookProject.Web.App.Account
{
    using System.Linq;
    using System.Web.UI;

    using Data;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public partial class Profile : Page
    {
        public bool HasProjects { get; set; }

        protected void Page_Load()
        {

        }

        public IQueryable<Project> GetUserProjectsGrid()
        {
            string currentUserId = this.Context.User.Identity.GetUserId();
            var db = new TheCodeBookProjectDbContext();
            IQueryable<Project> userProjects = db.Projects.Where(p => p.Developers.Any(d => d.Id == currentUserId));
            this.HasProjects = userProjects.Count() > 0;

            return userProjects;
        }
    }
}