using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Colum_fix_for_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantOwner_RestaurantDetails_RestaurantId",
                table: "RestaurantOwner");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantOwner_RestaurantId",
                table: "RestaurantOwner");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8917b58e-ff75-4c85-8cd8-f6096609b906", new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267), "AQAAAAEAACcQAAAAEOYPCpAO07ri2uhfZXzWzOmMPeNRrYmNFtajMCI9cbgclbg3CsSn5fBXYkmERi7Oow==", "191d26e6-5854-4dd4-9ec6-62e1de8334fe", new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "0f276f0a-b034-4753-bd74-37148110a97e", new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267), "AQAAAAEAACcQAAAAEHkJSHSVYWwBseK5/kEUV28LAWZfNIP4kjw2m+kB1lEMRNqGxxsovI4n1ACCD3wAlQ==", "50854290-d472-4630-b799-a4bead75e8e9", new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4606b2df-645a-463d-8c8e-8b7875a0f41b", new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267), "AQAAAAEAACcQAAAAEL8HdU1zStnvmZqE+7e71xtkS/Pr/pljOi8SBHLX2hMoEVZzpdusjZbnd2cM+qUYJQ==", "a9069b9b-de66-43ee-8d8f-4d9945461a77", new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267), new DateTime(2020, 12, 25, 17, 58, 52, 97, DateTimeKind.Local).AddTicks(8267) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "8f66d675-db8d-4be4-bf6d-46631ba2fe07", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), "AQAAAAEAACcQAAAAEOLEq2wotChloMpq+LktDgbvI8oMap3lFm4YMNwaTM03wZKMCLWc1FvD+2LwgnNzPQ==", "f65d58ba-ae73-433c-ab56-c17ef0b5f423", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "2d3c14aa-28e9-40a4-b055-bd062fdb340a", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), "AQAAAAEAACcQAAAAEKc1e8twcnjtznJcO0+uRNlUnJ69UsT8Y6/jNMG2BsFQ100t1PiK7FsdPLHJPkQmzQ==", "5b88d16f-b34c-427a-857d-9d30d34bebc1", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "4340c4a0-8b6f-47e3-8eef-a130ceb1cf4d", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), "AQAAAAEAACcQAAAAEFqitu0QHdhC534xZqS05teoulhaOba9/JBRtseKHZuFdxf0ZeXxkmH0gshzLcMvqQ==", "5dfb6f71-1b44-40a1-8bc1-74e590a54a09", new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195), new DateTime(2020, 12, 25, 17, 51, 36, 439, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOwner_RestaurantId",
                table: "RestaurantOwner",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_AspNetUsers_UserId",
                table: "RestaurantOwner",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantOwner_RestaurantDetails_RestaurantId",
                table: "RestaurantOwner",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
