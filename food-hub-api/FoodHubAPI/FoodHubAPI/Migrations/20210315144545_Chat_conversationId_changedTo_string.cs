using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Chat_conversationId_changedTo_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConversationId",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c2f3630e-19d5-4dfa-8b0a-c9528a79b97a", new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185), "AQAAAAEAACcQAAAAEPKJ5IV9R4nm798+ZgrDAfC2JgyRcB/PBTSxwfMQwlnVQfWpuZhbBs86jF0xoPPPqw==", "379645fb-1ec8-4ab5-921b-2ddbacefbcab", new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "a709ed52-b5d3-4ca4-977f-c6926f89a5f1", new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185), "AQAAAAEAACcQAAAAEDEiIFmRKFEIj8uTSXkLuo3FmqbCSXc9H9Or9ZSSDrJk+J2VtgQ/vqLlGp5pVrZjqw==", "e1f3c615-2947-49dd-95e3-bf3355e1d226", new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "875dafc7-3c71-4836-877d-3add7d0d3a01", new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185), "AQAAAAEAACcQAAAAEC7AgPWoy/RFUWlWBtr4cvmFeeVrEXucNGw/Z6v7IDofyj8nbhnG1AwHtJeCIn5pOQ==", "71cc89c1-d8f9-4e34-8b8e-e7b18f32d1fc", new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 45, 44, 833, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 45, 44, 833, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 45, 44, 833, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 15, 17, 45, 44, 833, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185), new DateTime(2021, 3, 15, 17, 45, 44, 810, DateTimeKind.Local).AddTicks(9185) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ConversationId",
                table: "Chat",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
