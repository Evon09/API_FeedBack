using FrontRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontRazer.Pages.FeedBacks
{
    public class detailsModel : PageModel
    {
        public feedBack Feedback { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri url = new Uri($"https://localhost:7033/FeedBacks/{id}");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url.ToString());

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Feedback = JsonConvert.DeserializeObject<feedBack>(responseContent);
            }

            return Page();
        }
    }
}

