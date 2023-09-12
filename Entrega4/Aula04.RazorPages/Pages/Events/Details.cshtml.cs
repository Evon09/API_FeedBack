using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Events
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public EventModel EventModel { get; set;  } = new();
        
        public Details(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null) {
                return NotFound();
            }   

            var eventModel =
             await _context.Events.Include(e=>e.Players) .FirstOrDefaultAsync(e => e.EventID == id);

             if (eventModel == null) {
                return NotFound();
             }

             EventModel = eventModel;
            
            return Page();
        }

    }
}