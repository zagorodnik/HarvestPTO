using System;
using System.Collections.Generic;
using Harvest.Net.Models;
using VacationHarvest.BL;

namespace VacationHarvestTests
{
    public class DailyEntriesFactory
    {
        public static IList<DayEntry> GetOldEmployeeEntries()
        {
            return new List<DayEntry>
            {
                new DayEntry { SpentAt = new DateTime(2008, 10, 14) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 7, 27) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 7, 30) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 17) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 18) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 19) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 22) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 23) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 24) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 25) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 26) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 29) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 30) },
                new DayEntry { TaskId = VacationCalculator.VACATION, Hours = 8, SpentAt = new DateTime(2012, 10, 31) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2013, 5, 24) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2013, 5, 27) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2013, 5, 28) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2013, 5, 29) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2013, 5, 30) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2013, 5, 31) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 3, SpentAt = new DateTime(2013, 11, 20) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 3, SpentAt = new DateTime(2013, 12, 23) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 4, SpentAt = new DateTime(2014, 3, 24) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 4, 21) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 4, 22) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 5, 1) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 5, 2) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 6, 9) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 3, SpentAt = new DateTime(2014, 7, 10) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 8, 8) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2014, 11, 11) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 2, SpentAt = new DateTime(2014, 11, 12) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 1, 1) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 3, SpentAt = new DateTime(2015, 1, 9) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 2, 16) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 4, SpentAt = new DateTime(2015, 4, 7) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 4, SpentAt = new DateTime(2015, 4, 23) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 4, 24) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 5, 4) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 3, SpentAt = new DateTime(2015, 6, 24) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 7, 30) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 7, 31) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 8, 3) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 8, 4) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 8, 5) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 8, 6) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 8, 7) },
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 3, SpentAt = new DateTime(2015, 8, 14) },
            };
        }

        public static IList<DayEntry> GetYoungEmployeeEntries()
        {
            return new List<DayEntry>
            {
                new DayEntry { SpentAt = new DateTime(2014, 1, 1)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 1, 1)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 1, 2)}
            };
        }

        public static IList<DayEntry> GetYoungEmployeeUnpaidAndSick()
        {
            return new List<DayEntry>
            {
                new DayEntry { SpentAt = new DateTime(2014, 1, 1)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 1, 1)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, SpentAt = new DateTime(2015, 1, 2)},
                new DayEntry { TaskId = 1, Hours = 8, SpentAt = new DateTime(2015, 1, 5)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, Notes = "Sick leave", SpentAt = new DateTime(2015, 1, 6)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, Notes = "Sick leave", SpentAt = new DateTime(2015, 1, 7)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, Notes = "Unpaid", SpentAt = new DateTime(2015, 1, 8)},
                new DayEntry { TaskId = VacationCalculator.PERSONAL_TIME_OFF, Hours = 8, Notes = "Unpaid", SpentAt = new DateTime(2015, 1, 9)},
            };
        }
    }
}