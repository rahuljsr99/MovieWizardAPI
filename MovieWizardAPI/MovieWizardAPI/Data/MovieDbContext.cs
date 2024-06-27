using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<MovieModel> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieModel>().ToTable("Movies");

            // Configure the relationships
            modelBuilder.Entity<MovieModel>()
                .HasOne(m => m.Director)
                .WithMany()
                .HasForeignKey(m => m.DirectorId);

            modelBuilder.Entity<MovieModel>()
                .HasOne(m => m.MovieBudget)
                .WithMany()
                .HasForeignKey(m => m.MovieBudgetId);

            modelBuilder.Entity<MovieModel>()
                .HasOne(m => m.MoviePrice)
                .WithMany()
                .HasForeignKey(m => m.MoviePriceId);

            modelBuilder.Entity<MovieModel>()
                .HasOne(m => m.MovieRevenue)
                .WithMany()
                .HasForeignKey(m => m.MovieRevenueId);

            // Configure the many-to-many relationship with Actors
            modelBuilder.Entity<MovieModel>()
                .HasMany(m => m.Actors)
                .WithMany("Movies");

            base.OnModelCreating(modelBuilder);
        }
    }
}
