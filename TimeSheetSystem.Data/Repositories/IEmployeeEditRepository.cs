using TimeSheetSystem.Data.Models;

namespace TimeSheetSystem.Data.Repositories;
public interface IEmployeeEditRepository
{
    Task<Employee?> GetByIdForEditAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> EmailExistsForOtherEmployeeAsync(string email, Guid excludeEmployeeId, CancellationToken cancellationToken = default);
    Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
}