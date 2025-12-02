using MediatR;
using TimeSheetSystem.Data.Data;
using TimeSheetSystem.Data.Repositories;
using TimeSheetSystem.Data.UnitOfWork;

namespace TimeSheetSystem.Data.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimeSheetDbContext _context;

        public ICreateEmployeeRepository Employees { get; }

        public UnitOfWork(TimeSheetDbContext context)
        {
            _context = context;
            Employees = new CreateEmployeeRepository(_context);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
            => _context.SaveChangesAsync(cancellationToken);
    }
}