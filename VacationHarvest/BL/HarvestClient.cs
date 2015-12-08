using Harvest.Net;

namespace VacationHarvest.BL
{
    public class HarvestClient
    {
        public HarvestClient(HarvestRestClient client, long userId)
        {
            Client = client;
            UserId = userId;
        }

        public HarvestRestClient Client { get; private set; }

        public long UserId { get; private set; }
    }
}