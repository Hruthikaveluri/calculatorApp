using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculatorWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class CreateCalculatorMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_calculator",
                table: "calculator");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "calculator",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calculator",
                table: "calculator",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_calculator",
                table: "calculator");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "calculator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calculator",
                table: "calculator",
                column: "operand1");
        }
    }
}
