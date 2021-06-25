using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
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

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "Created", "Message", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(6902), "This is a SUGGESTION feedback message from a normal user account", "Suggestion", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 2, new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(8426), "This is a BUG REPORT feedback message from a normal user account", "BugReport", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 3, new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(8458), "This is a SOMETHING ELSE  feedback message from a normal user account", "SomethingElse", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 4, new DateTime(2021, 3, 6, 21, 33, 56, 322, DateTimeKind.Local).AddTicks(8461), "This is a QUESTION  feedback message from a normal user account", "Question", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" }
                });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261), new DateTime(2021, 3, 6, 21, 33, 56, 298, DateTimeKind.Local).AddTicks(3261) });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ac0145ca-eb60-4e55-ae35-cd6210a7b35c", new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301), "AQAAAAEAACcQAAAAEOmm4fE80L6CMAmxtXz0qSp4Yr+zFmsJyh2vi8fowBDmF+e09RLOn9QrhdruD/rsjw==", "7803ac53-599b-4063-9d0d-2072e5a6d698", new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "965d6d33-e803-45e3-ac56-daff4905d70e", new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301), "AQAAAAEAACcQAAAAEOKSi7jEPa9fTsCoXILOLIoV/gXEIcThxolgYPKBFK8wLuppxJnmxFzgviX+k/ACBg==", "94530993-c0d2-4bde-902a-e330bf43af37", new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6ff5c423-ede1-40e3-af21-8a22af0efa63", new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301), "AQAAAAEAACcQAAAAEKr5LOscsqRBsxnow0VhiX21JZhQE08ojsKmY0Nmq0UGafHa5qpEh6+Dugcx6IaL9A==", "95d201b5-0cf9-4d9d-9b2a-05404815530a", new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301), new DateTime(2021, 3, 5, 16, 44, 14, 756, DateTimeKind.Local).AddTicks(301) });
        }
    }
}
