using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Read_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "617237da-2c79-43e9-addb-aae8a8b2e1a9", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), "AQAAAAEAACcQAAAAEOZaNJluqtFSajyMacYa6WV/biBA8r/MvLpBnJ0GuBp7N+wuTdzxYnRSlfaX9KYbTA==", "d8423edc-a05b-4630-90b3-15521649c18c", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "71d00031-1366-4254-89d6-7b4b0f7e4950", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), "AQAAAAEAACcQAAAAEFPgsDGtXJ3mpU16pg6PEtYkyvch4AxJV2PBtCP8lAJf20If/Hp+Qb4qGAa6zlKD5g==", "c75f544d-9920-4863-a65b-ae55a8fe4259", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "fa567ec1-f944-4f1d-ba4c-8dd99f49b9aa", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), "AQAAAAEAACcQAAAAEJW2SD2hGDmIhCe6zZXcz9rzZAK6E8XmG7XbHdZlC7KUNmDT2Sn4NtD5pPRji0MR9w==", "546bd8e7-51b2-4692-9699-54a851010b30", new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2021, 3, 16, 2, 24, 27, 643, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900), new DateTime(2021, 3, 16, 2, 24, 27, 620, DateTimeKind.Local).AddTicks(9900) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "Chat");

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
    }
}
