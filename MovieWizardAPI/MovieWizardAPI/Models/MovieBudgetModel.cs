using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.Models
{
    public class MovieBudget
    {
        [Key]
        public int MovieBudgetId { get; set; }

        [Required]
        public decimal BudgetAmount { get; set; }

        [Required]
        public DateTime BudgetDate { get; set; }
    }
}
