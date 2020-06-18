using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginService.Migrations
{
    public partial class HelloMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hello",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hello",
                table: "Accounts");
        }
    }
}
