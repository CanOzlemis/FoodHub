using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class Menu_Table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "5c766457-6920-4a30-a709-827bf2958ced", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), "AQAAAAEAACcQAAAAEIbWA1nwZJ5gJVaKHOIDGMw4gTd3akTUCCTmOJBN5kuXUiLNyH7T6ZhDKvxdsp+xsw==", "d93eefd5-6055-4020-9fcd-7129975f7367", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "0deb3e34-c40f-4176-a0d2-cca0a67cfe68", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), "AQAAAAEAACcQAAAAEGHZdgOAF9UzCYvQ1MMNnN07B5Z4IOgn7MXwStAKMqYOhW4AApOr1vjcYTqvyiecZA==", "5c4fe921-c70c-4582-9e21-440c33996287", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "6bfdb21a-6eaa-412e-b7b7-53987d95d842", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), "AQAAAAEAACcQAAAAEM8ghNHm5SkYEEyRdBUAW+R6L27sw8qui8wh1HUHsvYeYoZ067FtnP2U/FWMAO+Q4g==", "c1847b9a-a992-4a25-85e8-8dbc1c241188", new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603), new DateTime(2020, 12, 28, 18, 15, 55, 539, DateTimeKind.Local).AddTicks(5603) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "c982a60a-e2ff-42b1-b773-e85a51561d0a", new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594), "AQAAAAEAACcQAAAAELOvni4mexRQCVo/JD2R/ss182swY+rqw9XyCuptjPi663vmbgPk5kseJfHlELVhkw==", "f5a4ae5b-befa-471a-bcaf-b0c14375ae80", new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "135838f0-nvg2–4gfe-afbf-59lkfsdd72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "e783d1ce-92a2-4ebc-b388-e78c30c56f7e", new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594), "AQAAAAEAACcQAAAAEAm0s25/1UtQYNkttaNXBCbCeskzPGPY6FiYEjOID5Qm+KFi0Z1HIBaiLh4mGQBoNQ==", "e018a683-bb22-4847-86d8-678aba242dd8", new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                columns: new[] { "ConcurrencyStamp", "Created", "PasswordHash", "SecurityStamp", "Updated" },
                values: new object[] { "e2bdbbd8-3746-482d-9aee-04f752b08497", new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594), "AQAAAAEAACcQAAAAEMPGx+BXooI//U7bhmm7rEny7jpQSBOzdewQz9asfo/+wpcsDxegRrWxlBir9fXqXQ==", "d41f3d0b-691c-49c3-a63b-d773b3d0ccf0", new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "RestaurantDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594), new DateTime(2020, 12, 25, 18, 59, 44, 340, DateTimeKind.Local).AddTicks(1594) });
        }
    }
}
