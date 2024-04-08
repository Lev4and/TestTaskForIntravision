using TestTaskForIntravision.Domain.Entities;

namespace TestTaskForIntravision.Application.Databases.VendingMachine.DefaultData
{
    public class Coins : List<Coin>
    {
        public Coins()
        {
            Add(new Coin
            {
                Id = Guid.Parse("d32859c5-e579-47ed-bea9-afcf252ed0fd"),
                Value = 1,
                Storage = new StorageCoin
                {
                    Id = Guid.Parse("ef503d11-c3f6-4275-919a-204d21dc565e"),
                    IsBlockedForDeposit = false,
                    Count = 100
                }
            });

            Add(new Coin
            {
                Id = Guid.Parse("82e050b3-dce3-4d56-a95c-b62911867fe2"),
                Value = 2,
                Storage = new StorageCoin
                {
                    Id = Guid.Parse("e876e3c9-fa62-4889-9491-6a21484195cc"),
                    IsBlockedForDeposit = false,
                    Count = 75
                }
            });

            Add(new Coin
            {
                Id = Guid.Parse("406ee996-3552-4bfb-9d3a-b149d99b2a47"),
                Value = 5,
                Storage = new StorageCoin
                {
                    Id = Guid.Parse("5da7221e-efaf-45dc-9ab8-8de83bee6e7e"),
                    IsBlockedForDeposit = true,
                    Count = 50
                }
            });

            Add(new Coin
            {
                Id = Guid.Parse("238bcf95-3380-4dde-b878-f3de87e11cd6"),
                Value = 10,
                Storage = new StorageCoin
                {
                    Id = Guid.Parse("1afff46c-eb57-46a3-80ef-62988a93aba1"),
                    IsBlockedForDeposit = false,
                    Count = 25
                }
            });
        }
    }
}
