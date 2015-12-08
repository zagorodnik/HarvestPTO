using Harvest.Net.Models;

namespace VacationHarvest.BL.Entries
{
    public class UnpaidEntry : BaseEntry
    {
        public UnpaidEntry(DayEntry dayEntry)
            : base(dayEntry)
        {
			RecordType = PtoRecordType.Unpaid;
		}
    }
}