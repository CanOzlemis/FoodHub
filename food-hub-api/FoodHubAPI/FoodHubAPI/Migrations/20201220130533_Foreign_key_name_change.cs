using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Foreign_key_name_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId1",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RestaurantId1",
                table: "AspNetUsers",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RestaurantId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "AspNetUsers",
                newName: "RestaurantId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId1",
                table: "AspNetUsers",
                column: "RestaurantId1",
                principalTable: "RestaurantDetails",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
