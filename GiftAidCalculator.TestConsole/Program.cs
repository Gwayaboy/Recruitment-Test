using System;
using System.Linq;
using GiftAidCalculator.Domain;
using GiftAidCalculator.Domain.Interfaces;
using GiftAidCalculator.Infrastructure.Data;

namespace GiftAidCalculator.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ITaxDataStore taxDataStore = new TaxDataStore();
            var gifAid = args != null && args.Contains("/donor")
                ? new DonorGiftAid(taxDataStore)
                : new GiftAid(taxDataStore);

            if (args.Any())
            {
                if (args.Contains("/admin"))
                {
                    Console.WriteLine("Please Enter current tax percentage:");
                    taxDataStore.SetCurrentTaxRate(decimal.Parse(Console.ReadLine()));
                    Console.WriteLine();
                }
                else if (args.Contains("/eventPromoter"))
                {
                    Console.WriteLine("Choose an event type to promote:");

                    foreach (var eventType in EventType.All)
                    {
                        Console.WriteLine("- {0}. {1}",eventType.Id, eventType.Name);
                    }
                    var eventId = int.Parse(Console.ReadLine());
                    var selectedEventType = EventType.All.SingleOrDefault(e => e.Id == eventId);
                    gifAid.UpdateEventType(selectedEventType);
                    Console.WriteLine();
                }
            }

            // Calc Gift Aid Based on Previous
            Console.WriteLine("Please Enter donation amount:");
            Console.WriteLine("\nYour gift aid amount is : {0}",gifAid.Calculate(decimal.Parse(Console.ReadLine())));
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}