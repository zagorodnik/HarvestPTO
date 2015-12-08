using System.Collections.Generic;
using Harvest.Net.Models;

namespace VacationHarvest.BL.Entries
{
    public class VacationEntryFactory
    {
        public static IEnumerable<BaseEntry> Group(IEnumerable<DayEntry> dayEntries, decimal startMonthVacation)
        {
            decimal usedHours = 0;
            BaseEntry currEntry = null;
            foreach (var dayEntry in dayEntries)
            {
                if (dayEntry.PaidByArrow())
                {
                    usedHours += dayEntry.Hours;
                }
                
                if (currEntry == null)
                {
                    currEntry = BuildEntry(dayEntry);
                    currEntry.HoursLeft = startMonthVacation - usedHours;
                }
                else
                {
                    var nextEntry = BuildEntry(dayEntry);
                    if (!currEntry.AddEntry(nextEntry))
                    {
                        yield return currEntry.Clone();
                        currEntry = nextEntry;
                        currEntry.HoursLeft = startMonthVacation - usedHours;
                    }
                }
            }
            if (currEntry != null)
                yield return currEntry;
        }

        private static BaseEntry BuildEntry(DayEntry dayEntry)
        {
            if (dayEntry.IsSickness())
                return new SickLeaveEntry(dayEntry);
            if (dayEntry.IsUnpaid())
                return new UnpaidEntry(dayEntry);
            return new VacationEntry(dayEntry);
        }
    }
}