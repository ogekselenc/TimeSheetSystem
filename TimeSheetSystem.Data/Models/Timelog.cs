using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class Timelog
{
    public Guid Id { get; set; }

    public Guid Employeeid { get; set; }

    public Guid Projectid { get; set; }

    public DateOnly Date { get; set; }

    public decimal Hours { get; set; }

    public Guid? Approvedby { get; set; }

    public string? Note { get; set; }

    public bool? Isapproved { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public DateTime? Deletedat { get; set; }

    public Guid? Createdby { get; set; }

    public Guid? Updatedby { get; set; }

    public Guid? Deletedby { get; set; }

    public virtual Employee? ApprovedbyNavigation { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? DeletedbyNavigation { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Employee? UpdatedbyNavigation { get; set; }
}
