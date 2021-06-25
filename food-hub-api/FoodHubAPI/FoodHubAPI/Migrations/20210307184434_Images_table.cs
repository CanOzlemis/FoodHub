using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Images_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_RestaurantDetails_RestaurantId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Images_RestaurantId",
                table: "Images",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

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
    }
}
