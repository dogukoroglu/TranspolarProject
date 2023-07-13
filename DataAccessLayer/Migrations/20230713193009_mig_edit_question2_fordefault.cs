using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_edit_question2_fordefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area1",
                table: "Questions2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area2",
                table: "Questions2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area3",
                table: "Questions2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area4",
                table: "Questions2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area5",
                table: "Questions2",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area1",
                table: "Questions2");

            migrationBuilder.DropColumn(
                name: "Area2",
                table: "Questions2");

            migrationBuilder.DropColumn(
                name: "Area3",
                table: "Questions2");

            migrationBuilder.DropColumn(
                name: "Area4",
                table: "Questions2");

            migrationBuilder.DropColumn(
                name: "Area5",
                table: "Questions2");
        }
    }
}
