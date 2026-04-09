using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BasePrice", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 200m, new DateTime(2026, 4, 8, 17, 40, 51, 33, DateTimeKind.Local).AddTicks(2102), false, "T-Shirt" },
                    { 2, 800m, new DateTime(2026, 4, 8, 17, 40, 51, 33, DateTimeKind.Local).AddTicks(2108), false, "Sneakers" }
                });

            migrationBuilder.InsertData(
                table: "VariantOptions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Color" },
                    { 2, "Size" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Price", "ProductId", "SKU", "Stock" },
                values: new object[,]
                {
                    { 1, 220m, 1, "TS-RED-M", 10 },
                    { 2, 230m, 1, "TS-BLUE-L", 5 },
                    { 3, 850m, 2, "SN-WHITE-42", 8 }
                });

            migrationBuilder.InsertData(
                table: "VariantValues",
                columns: new[] { "Id", "ProductVariantId", "Value", "VariantOptionId" },
                values: new object[,]
                {
                    { 1, 1, "Red", 1 },
                    { 2, 1, "M", 2 },
                    { 3, 2, "Blue", 1 },
                    { 4, 2, "L", 2 },
                    { 5, 3, "White", 1 },
                    { 6, 3, "42", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VariantValues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VariantValues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VariantValues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VariantValues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VariantValues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VariantValues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VariantOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VariantOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
