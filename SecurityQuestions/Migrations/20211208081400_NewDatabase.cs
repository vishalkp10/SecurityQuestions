using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityQuestions.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityQuestion",
                columns: table => new
                {
                    SecurityQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestion", x => x.SecurityQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserSecurityQuestions",
                columns: table => new
                {
                    UserSecurityQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SecurityQuestionID = table.Column<int>(type: "int", nullable: false),
                    SecurityQuestionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurityQuestions", x => x.UserSecurityQuestionID);
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestion",
                columns: new[] { "SecurityQuestionID", "Description" },
                values: new object[,]
                {
                    { 1, "In what city were you born?" },
                    { 2, "What is the name of your favorite pet?" },
                    { 3, "What is your mother's maiden name?" },
                    { 4, "What high school did you attend?" },
                    { 5, "What was the mascot of your high school?" },
                    { 6, "What was the make of your first car?" },
                    { 7, "What was your favorite toy as a child?" },
                    { 8, "Where did you meet your spouse?" },
                    { 9, "What is your favorite meal?" },
                    { 10, "Who is your favorite actor / actress?" },
                    { 11, "What is your favorite album?" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name" },
                values: new object[,]
                {
                    { 1, "John" },
                    { 2, "David" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityQuestion");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSecurityQuestions");
        }
    }
}
