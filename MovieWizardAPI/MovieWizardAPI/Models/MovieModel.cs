using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieWizardAPI.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(100)]
        public string MovieName { get; set; }

        [Required]
        public DateTime MovieReleaseDate { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        [Required]
        public int MovieBudgetId { get; set; }
        public MovieBudget MovieBudget { get; set; }

        [Required]
        public int MoviePriceId { get; set; }
        public MoviePrice MoviePrice { get; set; }

        public int? MovieRevenueId { get; set; }
        public MovieRevenue MovieRevenue { get; set; }

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        // Navigation property for many-to-many relationship with Actors
        public ICollection<Actor> Actors { get; set; }
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] MoviePoster { get; set; }
    }
}
