using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Entities;

namespace MovieWizardAPI.Data
{
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options): base(options)
        {
       
        }
        public DbSet<Movies> MovieNew { get; set; }
        public DbSet<UsersNew> UsersNew { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>().HasData(
                new Movies
                {
                    MovieId = 1,
                    MovieName = "Shrek",
                    MovieReleaseDate = DateTime.Now,
                    IMBDRating = 3
                }
                );
        }
    }
}
