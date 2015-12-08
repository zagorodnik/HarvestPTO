using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;
using VacationHarvest.BL;

namespace VacationHarvest
{
	/// <summary>
	/// Summary description for PtoDataHandler
	/// </summary>
	public class PtoDataHandler : IHttpHandler, IReadOnlySessionState
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			var harvestClient = (HarvestClient)context.Session[Constants.HARVEST_CLIENT];
			if (harvestClient == null)
			{
				context.Response.Write(JsonConvert.SerializeObject(new
				{
					timeOut = true
				}));
				return;
			}

			var entries = DataAccess.GetEntries(harvestClient);
			var calc = new VacationCalculator(entries);
			var result =  calc.Calculate(DateTime.Now);
			context.Response.Write(JsonConvert.SerializeObject(new
			{
				entries = result.Entries,
				hoursLeft = result.HoursLeft,
				sickHours = result.SickHours,
				unpaidHours = result.UnpaidHours,
				usedHours = result.UsedHours,
				startDate = entries.Min(e => e.SpentAt)
			}));
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}