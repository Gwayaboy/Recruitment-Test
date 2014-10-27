using System;
using GiftAidCalculator.Domain.Interfaces;

namespace GiftAidCalculator.Domain
{
    public class GiftAid
    {
        private readonly ITaxDataStore _taxDataStore;

        public GiftAid(ITaxDataStore taxDataStore)
        {
            _taxDataStore = taxDataStore;
            EventType = EventType.Others;
        }

        public EventType EventType { get; private set; }

        public virtual decimal Calculate(decimal donationAmount)
        {
            return AddEventTypeSupplement(donationAmount * _taxDataStore.Current / (100 - _taxDataStore.Current));
        }

        private decimal AddEventTypeSupplement(decimal originalAmount)
        {
            return originalAmount * ((EventType.Percentage /100) + 1);
        }

        public void UpdateEventType(EventType eventType)
        {
            EventType = eventType;
        }
    }
}