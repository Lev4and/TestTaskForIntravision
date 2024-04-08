using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Infrastructure.Databases.EntityFramework.Repositories;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework.Repositories
{
    public class VendingMachineDbEntityFrameworkRepository : EntityFrameworkRepository<VendingMachineDbContext>
    {
        public VendingMachineDbEntityFrameworkRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }
    }

    public class VendingMachineDbEntityFrameworkRepository<TEntity> : EntityFrameworkRepository<VendingMachineDbContext, TEntity>
        where TEntity : Entity
    {
        public VendingMachineDbEntityFrameworkRepository(VendingMachineDbContext dbContext) : base(dbContext)
        {

        }
    }
}
