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

            if (args.Any() && args.Contains("/admin"))
            {
                Console.WriteLine("Please Enter current tax percentage:");
                taxDataStore.SetCurrentTaxRate(decimal.Parse(Console.ReadLine()));
            }

            // Calc Gift Aid Based on Previous
            Console.WriteLine("Please Enter donation amount:");
            Console.WriteLine(gifAid.Calculate(decimal.Parse(Console.ReadLine())));
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}