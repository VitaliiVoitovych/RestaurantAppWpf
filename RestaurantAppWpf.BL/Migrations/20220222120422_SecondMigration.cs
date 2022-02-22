using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAppWpf.BL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Dishes_DishId",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_DishId",
                table: "Carts",
                newName: "IX_Carts_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Dishes_DishId",
                table: "Carts",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Dishes_DishId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_DishId",
                table: "Cart",
                newName: "IX_Cart_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Dishes_DishId",
                table: "Cart",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
