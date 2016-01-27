namespace TheCodeBookProject.Services.Data.Contracts
{
    using System.Linq;
    using TheCodeBookProject.Data.Models;

    public interface ICompaniesService
    {
        Company GetByName(string name);

        void CreateCompany(Company company);

        int SaveChanges();
    }
}
