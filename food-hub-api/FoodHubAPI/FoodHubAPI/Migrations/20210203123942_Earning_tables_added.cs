using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Earning_tables_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveEarnings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EarningsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsHistory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActiveEarnings",
                columns: new[] { "Id", "RestaurantId", "Total" },
                values: new object[] { 1, 1, 0f });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "048b518e-68a5-4eae-bd10-e5a8f77c91e9", new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895), "AQAAAAEAACcQAAAAEFxHFTd5YwH0JtyjYpufhz67F+XlKytrEVkmyXgDdUpZd7dGQZJasOJoxvPye+8LcQ==", "e87165cb-d8da-4e17-a16e-623e011c0c88", new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "95a7751b-8577-4596-bc23-affce45360c6", new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895), "AQAAAAEAACcQAAAAEIsY7eHulcMSD9ycS9kFswdvwd5AxKLMf8TMQkjiMmhnokUz3emzpbUz3NM/qQBMIA==", "6f21a69f-9f2c-4094-928c-8ba21c73f5ca", new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "47881711-bb43-4b36-a93e-8eb10028e2bb", new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895), "AQAAAAEAACcQAAAAEJ21gQ+7rfdadkPJSkKaxH9vanExqp7OfhrF80PvkmFghn5lsSFjjg65Vfi+wy7JIQ==", "9bebcfa3-02b0-4dfa-9087-6a1d3f418b09", new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.InsertData(
                table: "EarningsHistory",
                columns: new[] { "Id", "Month", "RestaurantId", "Total", "Year" },
                values: new object[,]
                {
                    { 1, 12, 1, 13254.75f, 2019 },
                    { 2, 1, 1, 1710.25f, 2020 }
                });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Rating", "Updated" },
                values: new object[] { new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895), 0f, new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveEarnings");

            migrationBuilder.DropTable(
                name: "EarningsHistory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5aa7104c-63c7-4733-96be-ade0ebd8e6bd", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), "AQAAAAEAACcQAAAAEPfYe0VjbYl6a6UL3/OkY3xEtsYCeXqnIJn6wkF9oDNRqm1JsCfTzydAVfHH3pqR5A==", "f86f5318-5625-44d3-8cc9-4b8138e779fb", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "575e8f98-3a26-4dfd-8475-9072eade729f", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), "AQAAAAEAACcQAAAAEIRHFWLM3oCcOjqpWVrttnlUDjW6ci/sSnY/ffQAWIHAtbn+BgRsQGTJrHKoOQSXSw==", "c6c9d146-f2cb-4cd4-8d63-1cbb3105e63d", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "9df9acfd-aa12-449e-898f-676387ce9fa0", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), "AQAAAAEAACcQAAAAEOdFcLyGh4GdhCVogGR3QrPw2thcsyPsxaDicr/drYOJf7HXmoIG77wGMwpP2Ff4TQ==", "39091e18-92ce-45cd-9f43-5a107755b020", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Rating", "Updated" },
                values: new object[] { new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), 5f, new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });
        }
    }
}
