using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_edit_socialmedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMedia1",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "SocialMedia2",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "SocialMedia3",
                table: "SocialMedias");

            migrationBuilder.RenameColumn(
                name: "SocialMedia5",
                table: "SocialMedias",
                newName: "SocialMediaUrl");

            migrationBuilder.RenameColumn(
                name: "SocialMedia4",
                table: "SocialMedias",
                newName: "SocialMediaIcon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialMediaUrl",
                table: "SocialMedias",
                newName: "SocialMedia5");

            migrationBuilder.RenameColumn(
                name: "SocialMediaIcon",
                table: "SocialMedias",
                newName: "SocialMedia4");

            migrationBuilder.AddColumn<string>(
                name: "SocialMedia1",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMedia2",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMedia3",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
