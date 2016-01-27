namespace TheCodeBookProject.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TheCodeBookProjectDbContext : IdentityDbContext<User>, ITheCodeBookProjectDbContext
    {
        private const string DbConnectionName = "TheCodeBookProjectDbConnection";

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

            modelBuilder
                .Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(value: 50);

            modelBuilder
                .Entity<ProjectNotification>()
                .HasRequired(n => n.Sender)
                .WithMany(u => u.Invitations);
            modelBuilder
                .Entity<ProjectNotification>()
                .HasRequired(n => n.Receiver)
                .WithMany(u => u.Applications);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
