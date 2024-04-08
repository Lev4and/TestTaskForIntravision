using System.Linq.Expressions;
using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Domain.Repositories
{
    public interface IRepository
    {
        TEntity Add<TEntity>(TEntity entity) where TEntity : Entity;

        Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : Entity;

        Task<TEntity?> FindOneByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default)
            where TEntity : Entity;

        Task<TEntity?> FindOneByExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default) where TEntity : Entity;

        Task<TEntity> FindOneByExpressionOrAddAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default) where TEntity : Entity;

        void Update<TEntity>(TEntity entity) where TEntity : Entity;

        Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Entity;

        void Remove<TEntity>(TEntity entity) where TEntity : Entity;

        Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : Entity;
    }

    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> FindOneByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        Task<TEntity> FindOneByExpressionOrAddAsync(TEntity entity, Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Remove(TEntity entity);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
