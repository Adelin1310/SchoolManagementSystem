using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_School", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Subject", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Teacher", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Class_dbo_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "dbo_School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_SchoolTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_SchoolTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_SchoolTeacher_dbo_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "dbo_School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo_SchoolTeacher_dbo_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "dbo_Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_TeacherSubject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_TeacherSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_TeacherSubject_dbo_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbo_Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo_TeacherSubject_dbo_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "dbo_Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Classbook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Classbook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Classbook_dbo_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "dbo_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Student_dbo_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "dbo_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo_Student_dbo_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "dbo_School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Absence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WithLeave = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Absence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Absence_dbo_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "dbo_Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo_Absence_dbo_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbo_Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dbo_Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_Grade_dbo_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "dbo_Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo_Grade_dbo_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbo_Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Absence_StudentId",
                table: "dbo_Absence",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Absence_SubjectId",
                table: "dbo_Absence",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Class_SchoolId",
                table: "dbo_Class",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Classbook_ClassId",
                table: "dbo_Classbook",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Grade_StudentId",
                table: "dbo_Grade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Grade_SubjectId",
                table: "dbo_Grade",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_SchoolTeacher_SchoolId",
                table: "dbo_SchoolTeacher",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_SchoolTeacher_TeacherId",
                table: "dbo_SchoolTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Student_ClassId",
                table: "dbo_Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Student_SchoolId",
                table: "dbo_Student",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_TeacherSubject_SubjectId",
                table: "dbo_TeacherSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_TeacherSubject_TeacherId",
                table: "dbo_TeacherSubject",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo_Absence");

            migrationBuilder.DropTable(
                name: "dbo_Classbook");

            migrationBuilder.DropTable(
                name: "dbo_Grade");

            migrationBuilder.DropTable(
                name: "dbo_SchoolTeacher");

            migrationBuilder.DropTable(
                name: "dbo_TeacherSubject");

            migrationBuilder.DropTable(
                name: "dbo_Student");

            migrationBuilder.DropTable(
                name: "dbo_Subject");

            migrationBuilder.DropTable(
                name: "dbo_Teacher");

            migrationBuilder.DropTable(
                name: "dbo_Class");

            migrationBuilder.DropTable(
                name: "dbo_School");
        }
    }
}
