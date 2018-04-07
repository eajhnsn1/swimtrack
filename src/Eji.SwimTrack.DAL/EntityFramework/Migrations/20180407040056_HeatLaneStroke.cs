using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Eji.SwimTrack.DAL.EntityFramework.Migrations
{
    public partial class HeatLaneStroke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Heat",
                table: "Swims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lane",
                table: "Swims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stroke",
                table: "Swims",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heat",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "Lane",
                table: "Swims");

            migrationBuilder.DropColumn(
                name: "Stroke",
                table: "Swims");
        }
    }
}
