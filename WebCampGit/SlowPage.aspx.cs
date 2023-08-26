using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class SlowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;
           
           
            System.Threading.Thread.Sleep(10000);

            message.Text = "Page took " + DateTime.Now.Subtract(dtStart).TotalMilliseconds + " ms to load";
        }
    }
}