namespace TheCodeBookProject.Web.App.Developers
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
        public IProjectsService Projects { get; set; }

        [Inject]
        public IUsersService Users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.Request.QueryString["Invite"] != null && !this.IsPostBack)
            {
                string businessId = this.Request.QueryString["BusinessId"];
                string developerId = this.Request.QueryString["DeveloperId"];
                string projectId = this.Request.QueryString["ProjectId"];
                if (businessId != null && developerId != null && projectId != null)
                {
                    Project currentProject = this.Projects.GetById(int.Parse(projectId));
                    if (currentProject != null && currentProject.ProjectNotifications.Any(x => x.ReceiverId == this.Request.Params["DeveloperId"] && x.ProjectId == int.Parse(projectId)))
                    {
                        ErrorSuccessNotifier.AddErrorMessage("You have already invited this person for this project.");
                    }
                    else
                    {
                        this.Projects.InviteById(int.Parse(projectId), developerId);
                        this.Projects.SaveChanges();
                        ErrorSuccessNotifier.AddSuccessMessage("Invitation successful!");
                    }

                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    this.Response.Redirect("/Developers/View");
                }
            }
        }

        public IQueryable<User> AllDevelopersGridView_GetData()
        {
            return this.Users.GetAllUsersInRole("developer").OrderBy(u => u.Id);
        }

        protected void OnDataBound(object sender, EventArgs eventArgs)
        {
            this.AllDevelopersGridView.Columns[6].Visible = this.Request.QueryString["Invite"] != null &&
                                                            this.Request.QueryString["BusinessId"] != null &&
                                                            this.Request.QueryString["ProjectId"] != null;
        }
    }
}