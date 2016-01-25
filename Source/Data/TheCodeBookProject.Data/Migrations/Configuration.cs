namespace TheCodeBookProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Helpers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
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
                string businessRoleName = "business";

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
                    ImageUrl = "~/Images/admin.jpg",
                    Skills= "N/A",
                    Knowledge = "N/A",
                    Rating = 5,
                    Votes = 1
                };
                
                string password = "123456";
                IdentityResult adminIdentityResult = userManager.Create(admin, password);
                User dbAdmin = userManager.FindByName(admin.UserName);
                userManager.AddToRole(dbAdmin.Id, adminRoleName);

                var seedUtils = new SeedHelper();
                var devs = new List<User>();

                for (int i = 0; i < 20; i++)
                {
                    User user = seedUtils.GetUser();
                    user.UserName += i;

                    IdentityResult identityResult = userManager.Create(user, password);
                    if (identityResult.Succeeded)
                    {
                        User dbUser = userManager.FindByName(user.UserName);

                        if (i % 2 == 0)
                        {
                            devs.Add(dbUser);
                            userManager.AddToRole(dbUser.Id, developerRoleName);
                        }
                        else
                        {
                            Company company = seedUtils.GetCompany();
                            Project project = seedUtils.GetProject();
                            project.Organizer = company;
                            company.Projects.Add(project);
                            dbUser.MyCompany = company;
                            project.Developers.Add(devs.Last());
                            userManager.AddToRole(dbUser.Id, businessRoleName);
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
