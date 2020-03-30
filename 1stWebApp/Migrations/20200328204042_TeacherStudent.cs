using Microsoft.EntityFrameworkCore.Migrations;

namespace _1stWebApp.Migrations
{
    public partial class TeacherStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teacher_teacherId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Students",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_teacherId",
                table: "Students",
                newName: "IX_Students_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Students",
                newName: "teacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                newName: "IX_Students_teacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teacher_teacherId",
                table: "Students",
                column: "teacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
