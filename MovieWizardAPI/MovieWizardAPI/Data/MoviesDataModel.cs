using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using MovieWizardAPI.Data;

namespace MovieWizardAPI.Data
{
   
        public class Movies
        {
            [Key]
            public int MovieID { get; set; }

            [Required]
            [StringLength(100)]
            public string MovieName { get; set; }

            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }

            [Range(0, 10)]
            [Column(TypeName = "decimal(3,1)")]
            public decimal IMDBRating { get; set; }

            [ForeignKey("Director")]
            public int DirectorID { get; set; }

            public DateTime CreateDate { get; set; }

            [StringLength(100)]
            public string CreatedBy { get; set; }

            public DateTime? UpdateDate { get; set; }

            [StringLength(100)]
            public string UpdatedBy { get; set; }

            public bool IsActive { get; set; }

            public virtual Directors Director { get; set; }
        }
    }



