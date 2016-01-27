namespace TheCodeBookProject.Services.Data
{
    using System.Linq;

    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;
    using TheCodeBookProject.Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<IdentityRole> roles;

        public UsersService(IRepository<User> users, IRepository<IdentityRole> roles)
        {
            this.users = users;
            this.roles = roles;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string userId)
        {
            return this.users.GetById(userId);
        }

        public IQueryable<User> GetAllUsersInRole(string roleName)
        {
            IdentityRole role = this.roles.All().SingleOrDefault(r => r.Name == roleName);
            string roleId = role.Id;
            return this.users.All().Where(u => u.Roles.Any(r => r.RoleId == roleId));
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
