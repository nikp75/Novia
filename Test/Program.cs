using System;
using Microsoft.Extensions.DependencyInjection;
using Test.Interfaces;

namespace Test
{
    class Program
    {
        const string resultOutput = "Result for stay beginning: {0} and ending: {1} is £{2}";
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IChargeFactory, ChargeFactory>()
                .AddSingleton<IChargeCalculator, ChargeCalculator>()
                .BuildServiceProvider();

            var chargeFactory = serviceProvider.GetService<IChargeFactory>();
            
            var stay1 = chargeFactory.GetCharge(Enums.StayType.ShortStay, new DateTime(2020, 3, 30, 19, 0, 0), new DateTime(2020, 3, 31, 7, 0, 0));
            var stay2 = chargeFactory.GetCharge(Enums.StayType.ShortStay, new DateTime(2017, 9, 7, 16, 50, 0), new DateTime(2017, 9, 9, 19, 15, 0));
            var stay3 = chargeFactory.GetCharge(Enums.StayType.LongStay, new DateTime(2017, 9, 7, 7, 50, 0), new DateTime(2017, 9, 9, 5, 20, 0));

            var chargeCalculator = serviceProvider.GetService<IChargeCalculator>();

            var resultForStay1 = chargeCalculator.Calculate(stay1);
            var resultForStay2 = chargeCalculator.Calculate(stay2);
            var resultForStay3 = chargeCalculator.Calculate(stay3);

            Console.WriteLine(string.Format(resultOutput, stay1.Start, stay1.End, resultForStay1));
            Console.WriteLine(string.Format(resultOutput, stay2.Start, stay2.End, resultForStay2));
            Console.WriteLine(string.Format(resultOutput, stay3.Start, stay3.End, resultForStay3));

            Console.ReadLine();
        }
    }
}
