namespace TheCodeBookProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Project> projects;
        private ICollection<ProjectNotification> projectNotificatons;

        public User()
            : base()
        {
            this.projects = new HashSet<Project>();
            this.projectNotificatons = new HashSet<ProjectNotification>();
        }

        public bool IsDeactivated { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public int Rating { get; set; }

        public int Votes { get; set; }

        [MaxLength(300)]
        public string AboutMe { get; set; }

        [MaxLength(100)]
        public string Knowledge { get; set; }

        [MaxLength(100)]
        public string Skills { get; set; }

        public int? MyCompanyId { get; set; }

        public virtual Company MyCompany { get; set; }

        [MaxLength(100)]
        public string ImageUrl { get; set; }

        public virtual ICollection<ProjectNotification> ProjectNotifications
        {
            get { return this.projectNotificatons; }
            set { this.projectNotificatons = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            ClaimsIdentity userIdentity = manager
                .CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
