using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class TestDatabaseconnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringsSection csSection = (ConnectionStringsSection)ConfigurationManager.GetSection("connectionStrings");
            var defaultProviderName = csSection.ElementInformation.Properties["ProviderName"].DefaultValue.ToString();

            Response.Write("defaultProvider = " + defaultProviderName);

            Response.End();

            var connStr = ConfigurationManager.ConnectionStrings["definedInWebConfig"].ConnectionString;

            SqlConnection conn = new SqlConnection(connStr);
            
            Response.Write(connStr);

            

            try
            {
                conn.Open();

                Response.Write("connection succeeded");
                
               

            }
            catch (Exception ex)
            {
                Response.Write(ex.GetType().ToString() + "<br/>" + ex.Message + "<br>" + ex.StackTrace);

            }
        }
    }
}