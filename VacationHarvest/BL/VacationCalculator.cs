using System;
using System.Collections.Generic;
using System.Linq;
using Harvest.Net.Models;
using VacationHarvest.BL.Entries;

namespace VacationHarvest.BL
{
    public class VacationCalculator
    {
        public const decimal FULL_DAY_HOURS = 8;
        public const int PERSONAL_TIME_OFF = 1827252, VACATION = 70795;

        private const int OLD_EMPLOYEE_VACATION_DAYS_PER_YEAR = 15;
        private const int YOUNG_EMPLOYEE_VACATION_DAYS_PER_YEAR = 10;
        private const int MAX_DAYS_DELTA = 2;
        private const int YEARS_OF_WORK_BREAKPOINT = 5;
        private const int MONTH_IN_YEAR = 12;

        private readonly IList<DayEntry> entries;
        private readonly ILookup<Tuple<int, int>, DayEntry> entriesLookup;

        public VacationCalculator(IList<DayEntry> entries)
        {
            this.entries = entries;
            entriesLookup = entries.ToLookup(k => Tuple.Create(k.SpentAt.Year, k.SpentAt.Month));
        }

        public VacationResult Calculate(DateTime endTime)
        {
            var startTime = entries.First().SpentAt;
            return Calculate(startTime, endTime);
        }

        public VacationResult Calculate(DateTime startTime, DateTime endTime)
        {
            return GetHoursLeft(startTime, endTime);
        }

        private VacationResult GetHoursLeft(DateTime startTime, DateTime endTime)
        {
            var vacRes = new VacationResult();
            var start = StartOfMonth(startTime) != startTime ? StartOfMonth(startTime).AddMonths(1) : startTime;
            for (var date = start; date < endTime; date = date.AddMonths(1))
            {
                var newMonthEntry = new NewMonthEntry(date, vacRes.HoursLeft);
                vacRes.Entries.Add(newMonthEntry);

                var shouldIncrementForLastMonth = endTime == StartOfMonth(endTime) || date.AddMonths(1) < endTime;
                var vacMonthlyRes = GetVacationHours(
                    vacRes.HoursLeft, date, GetVacationDaysPerYear(date, start), shouldIncrementForLastMonth);
                vacRes.AddVacationResult(vacMonthlyRes);
            }
            vacRes.HoursLeft = Math.Round(vacRes.HoursLeft, 2);
            vacRes.SickHours = entries.Where(e => e.IsSickness()).Sum(e => e.Hours);
            vacRes.UnpaidHours = entries.Where(e => e.IsUnpaid()).Sum(e => e.Hours);
            return vacRes;
        }

        private static int GetVacationDaysPerYear(DateTime currDate, DateTime start)
        {
            return currDate <= start.AddYears(YEARS_OF_WORK_BREAKPOINT) ? YOUNG_EMPLOYEE_VACATION_DAYS_PER_YEAR : OLD_EMPLOYEE_VACATION_DAYS_PER_YEAR;
        }

        private VacationResult GetVacationHours(decimal vacation, DateTime date, int vacationDaysPerYear, bool shouldIncrementForLastMonth)
        {
            var pto = FilterPto(entriesLookup[Tuple.Create(date.Year, date.Month)]).ToList();
            var paidHours = pto.Where(e => e.PaidByArrow()).Sum(e => e.Hours);

            var startMonthVacation = vacation;
            vacation += shouldIncrementForLastMonth ? vacationDaysPerYear*FULL_DAY_HOURS/MONTH_IN_YEAR : 0;
            vacation -= paidHours;
            vacation = Math.Min(vacation, (MAX_DAYS_DELTA + vacationDaysPerYear)*FULL_DAY_HOURS);
            return new VacationResult
            {
                Entries = VacationEntryFactory.Group(pto, startMonthVacation).ToList(),
                HoursLeft = vacation,
                UsedHours = paidHours
            };
        }

        private DateTime StartOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        private static IEnumerable<DayEntry> FilterPto(IEnumerable<DayEntry> entries)
        {
            return entries.Where(e => e.TaskId == PERSONAL_TIME_OFF || e.TaskId == VACATION).ToList();
        }
    }
}