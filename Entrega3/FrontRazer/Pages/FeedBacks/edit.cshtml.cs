using FrontRazer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace FrontRazer.Pages.FeedBacks
{
    public class editModel : PageModel
    {
        public feedBack Feedback { get; set; } = new();

        public async Task<IActionResult> OnPostAsync(int? id, feedBack feedback)
        {
            if (id == null || feedback == null) return NotFound();

            Uri url = new Uri($"https://localhost:7033/FeedBacks/{id}");
      
            HttpContent content = new StringContent(JsonConvert.SerializeObject(feedback), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PutAsync(url.ToString(), content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return RedirectToPage("/FeedBacks/index");
            }
            return Page();
        }
    }
}
