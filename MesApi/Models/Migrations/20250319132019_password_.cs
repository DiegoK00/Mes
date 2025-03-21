﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MesApi.Models.Migrations
{
    /// <inheritdoc />
    public partial class password_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Utenti",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Utenti",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Utenti");
        }
    }
}
