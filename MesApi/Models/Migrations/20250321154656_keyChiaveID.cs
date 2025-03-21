using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesApi.Models.Migrations
{
    /// <inheritdoc />
    public partial class keyChiaveID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Utenti",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Utenti",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti",
                columns: new[] { "Id", "Username" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Utenti");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Utenti",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utenti",
                table: "Utenti",
                column: "Username");
        }
    }
}
