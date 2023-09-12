using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Events
{
    public class Edit : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public EventModel EventModel { get; set;  } = new();
        
        public Edit(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null) {
                return NotFound();
            }   

            var eventModel =
             await _context.Events.FirstOrDefaultAsync(e => e.EventID == id);

             if (eventModel == null) {
                return NotFound();
             }

             EventModel = eventModel;
            
            return Page();
        }
  
   public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }

            var eventToUpdate = await _context.Events!.FindAsync(id);

            if (eventToUpdate == null) {
                return NotFound();
            } 

            eventToUpdate.Name = EventModel.Name;
            eventToUpdate.Description = EventModel.Description;
            eventToUpdate.Date = EventModel.Date;

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Events/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}