using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyCon.Models;

namespace MyCon.DBContext;

public partial class MyConDbContext : DbContext
{
    public MyConDbContext()
    {
    }

    public MyConDbContext(DbContextOptions<MyConDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<TypeConnection> TypeConnections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=MyConDB.sqlite3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Connection>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("TEXT(250)");
            entity.Property(e => e.Ip)
                .HasColumnType("TEXT(50)")
                .HasColumnName("IP");
            entity.Property(e => e.Login).HasColumnType("TEXT(100)");
            entity.Property(e => e.Name).HasColumnType("TEXT(100)");
            entity.Property(e => e.Password).HasColumnType("TEXT(100)");

            entity.HasOne(d => d.Organization).WithMany(p => p.Connections)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.TypeConntecion).WithMany(p => p.Connections)
                .HasForeignKey(d => d.TypeConntecionId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("TEXT(50)");
        });

        modelBuilder.Entity<TypeConnection>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("TEXT(25)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
