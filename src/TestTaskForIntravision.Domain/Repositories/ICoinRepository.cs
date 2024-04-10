using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Domain.Repositories
{
    public interface ICoinRepository : IRepository<Coin>, IGridRepository<Coin>
    {
        Task<IReadOnlyCollection<Coin>> GetCoinsByIdsAsync(Guid[] ids, 
            CancellationToken cancellationToken = default);
    }
}
