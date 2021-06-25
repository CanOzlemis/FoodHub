using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class FK_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_RestaurantId",
                table: "WorkingTimes",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_RestaurantDetails_RestaurantId",
                table: "Menu",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_RestaurantDetails_RestaurantId",
                table: "WorkingTimes",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_RestaurantDetails_RestaurantId",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_RestaurantDetails_RestaurantId",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkingTimes_RestaurantId",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_Menu_RestaurantId",
                table: "Menu");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "0710beec-9f12-4d57-8e11-eb5d089978de", new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385), "AQAAAAEAACcQAAAAEEL3KHrrG1QMcz6G/naIrmRN+UNXSrrID2aPI5MKcuDE7YFZ4e7JjCK+L895c9Fa1w==", "0ff30a9c-3c7e-422c-9ba6-995f568c1426", new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8846d39e-8d16-40a5-9ec8-859c722c2324", new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385), "AQAAAAEAACcQAAAAEA4gPo2lrqz+2u+hYqjy6ponajVkC9/0dQ8O8OZQh5A91oXWunm2bNEuNdQ+hGNbJw==", "94432ea8-3a0d-4f18-8345-d70f2f34feb5", new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "67bc302e-a46a-40ef-a8f1-f481ac011975", new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385), "AQAAAAEAACcQAAAAEO7ZX7UfMzVd/n5xawolSrqRTGWWqLlLTbavDf3MVg7yikY1GPjuXzs8vELNaQPsfQ==", "be672354-618d-40b6-9493-346603f004a2", new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385), new DateTime(2020, 12, 28, 18, 19, 16, 219, DateTimeKind.Local).AddTicks(8385) });
        }
    }
}
