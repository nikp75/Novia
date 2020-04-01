using System;
using Test.Charges;
using Test.Enums;

namespace Test.Interfaces
{
    public interface IChargeFactory
    {
        BaseStay GetCharge(StayType stayType, DateTime start, DateTime end);
    }
}
