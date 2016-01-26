namespace TheCodeBookProject.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TheCodeBookProjectDbContext : IdentityDbContext<User>, ITheCodeBookProjectDbContext
    {
        private const string DbConnectionName = "DefaultConnection";

        public TheCodeBookProjectDbContext()
            : base(DbConnectionName, throwIfV1Schema: false)
        {
        }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<ProjectNotification> Applications { get; set; }

        public static TheCodeBookProjectDbContext Create()
        {
            return new TheCodeBookProjectDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(value: 50);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
