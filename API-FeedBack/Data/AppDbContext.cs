using API_FeedBack.Models;
using Microsoft.EntityFrameworkCore;

namespace API_FeedBack.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<feedBack> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("FeedbacksDb");
        }
    }
}
