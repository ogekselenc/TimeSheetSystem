using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TimeSheetSystem.Data.Models;

namespace TimeSheetSystem.Data.Data;

public partial class TimeSheetDbContext : DbContext
{
    public TimeSheetDbContext()
    {
    }

    public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TimeLog> TimeLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TimeSheetSystem;Username=ognjen;Password=ekselencija84.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employee_pkey");

            entity.ToTable("Employee", "TimeSheetSystem");

            entity.HasIndex(e => e.Email, "Employee_Email_key").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeletedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasColumnType("character varying");
            entity.Property(e => e.FirstName).HasColumnType("character varying");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasColumnType("character varying");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Employee_CreatedBy_fkey");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.InverseDeletedByNavigation)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("Employee_DeletedBy_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("Employee_UpdatedBy_fkey");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EmployeeProject_pkey");

            entity.ToTable("EmployeeProject", "TimeSheetSystem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeletedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Role).HasColumnType("character varying");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.EmployeeProjectAssignedByNavigations)
                .HasForeignKey(d => d.AssignedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeProject_AssignedBy_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EmployeeProjectCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("EmployeeProject_CreatedBy_fkey");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.EmployeeProjectDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("EmployeeProject_DeletedBy_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeProjectEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeProject_EmployeeId_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeProject_ProjectId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.EmployeeProjectUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("EmployeeProject_UpdatedBy_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Project_pkey");

            entity.ToTable("Project", "TimeSheetSystem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeletedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProjectCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("Project_CreatedBy_fkey");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.ProjectDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("Project_DeletedBy_fkey");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.ProjectManagerNavigations)
                .HasForeignKey(d => d.Manager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Project_Manager_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProjectUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("Project_UpdatedBy_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role", "TimeSheetSystem");

            entity.HasIndex(e => e.Name, "Role_Name_key").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("character varying");

            entity.HasMany(d => d.Employees).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeRole",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EmployeeRole_EmployeeId_fkey"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EmployeeRole_RoleId_fkey"),
                    j =>
                    {
                        j.HasKey("RoleId", "EmployeeId").HasName("EmployeeRole_pkey");
                        j.ToTable("EmployeeRole", "TimeSheetSystem");
                    });
        });

        modelBuilder.Entity<TimeLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TimeLog_pkey");

            entity.ToTable("TimeLog", "TimeSheetSystem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DeletedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Hours).HasPrecision(5, 2);
            entity.Property(e => e.IsApproved).HasDefaultValue(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.TimeLogApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("TimeLog_ApprovedBy_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TimeLogCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("TimeLog_CreatedBy_fkey");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TimeLogDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("TimeLog_DeletedBy_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.TimeLogEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TimeLog_EmployeeId_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.TimeLogs)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TimeLog_ProjectId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TimeLogUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("TimeLog_UpdatedBy_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
