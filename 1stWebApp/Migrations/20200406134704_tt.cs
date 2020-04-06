using Microsoft.EntityFrameworkCore.Migrations;

namespace _1stWebApp.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDiscipline_Disciplines_DisciplineName",
                table: "TeacherDiscipline");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDiscipline_Teachers_TeacherId",
                table: "TeacherDiscipline");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherDiscipline",
                table: "TeacherDiscipline");

            migrationBuilder.RenameTable(
                name: "TeacherDiscipline",
                newName: "TeacherDisciplines");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherDiscipline_DisciplineName",
                table: "TeacherDisciplines",
                newName: "IX_TeacherDisciplines_DisciplineName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDisciplines",
                table: "TeacherDisciplines",
                columns: new[] { "TeacherId", "DisciplineName" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDisciplines_Disciplines_DisciplineName",
                table: "TeacherDisciplines",
                column: "DisciplineName",
                principalTable: "Disciplines",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDisciplines_Teachers_TeacherId",
                table: "TeacherDisciplines",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDisciplines_Disciplines_DisciplineName",
                table: "TeacherDisciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDisciplines_Teachers_TeacherId",
                table: "TeacherDisciplines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherDisciplines",
                table: "TeacherDisciplines");

            migrationBuilder.RenameTable(
                name: "TeacherDisciplines",
                newName: "TeacherDiscipline");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherDisciplines_DisciplineName",
                table: "TeacherDiscipline",
                newName: "IX_TeacherDiscipline_DisciplineName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherDiscipline",
                table: "TeacherDiscipline",
                columns: new[] { "TeacherId", "DisciplineName" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDiscipline_Disciplines_DisciplineName",
                table: "TeacherDiscipline",
                column: "DisciplineName",
                principalTable: "Disciplines",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDiscipline_Teachers_TeacherId",
                table: "TeacherDiscipline",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
