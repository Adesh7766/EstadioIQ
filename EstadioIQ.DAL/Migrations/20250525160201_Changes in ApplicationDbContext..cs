using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstadioIQ.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangesinApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);
        }
    }
}
