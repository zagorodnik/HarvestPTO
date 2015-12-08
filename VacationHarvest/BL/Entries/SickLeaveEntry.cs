using Harvest.Net.Models;

namespace VacationHarvest.BL.Entries
{
    public class SickLeaveEntry : BaseEntry
    {
        public SickLeaveEntry(DayEntry dayEntry)
            : base(dayEntry)
        {
			RecordType = PtoRecordType.SickLeave;
		}
    }
}