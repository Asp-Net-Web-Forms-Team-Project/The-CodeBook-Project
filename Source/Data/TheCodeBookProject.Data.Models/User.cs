namespace TheCodeBookProject.Data.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            ClaimsIdentity userIdentity = manager
                .CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
