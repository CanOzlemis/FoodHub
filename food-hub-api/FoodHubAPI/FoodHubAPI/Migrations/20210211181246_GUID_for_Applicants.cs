using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class GUID_for_Applicants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "ApplicantRestaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "ApplicantRestaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "ApplicantRestaurants");

            migrationBuilder.DropColumn(
                name: "GUID",
                table: "ApplicantRestaurants");

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
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591), new DateTime(2021, 2, 10, 21, 43, 58, 588, DateTimeKind.Local).AddTicks(1591) });
        }
    }
}
