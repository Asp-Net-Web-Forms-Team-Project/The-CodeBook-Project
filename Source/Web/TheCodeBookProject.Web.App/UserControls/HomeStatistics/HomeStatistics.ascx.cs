namespace TheCodeBookProject.Web.App.UserControls.HomeStatistics
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;

    public partial class HomeStatistics : UserControl
    {
        public IQueryable<User> Users { get; set; }

        public IQueryable<Project> Projects { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public IQueryable<Project> MostRecentProjectsGridView_GetData()
        {
            return this.Projects;
        }
        
        public IQueryable<User> TopRatedDevelopersGridView_GetData()
        {
            return this.Users;
        }
    }
}