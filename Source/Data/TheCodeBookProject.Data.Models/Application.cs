namespace TheCodeBookProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Application
    {
        public int Id { get; set; }

        [Required]
        public User FromUser { get; set; }

        [Required]
        public Project ForProject { get; set; }

        public ApplicatonStatus Status { get; set; }
    }
}
