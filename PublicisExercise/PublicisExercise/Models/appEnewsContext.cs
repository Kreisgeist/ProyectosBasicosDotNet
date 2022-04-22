using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PublicisExercise.Models
{
    public partial class appEnewsContext : DbContext
    {
        public appEnewsContext()
        {
        }

        public appEnewsContext(DbContextOptions<appEnewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Copy> Copys { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "catalogue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias).HasColumnName("alias");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.RefId).HasColumnName("ref_id");
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.ToTable("copys", "catalogue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anunciante).HasColumnName("anunciante");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.File).HasColumnName("file");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Marca).HasColumnName("marca");

                entity.Property(e => e.Medio).HasColumnName("medio");

                entity.Property(e => e.Processing).HasColumnName("processing");

                entity.Property(e => e.Producto).HasColumnName("producto");

                entity.Property(e => e.Programa).HasColumnName("programa");

                entity.Property(e => e.Tema).HasColumnName("tema");

                entity.Property(e => e.Vehiculo).HasColumnName("vehiculo");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("pages", "catalogue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Medio).HasColumnName("medio");

                entity.Property(e => e.Processing).HasColumnName("processing");

                entity.Property(e => e.Spots).HasColumnName("spots");

                entity.Property(e => e.SrcLink).HasColumnName("src_link");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
