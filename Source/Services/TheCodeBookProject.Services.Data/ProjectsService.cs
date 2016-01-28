namespace TheCodeBookProject.Services.Data
{
    using System.Linq;

    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<Project> projects;
        private readonly IRepository<User> users;

        public ProjectsService(IRepository<Project> projects, IRepository<User> users)
        {
            this.projects = projects;
            this.users = users;
        }

        public IQueryable<Project> GetAll()
        {
            return this.projects.All();
        }

        public IQueryable<Project> GetAllInEarlyStage()
        {
            return this.projects.All().Where(p => p.DevelopersNeeded > p.Developers.Count);
        }

        public IQueryable<Project> GetByUserId(string userId)
        {
            return this.projects.All().Where(p => p.Developers.Any(d => d.Id == userId));
        }

        public Project GetById(int id)
        {
            return this.projects.All().SingleOrDefault(p => p.Id == id);
        }

        public IQueryable<ProjectNotification> GetApplicationsSent(string userId)
        {
            return this.GetAll()
                .SelectMany(p => p.ProjectNotifications.Where(n => p.CreatorId != userId && 
                                                                   n.SenderId ==  userId && 
                                                                   n.Status == ProjectNotificationStatus.Pending));
        }

        public IQueryable<ProjectNotification> GetApplicationsReceived(string userId)
        {
            return this.GetByUserId(userId)
                .SelectMany(p => p.ProjectNotifications.Where(n => p.CreatorId == userId && 
                                                                   n.ReceiverId ==  userId && 
                                                                   n.Status == ProjectNotificationStatus.Pending));
        }
        
        public IQueryable<ProjectNotification> GetInvitationsSent(string userId)
        {
            return this.GetByUserId(userId).SelectMany(p => p.ProjectNotifications.Where(n => p.CreatorId == userId && 
                                                                                              n.SenderId == userId && 
                                                                                              n.Status == ProjectNotificationStatus.Pending));
        }

        public IQueryable<ProjectNotification> GetInvitationsReceived(string userId)
        {
            return this.GetAll().SelectMany(p => p.ProjectNotifications.Where(n => p.CreatorId != userId && 
                                                                                   n.ReceiverId == userId && 
                                                                                   n.Status == ProjectNotificationStatus.Pending));
        }

        public void ApplyById(int projectId, string senderId)
        {
            Project dbProject = this.GetById(projectId);
            if (dbProject == null)
            {
                return;
            }

            string receiverId = dbProject.CreatorId;

            User sender = this.users.GetById(senderId);
            User receiver = this.users.GetById(receiverId);

            var notification = new ProjectNotification
            {
                Sender = sender,
                Receiver = receiver,
                ProjectId = projectId
            };

            dbProject.ProjectNotifications.Add(notification);
        }

        public void Create(Project project)
        {
            this.projects.Add(project);
        }

        public int SaveChanges()
        {
            return this.projects.SaveChanges();
        }
    }
}
