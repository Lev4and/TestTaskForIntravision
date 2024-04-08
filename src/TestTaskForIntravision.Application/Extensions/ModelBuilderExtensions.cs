using Microsoft.EntityFrameworkCore;
using TestTaskForIntravision.Application.Databases.VendingMachine.DefaultData;
using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Application.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddDefaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddCoins();
            modelBuilder.AddBeverages();

            return modelBuilder;
        }

        private static ModelBuilder AddCoins(this ModelBuilder modelBuilder)
        {
            var coins = new Coins();

            foreach(var coin in coins)
            {
                modelBuilder.AddCoin(coin);
            }

            return modelBuilder;
        }

        private static ModelBuilder AddCoin(this ModelBuilder modelBuilder, Coin coin)
        {
            modelBuilder.Entity<Coin>().HasData(
                new Coin
                {
                    Id = coin.Id,
                    Value = coin.Value
                });

            if (coin.Storage is not null)
            {
                modelBuilder.Entity<StorageCoin>().HasData(
                    new StorageCoin
                    {
                        Id = coin.Storage.Id,
                        CoinId = coin.Id,
                        IsBlockedForDeposit = coin.Storage.IsBlockedForDeposit,
                        Count = coin.Storage.Count
                    });
            }

            return modelBuilder;
        }

        private static ModelBuilder AddBeverages(this ModelBuilder modelBuilder) 
        {
            var beverages = new Beverages();

            foreach (var beverage in beverages)
            {
                modelBuilder.AddBeverage(beverage);
            }

            return modelBuilder;
        }

        private static ModelBuilder AddBeverage(this ModelBuilder modelBuilder, Beverage beverage)
        {
            modelBuilder.Entity<Beverage>().HasData(
                new Beverage
                {
                    Id = beverage.Id,
                    Title = beverage.Title,
                    Price = beverage.Price,
                });

            if (beverage.Image is not null)
            {
                modelBuilder.Entity<BeverageImage>().HasData(
                    new BeverageImage
                    {
                        Id = beverage.Image.Id,
                        BeverageId = beverage.Id,
                        Url = beverage.Image.Url,
                    });
            }

            if (beverage.Storage is not null)
            {
                modelBuilder.Entity<StorageBeverage>().HasData(
                    new StorageBeverage
                    {
                        Id = beverage.Storage.Id,
                        BeverageId = beverage.Id,
                        Count = beverage.Storage.Count,
                    });
            }

            return modelBuilder;
        }
    }
}
