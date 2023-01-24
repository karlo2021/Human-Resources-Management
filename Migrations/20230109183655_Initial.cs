using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideNavColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationInstitute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvDoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employed = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "BackgroundColor", "BannerText", "CvLocation", "Name", "SideNavColor" },
                values: new object[] { 1L, "secondary", "User Dashboard", "wwwroot\\images", 1, "secondary" });

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "A" },
                    { 2L, "B" }
                });

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "primary" },
                    { 2L, "secondary" },
                    { 3L, "danger" },
                    { 4L, "warning" },
                    { 5L, "dark" },
                    { 6L, "success" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Birth", "CvDoc", "EducationDegree", "EducationInstitute", "EmailAddress", "Employment", "Name", "PhoneNumb", "Profession", "Surname", "Workplace" },
                values: new object[,]
                {
                    { 1L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person1@email.com", "Yes", "Person", "000-888", "Profession 1", "One", "Workplace 1" },
                    { 2L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person2@email.com", "Yes", "Person", "000-888", "Profession 2", "Two", "Workplace 2" },
                    { 3L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person3@email.com", "Yes", "Person", "000-888", "Profession 3", "Three", "Workplace 3" },
                    { 4L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person4@email.com", "Yes", "Person 4", "000-888", "Profession 4", "Four", "Workplace 4" },
                    { 5L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person5@email.com", "Yes", "Person", "000-888", "Profession 5", "Five", "Workplace 5" },
                    { 6L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person6@email.com", "Yes", "Person", "000-888", "Profession 6", "Six", "Workplace 6" },
                    { 7L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person7@email.com", "Yes", "Person", "000-888", "Profession 7", "Seven", "Workplace 7" },
                    { 8L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person8@email.com", "Yes", "Person", "000-888", "Profession 8", "Eight", "Workplace 8" },
                    { 9L, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/", "A", "School", "person9@email.com", "Yes", "Person", "000-888", "Profession 9", "Nine", "Workplace 9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_PersonId",
                table: "Records",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
