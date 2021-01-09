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
                name: "TeachersSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
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
                    { 9, "Enoch Kuhn" },
                    { 14, "Idell Haag" },
                    { 13, "Jacey Kovacek" },
                    { 12, "Blair Goodwin" },
                    { 11, "Mariam Lockman" },
                    { 10, "Aidan Harber" },
                    { 8, "Caleigh Shanahan" },
                    { 3, "Zoe D'Amore Jr." },
                    { 6, "Elissa McLaughlin" },
                    { 5, "Dr. Mabel Murazik" },
                    { 4, "Ima Fadel" },
                    { 15, "Curt Renner" },
                    { 2, "Johathan Muller" },
                    { 1, "Andrew Morissette V" },
                    { 7, "Wilfrid Cartwright" },
                    { 16, "Cale Hansen" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "GradeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Alize Schamberger" },
                    { 15, 1, "Walter Goodwin" },
                    { 14, 1, "Ms. Angela Wiza" },
                    { 13, 1, "Stephanie Rowe" },
                    { 12, 1, "Linwood Abbott" },
                    { 10, 1, "Antonietta Rath" },
                    { 9, 1, "Samara Feil" },
                    { 11, 1, "Miss Ayden Williamson" },
                    { 7, 1, "Pattie Harber DVM" },
                    { 6, 1, "Aglae Greenholt" },
                    { 5, 1, "Heaven Abbott" },
                    { 4, 1, "Ansel Gulgowski" },
                    { 3, 1, "Reva Powlowski" },
                    { 2, 1, "Melany Greenholt" },
                    { 8, 1, "Margie Abbott" }
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
                    { 1, 1 },
                    { 3, 6 },
                    { 3, 5 },
                    { 2, 4 },
                    { 2, 3 },
                    { 1, 2 },
                    { 8, 15 },
                    { 4, 7 },
                    { 8, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersSubjects_TeacherId",
                table: "TeachersSubjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeachersSubjects");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
