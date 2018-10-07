using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetconf.Data.Migrations
{
    public partial class UpdateSession2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Sessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Sessions");
        }
    }
}
