namespace TheCodeBookProject.Web.App.Business
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Invitations : Page
    {
        [Inject]
        public IProjectNotificationsService ProjectNotifications { get; set; }

        [Inject]
        public IProjectsService Projects { get; set; }

        [Inject]
        public IUsersService Users { get; set; }

        public bool HasInvitationsReceived { get; set; }

        public bool HasInvitationsSent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["Accept"] != null)
            {
                bool accepts = bool.Parse(this.Request.QueryString["Accept"]);

                int notificationId = int.Parse(this.Request.QueryString["InvitationId"]);
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

                this.Response.Redirect("/Business/Invitations");
            }
        }

        public IQueryable<ProjectNotification> GetReceivedInvitations()
        {
            string userId = this.User.Identity.GetUserId();
            IQueryable<ProjectNotification> received = this.Projects.GetInvitationsReceived(userId);
            this.HasInvitationsReceived = received.Count() > 0;

            return received;
        }

        public IQueryable<ProjectNotification> GetSentInvitations()
        {
            string userId = this.User.Identity.GetUserId();
            IQueryable<ProjectNotification> sent = this.Projects.GetInvitationsSent(userId);
            this.HasInvitationsSent = sent.Count() > 0;

            return sent;
        }
    }
}