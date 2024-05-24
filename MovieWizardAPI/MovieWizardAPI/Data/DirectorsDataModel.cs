using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.Data
{
    public class Directors
    {
        [Key]
        public int DirectorID { get; set; }

        [Required]
        [StringLength(100)]
        public string DirectorName { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public bool IsActive { get; set; }
    
}
}
