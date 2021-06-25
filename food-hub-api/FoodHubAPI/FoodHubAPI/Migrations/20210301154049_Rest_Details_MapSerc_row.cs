using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Rest_Details_MapSerc_row : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapSrc",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "7ef21a02-cee7-40cf-a89b-29bf5e6ccb0c", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), "AQAAAAEAACcQAAAAECZaKfjblr6FgV/wdQ+dt70mFbJKv90i/FGswaXg/vPo8ErfQ5oOyHD0kvPvXluPOg==", "c5f09070-e51c-41e2-b037-ede7e84daf47", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6aa65c66-b767-4f68-8bb9-987e2f62c5b7", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), "AQAAAAEAACcQAAAAEJaNgbgDrNqf7hc8wwgSqP7asx64uY2vqVOYVn6m3JXCCcdhhcNhs2azGX8eljjd4w==", "be6bc21f-4c48-41ca-934b-ed7d8a8c2932", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "a0e57cc6-5658-4549-84ac-c24c48fa7d4f", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), "AQAAAAEAACcQAAAAEMifiCyDMgF1KBkExZN6dpocgp0bGVf8hPV9J95HUjU5wj5AqQgbl7vQ0HD2bEdkDQ==", "c1924a1b-3d3b-4faa-bed3-eb11cc81462b", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapSrc",
                table: "RestaurantDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "b8c80f36-808f-4fed-a601-5771a14d86cc", new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168), "AQAAAAEAACcQAAAAENwcRGx2Q15a7HYWwx60gsfhjE0ckBsN7jEBuc8XORAKoRYt++xIzsQ4oyW46yYLxw==", "fd473231-ee27-4ee6-97cd-acd85a30f865", new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c859a3d4-2889-4814-aba8-7a55f72da268", new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168), "AQAAAAEAACcQAAAAEMGJG3t/4dYSxfAhzntyutYl7OEe4XvnGOL+761dVByd/8rkwJ3aGNR0CQQsUci5qw==", "6ccb520f-26b1-4561-bc2e-455dd0a61ba9", new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "716e2934-a5c1-41a1-acde-32b98c053670", new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168), "AQAAAAEAACcQAAAAEL4AvVMdcJ7WvpFwwNs5pyCQk3nX5nEnLNUz0owFBt/JeQXv1M/RB55fJjS93ffqeg==", "a3a5cc5e-9eb4-4551-b837-c51025c1aa17", new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168), new DateTime(2021, 2, 11, 21, 12, 45, 400, DateTimeKind.Local).AddTicks(1168) });
        }
    }
}
