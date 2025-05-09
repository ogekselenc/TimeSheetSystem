using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class Employeeproject
{
    public Guid Id { get; set; }

    public Guid Employeeid { get; set; }

    public Guid Projectid { get; set; }

    public string Role { get; set; } = null!;

    public Guid Assignedby { get; set; }

    public DateOnly Joineddate { get; set; }

    public bool? Isactive { get; set; }

    public DateOnly? Enddate { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public DateTime? Deletedat { get; set; }

    public Guid? Createdby { get; set; }

    public Guid? Updatedby { get; set; }

    public Guid? Deletedby { get; set; }

    public virtual Employee AssignedbyNavigation { get; set; } = null!;

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? DeletedbyNavigation { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Employee? UpdatedbyNavigation { get; set; }
}
