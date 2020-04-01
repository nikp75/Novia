using System;

namespace Test.Charges
{
    public class LongStay : BaseStay
    {
        private const decimal costPerUnit = 7.5M;
        public LongStay(
            DateTime start,
            DateTime end) : base(start, end, costPerUnit)
        {
        }

        protected override void CalculateUnits()
        {
            // start is beginning of day
            var tempStart = new DateTime(Start.Year, Start.Month, Start.Day);

            // end is beginning of next day of the current end date
            var tempEnd = new DateTime(End.Year, End.Month, End.Day);

            // need to add day here, rather than above, as may be end of the month
            tempEnd = tempEnd.AddDays(1);

            var timespan = tempEnd - tempStart;

            UnitsToCharge = timespan.Days; // adding one because the day we start on is chargeable too
        }
    }
}
