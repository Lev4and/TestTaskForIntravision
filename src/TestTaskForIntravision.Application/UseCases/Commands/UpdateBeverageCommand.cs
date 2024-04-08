using MediatR;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Commands
{
    public class UpdateBeverageCommand : IRequest<bool>
    {
        internal class Handler : IRequestHandler<UpdateBeverageCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public Task<bool> Handle(UpdateBeverageCommand request, CancellationToken cancellationToken)
            {
                return Task.FromResult(true);
            }
        }
    }
}
