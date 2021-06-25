using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Order_table_grammar_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Order",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "ba9a9e62-b4fb-4c54-bf3d-a9dfaee46947", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), "AQAAAAEAACcQAAAAEIMfT/GQI4IOv93MWFwdsDb2v+9a9HptG+jtRRh1RERWfhBSdH7ReV1otgMlkC27Qg==", "b7fe5bd7-4123-46d5-9e93-1b4b60719adb", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6fdedd08-9872-495b-a3e7-9fc1921e7836", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), "AQAAAAEAACcQAAAAEJBGzny+mtKI+xO0xLAxCYro+SbPH/fneg68xaqZwVsMoOSyr84VtnWbut3N0gIFIQ==", "bc2a24a0-50fa-48b5-847c-843345551ac4", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "fb1ac28c-c6a0-438b-b3d5-5b31e629a8d7", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), "AQAAAAEAACcQAAAAEMDSP9WzzbYFtxkY0Ms02SUqPz1PgqQeTvNGp3pWLmtWLa05CwYdZf+tcS0+z7XKcA==", "67a250ef-bb2d-4bd5-93d7-0de2b9f140db", new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578), new DateTime(2020, 12, 30, 0, 46, 12, 493, DateTimeKind.Local).AddTicks(9578) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Order",
                newName: "Adress");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5097c6d4-42f3-4025-9202-6714bfc0512a", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), "AQAAAAEAACcQAAAAEPU/ZLr1XCCxA9sW0jUKc2FZO1zX98cggA7u/BSQisOBWgB/KL3EshXZMaRpC++v+A==", "665638c8-7dcf-4308-a7d8-8b2185fb782f", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "44dd6f1e-931c-4d3a-933e-4c725e4b155a", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), "AQAAAAEAACcQAAAAEK0Xd4bETq/j3H9qD+rOm47ZTLUDT+boGvY1+a/BxP2wgJy+W95JZcH/6G5n8wmp1Q==", "8c61c472-327c-44c8-9bd7-c40e94ca2b01", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5764d9f3-0e1c-44e4-82de-1c748c6dd1ca", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), "AQAAAAEAACcQAAAAECXB6ETmqaMBJVfHkxJmqlTBlIflvP4ENKNIUewbKf5w7OfsOaTjvkPZhHHda8d2RA==", "f512188e-adc8-4851-a3be-049da83e4150", new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699), new DateTime(2020, 12, 29, 20, 44, 27, 761, DateTimeKind.Local).AddTicks(9699) });
        }
    }
}
