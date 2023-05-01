using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpotlessAPI.Models;

namespace SpotlessAPI.Context;

public partial class EFContext : DbContext
{
    public EFContext()
    {
    }

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAdress> UserAdresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SpotlessDataBase;integrated security = sspi;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Address_pk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Id_pk");
        });

        modelBuilder.Entity<UserAdress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserAdress_pk");

            entity.HasOne(d => d.Adress).WithMany(p => p.UserAdresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserAdress_Address_Id_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserAdresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserAdress_Users_Id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
