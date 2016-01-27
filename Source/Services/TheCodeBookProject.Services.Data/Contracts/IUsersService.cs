namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;
    using TheCodeBookProject.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        void Update(User updatedUser);

        User GetById(string userId);

        IQueryable<User> GetAllUsersInRole(string roleName);

        int SaveChanges();
    }
}
