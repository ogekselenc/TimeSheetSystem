using TimeSheetSystem.Data.Models;

namespace TimeSheetSystem.Data.Repositories
{

    public interface ICreateEmployeeRepository 
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}