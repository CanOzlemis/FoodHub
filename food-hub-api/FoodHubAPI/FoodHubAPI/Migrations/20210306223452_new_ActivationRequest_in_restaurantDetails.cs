using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class new_ActivationRequest_in_restaurantDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActivationRequest",
                table: "RestaurantDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "52d81284-fc59-4731-8fb9-fbefcaae71cd", new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499), "AQAAAAEAACcQAAAAENz/JRNVHoXwH51ThYGMbdPYm0F+c1uqcd+JrovvUHYgyXNyqj4XblIM1GpxmstHPw==", "6d769ab8-b78a-48a7-82eb-009a2c6f34b5", new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "9d8f274f-d2ea-420a-9436-7d0ab688936c", new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499), "AQAAAAEAACcQAAAAEJO5vtJ5mNChvVJQLVVag8PVVqncWbvZqCzQG9k1uNETZi2l3AYkU0ps8Re8IsjlhA==", "74fe4a27-e0c7-488e-b0d0-34ad6b68dbde", new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "baba98e6-8c39-46f2-bc24-62ccfa8d83ae", new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499), "AQAAAAEAACcQAAAAEEGG7L2UAfuY20SiQsg20/hUfLc6AZ5+4uiy7oShSbW12jManBAgE43gLAw6QcXthg==", "9a6dfb6d-2893-421a-9d06-eaad81841423", new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 7, 1, 34, 51, 536, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 7, 1, 34, 51, 537, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 7, 1, 34, 51, 537, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 7, 1, 34, 51, 537, DateTimeKind.Local).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499), new DateTime(2021, 3, 7, 1, 34, 51, 509, DateTimeKind.Local).AddTicks(499) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationRequest",
                table: "RestaurantDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "786f745e-2f6d-4a31-9e0c-e74a9714a614", new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261), "AQAAAAEAACcQAAAAEFahJA+WvSd0NJ7x/X7CqL0E7t04Hq1OBzkPCQaonOLxcmGwKFATA1URE6TGlW9JAw==", "bc1eb5a8-610e-4225-9c43-7146fcabfb71", new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "38c1b22d-7b1a-4158-8bdc-06ee1922bd08", new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261), "AQAAAAEAACcQAAAAEM6AsD5cFstHs9elqabxfOiLcVUtmwNWzjQAcsum9qD6/YRICf7ciIjcWODQkh/vjg==", "edfd3c3e-9af8-40e1-b54b-08a58270e74a", new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6620562c-bd95-4fd1-92a9-8a402a4a6ccc", new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261), "AQAAAAEAACcQAAAAECIqwkyxmjSmuoaeMzmXgF3J6uWKL6XoPNcnyPfVhhHRt952tywblA4fh0ddvhdYQg==", "5f9b13b7-056f-4de7-a1bc-98ac1c6ff530", new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261), new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261) });
        }
    }
}
