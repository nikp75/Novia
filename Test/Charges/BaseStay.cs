using System;

namespace Test.Charges
{
    public abstract class BaseStay
    {
        public DateTime Start { get; protected set; }

        public DateTime End { get; protected set; }

        public decimal UnitsToCharge { get; protected set; }

        public decimal Cost { get; private set; }

        public BaseStay(
            DateTime start,
            DateTime end,
            decimal cost)
        {
            this.Start = start;
            this.End = end;
            this.Cost = cost;

            CalculateUnits();
        }

        protected abstract void CalculateUnits();
    }
}