using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryPattern.EF.Migrations
{
    public partial class addAuthorsBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Oth");

            migrationBuilder.EnsureSchema(
                name: "bok");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "Oth",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "bok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalSchema: "Oth",
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                schema: "bok",
                table: "Books",
                column: "AuthorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "Oth");
        }
    }
}
