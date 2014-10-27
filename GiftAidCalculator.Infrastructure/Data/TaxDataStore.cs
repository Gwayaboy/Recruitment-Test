using System;
using System.Collections.Generic;
using GiftAidCalculator.Domain;
using GiftAidCalculator.Domain.Interfaces;

namespace GiftAidCalculator.Infrastructure.Data
{
    public class TaxDataStore : ITaxDataStore
    {
        public TaxDataStore()
        {
            Current = 20m;
        }

        public virtual decimal Current { get; private set; }

        public void SetCurrentTaxRate(decimal taxRate)
        {
            //Here some business rule or validation can be applied concerning what rates are allowed
            Current = taxRate;
        }
    }
}