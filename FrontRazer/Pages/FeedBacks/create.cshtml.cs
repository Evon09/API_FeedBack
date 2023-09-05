using FrontRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace FrontRazer.Pages.FeedBacks
{
    public class createModel : PageModel
    {
        public feedBack Feedback { get; set; } = new();

        public async Task<IActionResult> OnPostAsync(feedBack feedback)
        {
            if (!ModelState.IsValid) return Page();

            Uri url = new Uri("https://localhost:7033/FeedBacks");
       
            HttpContent content = new StringContent(JsonConvert.SerializeObject(feedback), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url.ToString(), content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return RedirectToPage("/FeedBacks/index");
            }
            return Page();
        }
    }
}
