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
                    { 9, "Jean Mueller" },
                    { 14, "Isidro Moen DDS" },
                    { 13, "Ms. Mable Sporer" },
                    { 12, "Noe Gulgowski" },
                    { 11, "Verlie Kris" },
                    { 10, "Connie Blick" },
                    { 8, "Miss Nico Pouros" },
                    { 3, "Mandy Bednar" },
                    { 6, "Mallie Bradtke" },
                    { 5, "Mr. Conor Harris" },
                    { 4, "Cornell Williamson" },
                    { 15, "Ms. Cydney Gleichner" },
                    { 2, "Scotty Jast I" },
                    { 1, "Jerrod Kilback" },
                    { 7, "Alberto Gerhold" },
                    { 16, "Millie Crooks DDS" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "GradeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Adriana Grimes" },
                    { 2, 1, "Nolan Kuhlman" },
                    { 3, 1, "Tessie Corkery" },
                    { 4, 1, "Kianna O'Conner" },
                    { 5, 1, "Mrs. Richard Lindgren" },
                    { 6, 1, "Jayson O'Conner" },
                    { 7, 1, "Kiana Zulauf" },
                    { 8, 1, "Jesus Kuhn" },
                    { 9, 1, "Julia Adams Jr." },
                    { 10, 1, "Miller Kassulke" },
                    { 11, 1, "Lewis Corkery II" },
                    { 12, 1, "Yasmeen Reichert" },
                    { 13, 1, "Neva Bode IV" },
                    { 14, 1, "Adolf Buckridge" },
                    { 15, 1, "Ruthe Prohaska" }
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
