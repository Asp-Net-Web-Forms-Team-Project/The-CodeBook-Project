namespace TheCodeBookProject.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<TheCodeBookProjectDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TheCodeBookProjectDbContext context)
        {
            
        }
    }
}
