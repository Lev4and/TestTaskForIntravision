using MediatR;
using TestTaskForIntravision.Application.Specifications;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Queries
{
    public class GetBeveragesQuery : IRequest<IReadOnlyCollection<Beverage>>
    {
        internal class Handler : IRequestHandler<GetBeveragesQuery, IReadOnlyCollection<Beverage>>
        {
            private readonly IBeverageRepository _repository;

            public Handler(IBeverageRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<Beverage>> Handle(GetBeveragesQuery request, 
                CancellationToken cancellationToken)
            {
                return await _repository.FindAsync(new GetBeveragesSpecification(), cancellationToken);
            }
        }
    }
}
