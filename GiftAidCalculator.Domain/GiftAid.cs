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
            return EventType.CalculateSupplement(donationAmount * _taxDataStore.Current / (100 - _taxDataStore.Current));
        }

        public virtual void UpdateEventType(EventType eventType)
        {
            EventType = eventType;
        }
    }
}