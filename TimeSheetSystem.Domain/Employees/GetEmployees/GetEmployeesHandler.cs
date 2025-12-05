using MediatR;
using TimeSheetSystem.Domain.Employees.Dtos;
using TimeSheetSystem.Data.Repositories;

namespace TimeSheetSystem.Domain.Employees.GetEmployees;

public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    private readonly IEmployeeReadRepository _repository;

    public GetEmployeesHandler(IEmployeeReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _repository.GetAllAsync(cancellationToken);

        return employees.Select(e => new EmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            IsActive = e.IsActive,
            CreatedAt = e.CreatedAt
        }).ToList();
    }
}