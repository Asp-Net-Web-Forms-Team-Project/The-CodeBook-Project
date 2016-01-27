namespace TheCodeBookProject.Data.Helpers
{
    using System;

    using Models;

    public class SeedHelper
    {
        private readonly Random random = new Random();
        private readonly string[] firstNames = { "John", "Pesho", "Gosho", "Stamat", "Mitko", "Vasko", "Lubcho", "Tosho", "Jane", "Jack" };
        private readonly string[] lastNames = { "Jones", "Petrov", "Ivanov", "Georgiev", "Dimitrov", "Smith", "Johnson", "Black", "Silver", "Brunson" };
        private readonly string[] knowledge = { "C#", "JavaScript", "Java", "Pyhton", "Visual Basic", "PHP", "HTML", "CSS", "Turbo Pascal", "SQL", "jQuery", "AngularJS", "NodeJS" };
        private readonly string[] skills = { "Project Management", "DB Management", "ASP.NET Web Forms", "MEAN", "ASP.NET MVC", "SPA", "Native Mobile Apps Development", "Hybrid Mobile Apps Development", "Windows Universal Apps" };
        private readonly string[] companyNamesFirstWords = { "Pro", "Soft", "Unlimited", "Net" };
        private readonly string[] companyNamesSecondWords = { "Solutions", "Logic", "Engineering", "Enterprise" };
        private readonly string[] companyTypes = { "Ltd.", "PLC", "Inc." };
        private readonly string[] projectNames = { "Cool project", "Not so cool project", "Andromeda", "Next Facebook", "Next Google", "Next BG Coder", "Next Best" };

        public User GetUser()
        {
            var user = new User
            {
                FirstName = this.GetStringItem(this.firstNames),
                LastName = this.GetStringItem(this.lastNames),
                Knowledge = this.GetStringItem(this.knowledge) + ", " + this.GetStringItem(this.knowledge),
                Skills = this.GetStringItem(this.skills) + ", " + this.GetStringItem(this.skills),
                DateOfBirth = new DateTime(),
                ImageUrl = "~/Images/default.jpg",
                Rating = random.Next(10, 51),
                Votes = 10
            };

            user.UserName = user.FirstName;
            user.AboutMe = $"I am {user.FirstName} and I know {user.Knowledge}.";

            return user;
        }

        public Company GetCompany()
        {
            var company = new Company
            {
                Name = this.GetStringItem(this.companyNamesFirstWords) + " " +
                        this.GetStringItem(this.companyNamesSecondWords) + " " +
                        this.GetStringItem(this.companyTypes),
                Rating = random.Next(10, 51),
                Votes = 10 
            };

            return company;
        }

        public Project GetProject()
        {
            var project = new Project
            {
                Name = this.GetCompany().Name + "'s " + this.GetStringItem(this.projectNames),
                Description = "The project's detailed description.",
                Status = ProjectStatus.EarlyStage,
                DevelopersNeeded = this.random.Next(1, 10),
                KnowledgeRequired = this.GetStringItem(this.knowledge) + ", " +
                                    this.GetStringItem(this.knowledge) + ", " +
                                    this.GetStringItem(this.knowledge),
                SkillsRequired = this.GetStringItem(this.skills) + ", " +
                                    this.GetStringItem(this.skills) + ", " +
                                    this.GetStringItem(this.skills),
                AverageMonetaryAwardPerDeveloper = this.random.Next(500, 50000)
            };

            return project;
        }

        private string GetStringItem(string[] options)
        {
            int index = this.random.Next(0, options.Length);
            string info = options[index];
            return info;
        }
    }
}
