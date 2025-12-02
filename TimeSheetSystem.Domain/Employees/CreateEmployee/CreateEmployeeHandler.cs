using MediatR;
using TimeSheetSystem.Data.UnitOfWork;
using TimeSheetSystem.Data.Models;

using TimeSheetSystem.Domain.Employees.CreateEmployee;


namespace TimeSheetSystem.Domain.Employees.CreateEmployee
{

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResult>
    {
        private readonly IUnitOfWork _uow;

        public CreateEmployeeHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CreateEmployeeResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Optional: Check if email already exists
            var existing = await _uow.Employees.GetByEmailAsync(request.Email, cancellationToken);
            if (existing is not null)
            {
                throw new InvalidOperationException("An employee with this email already exists.");
            }

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _uow.Employees.AddAsync(employee, cancellationToken);
            await _uow.CommitAsync(cancellationToken);

            return new CreateEmployeeResult(employee.Id, employee.FirstName, employee.LastName, employee.Email);
        }
    }
}
