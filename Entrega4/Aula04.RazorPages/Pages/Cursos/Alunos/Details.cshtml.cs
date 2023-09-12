using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public AlunoModel AlunoModel { get; set;  } = new();
        
        public Details(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null) {
                return NotFound();
            }   

            var alunoModel =
             await _context.Alunos.Include(e=>e.Cursos) .FirstOrDefaultAsync(e => e.AlunoID == id);

             if (alunoModel == null) {
                return NotFound();
             }

             AlunoModel = alunoModel;
            
            return Page();
        }

    }
}