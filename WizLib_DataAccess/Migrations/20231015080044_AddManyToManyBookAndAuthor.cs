using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizLib_DataAccess.Migrations
{
    public partial class AddManyToManyBookAndAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Fluent_Authors_Fluent_AuthorAuthor_Id",
                table: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_Fluent_AuthorAuthor_Id",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "Fluent_AuthorAuthor_Id",
                table: "BookAuthor");

            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthor",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Fluent_AuthorAuthor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthor", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthor_Fluent_Authors_Fluent_AuthorAuthor_Id",
                        column: x => x.Fluent_AuthorAuthor_Id,
                        principalTable: "Fluent_Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthor_Fluent_Books_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthor_Fluent_AuthorAuthor_Id",
                table: "Fluent_BookAuthor",
                column: "Fluent_AuthorAuthor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_BookAuthor");

            migrationBuilder.AddColumn<int>(
                name: "Fluent_AuthorAuthor_Id",
                table: "BookAuthor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_Fluent_AuthorAuthor_Id",
                table: "BookAuthor",
                column: "Fluent_AuthorAuthor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Fluent_Authors_Fluent_AuthorAuthor_Id",
                table: "BookAuthor",
                column: "Fluent_AuthorAuthor_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id");
        }
    }
}
