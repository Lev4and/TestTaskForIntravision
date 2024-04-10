namespace TestTaskForIntravision.Application.DTOs
{
    public class BuyBeveragesDto
    {
        public IReadOnlyDictionary<Guid, uint> DepositedCoins { get; }

        public IReadOnlyDictionary<Guid, uint> SelectedBeverages { get; }

        public BuyBeveragesDto(IReadOnlyDictionary<Guid, uint> depositedCoins, 
            IReadOnlyDictionary<Guid, uint> SelectedBeverages)
        {
            DepositedCoins = depositedCoins;
            this.SelectedBeverages = SelectedBeverages;
        }
    }
}
