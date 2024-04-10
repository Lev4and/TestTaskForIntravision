using Microsoft.EntityFrameworkCore;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class CoinRepository : VendingMachineDbEntityFrameworkRepository<Coin>, ICoinRepository
    {
        public CoinRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyCollection<Coin>> GetCoinsByIdsAsync(Guid[] ids, 
            CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Coins.AsNoTracking()
                .Where(coin => ids.Contains(coin.Id));

            return await query.Include(coin => coin.Storage)
                .ToListAsync();
        }
    }
}
