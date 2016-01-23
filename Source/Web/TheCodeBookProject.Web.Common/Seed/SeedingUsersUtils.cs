namespace TheCodeBookProject.Web.Common.Seed
{
    using System;
    public class SeedingUsersUtils
    {
        private Random rnd = new Random();
        private static readonly string[] FirstNames = { "John", "Pesho", "Gosho", "Stamat", "Mitko", "Vasko", "Lubcho", "Tosho", "Jane", "Jack" };
        private static readonly string[] LastNames = { "Jones", "Petrov", "Ivanov", "Georgiev", "Dimitrov", "Smith", "Johnson", "Black", "Silver", "Brunson" };
        private static readonly string[] Knowledge = { "C#", "JavaScript", "Java", "Pyhton", "Visual Basic", "PHP", "HTML", "CSS", "Turbo Pascal", "SQL", "jQuery", "AngularJS", "node"};
        private static readonly string[] Skills = { "Project Management", "DB Management", "Web Forms", "MEAN", "ASP.NET MVC", "SPA", "Native Mobile Apps Development", "Hybrid Mobile Apps Development", "Windows Universal Apps" };

        public SeedingUsersUtils()
        {

        }

        private string GetStringItem(string[] names)
        {
            int index = this.rnd.Next(0, names.Length);
            string name = names[index];
            return name;
        }


    }
}
