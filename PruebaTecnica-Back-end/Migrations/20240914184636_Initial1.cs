using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica_Back_end.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_TasksItem",
                table: "TasksItem",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TasksItem",
                table: "TasksItem");
        }
    }
}
