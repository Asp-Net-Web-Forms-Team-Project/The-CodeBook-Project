namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;
    using TheCodeBookProject.Data.Models;

    public interface IProjectsService
    {
        IQueryable<Project> GetAll();

        IQueryable<Project> GetByUserId(string userId);

        int SaveChanges();
    }
}
