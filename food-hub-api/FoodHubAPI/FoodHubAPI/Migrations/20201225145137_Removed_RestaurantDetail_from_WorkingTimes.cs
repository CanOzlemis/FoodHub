using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Removed_RestaurantDetail_from_WorkingTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_RestaurantDetails_RestaurantId",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkingTimes_RestaurantId",
                table: "WorkingTimes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8f66d675-db8d-4be4-bf6d-46631ba2fe07", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), "AQAAAAEAACcQAAAAEOLEq2wotChloMpq+LktDgbvI8oMap3lFm4YMNwaTM03wZKMCLWc1FvD+2LwgnNzPQ==", "f65d58ba-ae73-433c-ab56-c17ef0b5f423", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "2d3c14aa-28e9-40a4-b055-bd062fdb340a", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), "AQAAAAEAACcQAAAAEKc1e8twcnjtznJcO0+uRNlUnJ69UsT8Y6/jNMG2BsFQ100t1PiK7FsdPLHJPkQmzQ==", "5b88d16f-b34c-427a-857d-9d30d34bebc1", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4340c4a0-8b6f-47e3-8eef-a130ceb1cf4d", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), "AQAAAAEAACcQAAAAEFqitu0QHdhC534xZqS05teoulhaOba9/JBRtseKHZuFdxf0ZeXxkmH0gshzLcMvqQ==", "5dfb6f71-1b44-40a1-8bc1-74e590a54a09", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "80dd34e7-c81a-493c-9b56-431488a60ff6", new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584), "AQAAAAEAACcQAAAAEAOvrv8TQG628OVUtvpzWQVwfeZlPE74oJ23hU8PgXQRdz0fIebVQgA68zFLkm9DPw==", "68110a55-02f4-4285-906b-107374647078", new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "a72aa922-fe58-4ff2-bc18-3458bcb09b5a", new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584), "AQAAAAEAACcQAAAAEPOudzq8WLJHD3SPk2JYIgg6YTni8RmoAgxKaF3QQQ+9B/zaU+UVjvomuDJNVhnrZQ==", "b2bc402f-4fa8-4ace-98ed-a3377999144c", new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c5c050ee-4f84-4fb8-95fa-7f966bccd949", new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584), "AQAAAAEAACcQAAAAENuOJ7jmwKH2+Yzud7zhacoV5EYQUoQoVuJRhhLZe/3NPmi8ZsCm1CAxpVp00V4EMw==", "c51f6bf0-e7ea-420e-9013-211a22acd4da", new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584), new DateTime(2020, 12, 25, 15, 34, 9, 814, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_RestaurantId",
                table: "WorkingTimes",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_RestaurantDetails_RestaurantId",
                table: "WorkingTimes",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
