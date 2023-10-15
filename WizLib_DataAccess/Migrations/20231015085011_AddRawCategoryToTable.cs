using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRawCategoryToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES('CAT 1')");
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES('CAT 2')");
            migrationBuilder.Sql("INSERT INTO tbl_Category VALUES('CAT 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
