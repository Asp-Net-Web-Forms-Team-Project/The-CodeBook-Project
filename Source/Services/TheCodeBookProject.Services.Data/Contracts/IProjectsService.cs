namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;
    using TheCodeBookProject.Data.Models;

    public interface IProjectsService
    {
        IQueryable<Project> GetAll();

        IQueryable<Project> GetAllInEarlyStage();

        IQueryable<Project> GetByUserId(string userId);

        IQueryable<ProjectNotification> GetApplicationsSent(string userId);

        IQueryable<ProjectNotification> GetApplicationsReceived(string userId);

        IQueryable<ProjectNotification> GetInvitationsSent(string userId);

        IQueryable<ProjectNotification> GetInvitationsReceived(string userId);

        Project GetById(int id);

        void ApplyById(int projectId, string senderId);

        void Create(Project project);

        int SaveChanges();
    }
}
