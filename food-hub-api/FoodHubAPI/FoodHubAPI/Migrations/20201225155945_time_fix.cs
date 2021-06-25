using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodHubAPI.Migrations
{
    public partial class time_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
