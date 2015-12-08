using Harvest.Net.Models;

namespace VacationHarvest.BL.Entries
{
    public class VacationEntry : BaseEntry
    {
        public VacationEntry(DayEntry dayEntry)
            : base (dayEntry)
        {
			RecordType = PtoRecordType.Vacation;
		}
    }
}