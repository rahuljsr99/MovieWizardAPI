using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public byte[]? ProfilePhoto { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public bool IsUser { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
