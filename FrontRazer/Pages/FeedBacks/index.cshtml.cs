using FrontRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontRazer.Pages.FeedBacks
{
    public class indexModel : PageModel
    {
        public List<feedBack> FeedbackList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Uri url = new Uri("https://localhost:7033/FeedBacks");
       

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url.ToString());

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                FeedbackList = JsonConvert.DeserializeObject<List<feedBack>>(responseContent);
            }

            return Page();
        }
    }
}
