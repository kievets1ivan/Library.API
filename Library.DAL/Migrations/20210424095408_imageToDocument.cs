using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DAL.Migrations
{
    public partial class imageToDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Documents",
                newName: "ImageFileName");

            migrationBuilder.AddColumn<string>(
                name: "DocumnetFileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumnetFileName",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Documents",
                newName: "FileName");
        }
    }
}
