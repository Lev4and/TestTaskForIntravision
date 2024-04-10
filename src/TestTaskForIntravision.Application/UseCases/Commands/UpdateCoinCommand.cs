using MediatR;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Commands
{
    public class UpdateCoinCommand : IRequest<bool>
    {
        public Coin Coin { get; }

        public UpdateCoinCommand(Coin coin)
        {
            Coin = coin;
        }

        internal class Handler : IRequestHandler<UpdateCoinCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(UpdateCoinCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Update(request.Coin);

                        if (request.Coin.Storage is not null)
                        {
                            _repository.Update(request.Coin.Storage);
                        }

                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        return true;
                    }
                    catch
                    {
                        await transaction.RollbackAsync(cancellationToken);

                        return false;
                    }
                }
            }
        }
    }
}
