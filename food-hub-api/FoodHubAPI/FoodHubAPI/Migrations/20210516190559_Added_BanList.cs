using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Added_BanList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ApplicantRestaurants",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ApplicantRestaurants",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.CreateTable(
                name: "BanList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "d9854d0b-8f69-4d9f-84d3-f3c4ad5f7080", new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983), "AQAAAAEAACcQAAAAEPMMomHYrnvUdCHqIzNWg8poYIoP5YfmtJSVzawn8ayqHCWoRaI0oNNcXhuWYV+Ibw==", "9f5dcb68-da56-42df-8c3c-52a4e9a19441", new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "3626d0d8-1f37-4861-bb51-4beaffb84091", new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983), "AQAAAAEAACcQAAAAEBoF5RhElBuq1zOnLSctlJHGSkpyIi9pkv21YbN72c1/9H+EdlElbrIEzM1OEU0YFg==", "3994baf8-5f5e-4dc6-acec-83726f64fcfd", new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c01a9aec-3254-40ad-b938-d9c1d527fb8a", new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983), "AQAAAAEAACcQAAAAEEbied7SYTbGZXV+1zV/Nm5uKmogfGCoMMHDCKqffGTF6Qc0ep5jZoslhdzF4mL2zQ==", "063fe53c-236b-4578-aee9-b2e515e44d3a", new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 5, 16, 22, 5, 58, 190, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 5, 16, 22, 5, 58, 191, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 5, 16, 22, 5, 58, 191, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 5, 16, 22, 5, 58, 191, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983), new DateTime(2021, 5, 16, 22, 5, 58, 167, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.CreateIndex(
                name: "IX_BanList_UserId",
                table: "BanList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BanList");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ApplicantRestaurants",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ApplicantRestaurants",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "617237da-2c79-43e9-addb-aae8a8b2e1a9", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), "AQAAAAEAACcQAAAAEOZaNJluqtFSajyMacYa6WV/biBA8r/MvLpBnJ0GuBp7N+wuTdzxYnRSlfaX9KYbTA==", "d8423edc-a05b-4630-90b3-15521649c18c", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "71d00031-1366-4254-89d6-7b4b0f7e4950", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), "AQAAAAEAACcQAAAAEFPgsDGtXJ3mpU16pg6PEtYkyvch4AxJV2PBtCP8lAJf20If/Hp+Qb4qGAa6zlKD5g==", "c75f544d-9920-4863-a65b-ae55a8fe4259", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "fa567ec1-f944-4f1d-ba4c-8dd99f49b9aa", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), "AQAAAAEAACcQAAAAEJW2SD2hGDmIhCe6zZXcz9rzZAK6E8XmG7XbHdZlC7KUNmDT2Sn4NtD5pPRji0MR9w==", "546bd8e7-51b2-4692-9699-54a851010b30", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });
        }
    }
}
