using Common.Models.Payments;
using Microsoft.EntityFrameworkCore;

namespace PaymentMicroservice.Data
{
    public class MAANPP20ContextPayment : DbContext
    {
        public MAANPP20ContextPayment(DbContextOptions<MAANPP20ContextPayment> options) 
            : base(options) { }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
