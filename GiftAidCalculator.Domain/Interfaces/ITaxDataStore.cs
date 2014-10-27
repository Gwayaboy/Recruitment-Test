namespace GiftAidCalculator.Domain.Interfaces
{
    public interface ITaxDataStore
    {
        decimal Current { get; }
        void SetCurrentTaxRate(decimal taxRate);
    }
}