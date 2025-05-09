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

    public virtual DbSet<Employeeproject> Employeeprojects { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Timelog> Timelogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TimeSheetSystem;Username=ognjen;Password=ekselencija84.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

            entity.ToTable("employee", "timesheetsystem");

            entity.HasIndex(e => e.Email, "employee_email_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Deletedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deletedat");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Updatedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.InverseCreatedbyNavigation)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("employee_createdby_fkey");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.InverseDeletedbyNavigation)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("employee_deletedby_fkey");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.InverseUpdatedbyNavigation)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("employee_updatedby_fkey");
        });

        modelBuilder.Entity<Employeeproject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employeeproject_pkey");

            entity.ToTable("employeeproject", "timesheetsystem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assignedby).HasColumnName("assignedby");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Deletedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deletedat");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Joineddate).HasColumnName("joineddate");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Role)
                .HasColumnType("character varying")
                .HasColumnName("role");
            entity.Property(e => e.Updatedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");

            entity.HasOne(d => d.AssignedbyNavigation).WithMany(p => p.EmployeeprojectAssignedbyNavigations)
                .HasForeignKey(d => d.Assignedby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeproject_assignedby_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.EmployeeprojectCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("employeeproject_createdby_fkey");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.EmployeeprojectDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("employeeproject_deletedby_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeprojectEmployees)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeproject_employeeid_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.Employeeprojects)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeproject_projectid_fkey");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.EmployeeprojectUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("employeeproject_updatedby_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_pkey");

            entity.ToTable("project", "timesheetsystem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Deletedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deletedat");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Manager).HasColumnName("manager");
            entity.Property(e => e.Maxemployees).HasColumnName("maxemployees");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Updatedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ProjectCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("project_createdby_fkey");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.ProjectDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("project_deletedby_fkey");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.ProjectManagerNavigations)
                .HasForeignKey(d => d.Manager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_manager_fkey");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.ProjectUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("project_updatedby_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role", "timesheetsystem");

            entity.HasIndex(e => e.Name, "role_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasMany(d => d.Employees).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeerole",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employeeid")
                        .HasConstraintName("employeerole_employeeid_fkey"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("Roleid")
                        .HasConstraintName("employeerole_roleid_fkey"),
                    j =>
                    {
                        j.HasKey("Roleid", "Employeeid").HasName("employeerole_pkey");
                        j.ToTable("employeerole", "timesheetsystem");
                        j.IndexerProperty<Guid>("Roleid").HasColumnName("roleid");
                        j.IndexerProperty<Guid>("Employeeid").HasColumnName("employeeid");
                    });
        });

        modelBuilder.Entity<Timelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("timelog_pkey");

            entity.ToTable("timelog", "timesheetsystem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Approvedby).HasColumnName("approvedby");
            entity.Property(e => e.Createdat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Deletedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deletedat");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Hours)
                .HasPrecision(5, 2)
                .HasColumnName("hours");
            entity.Property(e => e.Isapproved)
                .HasDefaultValue(false)
                .HasColumnName("isapproved");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Updatedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");

            entity.HasOne(d => d.ApprovedbyNavigation).WithMany(p => p.TimelogApprovedbyNavigations)
                .HasForeignKey(d => d.Approvedby)
                .HasConstraintName("timelog_approvedby_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TimelogCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("timelog_createdby_fkey");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.TimelogDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("timelog_deletedby_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.TimelogEmployees)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("timelog_employeeid_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.Timelogs)
                .HasForeignKey(d => d.Projectid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("timelog_projectid_fkey");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TimelogUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("timelog_updatedby_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
