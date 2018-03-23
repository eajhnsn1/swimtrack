using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    public partial class NewSwimColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Swims",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShortCourse",
                table: "Swims",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SwimDate",
                table: "Swims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "ShortCourse",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "SwimDate",
                table: "Swims");
        }
    }
}
