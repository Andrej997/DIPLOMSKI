using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroservice.Migrations
{
    public partial class InitialUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetAndNumber = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(maxLength: 25, nullable: false),
                    lastName = table.Column<string>(maxLength: 25, nullable: false),
                    profileImage = table.Column<string>(nullable: true),
                    addressid = table.Column<int>(nullable: true),
                    role = table.Column<int>(nullable: false),
                    passportHash = table.Column<string>(nullable: true),
                    authData = table.Column<string>(nullable: true),
                    serviceId = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    activationCode = table.Column<string>(nullable: true),
                    bonus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_addressid",
                        column: x => x.addressid,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FastFlightReservation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightId = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    seatNumeration = table.Column<int>(nullable: false),
                    seatId = table.Column<int>(nullable: false),
                    UserIdForPOST = table.Column<string>(nullable: true),
                    userBonus = table.Column<bool>(nullable: false),
                    ocenaLeta = table.Column<int>(nullable: false),
                    ocenaKompanije = table.Column<int>(nullable: false),
                    dateNow = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastFlightReservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_FastFlightReservation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightReservation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightId = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    seatNumeration = table.Column<int>(nullable: false),
                    seatId = table.Column<int>(nullable: false),
                    UserIdForPOST = table.Column<string>(nullable: true),
                    userBonus = table.Column<bool>(nullable: false),
                    ocenaLeta = table.Column<int>(nullable: false),
                    ocenaKompanije = table.Column<int>(nullable: false),
                    dateNow = table.Column<DateTime>(nullable: false),
                    rentACar = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightReservation", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightReservation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    myId = table.Column<string>(nullable: true),
                    hisId = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.id);
                    table.ForeignKey(
                        name: "FK_Friend_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    myId = table.Column<string>(nullable: true),
                    hisId = table.Column<string>(nullable: true),
                    isRequest = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_FriendRequest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaOdDo",
                columns: table => new
                {
                    idRezervacijaOdDo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Od = table.Column<DateTime>(nullable: false),
                    Do = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaOdDo", x => x.idRezervacijaOdDo);
                    table.ForeignKey(
                        name: "FK_RezervacijaOdDo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendForFlight",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    seatNumber = table.Column<int>(nullable: false),
                    seatId = table.Column<int>(nullable: false),
                    invitationString = table.Column<string>(nullable: true),
                    reservationDate = table.Column<DateTime>(nullable: false),
                    acceptedCall = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    FlightReservationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendForFlight", x => x.id);
                    table.ForeignKey(
                        name: "FK_FriendForFlight_FlightReservation_FlightReservationid",
                        column: x => x.FlightReservationid,
                        principalTable: "FlightReservation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(nullable: true),
                    dateTime = table.Column<DateTime>(nullable: false),
                    myId = table.Column<string>(nullable: true),
                    hisId = table.Column<string>(nullable: true),
                    isUnread = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    Friendid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.id);
                    table.ForeignKey(
                        name: "FK_Message_Friend_Friendid",
                        column: x => x.Friendid,
                        principalTable: "Friend",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FastFlightReservation_UserId",
                table: "FastFlightReservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightReservation_UserId",
                table: "FlightReservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_UserId",
                table: "Friend",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendForFlight_FlightReservationid",
                table: "FriendForFlight",
                column: "FlightReservationid");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequest_UserId",
                table: "FriendRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Friendid",
                table: "Message",
                column: "Friendid");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaOdDo_UserId",
                table: "RezervacijaOdDo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressid",
                table: "Users",
                column: "addressid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastFlightReservation");

            migrationBuilder.DropTable(
                name: "FriendForFlight");

            migrationBuilder.DropTable(
                name: "FriendRequest");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "RezervacijaOdDo");

            migrationBuilder.DropTable(
                name: "FlightReservation");

            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
