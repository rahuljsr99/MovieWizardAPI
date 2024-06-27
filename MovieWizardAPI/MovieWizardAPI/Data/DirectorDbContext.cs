using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Data
{
    public class DirectorDbContext : DbContext
    {
        public DirectorDbContext(DbContextOptions<DirectorDbContext> options) : base(options)
        {

        }

        public DbSet<Director> Directors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().ToTable("Directors");

            modelBuilder.Entity<Director>()
                .Property(d => d.CreatedTime)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
