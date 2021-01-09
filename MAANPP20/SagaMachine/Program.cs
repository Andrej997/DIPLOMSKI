using MassTransit;
using MassTransit.Definition;
using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.Saga;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RabbitMQMEssage.BusConfiguration;
using RabbitMQSaga.DbConfiguration;
using RabbitMQSaga.StateMachine;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SagaMachine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-H20J9R7; Database=MAANPP20-SAGA; Trusted_Connection=True; MultipleActiveResultSets=True;";

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddMassTransit(cfg =>
                   {
                       cfg.AddSagaStateMachine<FlightStateMachine, FlightStateData>()

                        .EntityFrameworkRepository(r =>
                        {
                            r.ConcurrencyMode = ConcurrencyMode.Pessimistic; // or use Optimistic, which requires RowVersion

                            r.AddDbContext<DbContext, FlightStateDbContext>((provider, builder) =>
                            {
                                builder.UseSqlServer(connectionString, m =>
                                {
                                    m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                                    m.MigrationsHistoryTable($"__{nameof(FlightStateDbContext)}");
                                });
                            });
                        });

                       cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider));
                   });

                   services.AddMassTransitHostedService();
               });

            await builder.RunConsoleAsync();
        }
    }
}
