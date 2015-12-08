using System;

namespace VacationHarvest.BL
{
    [Flags]
    public enum FilterOptions
    {
        None = 0,
        NewMonth = 1,
        Vacation = 2,
        SickLeave = 4,
        Unpaid = 8,
        All = NewMonth | Vacation | SickLeave | Unpaid
    }
}