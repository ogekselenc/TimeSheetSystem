using MediatR;

namespace TimeSheetSystem.Domain.Employees.EditEmployee;

public record EmployeeEditCommand(
    Guid EmployeeId,
    string FirstName,
    string LastName,
    string Email,
    bool IsActive) : IRequest<EmployeeEditResponse>;