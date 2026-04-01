using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class StudentsSubjectMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentsID",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsID",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_SubjectsID",
                table: "StudentSubject");

            migrationBuilder.RenameColumn(
                name: "SubjectsID",
                table: "StudentSubject",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "StudentsID",
                table: "StudentSubject",
                newName: "SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                columns: new[] { "StudentId", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectId",
                table: "StudentSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentSubject");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "StudentSubject",
                newName: "SubjectsID");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "StudentSubject",
                newName: "StudentsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                columns: new[] { "StudentsID", "SubjectsID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectsID",
                table: "StudentSubject",
                column: "SubjectsID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentsID",
                table: "StudentSubject",
                column: "StudentsID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsID",
                table: "StudentSubject",
                column: "SubjectsID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
