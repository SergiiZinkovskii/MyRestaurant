using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class hash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 36, 34, 457, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 36, 34, 457, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 36, 34, 457, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 36, 34, 457, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 36, 34, 457, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "481f6cc0511143ccdd7e2d1b1b94faf0a700a8b49cd13922a70b5ae28acaa8c5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 4, 36, 504, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 4, 36, 504, DateTimeKind.Local).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 4, 36, 504, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 4, 36, 504, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 3, 19, 4, 36, 504, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "123456");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "654321");
        }
    }
}
