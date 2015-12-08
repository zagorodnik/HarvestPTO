using System;
using System.Collections.Generic;
using Harvest.Net.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VacationHarvest.BL;

namespace VacationHarvestTests
{
    [TestClass]
    public class NoLoggedEntriesTests
    {
        private VacationCalculator Target { get; set; }

        public NoLoggedEntriesTests()
        {
            Target = new VacationCalculator(new List<DayEntry>());
        }

        [TestMethod]
        public void YoungEmployeeOneMonthTillMonthEndTest()
        {
            var res = Target.Calculate(new DateTime(2015, 9, 11), new DateTime(2015, 10, 1));
            Assert.AreEqual(0m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeThreeMonthTest()
        {
            var res = Target.Calculate(new DateTime(2015, 9, 11), new DateTime(2016, 1, 1));
            Assert.AreEqual(20m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeFullYearTest()
        {
            var res = Target.Calculate(new DateTime(2014, 9, 1), new DateTime(2015, 9, 1));
            Assert.AreEqual(80m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeFullSixMonthTest()
        {
            var res = Target.Calculate(new DateTime(2014, 7, 1), new DateTime(2015, 1, 1));
            Assert.AreEqual(40m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeFullNineMonthTest()
        {
            var res = Target.Calculate(new DateTime(2014, 1, 1), new DateTime(2014, 10, 1));
            Assert.AreEqual(60m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeYearAndHalfNoUsedTest()
        {
            var res = Target.Calculate(new DateTime(2014, 7, 1), new DateTime(2016, 1, 1));
            Assert.AreEqual(96m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeMonthAndHalfTest()
        {
            var res = Target.Calculate(new DateTime(2015, 9, 11), new DateTime(2015, 11, 1));
            Assert.AreEqual(6.67m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeMonthAndHalfNotEndedTest()
        {
            var res = Target.Calculate(new DateTime(2015, 9, 11), new DateTime(2015, 10, 27));
            Assert.AreEqual(0m, res.HoursLeft);
        }
    }
}