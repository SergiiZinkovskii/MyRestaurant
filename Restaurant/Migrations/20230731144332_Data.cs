using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "DateCreate", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, 0, new DateTime(2023, 7, 31, 17, 43, 31, 876, DateTimeKind.Local).AddTicks(3602), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "Bread", 2500m },
                    { 2L, 0, new DateTime(2023, 7, 31, 17, 43, 31, 876, DateTimeKind.Local).AddTicks(3643), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "Wine", 0m },
                    { 3L, 0, new DateTime(2023, 7, 31, 17, 43, 31, 876, DateTimeKind.Local).AddTicks(3645), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "Pizza", 3000m },
                    { 4L, 0, new DateTime(2023, 7, 31, 17, 43, 31, 876, DateTimeKind.Local).AddTicks(3647), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "Bear", 120m },
                    { 5L, 0, new DateTime(2023, 7, 31, 17, 43, 31, 876, DateTimeKind.Local).AddTicks(3649), "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", "Meat", 3000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
