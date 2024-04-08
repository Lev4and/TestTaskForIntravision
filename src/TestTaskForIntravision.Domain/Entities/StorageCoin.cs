namespace TestTaskForIntravision.Domain.Entities
{
    public class StorageCoin : Entity
    {
        public Guid CoinId { get; set; }

        public bool IsBlockedForDeposit { get; set; }

        public uint Count { get; set; }

        public Coin? Coin { get; set; }
    }
}
