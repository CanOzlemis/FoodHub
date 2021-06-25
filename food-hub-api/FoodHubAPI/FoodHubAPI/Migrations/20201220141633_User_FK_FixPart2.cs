using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class User_FK_FixPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantIdId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RestaurantIdId",
                table: "AspNetUsers",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RestaurantIdId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "AspNetUsers",
                newName: "RestaurantIdId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RestaurantIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantIdId",
                table: "AspNetUsers",
                column: "RestaurantIdId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
