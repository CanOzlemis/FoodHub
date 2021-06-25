using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Key_Change_OwnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantOwner",
                table: "RestaurantOwner");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOwner_UserId",
                table: "RestaurantOwner");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RestaurantOwner");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RestaurantOwner",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantOwner",
                table: "RestaurantOwner",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantOwner",
                table: "RestaurantOwner");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RestaurantOwner",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RestaurantOwner",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantOwner",
                table: "RestaurantOwner",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOwner_UserId",
                table: "RestaurantOwner",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
