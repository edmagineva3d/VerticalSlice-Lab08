using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Courses",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                Code = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                Credits = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Courses", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Students", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Admissions",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                AdmissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                AcademicYear = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Admissions", x => x.Id);
                table.ForeignKey("FK_Admissions_Students_StudentId", x => x.StudentId,
                    "Students", "Id", onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AdmissionCourses",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                AdmissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AdmissionCourses", x => x.Id);
                table.ForeignKey("FK_AdmissionCourses_Admissions_AdmissionId", x => x.AdmissionId,
                    "Admissions", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_AdmissionCourses_Courses_CourseId", x => x.CourseId,
                    "Courses", "Id", onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex("IX_Admissions_StudentId", "Admissions", "StudentId");
        migrationBuilder.CreateIndex("IX_AdmissionCourses_AdmissionId", "AdmissionCourses", "AdmissionId");
        migrationBuilder.CreateIndex("IX_AdmissionCourses_CourseId", "AdmissionCourses", "CourseId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("AdmissionCourses");
        migrationBuilder.DropTable("Admissions");
        migrationBuilder.DropTable("Courses");
        migrationBuilder.DropTable("Students");
    }
}
