using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class Edit : PageModel
    {
       private readonly AppDbContext _context;
       [BindProperty]
        public AlunoModel AlunoModel { get; set;  } = new();
        
        public Edit(AppDbContext context)
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

            if (Request.Form["submitButton"] == "addCurso")
            {
                // Lógica para adicionar um novo curso aqui
                // Por exemplo, redirecionar para uma página de adicionar curso
                return RedirectToPage("/Cursos/AdicionarCurso");
                
            }else{
                if (!ModelState.IsValid) {
                    return Page();
                }

                var cursoToUpdate = await _context.Alunos!.FindAsync(id);

                if (cursoToUpdate == null) {
                    return NotFound();
                } 

                cursoToUpdate.NomeAluno = AlunoModel.NomeAluno;
                cursoToUpdate.Email = AlunoModel.Email;
                cursoToUpdate.DataInscricao = AlunoModel.DataInscricao;
            }

            try{
                await _context.SaveChangesAsync();
                return RedirectToPage("/Cursos/Alunos/Index");
            } catch (DbUpdateException) {
                return Page();
            }

        }
    }
}