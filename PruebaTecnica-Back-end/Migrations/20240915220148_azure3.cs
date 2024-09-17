using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica_Back_end.Migrations
{
    /// <inheritdoc />
    public partial class azure3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "UserName" },
                values: new object[] { 1, "admin@gmail.com", "Admin123", "Admin", "admin" });
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
