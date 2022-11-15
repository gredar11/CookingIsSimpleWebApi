using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientDescription", "IngredientName" },
                values: new object[] { 4, "Orange", "Pumpkin" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientDescription", "IngredientName" },
                values: new object[] { 5, "Salty and green", "Pickle" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientDescription", "IngredientName" },
                values: new object[] { 6, "Bugs Bunny likes it.", "Carrot" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
