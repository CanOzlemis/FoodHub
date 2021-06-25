using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Deleted_column_Reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RatingAndReview",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "e8aef681-4502-4117-a49b-9d130d1f8f2d", new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389), "AQAAAAEAACcQAAAAEESgRErZH2Xh8scWgJ3lvQ0XazCeUnObL/1F5eGUH9CM0nVCVrhj0m4aQRi1/4lldQ==", "86dba919-03d9-4e4c-ba84-e2d0d3b0ef33", new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "e390488f-bac0-4d39-87aa-3d21db5e3ab6", new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389), "AQAAAAEAACcQAAAAEMO5Q+5dFAj0LPAmWfLDedPj6I3gEQjQsiyo4htUE04MA/7BGqAailpfHj7lmgSMAw==", "3eb725d3-6812-4ca3-b277-05dd99b04fa6", new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "764cb7fe-d1dc-4bdc-b93f-c303b6744ba9", new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389), "AQAAAAEAACcQAAAAEI5bc2BpH7B+KJasRpOE5/0IfMVsawoX3IxofGrz779iwTvUFdwhACzuitp1TmZoxw==", "409bb3c5-b6c8-4059-a081-34447cf238f3", new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 11, 17, 17, 49, 231, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 11, 17, 17, 49, 232, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 11, 17, 17, 49, 232, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 11, 17, 17, 49, 232, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389), new DateTime(2021, 3, 11, 17, 17, 49, 207, DateTimeKind.Local).AddTicks(7389) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RatingAndReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "40121787-7279-454b-8c6b-3aa3b74493aa", new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680), "AQAAAAEAACcQAAAAEAzawZGWqnv7oZo2Fd1z2XkPcx1MgcvphmKNYvjAEfMmy3fe9AZm3QP9wO3YHMtVKQ==", "525ca544-dd5c-486b-9e43-62e8d5092067", new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "de5ebd5a-1159-41e5-b283-2ef639941b30", new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680), "AQAAAAEAACcQAAAAELIUx0XeBhBPaclO8HU7c9JJdycfLlyF3rcn4frGU18UzHwOjItNMci0Yx3+cCoUeQ==", "c097d23c-e775-4c62-bbf0-d9eb48f9e247", new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "92c2ed36-a590-4c67-974f-665773f6c024", new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680), "AQAAAAEAACcQAAAAEFJjx6rBwDONWTmJVzAitXXSG50vv4Q/5T8crPmrf15NPyoryYiWRxKPutNVYrHNhA==", "d790c128-0c37-4dbf-8f70-dea72e64dd2b", new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 7, 21, 44, 33, 699, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 7, 21, 44, 33, 699, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 7, 21, 44, 33, 699, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 7, 21, 44, 33, 699, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680), new DateTime(2021, 3, 7, 21, 44, 33, 677, DateTimeKind.Local).AddTicks(3680) });
        }
    }
}
