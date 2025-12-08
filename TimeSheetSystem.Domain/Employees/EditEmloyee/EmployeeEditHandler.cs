using MediatR;
using TimeSheetSystem.Data.Repositories;
using TimeSheetSystem.Data.UnitOfWork;
using TimeSheetSystem.Domain.Common.Exceptions;
using TimeSheetSystem.Data.Models;


namespace TimeSheetSystem.Domain.Employees.EditEmployee;

public class EmployeeEditHandler : IRequestHandler<EmployeeEditCommand, EmployeeEditResponse>
{
    private readonly IEmployeeEditRepository _editRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeEditHandler(
        IEmployeeEditRepository editRepository,
        IUnitOfWork unitOfWork)
    {
        _editRepository = editRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EmployeeEditResponse> Handle(
        EmployeeEditCommand request,
        CancellationToken cancellationToken)
    {
        // 1. Get employee for edit
        var employee = await _editRepository.GetByIdForEditAsync(request.EmployeeId, cancellationToken);
        if (employee is null)
            throw new NotFoundException($"Employee with ID {request.EmployeeId} not found");

        // 2. Check if email is taken by another employee
        if (await _editRepository.EmailExistsForOtherEmployeeAsync(
            request.Email,
            request.EmployeeId,
            cancellationToken))
        {
            throw new InvalidOperationException(
                $"Email '{request.Email}' is already taken by another employee");
        }

        // 3. Update employee entity
        UpdateEmployeeEntity(employee, request);

        // 4. Save changes
        await _editRepository.UpdateAsync(employee, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        // 5. Return response
        return new EmployeeEditResponse(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.IsActive,
            employee.UpdatedAt!.Value);
    }

    private static void UpdateEmployeeEntity(Employee employee, EmployeeEditCommand command)
    {
        if (employee.IsDeleted)
            throw new InvalidOperationException("Cannot edit a deleted employee");

        employee.FirstName = command.FirstName;
        employee.LastName = command.LastName;
        employee.Email = command.Email;
        employee.IsActive = command.IsActive;
        employee.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

        // In real app, get from current user context
        //employee.UpdatedBy = Guid.Parse("00000000-0000-0000-0000-000000000001");
        employee.UpdatedBy = null;
    }
}