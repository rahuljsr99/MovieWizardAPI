using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.Models
{
    public class MoviePrice
    {
        [Key]
        public int MoviePriceId { get; set; }

        [Required]
        public decimal PriceAmount { get; set; }

        [Required]
        public DateTime PriceDate { get; set; }
    }
}
