namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;
    using TheCodeBookProject.Data.Models;

    public interface IProjectsService
    {
        IQueryable<Project> GetAll();

        IQueryable<Project> GetByUserId(string userId);

        IQueryable<Project> GetById(int id);

        void ApplyById(int id, string devId);

        int SaveChanges();
    }
}
