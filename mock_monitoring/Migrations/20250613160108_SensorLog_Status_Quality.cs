using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mock_monitoring.Migrations
{
    /// <inheritdoc />
    public partial class SensorLog_Status_Quality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<sbyte>(
                name: "Quality",
                table: "SensorLog",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "Status",
                table: "SensorLog",
                type: "tinyint(4)",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.UpdateData(
                table: "Sensor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 13, 16, 1, 8, 157, DateTimeKind.Utc).AddTicks(8309));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quality",
                table: "SensorLog");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SensorLog");

            migrationBuilder.UpdateData(
                table: "Sensor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 22, 35, 1, 6, DateTimeKind.Utc).AddTicks(9131));
        }
    }
}
