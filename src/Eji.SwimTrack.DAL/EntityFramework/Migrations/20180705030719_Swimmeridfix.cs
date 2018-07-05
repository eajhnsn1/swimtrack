using Microsoft.EntityFrameworkCore.Migrations;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    public partial class Swimmeridfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SwimmerId",
                table: "Swimmers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SwimmerId",
                table: "Swimmers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
