using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class new_seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "User", "USER" },
                    { "3", "3", "Owner", "OWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5af6724c-29a4-443c-adbb-d9b5a15fe30f", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "CANSARAJLIJA+ADMIN@GMAIL.COM", "CANSARAJLIJA+ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJzERM3uZ7L38P4Qo+wgVMDSUxcZqMJfA8MQ1Vi0zKndpTgbG9DdlHlBUKdyx3BaAQ==", "db8c3cf5-5c5e-493d-bd2e-61cfa3001f5b", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Updated", "UserName" },
                values: new object[,]
                {
                    { "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6", 0, "d6d6c938-f0c1-4f62-9f87-1a9ac9491606", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "User", "cansarajlija+owner@gmail.com", true, "Can", "Owner", false, null, "CANSARAJLIJA+OWNER@GMAIL.COM", "CANSARAJLIJA+OWNER@GMAIL.COM", "AQAAAAEAACcQAAAAEJjqU5zMoTGn1dDNAWGr38YLNRMylw8H0UDxTJl28UKcHCcN8EMmEIQaFQmCzIHf7Q==", "05313035675", false, "74958c60-d562-4b8b-bf12-436b4860d113", false, new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "cansarajlija+owner@gmail.com" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", 0, "27431157-fd4d-444a-b601-8376b21d96f0", new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "User", "cansarajlija+user@gmail.com", true, "Can", "User", false, null, "CANSARAJLIJA+USER@GMAIL.COM", "CANSARAJLIJA+USER@GMAIL.COM", "AQAAAAEAACcQAAAAEKvQr2vFRz7CfmVD0e42FeAwmo8gilELPazFD67MgGoSJpXRffbiIYQ8FkX5thYkHg==", "05313035675", false, "8507910e-112c-4cb7-aebe-9aa607339710", false, new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), "cansarajlija+user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantDetails",
                columns: new[] { "Id", "About", "Approved", "AverageDeliveryTime", "Created", "MinOrderPrice", "Name", "Rating", "Updated" },
                values: new object[] { 1, "This restaurant is created only for testing environment. SHOULD NOT BE SEEN ON PRODUCTION", false, 15, new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235), 10f, "Test Restaurant", 5f, new DateTime(2020, 12, 25, 15, 13, 27, 396, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" });

            migrationBuilder.DeleteData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "2f6ad270-b88d-41bf-9658-2bf4d49834f8", new DateTime(2020, 12, 25, 14, 47, 10, 466, DateTimeKind.Local).AddTicks(5567), null, null, "AQAAAAEAACcQAAAAEFTNVUr4eArvbztmvsv0p2A5XJBbquSX21ux//r/rGDQ1hlBPoHTOop1yM3vPfFbCA==", "494a72d9-4553-4ad9-bd24-0bededeabe01", new DateTime(2020, 12, 25, 14, 47, 10, 467, DateTimeKind.Local).AddTicks(8450) });
        }
    }
}
