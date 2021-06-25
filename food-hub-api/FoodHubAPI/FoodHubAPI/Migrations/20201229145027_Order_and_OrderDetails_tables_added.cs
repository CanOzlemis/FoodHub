using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Order_and_OrderDetails_tables_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5d6eab8f-8a02-44c3-9abb-087e32f21d9f", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEP0bwxM+sGZH97wFI/otpaW2IzcM/1BB8uqffYMdCe8W3Qa+EVClrEcGjnS+B+I/ZQ==", "c3cb820f-5095-485f-bb00-ca86ccd0f3b3", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "338dbcbc-c5de-4245-9791-36059a3953a0", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEC0UFDwukw+fRjEMW5p5xYiC1TI2Qkkl7fKswxUNJpYWguw4Bau5gqzPFlWn0aA0UQ==", "885be640-4069-4aad-bc96-b9905d93ba31", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "f7a79abd-5749-4c2d-b402-bd3c55a0f0d0", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEJkCyQc8WenXQ+j5fpN4qdEieIeyqkXM/r1noJrdGQTCNQWDGaWbUAo59IPXvbp3Qw==", "90bd315c-2bdc-4265-a826-153bf3dec60c", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "e855b989-11f5-443b-a20d-7b1b28227bee", new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276), "AQAAAAEAACcQAAAAEB2RmkeG5bdAvSa1RLwa5YVIQQdx71d30Zivukg5ifK0kMo4dMWuc66rWRGmHmybVA==", "389e64bd-ce24-48ce-887b-6c8813448d52", new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "77cec06f-f2d3-4ce2-b537-a3f393417859", new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276), "AQAAAAEAACcQAAAAEKlKq12f6AXjFv5QsDfZAAEMzqi35rxJPosP6rq/7QXiigN3yu0zNCq4vP2LjgsFCQ==", "3fbbb3e8-24f8-4c13-9179-c3c5e94f6285", new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "52a4fa98-2f18-41fd-b155-0ae73b74b883", new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276), "AQAAAAEAACcQAAAAEJgE2HY5//v0OrcOpHYREniknTryBRaG6my2BInVdoRedmRI3u65JDmd1vG8f5vBmg==", "3d47bcf3-a2b5-4830-aeb0-b2d55635ce8c", new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276), new DateTime(2020, 12, 28, 18, 22, 59, 594, DateTimeKind.Local).AddTicks(7276) });
        }
    }
}
