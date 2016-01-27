namespace TheCodeBookProject.Web.App.Projects
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Details : Page
    {
        [Inject]
        public IProjectsService Projects { get; set; }

        public bool HasDevelopers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int projectId = -1;
            int.TryParse(this.Request.QueryString["ProjectId"], out projectId);
            if (projectId != -1)
            {
                var list = new ArrayList();
                Project project = this.Projects.GetById(projectId);

                string userId = this.User.Identity.GetUserId();
                bool hasApplied = project.ProjectNotifications.Any(n => n.DeveloperId == userId);
                if(hasApplied)
                {
                    this.ApplyButton.CssClass = "btn btn-primary btn-raised disabled";
                    this.ApplyButton.Enabled = false;
                }

                this.HasDevelopers = project.Developers.Count > 0;
                list.Add(project);

                this.ProjectDetailsView.DataSource = list;
                this.ProjectDetailsView.DataBind();
            }
            else
            {
                this.Response.Redirect("/Home");
            }
        }

        public IQueryable<User> GetProjectDevelopersGridViewData()
        {
            int projectId = int.Parse(this.Request.QueryString["ProjectId"]);
            return this.Projects.GetById(projectId).Developers.AsQueryable();
        }

        protected void ApplyButtonClick(object sender, EventArgs e)
        {
            string projectId = this.Request.QueryString["ProjectId"];
            string userId = this.User.Identity.GetUserId();
            this.Response.Redirect("~/Projects/View?ProjectId=" + projectId + "&Apply=true&DeveloperId=" + userId);
        }
    }
}