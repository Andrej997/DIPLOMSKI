using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace UserMicroservice.Data
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MAANPP20ContextUser>());
            }
        }

        public static void SeedData(MAANPP20ContextUser context)
        {
            System.Console.WriteLine("[UserMicroservice] Appling Migrations...");

            context.Database.Migrate();

            //if (!context.Users.Any())
            //{
            //    System.Console.WriteLine("[UserMicroservice] Adding data...");

            //    context.Users.Add(new Common.Models.Common_U.User
            //    {
            //        Id = "108c6cd3-dfbc-45d6-a5c0-d42dccffa4dd",
            //        Email = "andrej.km997@gmail.com",
            //        EmailConfirmed = true,
            //        PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
            //        SecurityStamp = "54d70203-4500-4439-843a-6c6716d6ba3a",
            //        ConcurrencyStamp = "923ca572-1308-430d-9203-3e398d695378",
            //        PhoneNumber = "0652140497",
            //        PhoneNumberConfirmed = false,
            //        TwoFactorEnabled = false,
            //        LockoutEnabled = false,
            //        AccessFailedCount = 0,
            //        firstName = "Andrej",
            //        lastName = "Kalocanj Mohaci",

            //    });

            //    context.SaveChanges();
            //}
        }
    }
}
