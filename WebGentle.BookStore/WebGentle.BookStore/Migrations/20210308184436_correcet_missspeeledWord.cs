using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGentle.BookStore.Migrations
{
    public partial class correcet_missspeeledWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptiomn",
                table: "Language",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Language",
                newName: "Descriptiomn");
        }
    }
}
