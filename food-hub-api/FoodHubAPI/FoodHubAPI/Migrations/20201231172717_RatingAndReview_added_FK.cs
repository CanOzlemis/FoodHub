using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class RatingAndReview_added_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RatingAndReview",
                type: "int",
                nullable: true);

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
                name: "IX_RatingAndReview_RestaurantId",
                table: "RatingAndReview",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingAndReview_RestaurantDetails_RestaurantId",
                table: "RatingAndReview",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingAndReview_RestaurantDetails_RestaurantId",
                table: "RatingAndReview");

            migrationBuilder.DropIndex(
                name: "IX_RatingAndReview_RestaurantId",
                table: "RatingAndReview");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RatingAndReview");

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
    }
}
