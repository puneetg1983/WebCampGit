using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class AsyncThreadDelaySleep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(WaitForSomeTime));
        }

        private async Task WaitForSomeTime()
        {
            await Task.Delay(8000);
        }
    }
}