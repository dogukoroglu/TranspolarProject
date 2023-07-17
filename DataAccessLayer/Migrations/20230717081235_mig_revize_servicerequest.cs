using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_revize_servicerequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "ServiceRequests",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ServiceRequests");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "ServiceRequests",
                newName: "Destination");
        }
    }
}
