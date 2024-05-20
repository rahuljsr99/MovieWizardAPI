using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserDataModel
{
    [Key]
    public int UserId { get; set; }

    [Required, MaxLength(100)]
    public string UserName { get; set; }

    [Required, MaxLength(100)]
    public string Password { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    public byte[] ProfilePhoto { get; set; }

    [Required]
    public bool IsAdmin { get; set; }

    [Required]
    public bool IsUser { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [MaxLength(100)]
    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    [MaxLength(100)]
    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
