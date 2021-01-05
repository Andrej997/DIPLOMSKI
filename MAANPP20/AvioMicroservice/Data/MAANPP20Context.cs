using Common.Models.Common;
using Common.Models.Common_U;
using Common.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace AvioMicroservice.Data
{
    public class MAANPP20ContextFlight : DbContext
    {
        public MAANPP20ContextFlight(DbContextOptions<MAANPP20ContextFlight> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }

        #region Common
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        #endregion

        #region Flights

        #region Elementary tables
        public DbSet<AvioLuggage> AvioLuggages { get; set; }
        public DbSet<AvioSediste> AvioSedista { get; set; }
        public DbSet<StringForICollection> StringForICollections { get; set; }
        public DbSet<DoubleForICollection> DoubleForICollections { get; set; }
        public DbSet<FastFlightReservation> FastFlightReservations { get; set; }
        public DbSet<FlightReservation> FlightReservations { get; set; }
        public DbSet<FriendForFlight> FriendForFlights { get; set; }
        #endregion

        #region Tables only with ICollection
        public DbSet<Aeroplane> Aeroplanes { get; set; }
        public DbSet<Presedanje> Presedanja { get; set; }
        #endregion

        #region Complex tables
        public DbSet<FlightDestination> FlightDestinations { get; set; }
        public DbSet<FlightCompany> FlightCompanies { get; set; }
        public DbSet<Flight> Flights { get; set; }
        #endregion

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDestination>(entity =>
            {
                entity.HasOne(d => d.startAddress)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.endAddress)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasOne(d => d.to)
                    .WithMany()
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
