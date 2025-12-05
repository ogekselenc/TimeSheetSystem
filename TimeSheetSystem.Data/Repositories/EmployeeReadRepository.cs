using Microsoft.EntityFrameworkCore;
using TimeSheetSystem.Data.Data;
using TimeSheetSystem.Data.Models;
using TimeSheetSystem.Data.Repositories;


namespace TimeSheetSystem.Data.Repositories;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly TimeSheetDbContext _context;

    public EmployeeReadRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted, cancellationToken);
    }

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Employees
            .AsNoTracking()
            .Where(e => !e.IsDeleted)
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Employees
            .AnyAsync(e => e.Id == id && !e.IsDeleted, cancellationToken);
    }
}