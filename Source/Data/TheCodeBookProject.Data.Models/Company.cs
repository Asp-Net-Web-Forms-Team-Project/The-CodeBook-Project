namespace TheCodeBookProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        private ICollection<User> employees;
        private ICollection<Project> projects;

        public Company()
        {
            this.employees = new HashSet<User>();
            this.projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Rating { get; set; }
        
        public int Votes { get; set; }

        public ICollection<User> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }
        public ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

    }
}
