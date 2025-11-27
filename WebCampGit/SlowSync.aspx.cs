using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.162 Safari/537.36");
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");

                // Synchronous call to DelayPage
                string response = client.GetStringAsync(delayPageUrl).Result;
            }

            message.Text = $"Synchronously called DelayPage with {delay} seconds delay. Full URL: {delayPageUrl}. Total time: {DateTime.Now.Subtract(dtStart).TotalMilliseconds:F0} ms";
        }
    }
}