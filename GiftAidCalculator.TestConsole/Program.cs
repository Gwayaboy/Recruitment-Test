using System;
using GiftAidCalculator.Domain;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
		    var gifAid = new GiftAid(20);
			// Calc Gift Aid Based on Previous
			Console.WriteLine("Please Enter donation amount:");
            Console.WriteLine(gifAid.Calculate(decimal.Parse(Console.ReadLine())));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}

	}
}
