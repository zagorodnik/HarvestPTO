using System.Collections.Generic;
using VacationHarvest.BL.Entries;

namespace VacationHarvest.BL
{
    public class VacationResult
    {
        public VacationResult()
        {
            Entries = new List<BaseEntry>();
        }

        public List<BaseEntry> Entries { get; set; }

        public decimal UsedHours { get; set; }

        public decimal HoursLeft { get; set; }

        public decimal SickHours { get; set; }

        public decimal UnpaidHours { get; set; }

        public void AddVacationResult(VacationResult vacMonthlyRes)
        {
            UsedHours += vacMonthlyRes.UsedHours;
            Entries.AddRange(vacMonthlyRes.Entries);
            HoursLeft = vacMonthlyRes.HoursLeft;
        }
    }
}