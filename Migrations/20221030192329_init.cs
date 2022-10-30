using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Management_Project.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    TotalPages = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBooks_TblLanguages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "TblLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblBooks_LanguageId",
                table: "TblBooks",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblBooks");

            migrationBuilder.DropTable(
                name: "TblLanguages");
        }
    }
}
