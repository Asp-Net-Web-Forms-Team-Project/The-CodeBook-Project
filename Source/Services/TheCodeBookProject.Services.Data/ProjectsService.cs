namespace TheCodeBookProject.Services.Data
{
    using System.Linq;

    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;

    public class ProjectsService : IProjectsService
    {
        private readonly IRepository<Project> projects;

        public ProjectsService(IRepository<Project> projects)
        {
            this.projects = projects;
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

        public void ApplyById(int projectId, string senderId)
        {
            Project dbProject = this.GetById(projectId);
            if (dbProject == null)
            {
                return;
            }

            string receiverId = dbProject.CreatorId;
            var notification = new ProjectNotification
            {
                SenderId = senderId,
                ReceiverId = receiverId,
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
