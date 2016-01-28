namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;

    using TheCodeBookProject.Data.Models;

    public interface IProjectNotificationsService
    {
        ProjectNotification GetById(int notificationId);

        void Update(ProjectNotification notification);

        int SaveChanges();
    }
}
