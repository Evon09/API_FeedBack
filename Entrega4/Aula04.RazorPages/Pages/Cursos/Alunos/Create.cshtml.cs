using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class Create : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public AlunoModel AlunoModel { get; set;  } = new();
        
        public Create(AppDbContext context)
        {
          _context = context;
        }
  
        public async Task<IActionResult> OnPostAsync(int id) {
            if (!ModelState.IsValid) {
                return Page();
            }


            try{
                _context.Add(AlunoModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Alunos/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}