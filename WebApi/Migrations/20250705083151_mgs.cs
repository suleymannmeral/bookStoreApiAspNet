using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1e79d4-567c-4173-85f9-07c41205779e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6436d270-fd61-4479-a5ec-725fca6a4a57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7efd823c-3506-4f57-b0a1-c57b2fb3fb73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06032a14-a10e-461c-bdbd-debdcd187cef", null, "Editor", "EDITOR" },
                    { "0bbfdeff-c91c-4078-a4e6-9aa5b8a707c8", null, "Admin", "ADMIN" },
                    { "cad1e163-8f3d-4718-b3f5-5114b276045a", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Title" },
                values: new object[] { 50m, "Araba Sevdası" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Yaban");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06032a14-a10e-461c-bdbd-debdcd187cef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bbfdeff-c91c-4078-a4e6-9aa5b8a707c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cad1e163-8f3d-4718-b3f5-5114b276045a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d1e79d4-567c-4173-85f9-07c41205779e", null, "User", "USER" },
                    { "6436d270-fd61-4479-a5ec-725fca6a4a57", null, "Editor", "EDITOR" },
                    { "7efd823c-3506-4f57-b0a1-c57b2fb3fb73", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Title" },
                values: new object[] { 6m, "Beyza" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Ankara'yı Yaşamak");
        }
    }
}
