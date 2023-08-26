using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;
            WebClient client = new WebClient();
            client.DownloadString("http://www.microsoft.com");

            message.Text = "Page took " + DateTime.Now.Subtract(dtStart).TotalMilliseconds + " ms to load";
        }
    }
}