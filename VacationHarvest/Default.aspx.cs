using System;
using System.Web.UI;
using Harvest.Net.Models;
using VacationHarvest.BL;

namespace VacationHarvest
{
	public partial class _Default : Page
	{
		protected string FirstName { get; private set; }
		protected string LastName { get; private set; }

		protected string FullName
		{
			get { return string.Format("{0} {1}", FirstName, LastName); }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			var user = Session[Constants.ACCOUNT_USER] as AccountUser;
			if (user == null)
			{
				Response.Redirect("Account/Login");
				return;
			}

			FirstName = user.FirstName;
			LastName = user.LastName;
		}
	}
}