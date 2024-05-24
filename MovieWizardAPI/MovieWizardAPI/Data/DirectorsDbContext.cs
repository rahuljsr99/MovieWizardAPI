using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;
using System.IO;

namespace MovieWizardAPI.Data
{
    public class DirectorsDbContext : DbContext
    {
        public DirectorsDbContext(DbContextOptions<DirectorsDbContext> options) : base(options)
        {
        }

        public DbSet<Directors> Directors { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Directors>(entity =>
            {
                entity.HasKey(e => e.DirectorID);
                entity.Property(e => e.DirectorName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreateDate).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.IsActive).IsRequired();
            });

           
        }
    }
}
