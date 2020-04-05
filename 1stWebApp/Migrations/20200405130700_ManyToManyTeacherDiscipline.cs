using Microsoft.EntityFrameworkCore.Migrations;

namespace _1stWebApp.Migrations
{
    public partial class ManyToManyTeacherDiscipline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "Teachers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discipline",
                table: "Teachers",
                type: "text",
                nullable: true);
        }
    }
}
