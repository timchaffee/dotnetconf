using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetconf.Data.Migrations
{
    public partial class UpdateSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Presentors",
                table: "Sessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Presentors",
                table: "Sessions");
        }
    }
}
