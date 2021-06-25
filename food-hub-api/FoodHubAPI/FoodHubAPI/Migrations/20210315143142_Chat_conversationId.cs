using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Chat_conversationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "12486871-9023-4361-a1dd-a4bbad07e245", new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284), "AQAAAAEAACcQAAAAELp0SCK+PQyDR5ciB7RkCdthaqBWz/Q1QjbimXclis2K4n00NNlUc2mSQTsny73+DA==", "e98685ff-162e-4792-bf61-10fbcf73b7ed", new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "96e7696a-660b-4370-82ef-c629844924d5", new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284), "AQAAAAEAACcQAAAAEIL0Jq4eWwldp5Jz0c+k/A1l2bLSzPihfiyeasSRyaMnSsZR3B08T38PH/rS+c9dww==", "4d28e427-7b7a-4f27-91bb-53d591bb1826", new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6533290e-b125-4dc7-ba8e-2c72b9e17d28", new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284), "AQAAAAEAACcQAAAAEHlqD99VvomGUNQelSYMII41/ZwNxjVpvUp+1xJPSspZAKkSbFuK6lFgIO8GB1kKGw==", "635e4815-9bf4-4020-a7b2-215a1839dd9b", new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 31, 41, 229, DateTimeKind.Local).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 31, 41, 229, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 31, 41, 229, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 31, 41, 229, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284), new DateTime(2021, 3, 15, 17, 31, 41, 203, DateTimeKind.Local).AddTicks(284) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Chat");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5e725864-fb87-4d70-ac1f-df5633f56494", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), "AQAAAAEAACcQAAAAED1Oz2euxH/icggZ6pZ1zGMU5+rnJBQzUtQwe7pUR/lmRt+ATuCKHBoPwkmCchPnIg==", "810a8d35-0a56-4608-aa4e-efcc6e971114", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "2def9f9b-3325-4159-9cc4-1fd7584110a7", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), "AQAAAAEAACcQAAAAEHjjKxTWdGcZrDZHEoUQKIpusUQgCIV7lD6d4XEno7JWiN3a6VitdTXM3CQZJnniIA==", "0ce3292e-5486-4a8f-8f53-865f47080d3a", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "db1198cd-cc54-4f57-995e-b318a981eab4", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), "AQAAAAEAACcQAAAAEK4T6Sckor/vP2nf5CI4OJn8hRYa3ey4u0905PzInEllSiQ1nBqnooBWNAu9Spoh7w==", "784acfc9-5459-4011-9b0b-eea171d6e783", new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 18, 12, 528, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485), new DateTime(2021, 3, 15, 17, 18, 12, 502, DateTimeKind.Local).AddTicks(8485) });
        }
    }
}
