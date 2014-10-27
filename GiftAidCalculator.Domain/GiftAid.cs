namespace GiftAidCalculator.Domain
{
    public class GiftAid
    {
        public decimal TaxPercentage { get; private set; }

        public GiftAid(decimal taxPercentage)
        {
            TaxPercentage = taxPercentage;
        }

        public decimal Calculate(decimal donationAmount)
        {
            return donationAmount * TaxPercentage / (100 - TaxPercentage);
        }
    }
}