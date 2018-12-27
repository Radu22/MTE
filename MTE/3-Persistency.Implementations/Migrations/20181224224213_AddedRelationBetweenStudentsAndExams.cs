using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3_Persistency.Implementations.Migrations
{
    public partial class AddedRelationBetweenStudentsAndExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Students_ExamId",
                table: "Students",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Exams_ExamId",
                table: "Students",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Exams_ExamId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ExamId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Students");
        }
    }
}
