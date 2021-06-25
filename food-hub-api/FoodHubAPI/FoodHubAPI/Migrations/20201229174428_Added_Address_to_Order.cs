using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Added_Address_to_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5097c6d4-42f3-4025-9202-6714bfc0512a", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), "AQAAAAEAACcQAAAAEPU/ZLr1XCCxA9sW0jUKc2FZO1zX98cggA7u/BSQisOBWgB/KL3EshXZMaRpC++v+A==", "665638c8-7dcf-4308-a7d8-8b2185fb782f", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "44dd6f1e-931c-4d3a-933e-4c725e4b155a", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), "AQAAAAEAACcQAAAAEK0Xd4bETq/j3H9qD+rOm47ZTLUDT+boGvY1+a/BxP2wgJy+W95JZcH/6G5n8wmp1Q==", "8c61c472-327c-44c8-9bd7-c40e94ca2b01", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5764d9f3-0e1c-44e4-82de-1c748c6dd1ca", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), "AQAAAAEAACcQAAAAECXB6ETmqaMBJVfHkxJmqlTBlIflvP4ENKNIUewbKf5w7OfsOaTjvkPZhHHda8d2RA==", "f512188e-adc8-4851-a3be-049da83e4150", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "f0b3a595-c503-490a-94ba-054df949349f", new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963), "AQAAAAEAACcQAAAAELvkGwUsb/ANkOFKNMeI+VuFBcnTOC1tNG/S9aF4Gq+loe/MLZpn+db5+OpzyYZf+Q==", "f3acf7b6-ab57-4865-863d-decc2e175f5b", new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "701c7b19-13ca-478c-9740-32de5661dedc", new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963), "AQAAAAEAACcQAAAAEDzqCrz634ZVqhs0tuh5nF2pAYW1xw9ANGuw2K++DVCSXZYdVbpkMjx6A9deS7gGCA==", "44efe1f2-604d-4b5d-a9d6-9e976715948a", new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4bac3f61-270d-49dd-bc44-e5cdcd0e24c9", new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963), "AQAAAAEAACcQAAAAEFR5pZ0sS/vqbo5cueGiUmTKBjO8OgH2PCp8oRe9xBi+fgFPsTVJq1b3vFp5qPr0YQ==", "ac028a20-82b4-4dad-a1da-0d30c4a8b9b7", new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963), new DateTime(2020, 12, 29, 18, 53, 17, 856, DateTimeKind.Local).AddTicks(5963) });
        }
    }
}
