using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class new_WorkingTimes_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "RestaurantDetails",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WorkingTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingTimes_RestaurantDetails_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Updated", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "2f6ad270-b88d-41bf-9658-2bf4d49834f8", new DateTime(2020, 12, 25, 14, 47, 10, 466, DateTimeKind.Local).AddTicks(5567), "User", "cansarajlija+admin@gmail.com", true, "Can", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEFTNVUr4eArvbztmvsv0p2A5XJBbquSX21ux//r/rGDQ1hlBPoHTOop1yM3vPfFbCA==", "05313035675", false, "494a72d9-4553-4ad9-bd24-0bededeabe01", false, new DateTime(2020, 12, 25, 14, 47, 10, 467, DateTimeKind.Local).AddTicks(8450), "cansarajlija+admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_RestaurantId",
                table: "WorkingTimes",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingTimes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "RestaurantDetails",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);
        }
    }
}
