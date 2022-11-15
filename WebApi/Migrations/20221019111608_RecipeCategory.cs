using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RecipeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeCategoryId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeCategoryId",
                table: "Recipes",
                column: "RecipeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeCategories_RecipeCategoryId",
                table: "Recipes",
                column: "RecipeCategoryId",
                principalTable: "RecipeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeCategories_RecipeCategoryId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeCategoryId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeCategoryId",
                table: "Recipes");
        }
    }
}
