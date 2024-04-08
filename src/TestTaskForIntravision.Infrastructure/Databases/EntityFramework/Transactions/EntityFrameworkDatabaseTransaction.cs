using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using TestTaskForIntravision.Domain.Infrastructure.Databases.Transactions;

namespace TestTaskForIntravision.Infrastructure.Databases.EntityFramework.Transactions
{
    public class EntityFrameworkDatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EntityFrameworkDatabaseTransaction(DbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
