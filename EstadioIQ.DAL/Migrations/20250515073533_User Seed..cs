using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstadioIQ.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "adesh.pandey1673@gmail.com", "newpassword", "Admin", "Adesh.Pandey" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
