using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_2._5.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_persons_FK_PersonId",
                        column: x => x.FK_PersonId,
                        principalTable: "persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_FK_InterestId",
                        column: x => x.FK_InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "PersonId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Gösta Göstasson", "1234567890" },
                    { 2, "Eva Evasson", "9876543210" },
                    { 3, "Lennart Lennartsson", "0918273645" },
                    { 4, "Lena Lenasson", "1122334455" },
                    { 5, "Jesus Jesusson", "99887766" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "FK_PersonId", "Title" },
                values: new object[,]
                {
                    { 1, "Walk in the woods", 1, "Walking" },
                    { 2, "Code C#", 2, "Code" },
                    { 3, "Swim faster", 3, "Swiming" },
                    { 4, "Marathon", 4, "Running" },
                    { 5, "Flowers in all colour", 1, "Garden Work" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "FK_InterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Walk.com" },
                    { 2, 2, "CoDelike_a_pro.com" },
                    { 3, 3, "Swiming.com" },
                    { 4, 4, "Running.com" },
                    { 5, 5, "Flowers.uk.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FK_PersonId",
                table: "Interests",
                column: "FK_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FK_InterestId",
                table: "Links",
                column: "FK_InterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
