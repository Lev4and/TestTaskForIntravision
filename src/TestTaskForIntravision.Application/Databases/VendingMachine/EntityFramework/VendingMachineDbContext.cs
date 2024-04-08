using Microsoft.EntityFrameworkCore;
using TestTaskForIntravision.Application.Extensions;
using TestTaskForIntravision.Domain.Entities;
using TestTaskForIntravision.Domain.Infrastructure.Databases;
using TestTaskForIntravision.Domain.Infrastructure.Databases.Transactions;
using TestTaskForIntravision.Infrastructure.Databases.EntityFramework.Transactions;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.EntityFramework
{
    public class VendingMachineDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Beverage> Beverages { get; set; }

        public DbSet<BeverageImage> BeverageImages { get; set; }

        public DbSet<Coin> Coins { get; set; }

        public DbSet<StorageBeverage> StorageBeverages { get; set; }

        public DbSet<StorageCoin> StorageCoins { get; set; }

        public VendingMachineDbContext(DbContextOptions options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public Task<IDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IDatabaseTransaction>(new EntityFrameworkRepeatableReadDatabaseTransaction());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Beverage>()
                .HasIndex(beverage => beverage.Title);

            modelBuilder.Entity<Beverage>()
                .HasIndex(beverage => beverage.Price);

            modelBuilder.Entity<Beverage>()
                .HasOne(beverage => beverage.Image)
                    .WithOne(image => image.Beverage)
                        .HasPrincipalKey<BeverageImage>(image => image.BeverageId);

            modelBuilder.Entity<Beverage>()
                .HasOne(beverage => beverage.Storage)
                    .WithOne(storage => storage.Beverage)
                        .HasPrincipalKey<StorageBeverage>(storage => storage.BeverageId);

            modelBuilder.Entity<Coin>()
                .HasIndex(coin => coin.Value);

            modelBuilder.Entity<Coin>()
                .HasOne(coin => coin.Storage)
                    .WithOne(storage => storage.Coin)
                        .HasPrincipalKey<StorageCoin>(storage => storage.CoinId);

            modelBuilder.Entity<StorageBeverage>()
                .HasIndex(storage => storage.Count);

            modelBuilder.Entity<StorageCoin>()
                .HasIndex(storage => storage.Count);

            modelBuilder.AddDefaultData();
        }
    }
}
