using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Data
{
    public class MoviePriceDbContext : DbContext
    {
        public MoviePriceDbContext(DbContextOptions<MoviePriceDbContext> options) : base(options)
        {
        }

        public DbSet<MoviePrice> MovieRevenues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviePrice>().ToTable("MoviePrices");
            modelBuilder.Entity<MoviePrice>()
               .Property(d => d.PriceDate)
               .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
