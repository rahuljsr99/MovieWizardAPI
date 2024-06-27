using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Data
{
    public class MovieBudgetDbContext : DbContext
    {
        public MovieBudgetDbContext(DbContextOptions<MovieBudgetDbContext> options) : base(options)
        {
        }

        public DbSet<MovieBudget> MovieBudgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieBudget>().ToTable("MovieBudgets");
            modelBuilder.Entity<MovieBudget>()
               .Property(d => d.BudgetDate)
               .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
