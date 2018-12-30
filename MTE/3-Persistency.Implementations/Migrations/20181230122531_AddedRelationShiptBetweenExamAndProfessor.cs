using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3_Persistency.Implementations.Migrations
{
    public partial class AddedRelationShiptBetweenExamAndProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Exams",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ProfessorId",
                table: "Exams",
                column: "ProfessorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Professors_ProfessorId",
                table: "Exams",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Professors_ProfessorId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ProfessorId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Exams");
        }
    }
}
