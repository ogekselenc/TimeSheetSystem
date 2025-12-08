namespace TimeSheetSystem.Domain.Employees.EditEmployee;

public record EmployeeEditRequest(
    string FirstName,
    string LastName,
    string Email,
    bool IsActive);