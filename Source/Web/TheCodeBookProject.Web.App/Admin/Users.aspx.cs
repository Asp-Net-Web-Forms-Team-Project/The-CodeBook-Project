namespace TheCodeBookProject.Web.App.Admin
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;

    using Data;
    using Data.Models;

    public partial class Users : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> UsersGridView_GetData()
        {
            var context = new TheCodeBookProjectDbContext();
            return context.Users.Include("MyCompany").OrderBy(u => u.Id);
        }

        public void UsersGridView_UpdateItem(string id)
        {
            var context = new TheCodeBookProjectDbContext();
            User user = context.Users.Find(id);

            if (user == null)
            {
                ModelState.AddModelError("", string.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(user);
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UsersGridView_DeleteItem(string id)
        {
            var context = new TheCodeBookProjectDbContext();
            User user = context.Users.Find(id);

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}