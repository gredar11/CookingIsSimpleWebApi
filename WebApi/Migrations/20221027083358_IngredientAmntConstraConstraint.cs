using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class IngredientAmntConstraConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "Amount",
                table: "AmountOfIngredients",
                sql: "Amount >= 0.0 and Amount <= 10000.0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Amount",
                table: "AmountOfIngredients");
        }
    }
}
