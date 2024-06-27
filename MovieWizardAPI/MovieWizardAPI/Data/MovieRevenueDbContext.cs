using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Data
{
    public class MovieRevenueDbContext : DbContext
    {
        public MovieRevenueDbContext(DbContextOptions<MovieRevenueDbContext> options) : base(options)
        {
        }

        public DbSet<MovieRevenue> MovieRevenues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieRevenue>().ToTable("MovieRevenues");
            modelBuilder.Entity<MovieRevenue>()
               .Property(d => d.RevenueDate)
               .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
