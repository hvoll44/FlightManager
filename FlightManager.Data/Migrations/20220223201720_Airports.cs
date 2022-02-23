using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManager.Data.Migrations
{
    public partial class Airports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Flight");

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "Flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DestinationAirportID",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginAirportID",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationAirportID",
                table: "Flight",
                column: "DestinationAirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OriginAirportID",
                table: "Flight",
                column: "OriginAirportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DestinationAirportID",
                table: "Flight",
                column: "DestinationAirportID",
                principalTable: "Airport",
                principalColumn: "AirportID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_OriginAirportID",
                table: "Flight",
                column: "OriginAirportID",
                principalTable: "Airport",
                principalColumn: "AirportID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DestinationAirportID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_OriginAirportID",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DestinationAirportID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_OriginAirportID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DestinationAirportID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "OriginAirportID",
                table: "Flight");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
