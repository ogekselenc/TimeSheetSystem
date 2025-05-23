using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class Project
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid Manager { get; set; }

    public int MaxEmployees { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? DeletedByNavigation { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    public virtual Employee ManagerNavigation { get; set; } = null!;

    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();

    public virtual Employee? UpdatedByNavigation { get; set; }
}
