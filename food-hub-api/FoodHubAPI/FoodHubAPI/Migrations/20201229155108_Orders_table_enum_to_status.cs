using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Orders_table_enum_to_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "1d4958ed-ac5e-4289-a7ca-e5c2d7b712c0", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), "AQAAAAEAACcQAAAAEFg2BejbMUWOWEZlM4pbUmid0aasp+juluxxMkkzXO6B1mB1ygkoITypuyTjoIIfjA==", "1b7d0dd0-7290-43e5-8794-9addf83e9934", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ce1024b8-f508-4d1d-97b2-db39cbc3759c", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), "AQAAAAEAACcQAAAAEEnFR7D0ya72v1fNKk/8AmzPfywoK1JXlEdFcagwZ66SVJUafe2JINipCARdll5/iQ==", "8b44e2cb-43bd-4538-967e-b7a0d151c07f", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c45c419b-c3a6-4a1e-b00b-4392c3ceda59", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), "AQAAAAEAACcQAAAAEBp0IWRTEwsqMdQW09v7n8AC5StPOnC9s8UaKYvDu7ZsW4FG4swVMK/uZaDknb72Jw==", "1e1e5664-1905-455f-b336-3d89bfb857f1", new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786), new DateTime(2020, 12, 29, 18, 51, 7, 719, DateTimeKind.Local).AddTicks(7786) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
        }
    }
}
