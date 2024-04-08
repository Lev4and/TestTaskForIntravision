namespace TestTaskForIntravision.Domain.Entities
{
    public class Coin : Entity
    {
        public decimal Value { get; set; }

        public StorageCoin? Storage { get; set; }
    }
}
