using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class BeverageRepository : VendingMachineDbEntityFrameworkRepository<Beverage>, IBeverageRepository
    {
        public BeverageRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
