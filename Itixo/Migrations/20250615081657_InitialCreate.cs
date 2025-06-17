using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itixo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    today = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sunrise = table.Column<string>(type: "TEXT", nullable: false),
                    Sunset = table.Column<string>(type: "TEXT", nullable: false),
                    CivStart = table.Column<string>(type: "TEXT", nullable: false),
                    CivEnd = table.Column<string>(type: "TEXT", nullable: false),
                    NautStart = table.Column<string>(type: "TEXT", nullable: false),
                    NautEnd = table.Column<string>(type: "TEXT", nullable: false),
                    AstroStart = table.Column<string>(type: "TEXT", nullable: false),
                    AstroEnd = table.Column<string>(type: "TEXT", nullable: false),
                    DayLen = table.Column<string>(type: "TEXT", nullable: false),
                    CivLen = table.Column<string>(type: "TEXT", nullable: false),
                    NautLen = table.Column<string>(type: "TEXT", nullable: false),
                    AstroLen = table.Column<string>(type: "TEXT", nullable: false),
                    MoonPhase = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDay = table.Column<int>(type: "INTEGER", nullable: false),
                    Bio = table.Column<int>(type: "INTEGER", nullable: false),
                    PressureOld = table.Column<double>(type: "REAL", nullable: false),
                    TemperatureAvg = table.Column<double>(type: "REAL", nullable: false),
                    Agl = table.Column<int>(type: "INTEGER", nullable: false),
                    Fog = table.Column<int>(type: "INTEGER", nullable: false),
                    Lsp = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SensorID = table.Column<int>(type: "INTEGER", nullable: false),
                    SensorName = table.Column<string>(type: "TEXT", nullable: true),
                    SensorType = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<double>(type: "REAL", nullable: true),
                    IsOnline = table.Column<bool>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ErrorMessages = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayData");

            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
