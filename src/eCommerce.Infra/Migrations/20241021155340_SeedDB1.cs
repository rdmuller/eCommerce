using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2024, 10, 21, 15, 53, 39, 659, DateTimeKind.Unspecified).AddTicks(1014), new TimeSpan(0, 0, 0, 0, 0)), "Moda", null },
                    { 2L, new DateTimeOffset(new DateTime(2024, 10, 21, 15, 53, 39, 659, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 0, 0, 0, 0)), "Informática", null },
                    { 3L, new DateTimeOffset(new DateTime(2024, 10, 21, 15, 53, 39, 659, DateTimeKind.Unspecified).AddTicks(1027), new TimeSpan(0, 0, 0, 0, 0)), "Eletrodomésticos", null },
                    { 4L, new DateTimeOffset(new DateTime(2024, 10, 21, 15, 53, 39, 659, DateTimeKind.Unspecified).AddTicks(1028), new TimeSpan(0, 0, 0, 0, 0)), "Automóveis", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "CreatedDate", "Email", "FatherName", "MotherName", "Name", "RG", "Sex", "Status", "UpdatedDate" },
                values: new object[] { 1L, null, new DateTimeOffset(new DateTime(2024, 10, 21, 15, 53, 39, 659, DateTimeKind.Unspecified).AddTicks(3722), new TimeSpan(0, 0, 0, 0, 0)), "admin@localhost", "", "", "admin", null, 1, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
