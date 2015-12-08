using Harvest.Net.Models;

namespace VacationHarvest.BL
{
    public static class StaticExtensions
    {
        public static bool IsSickness(this DayEntry dayEntry)
        {
            return !string.IsNullOrEmpty(dayEntry.Notes) && dayEntry.Notes.Contains(Constants.SICK_LEAVE);
        }

        public static bool IsUnpaid(this DayEntry dayEntry)
        {
            return !string.IsNullOrEmpty(dayEntry.Notes) && dayEntry.Notes.Contains(Constants.UNPAID);
        }

        public static bool PaidByArrow(this DayEntry dayEntry)
        {
            return !dayEntry.IsSickness() && !dayEntry.IsUnpaid();
        }
    }
}