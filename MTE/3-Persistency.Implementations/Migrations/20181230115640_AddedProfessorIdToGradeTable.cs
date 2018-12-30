using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3_Persistency.Implementations.Migrations
{
    public partial class AddedProfessorIdToGradeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Grade",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Grade");
        }
    }
}
