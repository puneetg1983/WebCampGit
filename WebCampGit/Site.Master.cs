using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetProcessUptime()
        {
            if (DateTime.TryParse(Application["ProcessStartupTime"].ToString(), out DateTime startTime))
            {
                var upTime = DateTime.Now.Subtract(startTime);
                return upTime.ToString(@"hh\:mm\:ss");
            }

            return "Failure";
        }
    }
}