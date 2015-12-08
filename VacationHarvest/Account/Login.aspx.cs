using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Harvest.Net;
using VacationHarvest.BL;

namespace VacationHarvest.Account
{
    public partial class Login : Page
    {
        private const string COMPANY_NAME = "arrowdesigns";

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var client = new HarvestRestClient(COMPANY_NAME, Email.Text, Password.Text);
                var acc = client.WhoAmI();
                if (acc != null)
                {
	                Session[Constants.ACCOUNT_USER] = acc.User;
                    Session[Constants.HARVEST_CLIENT] = new HarvestClient(client, acc.User.Id);
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}