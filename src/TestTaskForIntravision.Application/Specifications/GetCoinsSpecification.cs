using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Specification;

namespace TestTaskForIntravision.Application.Specifications
{
    public class GetCoinsSpecification : GridSpecificationBase<Coin>
    {
        public GetCoinsSpecification()
        {
            AddInclude(coin => coin.Storage);

            ApplyOrderBy(coin => coin.Value);
        }
    }
}
