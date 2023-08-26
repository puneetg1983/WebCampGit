using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class StackOverflowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ThisIsARecursiveFunctionUsedToTriggerAStackOVerflow();
        }

        private void ThisIsARecursiveFunctionUsedToTriggerAStackOVerflow()
        {
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    ThisIsARecursiveFunctionUsedToTriggerAStackOVerflow();
                }
            }
            catch (StackOverflowException ex)
            {
                Response.Write(ex.Message + "<-*******->" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}