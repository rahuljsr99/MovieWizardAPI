using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.Models
{
    public class MovieRevenue
    {
        [Key]
        public int MovieRevenueId { get; set; }

        [Required]
        public decimal RevenueAmount { get; set; }

        [Required]
        public DateTime RevenueDate { get; set; }
    }
}
