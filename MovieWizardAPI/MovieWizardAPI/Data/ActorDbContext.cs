using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Data
{
    public class ActorDbContext : DbContext
    {
        public ActorDbContext(DbContextOptions<ActorDbContext> options) : base(options)
        {
        }

        public DbSet<Actor> MovieRevenues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().ToTable("Actors");
            modelBuilder.Entity<Actor>()
               .Property(d => d.CreatedTime)
               .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
