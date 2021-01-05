using Common.Models.Common;
using Common.Models.Common_U;
using Common.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace UserMicroservice.Data
{
    public class MAANPP20ContextUser : DbContext
    {
        public MAANPP20ContextUser(DbContextOptions<MAANPP20ContextUser> options)
            : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
