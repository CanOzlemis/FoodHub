using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class ForeignKey_for_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId1",
                table: "AspNetUsers",
                column: "RestaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId1",
                table: "AspNetUsers",
                column: "RestaurantId1",
                principalTable: "RestaurantDetails",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "AspNetUsers");
        }
    }
}
