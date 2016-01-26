namespace TheCodeBookProject.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface ITheCodeBookProjectDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Company> Companies { get; set; }

        IDbSet<ProjectNotification> Applications { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
