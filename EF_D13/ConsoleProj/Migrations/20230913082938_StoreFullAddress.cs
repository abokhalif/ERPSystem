using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleProj.Migrations
{
    /// <inheritdoc />
    public partial class StoreFullAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreAddress_FLine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreAddress_ZipCode = table.Column<int>(type: "int", nullable: false),
                    StoreAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreAddress_CountryCode = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    SartHr = table.Column<byte>(type: "tinyint", nullable: false),
                    EndHr = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
