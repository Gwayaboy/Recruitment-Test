using GiftAidCalculator.Domain.Interfaces;

namespace GiftAidCalculator.Domain
{
    public class GiftAid
    {
        private readonly ITaxDataStore _taxDataStore;

        public GiftAid(ITaxDataStore taxDataStore)
        {
            _taxDataStore = taxDataStore;
        }

        public virtual decimal Calculate(decimal donationAmount)
        {
            return donationAmount * _taxDataStore.Current/(100 - _taxDataStore.Current);
        }
    }
}