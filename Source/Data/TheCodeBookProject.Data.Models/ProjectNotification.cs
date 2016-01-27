namespace TheCodeBookProject.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectNotification
    {
        public int Id { get; set; }

        [Required]
        public string DeveloperId { get; set; }
        
        public User Developer { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public ProjectNotificationStatus Status { get; set; }

        public ProjectNotificationType Type { get; set; }
    }
}
