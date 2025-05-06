using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesApi.Models.Migrations
{
    /// <inheritdoc />
    public partial class localita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Località",
                table: "Utenti",
                newName: "Localita");

            migrationBuilder.RenameColumn(
                name: "Località",
                table: "Clienti",
                newName: "Localita");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localita",
                table: "Utenti",
                newName: "Località");

            migrationBuilder.RenameColumn(
                name: "Localita",
                table: "Clienti",
                newName: "Località");
        }
    }
}
