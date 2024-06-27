using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWizardAPI.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public int DirectorAge { get; set; }
        public string DirectorLocation { get; set; }
        public string DirectorDescription { get; set; }
        public bool IsActive {get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] ProfilePicture { get; set; }
    }

}
