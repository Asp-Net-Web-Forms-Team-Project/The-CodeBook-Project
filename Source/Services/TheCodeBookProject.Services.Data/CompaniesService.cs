namespace TheCodeBookProject.Services.Data
{
    using System.Linq;

    using Contracts;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Data.Repositories.Contracts;

    public class CompaniesService : ICompaniesService
    {
        private readonly IRepository<Company> companies;

        public CompaniesService(IRepository<Company> companies)
        {
            this.companies = companies;
        }

        public Company GetByName(string name)
        {
            return this.companies.All().FirstOrDefault(c => c.Name == name);
        }

        public void CreateCompany(Company company)
        {
            this.companies.Add(company);
        }

        public int SaveChanges()
        {
            return this.companies.SaveChanges();
        }
    }
}
