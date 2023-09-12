using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Events
{
    public class Delete : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public EventModel EventModel { get; set;  } = new();
        
        public Delete(AppDbContext context)
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
            var eventToDelete = await _context.Events!.FindAsync(id);

            if (eventToDelete == null) {
                return NotFound();
            } 

            try{
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Events/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}