using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using master.DAL.Entity;

namespace master.DAL.DBContext;

public partial class MasterManagementDBContext : DbContext
{
    public MasterManagementDBContext()
    {
    }

    public MasterManagementDBContext(DbContextOptions<MasterManagementDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ddo> Ddos { get; set; }

    public virtual DbSet<DemandMajorMapping> DemandMajorMappings { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<DetailHead> DetailHeads { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<MajorHead> MajorHeads { get; set; }

    public virtual DbSet<MinorHead> MinorHeads { get; set; }

    public virtual DbSet<SchemeHead> SchemeHeads { get; set; }

    public virtual DbSet<SchemeTypeMst> SchemeTypeMsts { get; set; }

    public virtual DbSet<SubDetailHead> SubDetailHeads { get; set; }

    public virtual DbSet<SubMajorHead> SubMajorHeads { get; set; }

    public virtual DbSet<SubSchemeType> SubSchemeTypes { get; set; }

    public virtual DbSet<Treasury> Treasuries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name = MasterManagementDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ddo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ddo_pkey");

            entity.Property(e => e.Code).IsFixedLength();
            entity.Property(e => e.Phone).IsFixedLength();
            entity.Property(e => e.TreasuryCode).IsFixedLength();
        });

        modelBuilder.Entity<DemandMajorMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("demand_major_mapping_pkey");

            entity.Property(e => e.DemandCode).IsFixedLength();
            entity.Property(e => e.MajorHeadCode).IsFixedLength();

            entity.HasOne(d => d.DemandCodeNavigation).WithMany(p => p.DemandMajorMappings)
                .HasPrincipalKey(p => p.DemandCode)
                .HasForeignKey(d => d.DemandCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deman_code");

            entity.HasOne(d => d.MajorHeadCodeNavigation).WithMany(p => p.DemandMajorMappings)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.MajorHeadCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_major_head_code");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pkey");

            entity.Property(e => e.Code).IsFixedLength();
            entity.Property(e => e.DemandCode).IsFixedLength();
            entity.Property(e => e.MobileNumber).IsFixedLength();
            entity.Property(e => e.PhoneNumber).IsFixedLength();
            entity.Property(e => e.PinCode).IsFixedLength();
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("designation_pkey");
        });

        modelBuilder.Entity<DetailHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detail_head_pkey");

            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("level_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<MajorHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("major_head1_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<MinorHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("minor_head_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).IsFixedLength();

            entity.HasOne(d => d.SubMajor).WithMany(p => p.MinorHeads).HasConstraintName("FK_submajor");
        });

        modelBuilder.Entity<SchemeHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scheme_head_pkey");

            entity.Property(e => e.Code).IsFixedLength();
            entity.Property(e => e.DemandCode).IsFixedLength();

            entity.HasOne(d => d.DemandCodeNavigation).WithMany(p => p.SchemeHeads)
                .HasPrincipalKey(p => p.DemandCode)
                .HasForeignKey(d => d.DemandCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Demand");

            entity.HasOne(d => d.MinorHead).WithMany(p => p.SchemeHeads).HasConstraintName("FK_MinorHead");
        });

        modelBuilder.Entity<SchemeTypeMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scheme_type_mst_pk");

            entity.Property(e => e.Type).IsFixedLength();
        });

        modelBuilder.Entity<SubDetailHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sub_detail_head_pkey");

            entity.Property(e => e.Code).IsFixedLength();

            entity.HasOne(d => d.DetailHead).WithMany(p => p.SubDetailHeads).HasConstraintName("FK_DetailHead");
        });

        modelBuilder.Entity<SubMajorHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sub_major_head_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).IsFixedLength();

            entity.HasOne(d => d.MajorHead).WithMany(p => p.SubMajorHeads).HasConstraintName("FK_majorhead");
        });

        modelBuilder.Entity<SubSchemeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sub_scheme_type_pk");
        });

        modelBuilder.Entity<Treasury>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("treasury_pkey");

            entity.Property(e => e.Code).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
