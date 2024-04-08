using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Specification;

namespace TestTaskForIntravision.Domain.Repositories
{
    public interface IGridRepository
    {
        ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> specification,
            CancellationToken cancellationToken = default) where TEntity : Entity;

        Task<IReadOnlyCollection<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> specification,
            CancellationToken cancellationToken = default) where TEntity : Entity;
    }

    public interface IGridRepository<TEntity> where TEntity : Entity
    {
        ValueTask<long> CountAsync(IGridSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<TEntity>> FindAsync(IGridSpecification<TEntity> specification,
            CancellationToken cancellationToken = default);
    }
}
