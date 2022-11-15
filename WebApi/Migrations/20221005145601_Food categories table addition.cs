using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cis.WebApi.Migrations
{
    public partial class Foodcategoriestableaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IngredientDescription",
                table: "Ingredients",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CategoryId",
                table: "Ingredients",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Id",
                table: "Ingredients",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_FoodCategories_CategoryId",
                table: "Ingredients",
                column: "CategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_FoodCategories_CategoryId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_CategoryId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_Id",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientDescription",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
