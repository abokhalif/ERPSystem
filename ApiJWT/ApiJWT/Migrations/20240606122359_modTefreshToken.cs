using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiJWT.Migrations
{
    public partial class modTefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiryOn",
                table: "RefreshToken",
                newName: "ExpiresOn");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "RefreshToken",
                newName: "CreatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiresOn",
                table: "RefreshToken",
                newName: "ExpiryOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "RefreshToken",
                newName: "CreateOn");
        }
    }
}
