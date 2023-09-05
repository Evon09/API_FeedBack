using API_FeedBack.Models;

namespace API_FeedBack.Data
{
    public class DbInicialize
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Feedbacks!.Any())
            {
                return;
            }

            var feedbacks = new feedBack[]
            {
         new feedBack
         {
             NomeCliente = "Jair José",
             EmailCliente = "teste@gmail.com",
             DataFeedback = DateTime.Parse("2023-08-23"),
             Comentario = "É bom!",
             Avaliacao = 5,
         }
            };

            context.AddRange(feedbacks);
            context.SaveChanges();
        }
    }
}
