using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvioMicroservice.Migrations
{
    public partial class InitialAvio : Migration
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
                name: "Aeroplanes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    numSeats = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroplanes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AvioLuggages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    priceCarryOn = table.Column<double>(nullable: false),
                    pricePersonalBag = table.Column<double>(nullable: false),
                    priceFullSizeSpinner = table.Column<double>(nullable: false),
                    priceLargeDuffel = table.Column<double>(nullable: false),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvioLuggages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Presedanja",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojPresedanja = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presedanja", x => x.id);
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
                name: "StringForICollections",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlainString = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    Presedanjeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringForICollections", x => x.id);
                    table.ForeignKey(
                        name: "FK_StringForICollections_Presedanja_Presedanjeid",
                        column: x => x.Presedanjeid,
                        principalTable: "Presedanja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FastFlightReservations",
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
                    table.PrimaryKey("PK_FastFlightReservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_FastFlightReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightCompanies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    addressId = table.Column<int>(nullable: false),
                    promotionalDesc = table.Column<string>(nullable: false),
                    logo = table.Column<string>(nullable: true),
                    idAdmin = table.Column<string>(nullable: true),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCompanies", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightCompanies_Addresses_addressId",
                        column: x => x.addressId,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightCompanies_Users_idAdmin",
                        column: x => x.idAdmin,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightReservations",
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
                    table.PrimaryKey("PK_FlightReservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
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
                    table.PrimaryKey("PK_FriendRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
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
                    table.PrimaryKey("PK_Friends", x => x.id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
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
                name: "FlightDestinations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sId = table.Column<int>(nullable: true),
                    eId = table.Column<int>(nullable: true),
                    deleted = table.Column<bool>(nullable: false),
                    FlightCompanyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDestinations", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightDestinations_FlightCompanies_FlightCompanyid",
                        column: x => x.FlightCompanyid,
                        principalTable: "FlightCompanies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightDestinations_Addresses_eId",
                        column: x => x.eId,
                        principalTable: "Addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FlightDestinations_Addresses_sId",
                        column: x => x.sId,
                        principalTable: "Addresses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company = table.Column<string>(nullable: true),
                    idCompany = table.Column<int>(nullable: false),
                    logo = table.Column<string>(nullable: true),
                    addressFromId = table.Column<int>(nullable: false),
                    addressToId = table.Column<int>(nullable: true),
                    destImg = table.Column<string>(nullable: true),
                    datumPolaska = table.Column<DateTime>(nullable: false),
                    datumSletanja = table.Column<DateTime>(nullable: false),
                    prise = table.Column<double>(nullable: false),
                    priceTwoWay = table.Column<double>(nullable: false),
                    vremePutovanja = table.Column<string>(nullable: true),
                    duzinaPutovanja = table.Column<double>(nullable: false),
                    presedanjeId = table.Column<int>(nullable: false),
                    aeroplaneId = table.Column<int>(nullable: false),
                    luggageId = table.Column<int>(nullable: false),
                    numOfFastReseravtions = table.Column<int>(nullable: false),
                    discountForFastReservation = table.Column<double>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    FlightCompanyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.id);
                    table.ForeignKey(
                        name: "FK_Flights_FlightCompanies_FlightCompanyid",
                        column: x => x.FlightCompanyid,
                        principalTable: "FlightCompanies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Addresses_addressFromId",
                        column: x => x.addressFromId,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Addresses_addressToId",
                        column: x => x.addressToId,
                        principalTable: "Addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Flights_Aeroplanes_aeroplaneId",
                        column: x => x.aeroplaneId,
                        principalTable: "Aeroplanes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_AvioLuggages_luggageId",
                        column: x => x.luggageId,
                        principalTable: "AvioLuggages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Presedanja_presedanjeId",
                        column: x => x.presedanjeId,
                        principalTable: "Presedanja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendForFlights",
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
                    table.PrimaryKey("PK_FriendForFlights", x => x.id);
                    table.ForeignKey(
                        name: "FK_FriendForFlights_FlightReservations_FlightReservationid",
                        column: x => x.FlightReservationid,
                        principalTable: "FlightReservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
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
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Friends_Friendid",
                        column: x => x.Friendid,
                        principalTable: "Friends",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvioSedista",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reserved = table.Column<bool>(nullable: false),
                    isFastReservation = table.Column<bool>(nullable: false),
                    isDisabled = table.Column<bool>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    Flightid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvioSedista", x => x.id);
                    table.ForeignKey(
                        name: "FK_AvioSedista_Flights_Flightid",
                        column: x => x.Flightid,
                        principalTable: "Flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoubleForICollections",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoubleValue = table.Column<double>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    FlightCompanyid = table.Column<int>(nullable: true),
                    Flightid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoubleForICollections", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoubleForICollections_FlightCompanies_FlightCompanyid",
                        column: x => x.FlightCompanyid,
                        principalTable: "FlightCompanies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoubleForICollections_Flights_Flightid",
                        column: x => x.Flightid,
                        principalTable: "Flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvioSedista_Flightid",
                table: "AvioSedista",
                column: "Flightid");

            migrationBuilder.CreateIndex(
                name: "IX_DoubleForICollections_FlightCompanyid",
                table: "DoubleForICollections",
                column: "FlightCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_DoubleForICollections_Flightid",
                table: "DoubleForICollections",
                column: "Flightid");

            migrationBuilder.CreateIndex(
                name: "IX_FastFlightReservations_UserId",
                table: "FastFlightReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCompanies_addressId",
                table: "FlightCompanies",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCompanies_idAdmin",
                table: "FlightCompanies",
                column: "idAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDestinations_FlightCompanyid",
                table: "FlightDestinations",
                column: "FlightCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDestinations_eId",
                table: "FlightDestinations",
                column: "eId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDestinations_sId",
                table: "FlightDestinations",
                column: "sId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightReservations_UserId",
                table: "FlightReservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightCompanyid",
                table: "Flights",
                column: "FlightCompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_addressFromId",
                table: "Flights",
                column: "addressFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_addressToId",
                table: "Flights",
                column: "addressToId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_aeroplaneId",
                table: "Flights",
                column: "aeroplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_luggageId",
                table: "Flights",
                column: "luggageId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_presedanjeId",
                table: "Flights",
                column: "presedanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendForFlights_FlightReservationid",
                table: "FriendForFlights",
                column: "FlightReservationid");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserId",
                table: "FriendRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Friendid",
                table: "Messages",
                column: "Friendid");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaOdDo_UserId",
                table: "RezervacijaOdDo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StringForICollections_Presedanjeid",
                table: "StringForICollections",
                column: "Presedanjeid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressid",
                table: "Users",
                column: "addressid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvioSedista");

            migrationBuilder.DropTable(
                name: "DoubleForICollections");

            migrationBuilder.DropTable(
                name: "FastFlightReservations");

            migrationBuilder.DropTable(
                name: "FlightDestinations");

            migrationBuilder.DropTable(
                name: "FriendForFlights");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "RezervacijaOdDo");

            migrationBuilder.DropTable(
                name: "StringForICollections");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "FlightReservations");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "FlightCompanies");

            migrationBuilder.DropTable(
                name: "Aeroplanes");

            migrationBuilder.DropTable(
                name: "AvioLuggages");

            migrationBuilder.DropTable(
                name: "Presedanja");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
