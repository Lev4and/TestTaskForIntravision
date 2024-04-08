namespace TestTaskForIntravision.Domain.Entities
{
    public class BeverageImage : Entity
    {
        public Guid BeverageId { get; set; }

        public string Url { get; set; }

        public Beverage? Beverage { get; set; }
    }
}
