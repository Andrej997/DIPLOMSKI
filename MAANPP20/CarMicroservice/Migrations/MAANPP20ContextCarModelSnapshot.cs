﻿// <auto-generated />
using System;
using CarMicroservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarMicroservice.Migrations
{
    [DbContext(typeof(MAANPP20ContextCar))]
    partial class MAANPP20ContextCarModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Models.Cars.Automobile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Avaible")
                        .HasColumnType("int");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Automobiles");
                });

            modelBuilder.Entity("Common.Models.Cars.Car", b =>
                {
                    b.Property<int>("idCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BabySeat")
                        .HasColumnType("bit");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<string>("CarImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cm3")
                        .HasColumnType("int");

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.Property<int>("FreeSeats")
                        .HasColumnType("int");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<int>("Gear")
                        .HasColumnType("int");

                    b.Property<int>("Kw")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Navigation")
                        .HasColumnType("bit");

                    b.Property<double>("PricePerDay")
                        .HasColumnType("float");

                    b.Property<int?>("RentACarServiceidRAC")
                        .HasColumnType("int");

                    b.Property<bool>("RoofRack")
                        .HasColumnType("bit");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Trunk")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<int>("idService")
                        .HasColumnType("int");

                    b.HasKey("idCar");

                    b.HasIndex("RentACarServiceidRAC");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Common.Models.Cars.Cenovnik", b =>
                {
                    b.Property<int>("idCenovnik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("idCenovnik");

                    b.ToTable("Cenovnik");
                });

            modelBuilder.Entity("Common.Models.Cars.Grad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("images")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("Common.Models.Cars.Ocena", b =>
                {
                    b.Property<int>("idOcena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaridCar")
                        .HasColumnType("int");

                    b.Property<int?>("RentACarServiceidRAC")
                        .HasColumnType("int");

                    b.Property<int>("broj")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("idOcena");

                    b.HasIndex("CaridCar");

                    b.HasIndex("RentACarServiceidRAC");

                    b.ToTable("OcenePojedinacnogAuta");
                });

            modelBuilder.Entity("Common.Models.Cars.RentACarService", b =>
                {
                    b.Property<int>("idRAC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CenovnikidCenovnik")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RACaddressId")
                        .HasColumnType("int");

                    b.Property<string>("RACidAdmin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("idRAC");

                    b.HasIndex("CenovnikidCenovnik");

                    b.HasIndex("RACaddressId");

                    b.HasIndex("RACidAdmin");

                    b.ToTable("RentACarServices");
                });

            modelBuilder.Entity("Common.Models.Cars.RezervacijaOdDo", b =>
                {
                    b.Property<int>("idRezervacijaOdDo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaridCar")
                        .HasColumnType("int");

                    b.Property<DateTime>("Do")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Od")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("idRezervacijaOdDo");

                    b.HasIndex("CaridCar");

                    b.HasIndex("UserId");

                    b.ToTable("RezervacijeOdDo");
                });

            modelBuilder.Entity("Common.Models.Cars.StavkaCenovnika", b =>
                {
                    b.Property<int>("idStavkeCenovnika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CenovnikidCenovnik")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vrednost")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.HasKey("idStavkeCenovnika");

                    b.HasIndex("CenovnikidCenovnik");

                    b.ToTable("StavkaCenovnika");
                });

            modelBuilder.Entity("Common.Models.Common.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RentACarServiceidRAC")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<string>("streetAndNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("RentACarServiceidRAC");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Common.Models.Common.Comment", b =>
                {
                    b.Property<int>("idComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RentACarServiceidRAC")
                        .HasColumnType("int");

                    b.Property<bool>("deleted")
                        .HasColumnType("bit");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("idComment");

                    b.HasIndex("RentACarServiceidRAC");

                    b.ToTable("Comment");
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

                    b.ToTable("Friend");
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

                    b.ToTable("FriendRequest");
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

                    b.ToTable("Message");
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

                    b.ToTable("FastFlightReservation");
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

                    b.ToTable("FlightReservation");
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

                    b.ToTable("FriendForFlight");
                });

            modelBuilder.Entity("Common.Models.Cars.Car", b =>
                {
                    b.HasOne("Common.Models.Cars.RentACarService", null)
                        .WithMany("RACServiceCars")
                        .HasForeignKey("RentACarServiceidRAC");
                });

            modelBuilder.Entity("Common.Models.Cars.Ocena", b =>
                {
                    b.HasOne("Common.Models.Cars.Car", null)
                        .WithMany("OceneAuta")
                        .HasForeignKey("CaridCar");

                    b.HasOne("Common.Models.Cars.RentACarService", null)
                        .WithMany("RACOcene")
                        .HasForeignKey("RentACarServiceidRAC");
                });

            modelBuilder.Entity("Common.Models.Cars.RentACarService", b =>
                {
                    b.HasOne("Common.Models.Cars.Cenovnik", "Cenovnik")
                        .WithMany()
                        .HasForeignKey("CenovnikidCenovnik");

                    b.HasOne("Common.Models.Common.Address", "RACAddress")
                        .WithMany()
                        .HasForeignKey("RACaddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Common_U.User", "RACAdmin")
                        .WithMany()
                        .HasForeignKey("RACidAdmin");
                });

            modelBuilder.Entity("Common.Models.Cars.RezervacijaOdDo", b =>
                {
                    b.HasOne("Common.Models.Cars.Car", null)
                        .WithMany("RezervacijeAutaOdDo")
                        .HasForeignKey("CaridCar");

                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("rentACarReservation")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Common.Models.Cars.StavkaCenovnika", b =>
                {
                    b.HasOne("Common.Models.Cars.Cenovnik", null)
                        .WithMany("StavkeCenovnika")
                        .HasForeignKey("CenovnikidCenovnik");
                });

            modelBuilder.Entity("Common.Models.Common.Address", b =>
                {
                    b.HasOne("Common.Models.Cars.RentACarService", null)
                        .WithMany("RACBranches")
                        .HasForeignKey("RentACarServiceidRAC");
                });

            modelBuilder.Entity("Common.Models.Common.Comment", b =>
                {
                    b.HasOne("Common.Models.Cars.RentACarService", null)
                        .WithMany("RACComments")
                        .HasForeignKey("RentACarServiceidRAC");
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

            modelBuilder.Entity("Common.Models.Common_U.User", b =>
                {
                    b.HasOne("Common.Models.Common.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressid");
                });

            modelBuilder.Entity("Common.Models.Flights.FastFlightReservation", b =>
                {
                    b.HasOne("Common.Models.Common_U.User", null)
                        .WithMany("fastFlightReservations")
                        .HasForeignKey("UserId");
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
