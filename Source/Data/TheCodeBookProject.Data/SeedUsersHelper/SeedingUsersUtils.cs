namespace TheCodeBookProject.Data.SeedUsersHelper
{
    using System;
    public class SeedingUsersUtils
    {
        private Random rnd = new Random();
        private static readonly string[] FirstNames = { "John", "Pesho", "Gosho", "Stamat", "Mitko", "Vasko", "Lubcho", "Tosho", "Jane", "Jack" };
        private static readonly string[] LastNames = { "Jones", "Petrov", "Ivanov", "Georgiev", "Dimitrov", "Smith", "Johnson", "Black", "Silver", "Brunson" };
        private static readonly string[] Knowledge = { "C#", "JavaScript", "Java", "Pyhton", "Visual Basic", "PHP", "HTML", "CSS", "Turbo Pascal", "SQL", "jQuery", "AngularJS", "node" };
        private static readonly string[] Skills = { "Project Management", "DB Management", "Web Forms", "MEAN", "ASP.NET MVC", "SPA", "Native Mobile Apps Development", "Hybrid Mobile Apps Development", "Windows Universal Apps" };

        public Models.User GetUser()
        {
            var user = new Models.User
            {
                FirstName = GetStringItem(FirstNames),
                LastName = GetStringItem(LastNames),
                Knowledge = GetStringItem(Knowledge) + ", " + GetStringItem(Knowledge),
                Skills = GetStringItem(Skills) + ", " + GetStringItem(Skills),
                Age = rnd.Next(20, 100),
                ImageUrl = "~/Images/default.jpg"
            };

            user.UserName = user.FirstName;
            user.AboutMe = $"I am {user.FirstName} and I know {user.Knowledge}.";

            return user;
        }

        private string GetStringItem(string[] options)
        {
            int index = this.rnd.Next(0, options.Length);
            string info = options[index];
            return info;
        }
    }
}
