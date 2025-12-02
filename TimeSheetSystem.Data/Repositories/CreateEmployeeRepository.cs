using Microsoft.EntityFrameworkCore;
using TimeSheetSystem.Data.Data;
using TimeSheetSystem.Data.Models;


namespace TimeSheetSystem.Data.Repositories;

public class CreateEmployeeRepository : ICreateEmployeeRepository
{
    private readonly TimeSheetDbContext _context;

    public CreateEmployeeRepository(TimeSheetDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Employee employee, CancellationToken cancellationToken)
        => _context.Employees.AddAsync(employee, cancellationToken).AsTask();

    public Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        => _context.Employees.FirstOrDefaultAsync(e => e.Email == email, cancellationToken);
}
