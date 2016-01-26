namespace TheCodeBookProject.Web.App.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    
    using Data.Models;
    using Ninject;
    using Services.Data.Contracts;

    public partial class Users : Page
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> UsersGridView_GetData()
        {
            return this.UsersService.GetAll();
        }

        public void UsersGridView_UpdateItem(string id)
        {
            User user = this.UsersService.GetById(id);

            if (user == null)
            {
                this.ModelState.AddModelError("", string.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(user);
            if (this.ModelState.IsValid)
            {
                this.UsersService.Update(user);
                this.UsersService.SaveChanges();
            }
        }

        public void UsersGridView_DeleteItem(string id)
        {
        }
    }
}