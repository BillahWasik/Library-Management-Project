using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_Project.Migrations
{
    public partial class addcolumnLanguageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblBooks_TblLanguages_LanguageId",
                table: "TblBooks");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "TblBooks");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "TblBooks",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBooks_TblLanguages_LanguageId",
                table: "TblBooks",
                column: "LanguageId",
                principalTable: "TblLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblBooks_TblLanguages_LanguageId",
                table: "TblBooks");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "TblBooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "TblBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblBooks_TblLanguages_LanguageId",
                table: "TblBooks",
                column: "LanguageId",
                principalTable: "TblLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
