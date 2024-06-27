using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWizardAPI.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ActorName { get; set; }
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }

        // Additional properties
        public string Biography { get; set; }

        public string Awards { get; set; }

        public string SocialMediaProfile { get; set; }
        // Navigation property for many-to-many relationship with Movies

        public ICollection<MovieModel> Movies { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        // Add other properties as needed (e.g., DateOfBirth, Nationality, etc.)
    }
}
