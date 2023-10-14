using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRealationCategoryAndBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoty_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categoty_Id",
                table: "Books",
                column: "Categoty_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Categoty_Id",
                table: "Books",
                column: "Categoty_Id",
                principalTable: "Categories",
                principalColumn: "Catrgoty_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categoty_Id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categoty_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Categoty_Id",
                table: "Books");
        }
    }
}
