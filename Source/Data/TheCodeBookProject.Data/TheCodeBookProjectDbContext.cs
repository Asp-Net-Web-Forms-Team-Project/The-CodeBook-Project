namespace TheCodeBookProject.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TheCodeBookProjectDbContext : IdentityDbContext<User>
    {
        private const string DbConnectionName = "DefaultConnection";

        public TheCodeBookProjectDbContext()
            : base(DbConnectionName, throwIfV1Schema: false)
        {
        }

        public static TheCodeBookProjectDbContext Create()
        {
            return new TheCodeBookProjectDbContext();
        }
    }
}
