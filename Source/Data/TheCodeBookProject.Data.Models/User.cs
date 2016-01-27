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
        private ICollection<Project> allProjects;
        private ICollection<ProjectNotification> invitations;
        private ICollection<ProjectNotification> applications;

        public User()
            : base()
        {
            this.allProjects = new HashSet<Project>();
            this.invitations = new HashSet<ProjectNotification>();
            this.applications = new HashSet<ProjectNotification>();
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

        public virtual ICollection<ProjectNotification> Invitations
        {
            get { return this.invitations; }
            set { this.invitations = value; }
        }

        public virtual ICollection<ProjectNotification> Applications
        {
            get { return this.applications; }
            set { this.applications = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.allProjects; }
            set { this.allProjects = value; }
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
