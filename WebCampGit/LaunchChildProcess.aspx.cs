using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class LaunchChildProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["success"] != null)
            {
                Process.Start("tcpping.exe", "www.bing.com -n 60");
                lblMessage.Text = $"Launched child process for www.bing.com - tcpping at {DateTime.UtcNow} UTC";
            }
            else
            {
                Process.Start("tcpping.exe", "127.0.0.1 -n 60");
                lblMessage.Text = $"Launched child process for 127.0.0.1 - tcpping at {DateTime.UtcNow} UTC";
            }
        }
    }
}