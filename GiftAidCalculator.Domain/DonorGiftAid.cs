using System;
using GiftAidCalculator.Domain.Interfaces;

namespace GiftAidCalculator.Domain
{
    public class DonorGiftAid : GiftAid
    {
        public DonorGiftAid(ITaxDataStore taxDataStore) : base(taxDataStore)
        {
        }

        public override decimal Calculate(decimal donationAmount)
        {
            return Math.Round(base.Calculate(donationAmount), 2);
        }
    }
}