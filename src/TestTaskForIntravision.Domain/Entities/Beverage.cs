namespace TestTaskForIntravision.Domain.Entities
{
    public class Beverage : Entity
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public BeverageImage? Image { get; set; }

        public StorageBeverage? Storage { get; set; }
    }
}
