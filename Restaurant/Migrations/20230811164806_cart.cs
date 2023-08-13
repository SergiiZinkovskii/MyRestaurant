using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 48, 6, 518, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 48, 6, 518, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 48, 6, 518, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 48, 6, 518, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 48, 6, 518, DateTimeKind.Local).AddTicks(8069));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1L);

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
                column: "DateCreate",
                value: new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 4, 15, 32, 44, 37, DateTimeKind.Local).AddTicks(4977));
        }
    }
}
