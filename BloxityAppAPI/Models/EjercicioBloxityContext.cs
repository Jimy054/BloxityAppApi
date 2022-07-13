using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloxityAppAPI.Models
{

    public partial class EjercicioBloxityContext : DbContext
    {
        public EjercicioBloxityContext()
        {
        }

        public EjercicioBloxityContext(DbContextOptions<EjercicioBloxityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-P4M713N\\SQLEXPRESS;Initial Catalog=EjercicioBloxity;User ID=runny;Password=ProList54;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.Codigo, "UQ__Producto__06370DAC27A07633")
                    .IsUnique();

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDeEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDeModificacion).HasColumnType("datetime");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.Unidad)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Productos).
                     OnDelete(DeleteBehavior.ClientCascade)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK__Productos__Prove__3A81B327");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.ProveedorId)
                    .HasName("PK__Proveedo__61266BB97B5B3462");

                entity.HasIndex(e => e.Codigo, "UQ__Proveedo__06370DAC2DEE2000")
                    .IsUnique();

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDeEliminacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDeModificacion).HasColumnType("datetime");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("RFC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
