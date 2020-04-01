using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.ExtensionMethods;

namespace UnitTests
{
    [TestClass]
    public class DayOfWeekExtensionTests
    {
        [TestMethod]
        public void IsWeekend_WithSaturday_ReturnsTrue()
        {
            // arrange
            var saturday = DayOfWeek.Saturday;

            // act
            var isWeekend = saturday.IsWeekend();

            // assert
            Assert.IsTrue(isWeekend);
        }

        [TestMethod]
        public void IsWeekend_WithSunday_ReturnsTrue()
        {
            // arrange
            var sunday = DayOfWeek.Sunday;

            // act
            var isWeekend = sunday.IsWeekend();

            // assert
            Assert.IsTrue(isWeekend);
        }

        [TestMethod]
        public void IsWeekend_WithMonday_ReturnsFalse()
        {
            // arrange
            var day = DayOfWeek.Monday;

            // act
            var isWeekend = day.IsWeekend();

            // assert
            Assert.IsFalse(isWeekend);
        }

        [TestMethod]
        public void IsWeekend_WithTuesday_ReturnsFalse()
        {
            // arrange
            var day = DayOfWeek.Tuesday;

            // act
            var isWeekend = day.IsWeekend();

            // assert
            Assert.IsFalse(isWeekend);
        }

        [TestMethod]
        public void IsWeekend_WithWednesday_ReturnsFalse()
        {
            // arrange
            var day = DayOfWeek.Wednesday;

            // act
            var isWeekend = day.IsWeekend();

            // assert
            Assert.IsFalse(isWeekend);
        }

        [TestMethod]
        public void IsWeekend_WithThursday_ReturnsFalse()
        {
            // arrange
            var day = DayOfWeek.Thursday;

            // act
            var isWeekend = day.IsWeekend();

            // assert
            Assert.IsFalse(isWeekend);
        }

        [TestMethod]
        public void IsWeekend_WithFriday_ReturnsFalse()
        {
            // arrange
            var day = DayOfWeek.Friday;

            // act
            var isWeekend = day.IsWeekend();

            // assert
            Assert.IsFalse(isWeekend);
        }
    }
}
