using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_edit_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescription",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "SubIcon",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Abouts");

            migrationBuilder.CreateTable(
                name: "About2s",
                columns: table => new
                {
                    About2ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About2s", x => x.About2ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About2s");

            migrationBuilder.AddColumn<string>(
                name: "SubDescription",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubIcon",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
