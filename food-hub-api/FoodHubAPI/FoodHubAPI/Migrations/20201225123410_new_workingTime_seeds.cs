using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class new_workingTime_seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "RestaurantOwner",
                columns: new[] { "UserId", "RestaurantId" },
                values: new object[] { "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6", 1 });

            migrationBuilder.InsertData(
                table: "WorkingTimes",
                columns: new[] { "Id", "CloseTime", "Day", "OpenTime", "RestaurantId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 22, 0, 0, 0), 0, new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 2, new TimeSpan(0, 22, 0, 0, 0), 1, new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 3, new TimeSpan(0, 22, 0, 0, 0), 2, new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 4, new TimeSpan(0, 22, 0, 0, 0), 3, new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 5, new TimeSpan(0, 22, 0, 0, 0), 4, new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 6, new TimeSpan(0, 22, 0, 0, 0), 5, new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 7, new TimeSpan(0, 22, 0, 0, 0), 6, new TimeSpan(0, 7, 0, 0, 0), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantOwner",
                keyColumn: "UserId",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6");

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkingTimes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5af6724c-29a4-443c-adbb-d9b5a15fe30f", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "AQAAAAEAACcQAAAAEJzERM3uZ7L38P4Qo+wgVMDSUxcZqMJfA8MQ1Vi0zKndpTgbG9DdlHlBUKdyx3BaAQ==", "db8c3cf5-5c5e-493d-bd2e-61cfa3001f5b", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "d6d6c938-f0c1-4f62-9f87-1a9ac9491606", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "AQAAAAEAACcQAAAAEJjqU5zMoTGn1dDNAWGr38YLNRMylw8H0UDxTJl28UKcHCcN8EMmEIQaFQmCzIHf7Q==", "74958c60-d562-4b8b-bf12-436b4860d113", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "27431157-fd4d-444a-b601-8376b21d96f0", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "AQAAAAEAACcQAAAAEKvQr2vFRz7CfmVD0e42FeAwmo8gilELPazFD67MgGoSJpXRffbiIYQ8FkX5thYkHg==", "8507910e-112c-4cb7-aebe-9aa607339710", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235) });
        }
    }
}
