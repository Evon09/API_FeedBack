using Aula04.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Data {
        public class AppDbContext : DbContext
    {
        public DbSet<EventModel>? Events { get; set; }
        public DbSet<PlayerModel>? Players { get; set; }
        public DbSet<AlunoModel>? Alunos {get; set;}
        public DbSet<CursoModel>? Cursos {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<EventModel>().ToTable("Eventos");
            modelBuilder.Entity<PlayerModel>().ToTable("Jogadores").HasKey(j => j.PlayerID);
            modelBuilder.Entity<PlayerModel>().Property(p=>p.PlayerID).ValueGeneratedOnAdd();

            modelBuilder.Entity<EventModel>()
                .HasMany(e => e.Players)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "EventoJogador",
                    j => j.HasOne<PlayerModel>().WithMany().HasForeignKey("PlayerID"),
                    e => e.HasOne<EventModel>().WithMany().HasForeignKey("EventID"),
                    eJ =>
                    {
                        eJ.HasKey("EventID", "PlayerID");
                        eJ.ToTable("EventoJogador");
                    });
        }
    }

}