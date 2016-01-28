namespace TheCodeBookProject.Web.App.Account
{
    using System;
    using System.Collections;
    using System.Web.UI;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Ninject;
    using Services.Data.Contracts;

    public partial class UserDetails : MasterPage
    {
        [Inject]
        public IUsersService Users { get; set; }

        public User DbUser { get; set; }

        public bool IsMe { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = this.Request.QueryString["UserId"];
            if (userId == null)
            {
                userId = this.Context.User.Identity.GetUserId();
            }

            this.DbUser = this.Users.GetById(userId);

            this.IsMe = this.DbUser.Id == userId;

            var list = new ArrayList();
            list.Add(this.DbUser);

            this.UserDetailsView.DataSource = list;
            this.UserDetailsView.DataBind();
            this.UserDetailsView.Rows[4].Cells[1].Text = this.DbUser.DateOfBirth.Date.ToLongDateString();
        }

        protected void Page_PreRender()
        {
            this.RatingVisualizer.RatingSum = this.DbUser.Rating;
            this.RatingVisualizer.VotesCount = this.DbUser.Votes;
        }
    }
}