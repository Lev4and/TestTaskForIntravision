namespace TestTaskForIntravision.Domain.Entities
{
    public class StorageBeverage : Entity
    {
        public Guid BeverageId { get; set; }

        public uint Count { get; set; }

        public Beverage? Beverage { get; set; }
    }
}
