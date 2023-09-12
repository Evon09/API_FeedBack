using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula04.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "EventoJogador",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoJogador", x => new { x.EventID, x.PlayerID });
                    table.ForeignKey(
                        name: "FK_EventoJogador_Eventos_EventID",
                        column: x => x.EventID,
                        principalTable: "Eventos",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoJogador_Jogadores_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Jogadores",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventoJogador_PlayerID",
                table: "EventoJogador",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoJogador");

            migrationBuilder.DropTable(
                name: "Jogadores");
        }
    }
}
