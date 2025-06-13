using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mock_monitoring.Migrations
{
    /// <inheritdoc />
    public partial class SensorLog_and_Seed_Sensor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sensor",
                columns: new[] { "Id", "Alarmen", "CreatedAt", "Enable", "MacAddress", "Name", "ProfileId", "Sample_Period" },
                values: new object[] { 1, (sbyte)0, new DateTime(2025, 6, 12, 19, 2, 10, 479, DateTimeKind.Utc).AddTicks(7530), true, "00:11:22:33:44:55", "Mock Sensor 1", 1, 900 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sensor",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
