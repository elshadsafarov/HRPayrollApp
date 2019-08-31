using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPayrollApp.Migrations
{
    public partial class AddressColumnAddedForBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Branches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Branches");
        }
    }
}
