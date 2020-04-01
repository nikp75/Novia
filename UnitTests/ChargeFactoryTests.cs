using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using Test.Charges;
using Test.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class ChargeFactoryTests
    {
        private IChargeFactory chargeFactory;

        [TestInitialize]
        public void Init()
        {
            chargeFactory = new ChargeFactory();
        }

        [TestMethod]
        public void Requests_ShortTerm_ReturnsShortTerm()
        {
            var charge = chargeFactory.GetCharge(Test.Enums.StayType.ShortStay, DateTime.Now, DateTime.Now);

            Assert.IsNotNull(charge);
            Assert.IsInstanceOfType(charge, typeof(ShortStay));
        }

        [TestMethod]
        public void Requests_LongTerm_ReturnsLongTerm()
        {
            var charge = chargeFactory.GetCharge(Test.Enums.StayType.LongStay, DateTime.Now, DateTime.Now);

            Assert.IsNotNull(charge);
            Assert.IsInstanceOfType(charge, typeof(LongStay));
        }
    }
}
