namespace TheCodeBookProject.Web.App.Projects
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Error_Handler_Control;

    using Ninject;

    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Services.Data.Contracts;

    public partial class View : System.Web.UI.Page
    {
        [Inject]
        public IProjectsService AllProjects { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.Request.Params["Apply"] != null)
            {
                var currentProject = this.AllProjects.GetById(int.Parse(this.Request.Params["ProjectId"]));
                var firstOrDefault = currentProject.FirstOrDefault();
                if (firstOrDefault != null && firstOrDefault.ProjectNotifications.Any(x => x.DeveloperId == this.Request.Params["devId"]))
                {
                    ErrorSuccessNotifier.AddErrorMessage("You have already applied for this project.");
                }
                else
                {
                    this.AllProjects.ApplyById(int.Parse(this.Request.Params["ProjectId"]), this.Request.Params["devId"]);
                    this.AllProjects.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Application successful!");
                }
            }
        }

        public IQueryable<Project> MostRecentProjectsGridView_GetData()
        {
            return this.AllProjects.GetAll().OrderByDescending(pr => pr.DateCreated);
        }

        protected void OnDataBound(object sender, EventArgs eventArgs)
        {
            this.AllProjectsGridView.Columns[4].Visible = this.User.IsInRole("developer");
        }
    }
}