namespace TheCodeBookProject.Web.App.Developers
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ninject;

    using TheCodeBookProject.Data;
    using TheCodeBookProject.Data.Models;
    using TheCodeBookProject.Services.Data.Contracts;

    public partial class View : System.Web.UI.Page
    {
        [Inject]
        public IUsersService Users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> AllDevelopersGridView_GetData()
        {
            var userStore = new UserStore<User>(new TheCodeBookProjectDbContext());
            var userManager = new UserManager<User>(userStore);

            return this.Users
               .GetAll()
               .ToList()
               .Where(u => userManager.IsInRole(u.Id, "developer"))
               .AsQueryable();
        }
    }
}