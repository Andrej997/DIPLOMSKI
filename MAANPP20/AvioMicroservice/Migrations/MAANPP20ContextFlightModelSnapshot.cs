﻿// <auto-generated />
using System;
using AvioMicroservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvioMicroservice.Migrations
{
    [DbContext(typeof(MAANPP20ContextFlight))]
    partial class MAANPP20ContextFlightModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Models.Cars.RezervacijaOdDo", b =>
                {
                    b.Property<int>("idRezervacijaOdDo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Do")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Od")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("idRezervacijaOdDo");

                    b.HasIndex("UserId");

                    b.ToTable("RezervacijaOdDo");
                });

            modelBuilder.Entity("Common.Models.Common.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("streetAndNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Common.Models.Common.DoubleForICollection", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DoubleValue")
                        .HasColumnType("float");

                    b.Property<int?>("FlightCompanyid")
                        .HasColumnType("int");

                    b.Property<int?>("Flightid")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("FlightCompanyid");

                    b.HasIndex("Flightid");

                    b.ToTable("DoubleForICollections");
                });

            modelBuilder.Entity("Common.Models.Common.Friend", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("hisId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("myId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Common.Models.Common.FriendRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("hisId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRequest")
                        .HasColumnType("bit");

                    b.Property<string>("myId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("Common.Models.Common.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Friendid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("hisId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isUnread")
                        .HasColumnType("bit");

                    b.Property<string>("myId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Friendid");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Common.Models.Common.StringForICollection", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlainString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Presedanjeid")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Presedanjeid");

                    b.ToTable("StringForICollections");
                });

            modelBuilder.Entity("Common.Models.Common_U.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("activationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("addressid")
                        .HasColumnType("int");

                    b.Property<string>("authData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("bonus")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("passportHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<int>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("addressid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Common.Models.Flights.Aeroplane", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numSeats")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Aeroplanes");
                });

            modelBuilder.Entity("Common.Models.Flights.AvioLuggage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<double>("priceCarryOn")
                        .HasColumnType("float");

                    b.Property<double>("priceFullSizeSpinner")
                        .HasColumnType("float");

                    b.Property<double>("priceLargeDuffel")
                        .HasColumnType("float");

                    b.Property<double>("pricePersonalBag")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("AvioLuggages");
                });

            modelBuilder.Entity("Common.Models.Flights.AvioSediste", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Flightid")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isDisabled")
                        .HasColumnType("bit");

                    b.Property<bool>("isFastReservation")
                        .HasColumnType("bit");

                    b.Property<bool>("reserved")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Flightid");

                    b.ToTable("AvioSedista");
                });

            modelBuilder.Entity("Common.Models.Flights.FastFlightReservation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserIdForPOST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateNow")
                        .HasColumnType("datetime2");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<int>("flightId")
                        .HasColumnType("int");

                    b.Property<int>("ocenaKompanije")
                        .HasColumnType("int");

                    b.Property<int>("ocenaLeta")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("seatId")
                        .HasColumnType("int");

                    b.Property<int>("seatNumeration")
                        .HasColumnType("int");

                    b.Property<bool>("userBonus")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("FastFlightReservations");
                });

            modelBuilder.Entity("Common.Models.Flights.Flight", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightCompanyid")
                        .HasColumnType("int");

                    b.Property<int>("addressFromId")
                        .HasColumnType("int");

                    b.Property<int?>("addressToId")
                        .HasColumnType("int");

                    b.Property<int>("aeroplaneId")
                        .HasColumnType("int");

                    b.Property<string>("company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumPolaska")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumSletanja")
                        .HasColumnType("datetime2");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("destImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("discountForFastReservation")
                        .HasColumnType("float");

                    b.Property<double>("duzinaPutovanja")
                        .HasColumnType("float");

                    b.Property<int>("idCompany")
                        .HasColumnType("int");

                    b.Property<string>("logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("luggageId")
                        .HasColumnType("int");

                    b.Property<int>("numOfFastReseravtions")
                        .HasColumnType("int");

                    b.Property<int>("presedanjeId")
                        .HasColumnType("int");

                    b.Property<double>("priceTwoWay")
                        .HasColumnType("float");

                    b.Property<double>("prise")
                        .HasColumnType("float");

                    b.Property<string>("vremePutovanja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("FlightCompanyid");

                    b.HasIndex("addressFromId");

                    b.HasIndex("addressToId");

                    b.HasIndex("aeroplaneId");

                    b.HasIndex("luggageId");

                    b.HasIndex("presedanjeId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Common.Models.Flights.FlightCompany", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("addressId")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("idAdmin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("promotionalDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("addressId");

                    b.HasIndex("idAdmin");

                    b.ToTable("FlightCompanies");
                });

            modelBuilder.Entity("Common.Models.Flights.FlightDestination", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightCompanyid")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("eId")
                        .HasColumnType("int");

                    b.Property<int?>("sId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FlightCompanyid");

                    b.HasIndex("eId");

                    b.HasIndex("sId");

                    b.ToTable("FlightDestinations");
                });

            modelBuilder.Entity("Common.Models.Flights.FlightReservation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserIdForPOST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateNow")
                        .HasColumnType("datetime2");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<int>("flightId")
                        .HasColumnType("int");

                    b.Property<int>("ocenaKompanije")
                        .HasColumnType("int");

                    b.Property<int>("ocenaLeta")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<bool>("rentACar")
                        .HasColumnType("bit");

                    b.Property<int>("seatId")
                        .HasColumnType("int");

                    b.Property<int>("seatNumeration")
                        .HasColumnType("int");

                    b.Property<bool>("userBonus")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("FlightReservations");
                });

            modelBuilder.Entity("Common.Models.Flights.FriendForFlight", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightReservationid")
                        .HasColumnType("int");

                    b.Property<bool>("acceptedCall")
                        .HasColumnType("bit");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("invitationString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("reservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("seatId")
                        .HasColumnType("int");

                    b.Property<int>("seatNumber")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FlightReservationid");

                    b.ToTable("FriendForFlights");
                });

            modelBuilder.Entity("Common.Models.Flights.Presedanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("brojPresedanja")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Presedanja");
                });

            modelBuilder.Entity("Common.Models.Flights.SagaFlightReservation", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("SagaFlightReservations");
                });

            modelBuilder.Entity("Common.Models.Cars.RezervacijaOdDo", b =>
                {
                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("rentACarReservation")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Common.Models.Common.DoubleForICollection", b =>
                {
                    b.HasOne("Common.Models.Flights.FlightCompany", null)
                        .WithMany("ocene")
                        .HasForeignKey("FlightCompanyid");

                    b.HasOne("Common.Models.Flights.Flight", null)
                        .WithMany("ocene")
                        .HasForeignKey("Flightid");
                });

            modelBuilder.Entity("Common.Models.Common.Friend", b =>
                {
                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("friends")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Common.Models.Common.FriendRequest", b =>
                {
                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("friendRequests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Common.Models.Common.Message", b =>
                {
                    b.HasOne("Common.Models.Common.Friend", null)
                        .WithMany("messages")
                        .HasForeignKey("Friendid");
                });

            modelBuilder.Entity("Common.Models.Common.StringForICollection", b =>
                {
                    b.HasOne("Common.Models.Flights.Presedanje", null)
                        .WithMany("gradoviPresedanja")
                        .HasForeignKey("Presedanjeid");
                });

            modelBuilder.Entity("Common.Models.Common_U.User", b =>
                {
                    b.HasOne("Common.Models.Common.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressid");
                });

            modelBuilder.Entity("Common.Models.Flights.AvioSediste", b =>
                {
                    b.HasOne("Common.Models.Flights.Flight", null)
                        .WithMany("allSeatsForThisFlight")
                        .HasForeignKey("Flightid");
                });

            modelBuilder.Entity("Common.Models.Flights.FastFlightReservation", b =>
                {
                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("fastFlightReservations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Common.Models.Flights.Flight", b =>
                {
                    b.HasOne("Common.Models.Flights.FlightCompany", null)
                        .WithMany("flights")
                        .HasForeignKey("FlightCompanyid");

                    b.HasOne("Common.Models.Common.Address", "from")
                        .WithMany()
                        .HasForeignKey("addressFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Common.Address", "to")
                        .WithMany()
                        .HasForeignKey("addressToId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Common.Models.Flights.Aeroplane", "aeroplane")
                        .WithMany()
                        .HasForeignKey("aeroplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Flights.AvioLuggage", "luggage")
                        .WithMany()
                        .HasForeignKey("luggageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Flights.Presedanje", "presedanje")
                        .WithMany()
                        .HasForeignKey("presedanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Common.Models.Flights.FlightCompany", b =>
                {
                    b.HasOne("Common.Models.Common.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Common_U.User", "admin")
                        .WithMany()
                        .HasForeignKey("idAdmin");
                });

            modelBuilder.Entity("Common.Models.Flights.FlightDestination", b =>
                {
                    b.HasOne("Common.Models.Flights.FlightCompany", null)
                        .WithMany("destinations")
                        .HasForeignKey("FlightCompanyid");

                    b.HasOne("Common.Models.Common.Address", "endAddress")
                        .WithMany()
                        .HasForeignKey("eId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Common.Models.Common.Address", "startAddress")
                        .WithMany()
                        .HasForeignKey("sId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Common.Models.Flights.FlightReservation", b =>
                {
                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("flightReservations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Common.Models.Flights.FriendForFlight", b =>
                {
                    b.HasOne("Common.Models.Flights.FlightReservation", null)
                        .WithMany("friendForFlights")
                        .HasForeignKey("FlightReservationid");
                });
#pragma warning restore 612, 618
        }
    }
}
