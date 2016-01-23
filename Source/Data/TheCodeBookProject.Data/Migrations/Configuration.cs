namespace TheCodeBookProject.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using Models;
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Data.Entity;

    public class Configuration : DbMigrationsConfiguration<TheCodeBookProjectDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TheCodeBookProjectDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var userStore = new UserStore<User>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userManager = new UserManager<User>(userStore);

            string adminRoleName = "admin";
            if (!roleManager.RoleExists(adminRoleName))
            {
                var adminRole = new IdentityRole
                {
                    Name = adminRoleName
                };

                roleManager.Create(adminRole);
            }

            var admin = new User
            {
                FirstName = "Administrator",
                LastName = "Administrator",
                UserName = "admin",
                Email = "admin@codebook.com",
                Age = 25,
                AboutMe = "The administrator of the web app",
            };
            
            if(userManager.FindByName(admin.UserName) == null)
            {
                string adminPassword = "123456";
                IdentityResult result = userManager.Create(admin, adminPassword);
                User dbAdmin = userManager.FindByName(admin.UserName);
                userManager.AddToRole(dbAdmin.Id, adminRoleName);
            }

            context.SaveChanges();
        }
    }
}
