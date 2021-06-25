using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Order_and_OrderDetails_tables_added_corrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_RestaurantDetails_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RestaurantDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Menu_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8fb8a19d-6037-4fc5-bed3-98763a29e2ed", new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508), "AQAAAAEAACcQAAAAEPiK+McL2kVUwQVfkWTc1fbK8sfKWfPMOOE1v+TdleU0AgErNPcDeBJU/CTq80Ihbg==", "21f44dc2-376e-4b32-a5df-fb73a3db6d20", new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8c8d54c2-71c8-4239-a797-416001429c94", new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508), "AQAAAAEAACcQAAAAEBfWgjz6FxWiTswDIjr/n7jQgJxl1dstLbUJxDpVK07t4UUejrr1OPY072olXyLdJw==", "7b77b197-85dd-49e5-8856-06e6ca544296", new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8ad8c190-4922-4267-8651-8c504b073a5f", new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508), "AQAAAAEAACcQAAAAEMLZE/QtAw0i+UvAtPOwISBdTQgF3UZGoAKtTDUyrwvHWkrGY9lf7K6ShTmWGMKfSA==", "85569ae7-fe8c-404d-a704-e9c98b73318a", new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508), new DateTime(2020, 12, 29, 18, 37, 52, 720, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.CreateIndex(
                name: "IX_Order_RestaurantId",
                table: "Order",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5d6eab8f-8a02-44c3-9abb-087e32f21d9f", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEP0bwxM+sGZH97wFI/otpaW2IzcM/1BB8uqffYMdCe8W3Qa+EVClrEcGjnS+B+I/ZQ==", "c3cb820f-5095-485f-bb00-ca86ccd0f3b3", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "338dbcbc-c5de-4245-9791-36059a3953a0", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEC0UFDwukw+fRjEMW5p5xYiC1TI2Qkkl7fKswxUNJpYWguw4Bau5gqzPFlWn0aA0UQ==", "885be640-4069-4aad-bc96-b9905d93ba31", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "f7a79abd-5749-4c2d-b402-bd3c55a0f0d0", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), "AQAAAAEAACcQAAAAEJkCyQc8WenXQ+j5fpN4qdEieIeyqkXM/r1noJrdGQTCNQWDGaWbUAo59IPXvbp3Qw==", "90bd315c-2bdc-4265-a826-153bf3dec60c", new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513), new DateTime(2020, 12, 29, 17, 50, 26, 975, DateTimeKind.Local).AddTicks(2513) });
        }
    }
}
