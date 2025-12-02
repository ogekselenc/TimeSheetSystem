using MediatR;

namespace TimeSheetSystem.Domain.Employees.CreateEmployee
{

    public record CreateEmployeeCommand(string FirstName, string LastName, string Email)
        : IRequest<CreateEmployeeResult>;
}