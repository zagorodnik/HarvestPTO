using System;

namespace VacationHarvest.BL.Entries
{
    public class NewMonthEntry : BaseEntry
    {
        public NewMonthEntry(DateTime start, decimal hoursLeft)
        {
			RecordType = PtoRecordType.NewMonth;
			StartDate = start;
            HoursLeft = hoursLeft;
            NotesSet.Add("New month started");
        }
    }
}