using TimeSheetSystem.Data.Repositories;
using MediatR;

namespace TimeSheetSystem.Data.UnitOfWork
{


    public interface IUnitOfWork
    {
        ICreateEmployeeRepository Employees { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}