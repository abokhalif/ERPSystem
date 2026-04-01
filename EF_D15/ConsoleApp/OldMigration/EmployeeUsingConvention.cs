//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace ConsoleApp.Migrations
//{
//    /// <inheritdoc />
//    public partial class EmployeeusingConvention : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Employees",
//                columns: table => new
//                {
//                    ID = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
//                    Age = table.Column<int>(type: "int", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Employees", x => x.ID);
//                });
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Employees");
//        }
//    }
//}

