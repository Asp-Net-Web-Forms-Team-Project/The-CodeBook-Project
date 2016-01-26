namespace TheCodeBookProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Project
    {
        private ICollection<User> developers;
        private ICollection<ProjectNotification> projectNotifications;

        public Project()
        {
            this.developers = new HashSet<User>();
            this.projectNotifications = new HashSet<ProjectNotification>();
            this.DateCreated = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public int OrganizerId { get; set; }

        public virtual Company Organizer { get; set; }

        public ProjectStatus Status { get; set; }
        
        public int DevelopersNeeded { get; set; }

        [Required]
        [MaxLength(100)]
        public string KnowledgeRequired { get; set; }

        [Required]
        [MaxLength(100)]
        public string SkillsRequired { get; set; }

        [Column(TypeName = "Money")]
        public decimal AverageMonetaryAwardPerDeveloper { get; set; }

        public virtual ICollection<ProjectNotification> ProjectNotifications
        {
            get { return this.projectNotifications; }
            set { this.projectNotifications = value; }
        }

        public virtual ICollection<User> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }
    }
}
