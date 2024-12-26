using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalsAndTasks.WebApi.DatabaseDesign.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeColumnsToTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "DueTime",
                table: "Tasks",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "Tasks",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Tasks");
        }
    }
}
