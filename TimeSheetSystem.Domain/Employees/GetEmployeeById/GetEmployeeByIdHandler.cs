using MediatR;
using TimeSheetSystem.Domain.Employees.Dtos;
using TimeSheetSystem.Data.Repositories;
using TimeSheetSystem.Domain.Common.Exceptions;

namespace TimeSheetSystem.Domain.Employees.GetEmployeeById;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IEmployeeReadRepository _repository;

    public GetEmployeeByIdHandler(IEmployeeReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (employee == null)
            throw new NotFoundException($"Employee with ID {request.Id} not found");

        return new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            IsActive = employee.IsActive,
            CreatedAt = employee.CreatedAt
        };
    }
}