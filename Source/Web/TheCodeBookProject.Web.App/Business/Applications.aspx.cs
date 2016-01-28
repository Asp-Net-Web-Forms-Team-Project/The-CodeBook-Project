namespace TheCodeBookProject.Web.App.Business
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Applications : Page
    {
        [Inject]
        public IProjectsService Projects { get; set; }

        [Inject]
        public IUsersService Users { get; set; }

        [Inject]
        public IProjectNotificationsService ProjectNotifications { get; set; }

        public bool HasApplicationsSent { get; set; }

        public bool HasApplicationsReceived { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["Accept"] != null)
            {
                bool accepts = bool.Parse(this.Request.QueryString["Accept"]);

                int notificationId = int.Parse(this.Request.QueryString["ApplicationId"]);
                ProjectNotification notification = this.ProjectNotifications.GetById(notificationId);

                if (accepts)
                {
                    notification.Status = ProjectNotificationStatus.Accepted;
                    this.ProjectNotifications.SaveChanges();

                    int projectId = int.Parse(this.Request.QueryString["ProjectId"]);
                    string userId = this.Request.QueryString["UserId"];

                    Project project = this.Projects.GetById(projectId);
                    User user = this.Users.GetById(userId);

                    project.Developers.Add(user);
                    this.Projects.SaveChanges();
                }
                else
                {
                    notification.Status = ProjectNotificationStatus.Declined;
                    this.ProjectNotifications.SaveChanges();
                }

                this.Response.Redirect("/Business/Applications");
            }
        }

        public IQueryable<ProjectNotification> GetSentApplications()
        {
            string userId = this.User.Identity.GetUserId();
            IQueryable<ProjectNotification> sent = this.Projects.GetApplicationsSent(userId);
            this.HasApplicationsSent = sent.Count() > 0;

            return sent;
        }

        public IQueryable<ProjectNotification> GetReceivedApplications()
        {
            string userId = this.User.Identity.GetUserId();
            IQueryable<ProjectNotification> received = this.Projects.GetApplicationsReceived(userId);
            this.HasApplicationsReceived = received.Count() > 0;

            return received;
        }
    }
}