using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class StorageCoinRepository : VendingMachineDbEntityFrameworkRepository<StorageCoin>,
        IStorageCoinRepository
    {
        public StorageCoinRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
