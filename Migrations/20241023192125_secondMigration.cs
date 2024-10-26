using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itmo.Mvc.StudentsJournal.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeLogs_Students_studentId",
                table: "GradeLogs");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "GradeLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GradeLogs_Students_studentId",
                table: "GradeLogs",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GradeLogs_Students_studentId",
                table: "GradeLogs");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "GradeLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeLogs_Students_studentId",
                table: "GradeLogs",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
