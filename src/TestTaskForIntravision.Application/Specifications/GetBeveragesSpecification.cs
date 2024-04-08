using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Specification;

namespace TestTaskForIntravision.Application.Specifications
{
    public class GetBeveragesSpecification : GridSpecificationBase<Beverage>
    {
        public GetBeveragesSpecification()
        {
            AddInclude(beverage => beverage.Image);
            AddInclude(beverage => beverage.Storage);

            ApplyOrderBy(beverage => beverage.Title);
        }
    }
}
