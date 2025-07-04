using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculatorWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class CreateCalculatorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calculator",
                columns: table => new
                {
                    operand1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    operand2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    operation = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calculator", x => x.operand1);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calculator");
        }
    }
}
