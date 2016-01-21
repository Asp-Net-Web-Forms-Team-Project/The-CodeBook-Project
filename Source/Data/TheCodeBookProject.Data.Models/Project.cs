namespace TheCodeBookProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Project
    {
        private ICollection<User> developers;

        public Project()
        {
            this.developers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public Company Organizer { get; set; }

        public ICollection<User> Developers
        {
            get { return this.developers; }
            set { this.developers = value; }
        }

        public int DevelopersNeeded { get; set; }

        [Required]
        [MaxLength(100)]
        public string KnowledgeRequired { get; set; }

        [Required]
        [MaxLength(100)]
        public string SkillsRequired { get; set; }

        [Column(TypeName = "Money")]
        public decimal AverageSalaryPerDeveloper { get; set; }
    }
}
