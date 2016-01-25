using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCodeBookProject.Data;

namespace TheCodeBookProject.Web.App.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TheCodeBookProject.Data.Models.User> gvUsers_GetData()
        {
            var context = new TheCodeBookProjectDbContext();

            return context.Users.Include("MyCompany").OrderBy(u => u.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvUsers_UpdateItem(string id)
        {
            var context = new TheCodeBookProjectDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (user == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(user);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvUsers_DeleteItem(string id)
        {
            var context = new TheCodeBookProjectDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user != null)
            {
                try
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}