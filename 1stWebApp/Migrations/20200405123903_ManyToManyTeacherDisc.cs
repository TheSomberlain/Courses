using Microsoft.EntityFrameworkCore.Migrations;

namespace _1stWebApp.Migrations
{
    public partial class ManyToManyTeacherDisc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDiscipline",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    DisciplineName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDiscipline", x => new { x.TeacherId, x.DisciplineName });
                    table.ForeignKey(
                        name: "FK_TeacherDiscipline_Disciplines_DisciplineName",
                        column: x => x.DisciplineName,
                        principalTable: "Disciplines",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherDiscipline_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDiscipline_DisciplineName",
                table: "TeacherDiscipline",
                column: "DisciplineName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherDiscipline");

            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}
