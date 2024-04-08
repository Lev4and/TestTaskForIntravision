using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class StorageBeverageRepository : VendingMachineDbEntityFrameworkRepository<StorageBeverage>,
        IStorageBeverageRepository
    {
        public StorageBeverageRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
