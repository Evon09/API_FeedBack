using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos
{
    public class Create : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public CursoModel cursoModel { get; set;  } = new();
        
        public Create(AppDbContext context)
        {
          _context = context;
        }
  
        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }


            try{
                _context.Add(cursoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}