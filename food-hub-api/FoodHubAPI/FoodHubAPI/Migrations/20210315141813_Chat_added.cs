using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Chat_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5e725864-fb87-4d70-ac1f-df5633f56494", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), "AQAAAAEAACcQAAAAED1Oz2euxH/icggZ6pZ1zGMU5+rnJBQzUtQwe7pUR/lmRt+ATuCKHBoPwkmCchPnIg==", "810a8d35-0a56-4608-aa4e-efcc6e971114", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "2def9f9b-3325-4159-9cc4-1fd7584110a7", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), "AQAAAAEAACcQAAAAEHjjKxTWdGcZrDZHEoUQKIpusUQgCIV7lD6d4XEno7JWiN3a6VitdTXM3CQZJnniIA==", "0ce3292e-5486-4a8f-8f53-865f47080d3a", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "db1198cd-cc54-4f57-995e-b318a981eab4", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), "AQAAAAEAACcQAAAAEK4T6Sckor/vP2nf5CI4OJn8hRYa3ey4u0905PzInEllSiQ1nBqnooBWNAu9Spoh7w==", "784acfc9-5459-4011-9b0b-eea171d6e783", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_FromUserId",
                table: "Chat",
                column: "FromUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ede9c0bb-67f1-4bf3-9a46-a4743e2e95c4", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), "AQAAAAEAACcQAAAAELpwA7kgYoBj4EGMXgUS5RU5BF+/VfgapbJq0AhPwBlKL12hXgyFa9Wzc/OGQRocIw==", "ebafacb8-112c-4fd7-9d73-cecd0b8454b2", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4f6bc977-1802-4ad5-9f9b-636cb9b68bc1", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), "AQAAAAEAACcQAAAAEDk1yek2N4A2QzERMnlh04dSXHjyBOSviia+B9QO1dWmBUiMFSKaja2f06uZ326bWA==", "aec90506-f3f7-4b0e-b5d8-13321d7a72c3", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "727c3ab8-c26a-4dd8-8460-5dc46f2b2487", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), "AQAAAAEAACcQAAAAEI8W8hakovWIzbmJFUVT1reDxFajn71nCWx2V5bz1NFSWzLhTpfM+vWDhx0l/JkNug==", "5ef5a80e-17e2-4fcc-803e-42fbeb4630a5", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });
        }
    }
}
