using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPayrollApp.Migrations
{
    public partial class PhotoColumnAddedForEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Employees");
        }
    }
}
