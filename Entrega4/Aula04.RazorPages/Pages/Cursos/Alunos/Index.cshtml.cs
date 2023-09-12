using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;
        public List<AlunoModel> AlunoList { get; set;  } = new();
        
        public Index(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }
    }
}