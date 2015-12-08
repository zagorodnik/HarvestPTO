using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VacationHarvest.BL;
using VacationHarvest.BL.Entries;

namespace VacationHarvestTests
{
    [TestClass]
    public class VacationCalculatorTest
    {
        [TestMethod]
        public void OldEmployeeTotalHoursTest()
        {
            var target = new VacationCalculator(DailyEntriesFactory.GetOldEmployeeEntries());
            var res = target.Calculate(new DateTime(2015, 9, 24));
            Assert.AreEqual(328m, res.UsedHours);
            Assert.AreEqual(87.33m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeBurnedVacationTest()
        {
            var target = new VacationCalculator(DailyEntriesFactory.GetYoungEmployeeEntries());
            var res = target.Calculate(new DateTime(2015, 7, 1));
            Assert.AreEqual(16m, res.UsedHours);
            Assert.AreEqual(96m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeNotBurnedVacationTest()
        {
            var target = new VacationCalculator(DailyEntriesFactory.GetYoungEmployeeEntries());
            var res = target.Calculate(new DateTime(2015, 4, 1));
            Assert.AreEqual(16m, res.UsedHours);
            Assert.AreEqual(84m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeLastMonthVacationTest()
        {
            var target = new VacationCalculator(DailyEntriesFactory.GetYoungEmployeeEntries());
            var res = target.Calculate(new DateTime(2015, 1, 16));
            Assert.AreEqual(16m, res.UsedHours);
            Assert.AreEqual(64m, res.HoursLeft);
        }

        [TestMethod]
        public void YoungEmployeeUnpaidAndSickTest()
        {
            var target = new VacationCalculator(DailyEntriesFactory.GetYoungEmployeeUnpaidAndSick());
            var res = target.Calculate(new DateTime(2015, 1, 16));
            Assert.AreEqual(16, res.Entries.Count);
            Assert.IsTrue(res.Entries[13] is VacationEntry);
            Assert.IsTrue(res.Entries[14] is SickLeaveEntry);
            Assert.IsTrue(res.Entries[15] is UnpaidEntry);
            Assert.AreEqual(64m, res.HoursLeft);
        }
    }
}
