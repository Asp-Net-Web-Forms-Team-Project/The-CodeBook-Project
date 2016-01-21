﻿namespace TheCodeBookProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Project> projects;

        public User()
            : base()
        {
            this.projects = new HashSet<Project>();
        }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Range(14, 100)]
        public int Age { get; set; }

        public int Rating { get; set; }

        public int Votes { get; set; }

        [MaxLength(300)]
        public string AboutMe { get; set; }

        public int ProjectsCurrent { get; set; }

        public int ProjectsCompleted { get; set; }

        [MaxLength(100)]
        public string Knowledge { get; set; }

        [MaxLength(100)]
        public string Skills { get; set; }

        public Company MyCompany { get; set; }

        public ICollection<Project> Projects
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
