using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    public partial class Swimmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SwimmerId",
                table: "Swims",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Swimmers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SwimmerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    Nickname = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swimmers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Swims_SwimmerId",
                table: "Swims",
                column: "SwimmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Swims_Swimmers_SwimmerId",
                table: "Swims",
                column: "SwimmerId",
                principalTable: "Swimmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swims_Swimmers_SwimmerId",
                table: "Swims");

            migrationBuilder.DropTable(
                name: "Swimmers");

            migrationBuilder.DropIndex(
                name: "IX_Swims_SwimmerId",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "SwimmerId",
                table: "Swims");
        }
    }
}
