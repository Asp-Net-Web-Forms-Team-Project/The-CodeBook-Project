namespace TheCodeBookProject.Services.Data
{
    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;

    public class ProjectNotificationsService : IProjectNotificationsService
    {
        private IRepository<ProjectNotification> notifications;

        public ProjectNotificationsService(IRepository<ProjectNotification> notifications)
        {
            this.notifications = notifications;
        }

        public ProjectNotification GetById(int notificationId)
        {
            return this.notifications.GetById(notificationId);
        }

        public void Update(ProjectNotification notification)
        {
            this.notifications.Update(notification);
        }

        public int SaveChanges()
        {
            return this.notifications.SaveChanges();
        }
    }
}
