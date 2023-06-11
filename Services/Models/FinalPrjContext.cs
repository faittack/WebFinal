using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Services.Models;

public partial class FinalPrjContext : DbContext
{
    public FinalPrjContext()
    {
    }

    public FinalPrjContext(DbContextOptions<FinalPrjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryTable> CategoryTables { get; set; }

    public virtual DbSet<CityTable> CityTables { get; set; }

    public virtual DbSet<ProductTable> ProductTables { get; set; }

    public virtual DbSet<SubCategoryTable> SubCategoryTables { get; set; }

    public virtual DbSet<UsersTable> UsersTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-54BGQ5K;Initial Catalog=FinalPrj;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryTable>(entity =>
        {
            entity.ToTable("CategoryTable");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CityTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_City");

            entity.ToTable("CityTable");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product");

            entity.ToTable("ProductTable");

            entity.Property(e => e.ProductImage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductPrize).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CategoryTable).WithMany(p => p.ProductTables)
                .HasForeignKey(d => d.ProductCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTable_CategoryTable");
        });

        modelBuilder.Entity<SubCategoryTable>(entity =>
        {
            entity.ToTable("Sub-CategoryTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.SubCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Sub-Category");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategoryTables)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sub-CategoryTable_CategoryTable");
        });

        modelBuilder.Entity<UsersTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("UsersTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
