using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AvioMicroservice.Data
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MAANPP20ContextFlight>());
            }
        }

        public static void SeedData(MAANPP20ContextFlight context)
        {
            System.Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();

        }
    }
}
