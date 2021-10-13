using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.View.Migrations
{
    public partial class RenameFieldCountryInRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AspNetUsers",
                newName: "Region");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Region",
                table: "AspNetUsers",
                newName: "Country");
        }
    }
}
