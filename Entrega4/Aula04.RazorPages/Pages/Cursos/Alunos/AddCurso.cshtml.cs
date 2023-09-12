using System.Diagnostics;
using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class AddCurso : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoModel { get; set;  } = new();
        public List<CursoModel> ListCursos {get; set;} = new();
        public AddCurso(AppDbContext context)
        {
          _context = context;
        }
  
        public async Task<IActionResult> OnPostAsync(int id, int cursoID) {
            var alunoToUpdate = await _context.Alunos!.Include(e => e.Cursos).FirstOrDefaultAsync(e => e.AlunoID == id);
            var selectedCurso = await _context.Cursos!.Include(e => e.Alunos).FirstOrDefaultAsync(e => e.IdCurso == cursoID);

            if (alunoToUpdate == null || selectedCurso == null) {
                return NotFound();
            } 
            
             alunoToUpdate.Cursos!.Add(selectedCurso);


            await _context.SaveChangesAsync();
            return RedirectToPage("/Cursos/Alunos/Index");        
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
            
            var listCursos = await _context.Cursos!.ToListAsync();
            if (listCursos == null){
                return NotFound();
            }

            ListCursos = listCursos;

            return Page();
        }
    }
}