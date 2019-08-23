using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPayrollApp.Migrations
{
    public partial class ForeignKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FireReason",
                table: "OldWorkPlace",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FireReason",
                table: "OldWorkPlace",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
