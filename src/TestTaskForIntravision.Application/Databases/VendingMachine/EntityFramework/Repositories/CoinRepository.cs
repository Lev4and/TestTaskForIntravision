using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class CoinRepository : VendingMachineDbEntityFrameworkRepository<Coin>, ICoinRepository
    {
        public CoinRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
