using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class Delete : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public AlunoModel AlunoModel { get; set;  } = new();
        
        public Delete(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null) {
                return NotFound();
            }   

            var alunoModel =
             await _context.Alunos.FirstOrDefaultAsync(e => e.AlunoID == id);

             if (alunoModel == null) {
                return NotFound();
             }

             AlunoModel = alunoModel;
            
            return Page();
        }
  
       public async Task<IActionResult> OnPostAsync(int id) {
            var eventToDelete = await _context.Alunos!.FindAsync(id);

            if (eventToDelete == null) {
                return NotFound();
            } 

            try{
                _context.Alunos.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Alunos/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}