using Microsoft.EntityFrameworkCore;
using TimeSheetSystem.Data.Repositories;
using TimeSheetSystem.Data.Data;
using TimeSheetSystem.Data.Models;


namespace TimeSheetSystem.Data.Repositories;

public class EmployeeEditRepository : IEmployeeEditRepository
{
    private readonly TimeSheetDbContext _context;

    public EmployeeEditRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdForEditAsync(Guid id, CancellationToken cancellationToken = default)
    {
        // Get employee for editing (without AsNoTracking since we'll update it)
        return await _context.Employees
            .FirstOrDefaultAsync(e =>
                e.Id == id &&
                !e.IsDeleted,
                cancellationToken);
    }

    public async Task<bool> EmailExistsForOtherEmployeeAsync(
        string email,
        Guid excludeEmployeeId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Employees
            .AnyAsync(e =>
                e.Email == email &&
                e.Id != excludeEmployeeId &&
                !e.IsDeleted,
                cancellationToken);
    }

    public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        _context.Entry(employee).State = EntityState.Modified;
        await Task.CompletedTask; // UnitOfWork will call SaveChanges
    }
}