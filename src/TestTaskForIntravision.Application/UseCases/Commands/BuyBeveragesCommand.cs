using FluentValidation;
using MediatR;
using TestTaskForIntravision.Application.Specifications;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Repositories;

namespace TestTaskForIntravision.Application.UseCases.Commands
{
    public class BuyBeveragesCommand : IRequest<IReadOnlyDictionary<decimal, uint>>
    {
        public IReadOnlyDictionary<Guid, uint> DepositedCoins { get; }

        public IReadOnlyDictionary<Guid, uint> SelectedBeverages { get; }

        public BuyBeveragesCommand(IReadOnlyDictionary<Guid, uint> depositedCoins, IReadOnlyDictionary<Guid, uint> selectedBeverages)
        {
            DepositedCoins = depositedCoins;
            SelectedBeverages = selectedBeverages;
        }

        internal class Handler : IRequestHandler<BuyBeveragesCommand, IReadOnlyDictionary<decimal, uint>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRepository _repository;
            private readonly ICoinRepository _coinRepository;
            private readonly IBeverageRepository _beverageRepository;

            public Handler(IUnitOfWork unitOfWork, IRepository repository, ICoinRepository coinRepository, 
                IBeverageRepository beverageRepository)
            {
                _unitOfWork = unitOfWork;
                _repository = repository;
                _coinRepository = coinRepository;
                _beverageRepository = beverageRepository;
            }

            public async Task<IReadOnlyDictionary<decimal, uint>> Handle(BuyBeveragesCommand request, 
                CancellationToken cancellationToken)
            {
                var coins = await GetCoinsAsync(cancellationToken);
                var beverages = await GetBeveragesByIdsAsync(request.SelectedBeverages.Keys.ToList(), cancellationToken);

                ValidateDepositedCoins(coins, request.DepositedCoins);
                ValidateSelectedBeverages(beverages, request.SelectedBeverages);

                IncreaseCountCoinsInStorage(coins, request.DepositedCoins);
                ReduceCountBeveragesInStorage(beverages, request.SelectedBeverages);

                var change = CalculateChange(request.DepositedCoins, coins, 
                    request.SelectedBeverages, beverages);

                ValidateChange(change);

                var changeCoins = GetChangeCoins(change, coins);

                ReduceCountCoinsInStorage(coins, changeCoins);

                await SaveChangesAsync(coins, beverages, cancellationToken);

                return changeCoins.Where(item => item.Value > 0)
                    .ToDictionary(item => item.Key.Value, item => item.Value);
            }

            private async Task<IReadOnlyCollection<Coin>> GetCoinsAsync(CancellationToken cancellationToken = default)
            {
                return (await _coinRepository.FindAsync(new GetCoinsSpecification(), cancellationToken))
                    .OrderByDescending(coin => coin.Value)
                    .ToList();
            }

            private void ValidateDepositedCoins(IReadOnlyCollection<Coin> coins, 
                IReadOnlyDictionary<Guid, uint> depositedCoins)
            {
                var nonExistentCoins = depositedCoins.Keys
                    .Where(coinId => !coins.Any(coin => coin.Id == coinId))
                    .ToList();

                if (nonExistentCoins.Count > 0)
                    throw new ValidationException("Some coins don't exist.");

                var blockedForDepositCoins = coins.Where(item => 
                    (item.Storage?.IsBlockedForDeposit ?? true) && depositedCoins.ContainsKey(item.Id))
                        .ToList();

                if (blockedForDepositCoins.Count > 0)
                    throw new ValidationException("Some coins are not accepted.");
            }

            private void IncreaseCountCoinsInStorage(IReadOnlyCollection<Coin> coins,
                IReadOnlyDictionary<Guid, uint> depositedCoins)
            {
                foreach (var coin in coins)
                    if (coin.Storage is not null && depositedCoins.ContainsKey(coin.Id))
                        coin.Storage.Count += depositedCoins[coin.Id];
            }

            private async Task<IReadOnlyCollection<Beverage>> GetBeveragesByIdsAsync(IReadOnlyCollection<Guid> beveragesIds,
                CancellationToken cancellationToken = default)
            {
                return (await _beverageRepository.GetBeveragesByIdsAsync(beveragesIds.ToArray(), cancellationToken))
                    .ToList();
            }

            private void ValidateSelectedBeverages(IReadOnlyCollection<Beverage> beverages,
                IReadOnlyDictionary<Guid, uint> selectedBeverages)
            {
                var nonExistentBeverages = selectedBeverages.Keys
                    .Where(beverageId => !beverages.Any(beverage => beverage.Id == beverageId))
                    .ToList();

                if (nonExistentBeverages.Count > 0)
                    throw new ValidationException("Some beverages don't exist.");
            }
            
            private void ReduceCountBeveragesInStorage(IReadOnlyCollection<Beverage> beverages,
                IReadOnlyDictionary<Guid, uint> selectedBeverages)
            {
                foreach (var beverage in beverages)
                {
                    if (beverage.Storage is not null && selectedBeverages.ContainsKey(beverage.Id))
                    {
                        if (selectedBeverages[beverage.Id] > beverage.Storage.Count)
                            throw new ValidationException("Some beverages are not available.");

                        beverage.Storage.Count -= selectedBeverages[beverage.Id];
                    }
                }
            }

            private decimal CalculateChange(IReadOnlyDictionary<Guid, uint> depositedCoins, IReadOnlyCollection<Coin> coins,
                IReadOnlyDictionary<Guid, uint> selectedBeverages, IReadOnlyCollection<Beverage> beverages)
            {
                return depositedCoins.Sum(item => coins.Single(coin => coin.Id == item.Key).Value * item.Value) -
                    selectedBeverages.Sum(item => beverages.Single(beverage => beverage.Id == item.Key).Price * item.Value);
            }

            private void ValidateChange(decimal change)
            {
                if (change < 0)
                {
                    throw new ValidationException("Invalid request params.");
                }
            }

            private IReadOnlyDictionary<Coin, uint> GetChangeCoins(decimal change, IReadOnlyCollection<Coin> coins)
            {
                var result = new Dictionary<Coin, uint>();

                if (change > 0)
                {
                    foreach (var coin in coins)
                    {
                        if (coin.Storage is not null)
                        {
                            var coinCount = Convert.ToUInt32(Math.Floor(change / coin.Value));

                            if (coinCount > coin.Storage.Count)
                                coinCount = coin.Storage.Count;

                            result.Add(coin, coinCount);

                            change -= coin.Value * coinCount;

                            if (change == 0) break;
                        }
                    }

                    if (change > 0)
                        throw new ValidationException("It is impossible to give change.");
                }

                return result;
            }

            private void ReduceCountCoinsInStorage(IReadOnlyCollection<Coin> coins,
                IReadOnlyDictionary<Coin, uint> changeCoins)
            {
                foreach (var coin in coins)
                    if (coin.Storage is not null)
                        coin.Storage.Count -= changeCoins.SingleOrDefault(item => item.Key.Id == coin.Id).Value;
            }

            private async Task<bool> SaveChangesAsync(IReadOnlyCollection<Coin> coins, 
                IReadOnlyCollection<Beverage> beverages, CancellationToken cancellationToken = default)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        foreach (var coin in coins)
                            if (coin.Storage is not null)
                                _repository.Update(coin.Storage);

                        foreach (var beverage in beverages)
                            if (beverage.Storage is not null)
                                _repository.Update(beverage.Storage);

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
