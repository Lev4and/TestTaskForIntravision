using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Infrastructure.Databases.EntityFramework.Repositories
{
    public interface IEntityFrameworkRepository : IRepository, IGridRepository
    {

    }

    public interface IEntityFrameworkRepository<TEntity> : IRepository<TEntity>, IGridRepository<TEntity>
        where TEntity : Entity
    {

    }
}
