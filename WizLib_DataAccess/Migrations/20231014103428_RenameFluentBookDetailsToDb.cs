using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizLib_DataAccess.Migrations
{
    public partial class RenameFluentBookDetailsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookDetail",
                table: "Fluent_BookDetail");

            migrationBuilder.RenameTable(
                name: "Fluent_BookDetail",
                newName: "Fluent_BookDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookDetails",
                table: "Fluent_BookDetails",
                column: "BookDetail_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookDetails",
                table: "Fluent_BookDetails");

            migrationBuilder.RenameTable(
                name: "Fluent_BookDetails",
                newName: "Fluent_BookDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookDetail",
                table: "Fluent_BookDetail",
                column: "BookDetail_Id");
        }
    }
}
