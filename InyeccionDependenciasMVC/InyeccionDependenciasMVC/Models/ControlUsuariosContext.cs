using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InyeccionDependenciasMVC.Models
{
    public partial class ControlUsuariosContext : DbContext
    {
        public ControlUsuariosContext()
        {
        }

        public ControlUsuariosContext(DbContextOptions<ControlUsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=10.0.0.15\\APPSFABPSA;initial catalog=ControlUsuarios;user=sa;password=F4bp54cdmx*/30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Genders", "Catalogs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Gender");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Auth");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.User1)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("user");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CatalogsGender_AuthUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
