using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class new_Applicant_Restaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RestaurantDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApplicantRestaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "varchar(64)", nullable: false),
                    RestaurantCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantRestaurants", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "be02f802-5eeb-42e8-8f9c-451877465b2f", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591), "AQAAAAEAACcQAAAAEMLsyY3EW0eNf0ZFOQofdSngJNTiNyH4Su/NbDfQrcQY2Y0qdHzAbZ+4uY1LL1uFJQ==", "cda1b12e-7d46-4147-99ee-8d37eec56c59", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "2c86dc27-d991-4137-87b2-cbb631527cd3", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591), "AQAAAAEAACcQAAAAEEQrCoMvEmPVQYhBTHN+rU9eGBLpTrhU6joRf5nAwObEMw9ZTxj3hoCxLU9QsRymfw==", "d2c6c25e-dcc7-4383-903e-a5288f112f6d", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "24bb5bf3-8b43-4952-b73f-544f053c613b", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591), "AQAAAAEAACcQAAAAENzKVGwhO6ws4ETkAhAdFVKfidBo3Gu7iKD58jJfuslWVIUw34/OZZeyj6ryBxHnZw==", "f2b366e0-7b8d-4910-a4ed-5da12ba3b4e8", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "Created", "Street", "Updated" },
                values: new object[] { "Antalya", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591), "Muratpaşa/12. Cadde", new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantRestaurants");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "RestaurantDetails");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RestaurantDetails");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "RestaurantDetails");

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

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895), new DateTime(2021, 2, 3, 15, 39, 41, 988, DateTimeKind.Local).AddTicks(4895) });
        }
    }
}
