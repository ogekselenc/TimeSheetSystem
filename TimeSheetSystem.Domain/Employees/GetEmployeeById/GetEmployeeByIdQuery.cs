using MediatR;
using TimeSheetSystem.Domain.Employees.Dtos;

namespace TimeSheetSystem.Domain.Employees.GetEmployeeById;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDto>;