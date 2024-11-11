using System;
using System.Collections.Generic;
using JFApi2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JFApi2.Data;

public partial class JfejercicioBugerContextContext : DbContext
{
    public JfejercicioBugerContextContext()
    {
    }

    public JfejercicioBugerContextContext(DbContextOptions<JfejercicioBugerContextContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Burguer> Burguers { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JFEjercicioBugerContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burguer>(entity =>
        {
            entity.ToTable("Burguer");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.BurguerId, "IX_Promo_BurguerID");

            entity.Property(e => e.BurguerId).HasColumnName("BurguerID");

            entity.HasOne(d => d.Burguer).WithMany(p => p.Promos).HasForeignKey(d => d.BurguerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
