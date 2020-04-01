using System;
using Test.ExtensionMethods;

namespace Test.Charges
{
    public class ShortStay : BaseStay
    {
        // sets constants for start and end times - easily changed if necessary (e.g. by config if desired)
        private const int chargeableStart = 8;
        private const int chargeableEnd = 18;
        private const decimal costPerUnit = 1.1M;

        public ShortStay(
            DateTime start,
            DateTime end) : base(start, end, costPerUnit)
        {
        }

        protected override void CalculateUnits()
        {
            var tempStartDateTime = CheckAndFixStart();
            var tempEndDateTime = CheckAndFixEnd();

            var numberOfDays = (tempEndDateTime - tempStartDateTime).Days - 1;

            var startHourAsDecimal = (decimal)tempStartDateTime.Hour + (((decimal)tempStartDateTime.Minute) / 60);
            var endHourAsDecimal = (decimal)tempEndDateTime.Hour + (((decimal)tempEndDateTime.Minute) / 60);

            var hoursToChargeFor = 0.0M;

            if (End.Date > Start.Date)
            {
                hoursToChargeFor = chargeableEnd - startHourAsDecimal;
                hoursToChargeFor = hoursToChargeFor + (endHourAsDecimal - chargeableStart);
                hoursToChargeFor = (numberOfDays * (chargeableEnd - chargeableStart)) + hoursToChargeFor;
            }
            else
            {
                hoursToChargeFor = endHourAsDecimal - startHourAsDecimal;
            }

            UnitsToCharge = hoursToChargeFor;

            if (UnitsToCharge < 0)
            {
                UnitsToCharge = 0;
            }
        }

        private DateTime CheckAndFixStart()
        {
            var tempStart = Start;
            var resetToBeginningOfDay = false;

            // number of hours from beginning
            if (tempStart.DayOfWeek == DayOfWeek.Saturday)
            {
                // increment start to earliest chargeable point on monday
                tempStart = tempStart.AddDays(2);
                resetToBeginningOfDay = true;
            }

            if (Start.DayOfWeek == DayOfWeek.Sunday)
            {
                // increment start to earliest chargeable point on monday
                tempStart = tempStart.AddDays(1);
                resetToBeginningOfDay = true;
            }

            resetToBeginningOfDay = resetToBeginningOfDay || 
                (!tempStart.DayOfWeek.IsWeekend() && (tempStart.Hour < chargeableStart));

            if (resetToBeginningOfDay)
            {
                tempStart = new DateTime(tempStart.Year, tempStart.Month, tempStart.Day, chargeableStart, 0, 0);
            }

            return tempStart;
        }

        private DateTime CheckAndFixEnd()
        {
            var tempEnd = End;
            var resetToEndOfDay = false;

            if (End.DayOfWeek == DayOfWeek.Saturday)
            {
                tempEnd = tempEnd.AddDays(-1);
                resetToEndOfDay = true;
            }

            if (End.DayOfWeek == DayOfWeek.Sunday)
            {
                tempEnd = tempEnd.AddDays(-2);
                resetToEndOfDay = true;
            }

            resetToEndOfDay = resetToEndOfDay || 
                (!tempEnd.DayOfWeek.IsWeekend() && (tempEnd.Hour > chargeableEnd || (tempEnd.Hour == chargeableEnd && tempEnd.Minute > 0)));

            if (resetToEndOfDay)
            {
                tempEnd = new DateTime(tempEnd.Year, tempEnd.Month, tempEnd.Day, chargeableEnd, 0, 0);
            }

            return tempEnd;
        }
    }
}
