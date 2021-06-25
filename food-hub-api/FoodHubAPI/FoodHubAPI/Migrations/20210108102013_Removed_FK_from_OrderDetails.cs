using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Removed_FK_from_OrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Menu_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "ProductUnitPrice",
                table: "OrderDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5aa7104c-63c7-4733-96be-ade0ebd8e6bd", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), "AQAAAAEAACcQAAAAEPfYe0VjbYl6a6UL3/OkY3xEtsYCeXqnIJn6wkF9oDNRqm1JsCfTzydAVfHH3pqR5A==", "f86f5318-5625-44d3-8cc9-4b8138e779fb", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "575e8f98-3a26-4dfd-8475-9072eade729f", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), "AQAAAAEAACcQAAAAEIRHFWLM3oCcOjqpWVrttnlUDjW6ci/sSnY/ffQAWIHAtbn+BgRsQGTJrHKoOQSXSw==", "c6c9d146-f2cb-4cd4-8d63-1cbb3105e63d", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "9df9acfd-aa12-449e-898f-676387ce9fa0", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), "AQAAAAEAACcQAAAAEOdFcLyGh4GdhCVogGR3QrPw2thcsyPsxaDicr/drYOJf7HXmoIG77wGMwpP2Ff4TQ==", "39091e18-92ce-45cd-9f43-5a107755b020", new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346), new DateTime(2021, 1, 8, 13, 20, 12, 835, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductUnitPrice",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "cab7eef4-0e03-4a44-b7e1-4ae5886877de", new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170), "AQAAAAEAACcQAAAAEOT7lAoNBVB2nQaQrFnSgrnChz+iR96BrUkpf7qlstu02/5oet+eA3NYpzHhhF06GQ==", "3688c4b8-8622-4c17-bbd7-1a328ef5670f", new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "1e24b4f0-2811-4138-9708-fbfec1aceff3", new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170), "AQAAAAEAACcQAAAAEJr6i8NTpxyVNaziHEuMRl4ob6qYrl8e76sDAlJPOmztSqlbx4/mczF9DXnT8Y8ESQ==", "dd3f9ea6-f15f-4c86-86d4-3cea029b5058", new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "505b6bf6-ba06-445f-b46d-efd4fcee52b8", new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170), "AQAAAAEAACcQAAAAEBQyMXWKa4fF1rbD3enq7SEek5ANJkfLr+XWI5YciwdGieUyfvIKTjBTupmQWeC8gw==", "860ff6e5-3c4b-4b8f-a223-c2475af2a8cb", new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170), new DateTime(2020, 12, 31, 20, 27, 16, 793, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Menu_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Order_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
