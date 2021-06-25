using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Favourite_restaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavouriteRestaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteRestaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteRestaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteRestaurants_RestaurantDetails_RestaurantId",
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

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteRestaurants_RestaurantId",
                table: "FavouriteRestaurants",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteRestaurants_UserId",
                table: "FavouriteRestaurants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteRestaurants");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

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
        }
    }
}
