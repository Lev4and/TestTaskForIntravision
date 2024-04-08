using MediatR;
using TestTaskForIntravision.Application.Specifications;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Queries
{
    public class GetCoinsQuery : IRequest<IReadOnlyCollection<Coin>>
    {
        internal class Handler : IRequestHandler<GetCoinsQuery, IReadOnlyCollection<Coin>>
        {
            private readonly ICoinRepository _repository;

            public Handler(ICoinRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<Coin>> Handle(GetCoinsQuery request, 
                CancellationToken cancellationToken)
            {
                return await _repository.FindAsync(new GetCoinsSpecification(), cancellationToken);
            }
        }
    }
}
