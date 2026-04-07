using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifingVariantOptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Drop FK first (because it depends on table name)
            migrationBuilder.DropForeignKey(
                name: "FK_VariantValues_VariantOption_VariantOptionId",
                table: "VariantValues");

            // 2. Drop PK
            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantOption",
                table: "VariantOption");

            // 3. Rename table
            migrationBuilder.RenameTable(
                name: "VariantOption",
                newName: "VariantOptions");

            // 4. Rename index
            migrationBuilder.RenameIndex(
                name: "IX_VariantOption_Name",
                table: "VariantOptions",
                newName: "IX_VariantOptions_Name");

            // 5. Add PK again
            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantOptions",
                table: "VariantOptions",
                column: "Id");

            // 6. Recreate FK
            migrationBuilder.AddForeignKey(
                name: "FK_VariantValues_VariantOptions_VariantOptionId",
                table: "VariantValues",
                column: "VariantOptionId",
                principalTable: "VariantOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariantValues_VariantOptions_VariantOptionId",
                table: "VariantValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariantOptions",
                table: "VariantOptions");

            migrationBuilder.RenameTable(
                name: "VariantOptions",
                newName: "VariantOption");

            migrationBuilder.RenameIndex(
                name: "IX_VariantOptions_Name",
                table: "VariantOption",
                newName: "IX_VariantOption_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariantOption",
                table: "VariantOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantValues_VariantOption_VariantOptionId",
                table: "VariantValues",
                column: "VariantOptionId",
                principalTable: "VariantOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }


    }
}
