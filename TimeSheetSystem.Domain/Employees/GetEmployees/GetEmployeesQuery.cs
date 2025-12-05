using MediatR;
using TimeSheetSystem.Domain.Employees.Dtos;

namespace TimeSheetSystem.Domain.Employees.GetEmployees;

public record GetEmployeesQuery : IRequest<List<EmployeeDto>>;