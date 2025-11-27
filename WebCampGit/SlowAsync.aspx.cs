using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demomvp
{
    public partial class SlowAsync : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
        }

        public async Task LoadSomeData()
        {
            // Generate random delay between 20-45 seconds
            Random rand = new Random();
            int delay = rand.Next(20, 46);

            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.162 Safari/537.36");
            Client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");

            // Construct URL to our new DelayPage with the random delay
            string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
            string delayPageUrl = $"{baseUrl}/DelayPage.aspx?t={delay}";
            
            var clientcontacts = Client.GetStringAsync(delayPageUrl);
            
            await Task.WhenAll(clientcontacts);

            message.Text = $"Called DelayPage with {delay} seconds delay. Full URL: {delayPageUrl}";
        }
    }
}