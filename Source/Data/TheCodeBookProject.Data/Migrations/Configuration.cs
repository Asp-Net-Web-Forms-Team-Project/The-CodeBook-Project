namespace TheCodeBookProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Helpers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class Configuration : DbMigrationsConfiguration<TheCodeBookProjectDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheCodeBookProjectDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var userStore = new UserStore<User>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userManager = new UserManager<User>(userStore);
            string adminUsername = "admin";

            if (userManager.FindByName(adminUsername) == null)
            {
                string adminRoleName = "admin";
                string developerRoleName = "developer";
                string businessRoleName = "businessman";

                var adminRole = new IdentityRole
                {
                    Name = adminRoleName
                };

                var developerRole = new IdentityRole
                {
                    Name = developerRoleName
                };

                var businessRole = new IdentityRole
                {
                    Name = businessRoleName
                };


                roleManager.Create(adminRole);
                roleManager.Create(developerRole);
                roleManager.Create(businessRole);

                var admin = new User
                {
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    UserName = adminUsername,
                    Email = "admin@codebook.com",
                    DateOfBirth = new DateTime(),
                    AboutMe = "The administrator of the web app",
                    ImageUrl = "~/Images/default.jpg"
                };
                
                string password = "123456";
                IdentityResult adminIdentityResult = userManager.Create(admin, password);
                User dbAdmin = userManager.FindByName(admin.UserName);
                userManager.AddToRole(dbAdmin.Id, adminRoleName);

                var userUtils = new UsersSeedHelper();

                for (int i = 0; i < 20; i++)
                {
                    User user = userUtils.GetUser();
                    user.UserName += i;

                    IdentityResult identityResult = userManager.Create(user, password);
                    if (identityResult.Succeeded)
                    {
                        User dbUser = userManager.FindByName(user.UserName);

                        if (i % 2 == 0)
                        {
                            userManager.AddToRole(dbUser.Id, developerRoleName);
                        }
                        else
                        {
                            userManager.AddToRole(dbUser.Id, businessRoleName);
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
