using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Domain.Repositories
{
    public interface IBeverageRepository : IRepository<Beverage>, IGridRepository<Beverage>
    {

    }
}
