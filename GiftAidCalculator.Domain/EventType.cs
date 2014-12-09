using System.Collections.Generic;

namespace GiftAidCalculator.Domain
{
    public sealed class EventType
    {
        public readonly static EventType Running = new EventType(1,"running",5m);
        public readonly static EventType Swimming = new EventType(2,"swimming",3m);
        public readonly static EventType Others = new EventType(3,"others");

        public EventType()
        {
            
        }

        public EventType(int id,string name, decimal percentage  = 0m)
        {
            Id = id;
            Name = name;
            Percentage = percentage;
        }

        public static IEnumerable<EventType> All
        {
            get
            {
                return new[]
                {
                    Running,
                    Swimming,
                    Others
                };
            }
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Percentage { get; set; }

        public decimal CalculateSupplement(decimal originalAmount)
        {
            return originalAmount * ((Percentage / 100) + 1);
        }
    }
}