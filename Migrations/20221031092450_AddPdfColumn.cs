using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_Project.Migrations
{
    public partial class AddPdfColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "TblBooks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "TblBooks");
        }
    }
}
