using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class headers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Headers["Request-Id"] != null)
            {
                lblMessage.Text = Request.Headers["Request-Id"].ToString();
                return;
            }

            lblMessage.Text = "Header Request-Id not found";
        }
    }
}