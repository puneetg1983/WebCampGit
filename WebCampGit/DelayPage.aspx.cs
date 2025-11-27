using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class DelayPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;
            int delay = 5; // Default delay of 5 seconds

            // Check if 't' parameter is provided
            if (Request.QueryString["t"] != null)
            {
                Int32.TryParse(Request.QueryString["t"].ToString(), out delay);
            }

            // Convert seconds to milliseconds for Thread.Sleep
            System.Threading.Thread.Sleep(delay * 1000);

            message.Text = $"Page took {DateTime.Now.Subtract(dtStart).TotalMilliseconds:F0} ms to load (requested delay: {delay} seconds)";
        }
    }
}