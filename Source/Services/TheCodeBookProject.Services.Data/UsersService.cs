namespace TheCodeBookProject.Services.Data
{
    using System.Linq;

    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string userId)
        {
            return this.users.GetById(userId);
        }

        public void Update(User updatedUser)
        {
            this.users.Update(updatedUser);
        }

        public int SaveChanges()
        {
            return this.users.SaveChanges();
        }
    }
}
