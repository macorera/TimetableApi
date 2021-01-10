using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimetableApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradesSubjects",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesSubjects", x => new { x.SubjectId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_GradesSubjects_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradesSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersSubjects", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeachersSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timetables_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetables_Leaves_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timetables_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetables_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Grade 5" },
                    { 2, "Grade 6" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 8, "World Literature" },
                    { 6, "Physics" },
                    { 5, "Biology" },
                    { 7, "Chemistry" },
                    { 3, "Science" },
                    { 2, "English" },
                    { 1, "Maths" },
                    { 4, "Geometry" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Gustave Hayes" },
                    { 14, "Adeline O'Hara DDS" },
                    { 13, "Litzy Funk" },
                    { 12, "Wallace Torp" },
                    { 11, "Jared Rosenbaum" },
                    { 10, "Kurtis Schimmel" },
                    { 8, "Alva Johns" },
                    { 3, "Alexandrine Daniel" },
                    { 6, "Sydney Rolfson" },
                    { 5, "Gabriel Blick" },
                    { 4, "Dr. Diego Toy" },
                    { 15, "Mauricio Schimmel" },
                    { 2, "Brandi Zulauf" },
                    { 1, "Sarah Collins" },
                    { 7, "Billy Quitzon" },
                    { 16, "Nicolas Jenkins MD" }
                });

            migrationBuilder.InsertData(
                table: "GradesSubjects",
                columns: new[] { "GradeId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 6 },
                    { 1, 5 },
                    { 1, 4 },
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "GradeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Braeden Monahan" },
                    { 4, 1, "Mary Beahan" },
                    { 3, 1, "Jailyn Koss" },
                    { 2, 1, "Yasmeen Beer" },
                    { 5, 1, "Mr. Dillan Lubowitz" }
                });

            migrationBuilder.InsertData(
                table: "TeachersSubjects",
                columns: new[] { "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 3, 5 },
                    { 7, 14 },
                    { 7, 13 },
                    { 6, 12 },
                    { 6, 11 },
                    { 5, 10 },
                    { 5, 9 },
                    { 4, 8 },
                    { 4, 7 },
                    { 3, 6 },
                    { 8, 15 },
                    { 2, 4 },
                    { 8, 16 },
                    { 1, 1 },
                    { 2, 3 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Timetables",
                columns: new[] { "Id", "EndsAt", "GradeId", "LeaveId", "StartAt", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 26, new DateTime(2021, 1, 14, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 7, new DateTime(2021, 1, 11, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 15, new DateTime(2021, 1, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 23, new DateTime(2021, 1, 13, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 31, new DateTime(2021, 1, 14, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 39, new DateTime(2021, 1, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 33, new DateTime(2021, 1, 15, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 8, new DateTime(2021, 1, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 16, new DateTime(2021, 1, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 24, new DateTime(2021, 1, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 32, new DateTime(2021, 1, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 40, new DateTime(2021, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 25, new DateTime(2021, 1, 14, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Timetables",
                columns: new[] { "Id", "EndsAt", "GradeId", "LeaveId", "StartAt", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 1, 13, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 9, new DateTime(2021, 1, 12, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 1, new DateTime(2021, 1, 11, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 38, new DateTime(2021, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 30, new DateTime(2021, 1, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 22, new DateTime(2021, 1, 13, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 14, new DateTime(2021, 1, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 3, new DateTime(2021, 1, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 11, new DateTime(2021, 1, 12, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 19, new DateTime(2021, 1, 13, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 27, new DateTime(2021, 1, 14, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 35, new DateTime(2021, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 18, new DateTime(2021, 1, 13, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, new DateTime(2021, 1, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 10, new DateTime(2021, 1, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 34, new DateTime(2021, 1, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 20, new DateTime(2021, 1, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 36, new DateTime(2021, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 2, new DateTime(2021, 1, 11, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 5, new DateTime(2021, 1, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 13, new DateTime(2021, 1, 12, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 21, new DateTime(2021, 1, 13, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 29, new DateTime(2021, 1, 14, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 37, new DateTime(2021, 1, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 6, new DateTime(2021, 1, 11, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 28, new DateTime(2021, 1, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 12, new DateTime(2021, 1, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradesSubjects_GradeId",
                table: "GradesSubjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersSubjects_TeacherId",
                table: "TeachersSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_GradeId",
                table: "Timetables",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_LeaveId",
                table: "Timetables",
                column: "LeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_SubjectId",
                table: "Timetables",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_TeacherId",
                table: "Timetables",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradesSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeachersSubjects");

            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
