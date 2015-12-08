using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Harvest.Net;
using Harvest.Net.Models;

namespace VacationHarvest.BL
{
    public class DataAccess
    {
        public static IList<DayEntry> GetEntries(HarvestClient harvestClient)
        {
            var entriesBag = new ConcurrentBag<DayEntry>();
            Parallel.ForEach(PartitionTimePeriod(new DateTime(2005, 1, 1), DateTime.Now), part =>
            {
                foreach (var dayEntry in harvestClient.Client.ListUserEntries(harvestClient.UserId, part.Item1, part.Item2))
                {
                    entriesBag.Add(dayEntry);
                }
            });
            return entriesBag.OrderBy(e => e.SpentAt).ToList();
        }

        private static IEnumerable<Tuple<DateTime, DateTime>> PartitionTimePeriod(DateTime start, DateTime end)
        {
            for (var date = start; date < end; date = date.AddMonths(12))
            {
                yield return Tuple.Create(date, date.AddMonths(12).AddDays(-1));
            }
        }
    }
}