using TimeSheetSystem.Data.Models;

namespace TimeSheetSystem.Data.Repositories;

public interface IEmployeeReadRepository
{
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}