using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class RestaurantDetail_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantDetails",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    About = table.Column<string>(type: "varchar(500)", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    AverageDeliveryTime = table.Column<int>(type: "int", nullable: false),
                    MinOrderPrice = table.Column<float>(type: "real", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantDetails", x => x.RestaurantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantDetails");
        }
    }
}
