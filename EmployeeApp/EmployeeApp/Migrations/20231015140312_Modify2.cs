using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Migrations
{
    public partial class Modify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_EmployeetId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_EmployeetId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "EmployeetId",
                schema: "dbo",
                table: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeetId",
                schema: "dbo",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_EmployeetId",
                schema: "dbo",
                table: "Department",
                column: "EmployeetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_EmployeetId",
                schema: "dbo",
                table: "Department",
                column: "EmployeetId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "EmployeetId");
        }
    }
}
