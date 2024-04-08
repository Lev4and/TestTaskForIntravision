using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Domain.Repositories
{
    public interface ICoinRepository : IRepository<Coin>, IGridRepository<Coin>
    {

    }
}
