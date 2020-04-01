using System;
using Test.Charges;
using Test.Interfaces;

namespace Test
{
    public class ChargeCalculator : IChargeCalculator
    {
        public decimal Calculate(BaseStay stayBeingChargedFor)
        {
            if (stayBeingChargedFor == null)
            {
                throw new NullReferenceException("No valid stay object provided");
            }

            var numberOfUnits = stayBeingChargedFor.UnitsToCharge;
            var chargePerUnit = stayBeingChargedFor.Cost;

            return ((decimal)numberOfUnits) * chargePerUnit;
        }
    }
}