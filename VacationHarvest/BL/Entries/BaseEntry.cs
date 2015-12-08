using System;
using System.Collections.Generic;
using Harvest.Net.Models;

namespace VacationHarvest.BL.Entries
{
    public abstract class BaseEntry
    {
		public PtoRecordType RecordType { get; protected set; }

	    protected BaseEntry()
	    {
		    RecordType = PtoRecordType.Default;
            NotesSet = new HashSet<string>();
        }

        protected BaseEntry(DayEntry dayEntry)
        {
            StartDate = dayEntry.SpentAt;
            EndDate = dayEntry.SpentAt;
            UsedHours = dayEntry.Hours;
            NotesSet = new HashSet<string> { dayEntry.Notes };
        }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Notes
        {
            get { return string.Join(";", NotesSet); }
        }

        public Decimal UsedHours { get; set; }

        public Decimal HoursLeft { get; set; }

        public HashSet<string> NotesSet { get; private set; }

        public BaseEntry Clone()
        {
            return (BaseEntry) MemberwiseClone();
        }

        public bool AddEntry(BaseEntry dayEntry)
        {
            if (FullDay(dayEntry) && IsNextWorkDay(dayEntry.StartDate) && GetType() == dayEntry.GetType())
            {
                EndDate = dayEntry.StartDate;
                NotesSet.Add(dayEntry.Notes);
                UsedHours += dayEntry.UsedHours;

                if (dayEntry.GetType() == typeof (VacationEntry))
                {
                    HoursLeft -= dayEntry.UsedHours;
                }
                return true;
            }
            return false;
        }

        private bool IsNextWorkDay(DateTime start)
        {
            return (start - EndDate <= TimeSpan.FromDays(1)) ||
                   ((start.DayOfWeek == DayOfWeek.Monday) && (start - EndDate <= TimeSpan.FromDays(3)));
        }

        private bool FullDay(BaseEntry dayEntry)
        {
            return (UsedHours + dayEntry.UsedHours)%VacationCalculator.FULL_DAY_HOURS == 0;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3:#.##}", StartDate, EndDate, UsedHours, HoursLeft);
        }
    }
}