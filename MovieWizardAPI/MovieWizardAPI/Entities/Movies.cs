using System.ComponentModel.DataAnnotations;

namespace MovieWizardAPI.Entities
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public DateTime MovieReleaseDate { get; set; }

        public float IMBDRating { get; set; }

    }
}
