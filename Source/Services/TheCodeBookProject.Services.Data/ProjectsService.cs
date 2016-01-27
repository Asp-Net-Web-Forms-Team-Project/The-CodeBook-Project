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

        public IQueryable<Project> GetById(int id)
        {
            return this.projects.All().Where(p => p.Id == id);
        }

        public void ApplyById(int id, string devId)
        {
            var notification = new ProjectNotification
                                   {
                                        DeveloperId = devId,
                                        ProjectId = id
                                   };
            var firstOrDefault = this.GetById(id).FirstOrDefault();
            firstOrDefault?.ProjectNotifications.Add(notification);
        }

        public int SaveChanges()
        {
            return this.projects.SaveChanges();
        }
    }
}
