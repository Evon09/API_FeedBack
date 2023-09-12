using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos
{
    public class Delete : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public CursoModel CursoModel { get; set;  } = new();
        
        public Delete(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null) {
                return NotFound();
            }   

            var cursoModel =
             await _context.Cursos.FirstOrDefaultAsync(e => e.IdCurso == id);

             if (cursoModel == null) {
                return NotFound();
             }

             CursoModel = cursoModel;
            
            return Page();
        }
  
       public async Task<IActionResult> OnPostAsync(int id) {
            var eventToDelete = await _context.Cursos!.FindAsync(id);

            if (eventToDelete == null) {
                return NotFound();
            } 

            try{
                _context.Cursos.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}