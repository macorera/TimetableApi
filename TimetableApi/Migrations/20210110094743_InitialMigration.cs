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
                        name: "FK_Timetables_Leaves_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 10, "Dr. Clark Gulgowski" },
                    { 16, "Tyler Kessler" },
                    { 15, "Jimmie Carroll V" },
                    { 14, "Richmond Muller" },
                    { 12, "Destin Kunze" },
                    { 11, "Elinor Kovacek" },
                    { 9, "Danial Turner" },
                    { 13, "Clifton Wehner" },
                    { 7, "Jessica Shields" },
                    { 6, "Ronaldo Cruickshank" },
                    { 5, "Kraig Kshlerin" },
                    { 4, "Anthony Sipes" },
                    { 3, "Mr. Myah Dickinson" },
                    { 2, "Pasquale Toy" },
                    { 1, "Clemens Yost II" },
                    { 8, "Ms. Maiya Kunde" }
                });

            migrationBuilder.InsertData(
                table: "Timetables",
                columns: new[] { "Id", "EndsAt", "GradeId", "LeaveId", "StartAt", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 22, new DateTime(2021, 1, 13, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 23, new DateTime(2021, 1, 13, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 24, new DateTime(2021, 1, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 25, new DateTime(2021, 1, 14, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 26, new DateTime(2021, 1, 14, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 27, new DateTime(2021, 1, 14, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 28, new DateTime(2021, 1, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 29, new DateTime(2021, 1, 14, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 33, new DateTime(2021, 1, 15, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 31, new DateTime(2021, 1, 14, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 32, new DateTime(2021, 1, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 34, new DateTime(2021, 1, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 35, new DateTime(2021, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 36, new DateTime(2021, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 37, new DateTime(2021, 1, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 38, new DateTime(2021, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 }
                });

            migrationBuilder.InsertData(
                table: "Timetables",
                columns: new[] { "Id", "EndsAt", "GradeId", "LeaveId", "StartAt", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 21, new DateTime(2021, 1, 13, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 30, new DateTime(2021, 1, 14, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 14, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 20, new DateTime(2021, 1, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 7, new DateTime(2021, 1, 11, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 18, new DateTime(2021, 1, 13, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 1, new DateTime(2021, 1, 11, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2021, 1, 11, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 3, new DateTime(2021, 1, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 4, new DateTime(2021, 1, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 5, new DateTime(2021, 1, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 6, new DateTime(2021, 1, 11, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 39, new DateTime(2021, 1, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 8, new DateTime(2021, 1, 11, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 11, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 9, new DateTime(2021, 1, 12, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 10, new DateTime(2021, 1, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 8, 45, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 11, new DateTime(2021, 1, 12, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 12, new DateTime(2021, 1, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 13, new DateTime(2021, 1, 12, 11, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 14, new DateTime(2021, 1, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 15, new DateTime(2021, 1, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 16, new DateTime(2021, 1, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 },
                    { 17, new DateTime(2021, 1, 13, 8, 45, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 19, new DateTime(2021, 1, 13, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 13, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 40, new DateTime(2021, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2021, 1, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), 8, 9 }
                });

            migrationBuilder.InsertData(
                table: "GradesSubjects",
                columns: new[] { "GradeId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 6 },
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
                    { 1, 1, "Ned VonRueden" },
                    { 4, 1, "Verla Runolfsdottir" },
                    { 3, 1, "Demarcus Kulas" },
                    { 2, 1, "Jillian Dooley" },
                    { 5, 1, "August Jewess" }
                });

            migrationBuilder.InsertData(
                table: "TeachersSubjects",
                columns: new[] { "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 5, 9 },
                    { 7, 14 },
                    { 7, 13 },
                    { 6, 12 },
                    { 6, 11 },
                    { 5, 10 },
                    { 4, 8 },
                    { 1, 2 },
                    { 3, 6 },
                    { 3, 5 },
                    { 2, 4 },
                    { 2, 3 },
                    { 8, 15 },
                    { 1, 1 },
                    { 4, 7 },
                    { 8, 16 }
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
                name: "IX_Timetables_LeaveId",
                table: "Timetables",
                column: "LeaveId");
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
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Leaves");
        }
    }
}
