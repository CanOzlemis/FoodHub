using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Order_table_revert_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "1d4958ed-ac5e-4289-a7ca-e5c2d7b712c0", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), "AQAAAAEAACcQAAAAEFg2BejbMUWOWEZlM4pbUmid0aasp+juluxxMkkzXO6B1mB1ygkoITypuyTjoIIfjA==", "1b7d0dd0-7290-43e5-8794-9addf83e9934", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ce1024b8-f508-4d1d-97b2-db39cbc3759c", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), "AQAAAAEAACcQAAAAEEnFR7D0ya72v1fNKk/8AmzPfywoK1JXlEdFcagwZ66SVJUafe2JINipCARdll5/iQ==", "8b44e2cb-43bd-4538-967e-b7a0d151c07f", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c45c419b-c3a6-4a1e-b00b-4392c3ceda59", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), "AQAAAAEAACcQAAAAEBp0IWRTEwsqMdQW09v7n8AC5StPOnC9s8UaKYvDu7ZsW4FG4swVMK/uZaDknb72Jw==", "1e1e5664-1905-455f-b336-3d89bfb857f1", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });
        }
    }
}
