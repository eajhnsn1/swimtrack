using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    public partial class RelayNotesEventNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DQ",
                table: "Swims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventNumber",
                table: "Swims",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRelay",
                table: "Swims",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Swims",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DQ",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "EventNumber",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "IsRelay",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Swims");
        }
    }
}
