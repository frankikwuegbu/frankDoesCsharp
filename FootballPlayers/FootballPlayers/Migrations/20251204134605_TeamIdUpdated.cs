using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballPlayers.Migrations
{
    /// <inheritdoc />
    public partial class TeamIdUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "Age", "Name", "TeamId" },
                values: new object[] { 22, "Jude Bellingham", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "Age", "Name", "TeamId" },
                values: new object[] { 32, "Harry Kane", new Guid("3d490a71-94cf-4d16-9495-5248280c2ce4") });
        }
    }
}
