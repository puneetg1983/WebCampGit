using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class SlowSync : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;

            // Generate random delay between 20-45 seconds
            Random rand = new Random();
            int delay = rand.Next(20, 46);

            // Construct URL to our new DelayPage with the random delay
            string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
            string delayPageUrl = $"{baseUrl}/DelayPage.aspx?t={delay}";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(delayPageUrl);
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.162 Safari/537.36";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            webRequest.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                // Synchronous call to DelayPage
                string responseContent = reader.ReadToEnd();
            }

            message.Text = $"Synchronously called DelayPage with {delay} seconds delay. Full URL: {delayPageUrl}. Total time: {DateTime.Now.Subtract(dtStart).TotalMilliseconds:F0} ms";
        }
    }
}