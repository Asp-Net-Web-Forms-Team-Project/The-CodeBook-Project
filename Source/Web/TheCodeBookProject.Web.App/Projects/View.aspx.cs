namespace TheCodeBookProject.Web.App.Projects
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using ErrorHandlerControl;
    using Ninject;
    using Services.Data.Contracts;

    public partial class View : Page
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
                string devId = this.Request.Params["DeveloperId"];

                Project currentProject = this.AllProjects.GetById(int.Parse(this.Request.Params["ProjectId"]));
                if (currentProject != null &&
                    (currentProject.ProjectNotifications.Any(x => x.SenderId == devId) ||
                    currentProject.Developers.Any(d => d.Id == devId)))
                {
                    ErrorSuccessNotifier.AddErrorMessage("You cannot apply.");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                }
                else
                {
                    this.AllProjects.ApplyById(int.Parse(this.Request.Params["ProjectId"]), this.Request.Params["DeveloperId"]);
                    this.AllProjects.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Application successful!");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                }

                this.Response.Redirect("~/Projects/View");
            }
        }

        public IQueryable<Project> GetProjectsGridViewData()
        {
            return this.AllProjects.GetAll().OrderByDescending(pr => pr.DateCreated);
        }

        protected void OnDataBound(object sender, EventArgs eventArgs)
        {
            this.AllProjectsGridView.Columns[4].Visible = this.User.IsInRole("developer");
        }
    }
}