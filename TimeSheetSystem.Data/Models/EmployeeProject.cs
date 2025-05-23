using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class EmployeeProject
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ProjectId { get; set; }

    public string Role { get; set; } = null!;

    public Guid AssignedBy { get; set; }

    public DateOnly JoinedDate { get; set; }

    public bool IsActive { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Employee AssignedByNavigation { get; set; } = null!;

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? DeletedByNavigation { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Employee? UpdatedByNavigation { get; set; }
}
