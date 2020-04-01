using System;
using Test.Charges;
using Test.Enums;
using Test.Interfaces;

namespace Test
{
    public class ChargeFactory : IChargeFactory
    {
        public BaseStay GetCharge(StayType stayType, DateTime start, DateTime end)
        {
            switch (stayType)
            {
                case StayType.ShortStay:
                    return new ShortStay(start, end);
                case StayType.LongStay:
                    return new LongStay(start, end);
                default:
                    throw new InvalidOperationException($"Invalid stay type. Provided: {stayType}");
            }
        }
    }
}
