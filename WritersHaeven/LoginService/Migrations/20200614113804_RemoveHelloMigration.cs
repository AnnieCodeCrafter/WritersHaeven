using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginService.Migrations
{
    public partial class RemoveHelloMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hello",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hello",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
