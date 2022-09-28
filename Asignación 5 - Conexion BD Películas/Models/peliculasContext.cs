using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Asignación_5___Conexion_BD_Películas.Models
{
    public partial class peliculasContext : DbContext
    {
        public peliculasContext()
        {
        }

        public peliculasContext(DbContextOptions<peliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-448GVJA;Database=peliculas;User Id=joan;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("genero");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Genero1)
                    .HasColumnName("genero")
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("pelicula");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Generoid).HasColumnName("generoid");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Pelicula)
                    .HasForeignKey(d => d.Generoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pelicula_genero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
