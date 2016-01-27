namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;
    using TheCodeBookProject.Data.Models;

    public interface IProjectsService
    {
        IQueryable<Project> GetAll();

        IQueryable<Project> GetAllInEarlyStage();

        IQueryable<Project> GetByUserId(string userId);

        Project GetById(int id);

        void ApplyById(int id, string devId);

        void Create(Project project);

        int SaveChanges();
    }
}
