using Common.Models.Hotels;
using Microsoft.EntityFrameworkCore;

namespace HotelMicroservice.Data
{
    public class MAANPP20ContextHotel : DbContext
    {
        public MAANPP20ContextHotel(DbContextOptions<MAANPP20ContextHotel> options) 
            : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
