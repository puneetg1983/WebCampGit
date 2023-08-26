using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class UnhandledException : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                throw new ApplicationException("I will crash your process");
            });
        }       
    }
}