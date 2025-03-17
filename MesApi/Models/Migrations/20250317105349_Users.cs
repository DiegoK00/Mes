using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesApi.Models.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Indirizzo = table.Column<string>(type: "TEXT", nullable: true),
                    Località = table.Column<string>(type: "TEXT", nullable: true),
                    Provincia = table.Column<string>(type: "TEXT", nullable: true),
                    Regione = table.Column<string>(type: "TEXT", nullable: true),
                    Nazione = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Username);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
