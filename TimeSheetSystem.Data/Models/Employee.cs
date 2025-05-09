using System;
using System.Collections.Generic;

namespace TimeSheetSystem.Data.Models;

public partial class Employee
{
    public Guid Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Isactive { get; set; }

    public bool? Isdeleted { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public DateTime? Deletedat { get; set; }

    public Guid? Createdby { get; set; }

    public Guid? Updatedby { get; set; }

    public Guid? Deletedby { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? DeletedbyNavigation { get; set; }

    public virtual ICollection<Employeeproject> EmployeeprojectAssignedbyNavigations { get; set; } = new List<Employeeproject>();

    public virtual ICollection<Employeeproject> EmployeeprojectCreatedbyNavigations { get; set; } = new List<Employeeproject>();

    public virtual ICollection<Employeeproject> EmployeeprojectDeletedbyNavigations { get; set; } = new List<Employeeproject>();

    public virtual ICollection<Employeeproject> EmployeeprojectEmployees { get; set; } = new List<Employeeproject>();

    public virtual ICollection<Employeeproject> EmployeeprojectUpdatedbyNavigations { get; set; } = new List<Employeeproject>();

    public virtual ICollection<Employee> InverseCreatedbyNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseDeletedbyNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseUpdatedbyNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Project> ProjectCreatedbyNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectDeletedbyNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectManagerNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectUpdatedbyNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Timelog> TimelogApprovedbyNavigations { get; set; } = new List<Timelog>();

    public virtual ICollection<Timelog> TimelogCreatedbyNavigations { get; set; } = new List<Timelog>();

    public virtual ICollection<Timelog> TimelogDeletedbyNavigations { get; set; } = new List<Timelog>();

    public virtual ICollection<Timelog> TimelogEmployees { get; set; } = new List<Timelog>();

    public virtual ICollection<Timelog> TimelogUpdatedbyNavigations { get; set; } = new List<Timelog>();

    public virtual Employee? UpdatedbyNavigation { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
