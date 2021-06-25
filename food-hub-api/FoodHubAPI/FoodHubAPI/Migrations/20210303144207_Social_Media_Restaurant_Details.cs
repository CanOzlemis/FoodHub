using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Social_Media_Restaurant_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarningsHistory");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "RestaurantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "b7fd9f6e-4f5e-40ee-af9e-cc55f46139e7", new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218), "AQAAAAEAACcQAAAAEDZME0tD4VHh2PZFNDgQU3dku1cnbTwfgzZfNA7WbObknuYELP/+Lr1hRG1vheYbFg==", "ce135086-6886-44a0-b157-a0ae0d621dcf", new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "9927fcfd-9034-40e7-8823-f97542e520c5", new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218), "AQAAAAEAACcQAAAAEOv/OL0VuT7K8a46IEkuYFtr1K2GCE7O/2Hqx0ndEvhney7PLVY8nW8u+/iI/Zny3Q==", "9ae73731-9d2e-4aeb-a768-4829563b2346", new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "912067e4-fe51-4a2c-aadf-04ad19cc34b3", new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218), "AQAAAAEAACcQAAAAEMVzjwU90IRSB+iBJS4ZqbBocyahJ5ulz8N5dY4AmARSfEY4S7Yeuj6a27hj85UPJA==", "ad2ecf52-6d6c-456c-abbe-12c1e7247f42", new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218), new DateTime(2021, 3, 3, 17, 42, 6, 229, DateTimeKind.Local).AddTicks(1218) });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveEarnings_RestaurantId",
                table: "ActiveEarnings",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveEarnings_RestaurantDetails_RestaurantId",
                table: "ActiveEarnings",
                column: "RestaurantId",
                principalTable: "RestaurantDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveEarnings_RestaurantDetails_RestaurantId",
                table: "ActiveEarnings");

            migrationBuilder.DropIndex(
                name: "IX_ActiveEarnings_RestaurantId",
                table: "ActiveEarnings");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "RestaurantDetails");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "RestaurantDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "RestaurantDetails");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "RestaurantDetails");

            migrationBuilder.CreateTable(
                name: "EarningsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsHistory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "7ef21a02-cee7-40cf-a89b-29bf5e6ccb0c", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), "AQAAAAEAACcQAAAAECZaKfjblr6FgV/wdQ+dt70mFbJKv90i/FGswaXg/vPo8ErfQ5oOyHD0kvPvXluPOg==", "c5f09070-e51c-41e2-b037-ede7e84daf47", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6aa65c66-b767-4f68-8bb9-987e2f62c5b7", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), "AQAAAAEAACcQAAAAEJaNgbgDrNqf7hc8wwgSqP7asx64uY2vqVOYVn6m3JXCCcdhhcNhs2azGX8eljjd4w==", "be6bc21f-4c48-41ca-934b-ed7d8a8c2932", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "a0e57cc6-5658-4549-84ac-c24c48fa7d4f", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), "AQAAAAEAACcQAAAAEMifiCyDMgF1KBkExZN6dpocgp0bGVf8hPV9J95HUjU5wj5AqQgbl7vQ0HD2bEdkDQ==", "c1924a1b-3d3b-4faa-bed3-eb11cc81462b", new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });

            migrationBuilder.InsertData(
                table: "EarningsHistory",
                columns: new[] { "Id", "Month", "RestaurantId", "Total", "Year" },
                values: new object[,]
                {
                    { 1, 12, 1, 13254.75f, 2019 },
                    { 2, 1, 1, 1710.25f, 2020 }
                });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473), new DateTime(2021, 3, 1, 18, 40, 48, 206, DateTimeKind.Local).AddTicks(2473) });
        }
    }
}
