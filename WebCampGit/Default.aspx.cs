using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strMessage = "Hello World";

            lblMessage.Text = strMessage;

            System.Diagnostics.Trace.TraceInformation("Page Loaded Successfully ");

        }
    }
}