using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class TimeLog
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ProjectId { get; set; }

    public DateOnly Date { get; set; }

    public decimal Hours { get; set; }

    public Guid? ApprovedBy { get; set; }

    public string? Note { get; set; }

    public bool IsApproved { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual Employee? ApprovedByNavigation { get; set; }

    public virtual Employee? CreatedByNavigation { get; set; }

    public virtual Employee? DeletedByNavigation { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Employee? UpdatedByNavigation { get; set; }
}
