namespace TheCodeBookProject.Web.App.Projects
{
    using System;
    using System.Collections.Generic;
    using Services.Data.Contracts;
    using System.Web.UI.WebControls;
    using System.Web.UI;

    using Ninject;
    using Data.Models;
    using Microsoft.AspNet.Identity;

    public partial class Create : Page
    {
        [Inject]
        public IProjectsService Projects { get; set; }

        [Inject]
        public ICompaniesService Companies { get; set; }

        [Inject]
        public IUsersService Users { get; set; }

        public Company UserCompany { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = this.User.Identity.GetUserId();
            User user = this.Users.GetById(userId);
            this.UserCompany = user.MyCompany;
        }

        protected void SubmitClick(object sender, EventArgs e)
        {
            var project = new Project
            {
                Name = this.Name.Text,
                Description = this.Description.Text,
                DateCreated = DateTime.UtcNow,
                AverageMonetaryAwardPerDeveloper = int.Parse(this.Reward.Text),
                DevelopersNeeded = int.Parse(this.DevsNeeded.Text)
            };

            if (this.UserCompany == null)
            {
                string companyName = this.Company.Text;
                Company dbCompany = this.Companies.GetByName(companyName);
                if (dbCompany == null)
                {
                    dbCompany = new Company
                    {
                        Name = companyName
                    };

                    string userId = this.User.Identity.GetUserId();
                    User user = this.Users.GetById(userId);
                    user.MyCompany = dbCompany;
                }

                project.Organizer = dbCompany;
            }
            else
            {
                project.Organizer = this.UserCompany;
            }

            var skillsRequirements = new List<string>();

            foreach (ListItem item in this.DeveloperSkillsRequiredListBox.Items)
            {
                if (item.Selected)
                {
                    skillsRequirements.Add(item.Value);
                }
            }

            var knowledgeRequirements = new List<string>();

            foreach (ListItem item in this.DeveloperKnowledgeRequiredListBox.Items)
            {
                if (item.Selected)
                {
                    knowledgeRequirements.Add(item.Value);
                }
            }

            project.SkillsRequired = string.Join(", ", skillsRequirements);
            project.KnowledgeRequired = string.Join(", ", knowledgeRequirements);

            this.Projects.Create(project);
            this.Projects.SaveChanges();
        }
    }
}