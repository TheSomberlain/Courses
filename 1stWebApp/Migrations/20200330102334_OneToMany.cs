using Microsoft.EntityFrameworkCore.Migrations;

namespace _1stWebApp.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeacherId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "CurrentTeacherId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurrentTeacherId",
                table: "Students",
                column: "CurrentTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_CurrentTeacherId",
                table: "Students",
                column: "CurrentTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_CurrentTeacherId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CurrentTeacherId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentTeacherId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
