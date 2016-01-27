namespace TheCodeBookProject.Web.App.Developers
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Data.Models;
    using Ninject;
    using Services.Data.Contracts;

    public partial class View : Page
    {
        [Inject]
        public IUsersService Users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> AllDevelopersGridView_GetData()
        {
            return this.Users.GetAllUsersInRole("developer").OrderBy(u => u.Id);
        }
    }
}