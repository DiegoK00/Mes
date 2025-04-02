using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesApi.Models.Migrations
{
    /// <inheritdoc />
    public partial class campiUtenti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Utenti",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Utenti");
        }
    }
}
