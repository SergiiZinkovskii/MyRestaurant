using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class carts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_BasketId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 51, 54, 448, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 51, 54, 448, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 51, 54, 448, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 51, 54, 448, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreate",
                value: new DateTime(2023, 8, 11, 19, 51, 54, 448, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders");

            migrationBuilder.AddColumn<long>(
                name: "BasketId",
                table: "Orders",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_BasketId",
                table: "Orders",
                column: "BasketId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
