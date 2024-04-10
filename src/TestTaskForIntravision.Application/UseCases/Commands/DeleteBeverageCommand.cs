using MediatR;
using TestTaskForIntravision.Application.Exceptions;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Commands
{
    public class DeleteBeverageCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteBeverageCommand(Guid id)
        {
            Id = id;
        }

        internal class Handler : IRequestHandler<DeleteBeverageCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(DeleteBeverageCommand request, CancellationToken cancellationToken)
            {
                var beverage = (await _repository.FindOneByIdAsync<Beverage>(request.Id, cancellationToken))
                    ?? throw new NotFoundException($"The beverage {request.Id} not found.");

                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Remove(beverage);

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
