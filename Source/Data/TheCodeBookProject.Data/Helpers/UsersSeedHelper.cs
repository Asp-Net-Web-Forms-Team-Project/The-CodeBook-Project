namespace TheCodeBookProject.Data.Helpers
{
    using System;

    using Models;

    public class UsersSeedHelper
    {
        private readonly Random random = new Random();
        private readonly string[] firstNames = { "John", "Pesho", "Gosho", "Stamat", "Mitko", "Vasko", "Lubcho", "Tosho", "Jane", "Jack" };
        private readonly string[] lastNames = { "Jones", "Petrov", "Ivanov", "Georgiev", "Dimitrov", "Smith", "Johnson", "Black", "Silver", "Brunson" };
        private readonly string[] knowledge = { "C#", "JavaScript", "Java", "Pyhton", "Visual Basic", "PHP", "HTML", "CSS", "Turbo Pascal", "SQL", "jQuery", "AngularJS", "node" };
        private readonly string[] skills = { "Project Management", "DB Management", "Web Forms", "MEAN", "ASP.NET MVC", "SPA", "Native Mobile Apps Development", "Hybrid Mobile Apps Development", "Windows Universal Apps" };

        public User GetUser()
        {
            var user = new Models.User
            {
                FirstName = this.GetStringItem(this.firstNames),
                LastName = this.GetStringItem(this.lastNames),
                Knowledge = this.GetStringItem(this.knowledge) + ", " + this.GetStringItem(this.knowledge),
                Skills = this.GetStringItem(this.skills) + ", " + this.GetStringItem(this.skills),
                DateOfBirth = new DateTime(),
                ImageUrl = "~/Images/default.jpg"
            };

            user.UserName = user.FirstName;
            user.AboutMe = $"I am {user.FirstName} and I know {user.Knowledge}.";

            return user;
        }

        private string GetStringItem(string[] options)
        {
            int index = this.random.Next(0, options.Length);
            string info = options[index];
            return info;
        }
    }
}
