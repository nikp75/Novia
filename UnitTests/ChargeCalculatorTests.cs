using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using Test.Charges;
using Test.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class ChargeCalculatorTests
    {
        private IChargeCalculator chargeCalculator;

        [TestInitialize]
        public void Init()
        {
            chargeCalculator = new ChargeCalculator();
        }

        [TestMethod]
        public void Calculate_WithShortStayForWholeDay_ReturnsCorrectCharge()
        {
            // arrange
            var start = new DateTime(2020, 4, 1, 8, 0, 0);
            var end = new DateTime(2020, 4, 1, 18, 0, 0);
            var stay = new ShortStay(start, end);

            // act
            var charge = chargeCalculator.Calculate(stay);

            // assert
            // charge should be 10hours * 1.1 = £11
            Assert.IsTrue(charge == 11M);
        }

        [TestMethod]
        public void Calculate_WithStartHourBeforeChargeablePeriodAndEndHourAtEnd_ReturnsCorrectCharge()
        {
            // arrange
            var start = new DateTime(2020, 4, 1, 0, 0, 0);
            var end = new DateTime(2020, 4, 1, 18, 0, 0);
            var stay = new ShortStay(start, end);

            // act
            var charge = chargeCalculator.Calculate(stay);

            // assert
            // charge should be 10hours * 1.1 = £11
            Assert.IsTrue(charge == 11M);
        }

        [TestMethod]
        public void Calculate_WithEndHourAfterChargeablePeriodAndStartHourAtStart_ReturnsCorrectCharge()
        {
            // arrange
            var start = new DateTime(2020, 4, 1, 0, 0, 0);
            var end = new DateTime(2020, 4, 1, 23, 59, 59);
            var stay = new ShortStay(start, end);

            // act
            var charge = chargeCalculator.Calculate(stay);

            // assert
            // charge should be 10hours * 1.1 = £11
            Assert.IsTrue(charge == 11M);
        }

        [TestMethod]
        public void Calculate_WithLongStayFromMidnightToEndOfCurrentDay_ReturnsCorrectCharge()
        {
            // arrange
            var start = new DateTime(2020, 3, 30);
            var end = new DateTime(2020, 3, 30, 23, 59, 59);
            var stay = new LongStay(start, end);

            // act
            var charge = chargeCalculator.Calculate(stay);

            // assert
            // charge should be for one full day: £7.5
            Assert.IsTrue(charge == 7.5M);
        }

        [TestMethod]
        public void Calculate_WithLongStayFromSundayToTuesday_ReturnsCorrectCharge()
        {
            // arrange
            var start = new DateTime(2020, 4, 5);
            var end = new DateTime(2020, 4, 7);
            var stay = new LongStay(start, end);

            // act
            var charge = chargeCalculator.Calculate(stay);

            // assert
            // charge should be for 3 full days: £7.5
            Assert.IsTrue(charge == 22.5M);
        }
    }
}
