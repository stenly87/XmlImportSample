using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp46;

public partial class User29Context : DbContext
{
    public User29Context()
    {
    }

    public User29Context(DbContextOptions<User29Context> options)
        : base(options)
    {
    }

    public virtual DbSet<InsuranceCmpany> InsuranceCmpanies { get; set; }

    public virtual DbSet<InsurancePolicyType> InsurancePolicyTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<StatusService> StatusServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=192.168.200.35;user=user29;database=user29;password=94426;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InsuranceCmpany>(entity =>
        {
            entity.ToTable("InsuranceCmpany");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bik)
                .HasMaxLength(50)
                .HasColumnName("BIK");
            entity.Property(e => e.CheckingAccount).HasMaxLength(50);
            entity.Property(e => e.Inn)
                .HasMaxLength(50)
                .HasColumnName("INN");
        });

        modelBuilder.Entity<InsurancePolicyType>(entity =>
        {
            entity.ToTable("InsurancePolicyType");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfCreation).HasColumnType("datetime");
            entity.Property(e => e.LeadTime)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ServicesId).HasColumnName("Services_ID");
            entity.Property(e => e.StatusOrderId).HasColumnName("StatusOrder_ID");
            entity.Property(e => e.StatusServicesId).HasColumnName("StatusServices_ID");

            entity.HasOne(d => d.StatusOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_StatusOrder");

            entity.HasOne(d => d.StatusServices).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_StatusServices");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Fio).HasColumnName("FIO");
            entity.Property(e => e.InsuranceCompanyId).HasColumnName("InsuranceCompany_ID");
            entity.Property(e => e.InsurancePolicyNumber).HasMaxLength(50);
            entity.Property(e => e.InsurancePolicyTypeId).HasColumnName("InsurancePolicyType_ID");
            entity.Property(e => e.NumbersPassport)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SeriesPassport)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Telephone).HasMaxLength(50);

            entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.Patients)
                .HasForeignKey(d => d.InsuranceCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_InsuranceCmpany");

            entity.HasOne(d => d.InsurancePolicyType).WithMany(p => p.Patients)
                .HasForeignKey(d => d.InsurancePolicyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_InsurancePolicyType");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AverageDeviation)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Deadline)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.ToTable("StatusOrder");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<StatusService>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
