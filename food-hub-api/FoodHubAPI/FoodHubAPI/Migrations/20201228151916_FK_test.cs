using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class FK_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOwner_RestaurantId",
                table: "RestaurantOwner",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_RestaurantDetails_RestaurantId",
                table: "RestaurantOwner",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_RestaurantDetails_RestaurantId",
                table: "RestaurantOwner");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOwner_RestaurantId",
                table: "RestaurantOwner");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5c766457-6920-4a30-a709-827bf2958ced", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), "AQAAAAEAACcQAAAAEIbWA1nwZJ5gJVaKHOIDGMw4gTd3akTUCCTmOJBN5kuXUiLNyH7T6ZhDKvxdsp+xsw==", "d93eefd5-6055-4020-9fcd-7129975f7367", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "0deb3e34-c40f-4176-a0d2-cca0a67cfe68", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), "AQAAAAEAACcQAAAAEGHZdgOAF9UzCYvQ1MMNnN07B5Z4IOgn7MXwStAKMqYOhW4AApOr1vjcYTqvyiecZA==", "5c4fe921-c70c-4582-9e21-440c33996287", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6bfdb21a-6eaa-412e-b7b7-53987d95d842", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), "AQAAAAEAACcQAAAAEM8ghNHm5SkYEEyRdBUAW+R6L27sw8qui8wh1HUHsvYeYoZ067FtnP2U/FWMAO+Q4g==", "c1847b9a-a992-4a25-85e8-8dbc1c241188", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });
        }
    }
}
