using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Models;
using System.IO;

namespace MovieWizardAPI.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

       
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Directors> Directors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieID);
                entity.Property(e => e.MovieName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
                entity.Property(e => e.IMDBRating).HasColumnType("decimal(3,1)");
                entity.Property(e => e.CreateDate).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.IsActive).IsRequired();

                entity.HasOne(e => e.Director)
                      .WithMany()
                      .HasForeignKey(e => e.DirectorID);
            });

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