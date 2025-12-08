namespace TimeSheetSystem.Domain.Employees.EditEmployee;

public record EmployeeEditResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsActive,
    DateTime UpdatedAt);