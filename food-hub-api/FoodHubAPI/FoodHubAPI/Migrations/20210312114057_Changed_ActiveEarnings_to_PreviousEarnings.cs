using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Changed_ActiveEarnings_to_PreviousEarnings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveEarnings");

            migrationBuilder.CreateTable(
                name: "PreviousEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousEarnings_RestaurantDetails_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ede9c0bb-67f1-4bf3-9a46-a4743e2e95c4", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), "AQAAAAEAACcQAAAAELpwA7kgYoBj4EGMXgUS5RU5BF+/VfgapbJq0AhPwBlKL12hXgyFa9Wzc/OGQRocIw==", "ebafacb8-112c-4fd7-9d73-cecd0b8454b2", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4f6bc977-1802-4ad5-9f9b-636cb9b68bc1", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), "AQAAAAEAACcQAAAAEDk1yek2N4A2QzERMnlh04dSXHjyBOSviia+B9QO1dWmBUiMFSKaja2f06uZ326bWA==", "aec90506-f3f7-4b0e-b5d8-13321d7a72c3", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "727c3ab8-c26a-4dd8-8460-5dc46f2b2487", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), "AQAAAAEAACcQAAAAEI8W8hakovWIzbmJFUVT1reDxFajn71nCWx2V5bz1NFSWzLhTpfM+vWDhx0l/JkNug==", "5ef5a80e-17e2-4fcc-803e-42fbeb4630a5", new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 12, 14, 40, 56, 184, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.InsertData(
                table: "PreviousEarnings",
                columns: new[] { "Id", "Month", "RestaurantId", "Total", "Year" },
                values: new object[] { 1, 0, 1, 0f, 0 });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715), new DateTime(2021, 3, 12, 14, 40, 56, 157, DateTimeKind.Local).AddTicks(7715) });

            migrationBuilder.CreateIndex(
                name: "IX_PreviousEarnings_RestaurantId",
                table: "PreviousEarnings",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviousEarnings");

            migrationBuilder.CreateTable(
                name: "ActiveEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveEarnings_RestaurantDetails_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActiveEarnings",
                columns: new[] { "Id", "RestaurantId", "Total" },
                values: new object[] { 1, 1, 0f });

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

            migrationBuilder.CreateIndex(
                name: "IX_ActiveEarnings_RestaurantId",
                table: "ActiveEarnings",
                column: "RestaurantId");
        }
    }
}
