using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Owner_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RestaurantOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantOwner_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantOwner_RestaurantDetails_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOwner_RestaurantId",
                table: "RestaurantOwner",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOwner_UserId",
                table: "RestaurantOwner",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantOwner");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantDetails_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
