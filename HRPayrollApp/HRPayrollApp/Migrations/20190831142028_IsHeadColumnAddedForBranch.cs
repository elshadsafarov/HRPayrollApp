using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPayrollApp.Migrations
{
    public partial class IsHeadColumnAddedForBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHead",
                table: "Branches",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHead",
                table: "Branches");
        }
    }
}
