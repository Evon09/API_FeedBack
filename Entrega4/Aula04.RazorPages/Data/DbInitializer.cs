using Aula04.RazorPages.Models;

namespace Aula04.RazorPages.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Events!.Any())
            {
                var events = new EventModel[] {
                    new EventModel{
                        Name ="Interclasse",
                        Description = "Fute com a galera",
                        Date = DateTime.Parse("2023-04-01")
                    },
                };
                context.AddRange(events);
            }

            if (!context.Alunos!.Any()){
                var alunos = new AlunoModel[]{
                    new AlunoModel{
                        NomeAluno ="Jair",
                        Email = "Jair@jair.com",
                        DataInscricao = DateTime.Parse("2022-11-09")
                    }, 
                };
                context.AddRange(alunos);
            }

            if (!context.Cursos!.Any()){
                var curso = new CursoModel[]{
                    new CursoModel{
                        NomeCurso = "Mecanico",
                        Descricao = "Curso de mecanica",
                        DataInicio = DateTime.Parse("2021-03-01"),
                        DataTérmino = DateTime.Parse("2023-01-03")
                    }, 
                };
                context.AddRange(curso);
            }

            if (!context.Players!.Any())
            {
                var players = new PlayerModel[] {
                    new PlayerModel{
                        Name = "Pedrinho",
                        Age = 27
                    },
                };
                context.AddRange(players);
            }

            context.SaveChanges();
        }
    }
}