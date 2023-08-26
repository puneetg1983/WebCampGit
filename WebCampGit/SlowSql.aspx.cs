using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class SlowSql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;

            message.Text = "";

            try
            {

                SqlConnection conn = new SqlConnection("Server=tcp:itsqobarp5.database.windows.net,1433;Database=demomvp;User ID=kaushal@itsqobarp5;Password=LS1setup!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sleepingproc", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sleeptime", "00:00:05"));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                message.Text = "ERROR connecting to DB :" + ex.Message + "<br/>";
            }

            message.Text += "Page took " + DateTime.Now.Subtract(dtStart).TotalMilliseconds + " ms to load";
        }
    }
}