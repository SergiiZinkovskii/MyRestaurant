using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class initializationWithPhotosAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 7, new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 3, new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 8, new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 1, new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4977) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 4, 10, 47, 30, 454, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 0, new DateTime(2023, 8, 4, 10, 47, 30, 454, DateTimeKind.Local).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 0, new DateTime(2023, 8, 4, 10, 47, 30, 454, DateTimeKind.Local).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 0, new DateTime(2023, 8, 4, 10, 47, 30, 454, DateTimeKind.Local).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Category", "DateCreate" },
                values: new object[] { 0, new DateTime(2023, 8, 4, 10, 47, 30, 454, DateTimeKind.Local).AddTicks(7622) });
        }
    }
}
