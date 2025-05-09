using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class Project
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid Manager { get; set; }

    public int Maxemployees { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public DateTime? Deletedat { get; set; }

    public Guid? Createdby { get; set; }

    public Guid? Updatedby { get; set; }

    public Guid? Deletedby { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? DeletedbyNavigation { get; set; }

    public virtual ICollection<Employeeproject> Employeeprojects { get; set; } = new List<Employeeproject>();

    public virtual Employee ManagerNavigation { get; set; } = null!;

    public virtual ICollection<Timelog> Timelogs { get; set; } = new List<Timelog>();

    public virtual Employee? UpdatedbyNavigation { get; set; }
}
