using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class RatingAndReview_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingAndReview",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingAndReview", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_RatingAndReview_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4a6c60ea-433c-41f3-9fa0-d1c6b5a8489a", new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605), "AQAAAAEAACcQAAAAELMFOFEn9eNGkC693WQhkj2Mp81GFfW9zRt4IDxN1MgHqh/MrSpAWBUZNIXIC0CP8w==", "b755eadf-96fd-4eae-8600-17fb38bbe225", new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "1f838af6-c575-44b3-bbaa-986fc01a9437", new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605), "AQAAAAEAACcQAAAAEMU4yy1yB0NDuKMSN94AgRMTnPiX5QaEFtHxXY/1nzjVfNYkVh09JpLfy0q2he8pJg==", "c1daeb5c-2225-42c3-b20d-d9179045365d", new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "bc7fea01-6b2a-4da8-99e8-5a319218d959", new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605), "AQAAAAEAACcQAAAAEB1PFRaEcdrkzAHPb1vAMYB4vf6Zp0TQI+KkSElaD73uQAHZDzfPbbO3osdQ5jcKFw==", "e0d048cc-bcaf-4a07-9a19-6b9fc893ca74", new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605), new DateTime(2020, 12, 31, 20, 6, 38, 829, DateTimeKind.Local).AddTicks(605) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingAndReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ba9a9e62-b4fb-4c54-bf3d-a9dfaee46947", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), "AQAAAAEAACcQAAAAEIMfT/GQI4IOv93MWFwdsDb2v+9a9HptG+jtRRh1RERWfhBSdH7ReV1otgMlkC27Qg==", "b7fe5bd7-4123-46d5-9e93-1b4b60719adb", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6fdedd08-9872-495b-a3e7-9fc1921e7836", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), "AQAAAAEAACcQAAAAEJBGzny+mtKI+xO0xLAxCYro+SbPH/fneg68xaqZwVsMoOSyr84VtnWbut3N0gIFIQ==", "bc2a24a0-50fa-48b5-847c-843345551ac4", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "fb1ac28c-c6a0-438b-b3d5-5b31e629a8d7", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), "AQAAAAEAACcQAAAAEMDSP9WzzbYFtxkY0Ms02SUqPz1PgqQeTvNGp3pWLmtWLa05CwYdZf+tcS0+z7XKcA==", "67a250ef-bb2d-4bd5-93d7-0de2b9f140db", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });
        }
    }
}
