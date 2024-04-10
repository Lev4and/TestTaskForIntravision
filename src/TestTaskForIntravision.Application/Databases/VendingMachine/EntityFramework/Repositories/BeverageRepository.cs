using Microsoft.EntityFrameworkCore;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class BeverageRepository : VendingMachineDbEntityFrameworkRepository<Beverage>, IBeverageRepository
    {
        public BeverageRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyCollection<Beverage>> GetBeveragesByIdsAsync(Guid[] ids, 
            CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Beverages.AsNoTracking()
                .Where(beverage => ids.Contains(beverage.Id));

            return await query.Include(beverage => beverage.Storage)
                .ToListAsync();
        }
    }
}
