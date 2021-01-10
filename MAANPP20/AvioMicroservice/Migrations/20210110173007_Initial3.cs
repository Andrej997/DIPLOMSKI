using Microsoft.EntityFrameworkCore.Migrations;

namespace AvioMicroservice.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SagaFlightReservations");

            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "SagaFlightReservations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "SagaFlightReservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "SagaFlightReservations");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "SagaFlightReservations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SagaFlightReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
