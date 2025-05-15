using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class Employee
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? DeletedByNavigation { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjectAssignedByNavigations { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<EmployeeProject> EmployeeProjectCreatedByNavigations { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<EmployeeProject> EmployeeProjectDeletedByNavigations { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<EmployeeProject> EmployeeProjectEmployees { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<EmployeeProject> EmployeeProjectUpdatedByNavigations { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<Employee> InverseCreatedByNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseDeletedByNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseUpdatedByNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Project> ProjectCreatedByNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectDeletedByNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectManagerNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectUpdatedByNavigations { get; set; } = new List<Project>();

    public virtual ICollection<TimeLog> TimeLogApprovedByNavigations { get; set; } = new List<TimeLog>();

    public virtual ICollection<TimeLog> TimeLogCreatedByNavigations { get; set; } = new List<TimeLog>();

    public virtual ICollection<TimeLog> TimeLogDeletedByNavigations { get; set; } = new List<TimeLog>();

    public virtual ICollection<TimeLog> TimeLogEmployees { get; set; } = new List<TimeLog>();

    public virtual ICollection<TimeLog> TimeLogUpdatedByNavigations { get; set; } = new List<TimeLog>();

    public virtual Employee? UpdatedByNavigation { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
