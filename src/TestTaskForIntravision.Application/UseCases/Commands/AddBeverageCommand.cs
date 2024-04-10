using MediatR;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Commands
{
    public class AddBeverageCommand : IRequest<bool>
    {
        public Beverage Beverage { get; }

        public AddBeverageCommand(Beverage beverage)
        {
            Beverage = beverage;
        }

        internal class Handler : IRequestHandler<AddBeverageCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

            public async Task<bool> Handle(AddBeverageCommand request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        _repository.Add(request.Beverage);

                        if (request.Beverage.Image is not null)
                        {
                            request.Beverage.Image.BeverageId = request.Beverage.Id;

                            _repository.Add(request.Beverage.Image);
                        }

                        if (request.Beverage.Storage is not null)
                        {
                            request.Beverage.Storage.BeverageId = request.Beverage.Id;

                            _repository.Add(request.Beverage.Storage);
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
