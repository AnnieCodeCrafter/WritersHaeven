using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginService.Migrations
{
    public partial class role3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "IdentityId", "Name" },
                values: new object[] { 1, 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "IdentityId", "Name" },
                values: new object[] { 2, 2, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
